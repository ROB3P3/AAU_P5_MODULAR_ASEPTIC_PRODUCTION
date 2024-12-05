using System.Threading;
using Opc.Ua;
using Opc.Ua.Client;

namespace ROB5_MES_System.Classes
{
    public class OPCUA
    {
        private string _appType;
        private string _appState;
        private ushort _carrierID;
        private Session _clientSession;
        private Subscription _subscription;
        private string _nodeId;
        private PLCInfo _plcinfo;
        private Order _currentOrder;
        private Carrier _carrierInOrder;

        public string AppType
        {
            get { return _appType; }
            set { _appType = value; }
        }
        public string AppState
        {
            get { return _appState; }
            set { _appState = value; }
        }
        public ushort CarrierIdentifier
        {
            get { return _carrierID; }
            set { _carrierID = value; }
        }

        public string NodeIdentifier
        {
            get { return _nodeId; }
            set { _nodeId = value; }
        }
        public PLCInfo PlcInfo
        {
            get { return _plcinfo; }
            set { _plcinfo = value; }
        }

        public Order currentOrder
        {
            get { return _currentOrder; }
            set { _currentOrder = value; }
        }
        public Carrier carrierInOrder
        {
            get { return _carrierInOrder; }
            set { _carrierInOrder = value; }
        }


        public OPCUA(string endpointUrl, string nodeId, PLCInfo plcinfo)
        {
            // try to create a connection to the server
            Console.WriteLine("Connecting to {0}", endpointUrl);
            NodeIdentifier = nodeId;
            PlcInfo = plcinfo;


            try
            {
                // Create the application configuration
                var applicationConfiguration = CreateApplicationConfiguration();
                // Create the endpoint
                var endpoint = CreateEndpoint(applicationConfiguration, endpointUrl);

                // Connect to the server
                _clientSession = Session.Create(applicationConfiguration, endpoint, true, "OPCUAClient", 60000, null, null).Result;
                plcinfo.ConnectionStatus = _clientSession.Connected;
                //Console.WriteLine("PLC0{0} Connection state: {1}", plcinfo.Id, _clientSession.Connected);

                // set command to default
                ModifyNodeValue("ServerCommand", "wait");

                // read application type
                this.AppType = (string)DisplayNodeValue(_clientSession, String.Format("{0}.AppType", nodeId), "AppType");
                plcinfo.Type = this.AppType;
                // subscribe to application state and carrier id
                SubscribeNodeValue(_clientSession, String.Format("{0}.AppState", nodeId), "AppState", plcinfo);
                SubscribeNodeValue(_clientSession, String.Format("{0}.CarrierID", nodeId), "CarrierID", plcinfo);
            }
            catch (Exception e)
            {
                // write the error message
                Console.WriteLine("Failed to connect to {0}, error: {1}", nodeId, e.Message);
                plcinfo.AppState = "N/A";
                plcinfo.Type = "N/A";
                plcinfo.ConnectionStatus = false;
            }

        }



        private static Opc.Ua.ApplicationConfiguration CreateApplicationConfiguration()
        {
            // Create a ApplicationConfiguration object
            return new Opc.Ua.ApplicationConfiguration()
            {
                // Set the application name
                ApplicationName = "OPCUAClient",
                // Set the application type to Client as Server is on the PLC
                ApplicationType = ApplicationType.Client,
                // don't really know what the next 3 things are exactly beyond being preset configurations
                // Configure security settings
                SecurityConfiguration = new SecurityConfiguration
                {
                    // Set the application certificate identifier, 
                    ApplicationCertificate = new CertificateIdentifier()
                },
                // Configure client settings
                ClientConfiguration = new ClientConfiguration()
            };
        }

        private static ConfiguredEndpoint CreateEndpoint(Opc.Ua.ApplicationConfiguration applicationConfiguration, string endpointUrl)
        {
            // Create an endpoint configuration using the application configuration, said so online!
            var endpointConfiguration = EndpointConfiguration.Create(applicationConfiguration);

            // Select the endpoint using the provided URL and disable security, let us get hacked lmao
            var selectedEndpoint = CoreClientUtils.SelectEndpoint(endpointUrl, useSecurity: false);

            // Return a configured endpoint with the selected endpoint and endpoint configuration
            return new ConfiguredEndpoint(null, selectedEndpoint, endpointConfiguration);
        }

        private static string DisplayNodeValue(Session client, string nodeId, string variableName)
        {
            // Create a NodeId object from the string nodeId
            NodeId node = new NodeId(nodeId);

            // Read the value of the node
            DataValue value = client.ReadValue(node);

            // Display the value
            Console.WriteLine("{0} is: {1}", variableName, value.Value);

            // Return the value
            return (string)value.Value;
        }

        private void SubscribeNodeValue(Session client, string nodeId, string variableName, PLCInfo plcinfo)
        {
            // write which node we are subscribing to and if connection is successful
            Console.WriteLine("Subscribing to {0}", nodeId);

            // Create a NodeId object from the string nodeId
            NodeId node = new NodeId(nodeId);

            // create a subscription to the ApplicationState node
            _subscription = new Subscription(client.DefaultSubscription);

            // create a monitored item for the ApplicationState node
            var monitoredItem = new MonitoredItem(_subscription.DefaultItem)
            {
                StartNodeId = node,
                AttributeId = Attributes.Value
            };

            // add the monitored item to the subscription
            _subscription.AddItem(monitoredItem);

            // create a callback for the DataChanged event
            monitoredItem.Notification += (item, eventArgs) =>
            {
                // get the value of the ApplicationState node
                var value = ((MonitoredItemNotification)eventArgs.NotificationValue).Value.Value;
                // react differently depending on the variable name
                
                switch (variableName)
                {
                    case "AppState":
                        plcinfo.AppState = (string)value;
                        Console.WriteLine("\nPLC {0} event:", plcinfo.Id);
                        Console.WriteLine("Application state changed, new state is: {0}\n", value);
                        if (MainWindowForm.isProductionRunning) { ApplicationHandler(client, (string)value); }
                        break;
                    case "CarrierID":
                        Console.WriteLine("\nPLC {0} event:", plcinfo.Id);
                        plcinfo.CarrierID = (ushort)value;
                        Console.WriteLine("{0} is: {1}\n", variableName, value);
                        // only do something if carrierID is not 0 and production is running
                        if (plcinfo.CarrierID != 0 && MainWindowForm.isProductionRunning) { CarrierHandler((ushort)value, plcinfo.Type); }
                        break;
                }
            };

            // add the subscription to the session
            client.AddSubscription(_subscription);
            // start the subscription
            _subscription.Create();
        }

        private void CarrierHandler(ushort carrierID, string task)
        {
            Console.WriteLine("\nCarrier {0} found, checking if assigned to order.", carrierID);
            // goes through all orders to see if carrierID is in production, then adds it to the list if it isn't

            bool _carrierExists = false;
            foreach (Order order in MainWindowForm.mesSystem.Orders)
            {
                //Console.WriteLine("Order: {0}", order);
                foreach (Carrier carrier in order.CarriersInProductionList)
                {
                    // if the carrier is already assigned to the order, tell PLC to pass it on
                    if (carrier.CarrierID == carrierID)
                    {
                        Console.WriteLine("Carrier {0} is already assigned to order {1}, checking if the first task is the desired task", carrierID, order);
                        _carrierExists = true;
                        // if the carrier is already assigned to the order, check if the first task is valid
                        if(carrier.TaskQueue.Count > 0)
                        {
                            if (carrier.TaskQueue.ElementAt(0).TaskName == task)
                            {
                                Console.WriteLine("Carrier {0} has {1} as its first task, performing the task", carrierID, task);
                                carrier.TaskQueue.ElementAt(0).Status = "in progress";
                                carrier.TaskQueue.ElementAt(0).StartTime = DateTime.Now;
                                UpdateOrderForm();
                                // send the carrier to the PLC
                                OpcuaHandler("valid");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Carrier {0} does not have {1} as its first task, passing on to next module", carrierID, task);
                                OpcuaHandler("pass");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Carrier {0} does not have anymore tasks, passing it on", carrierID);
                            OpcuaHandler("pass");
                            return;
                        }
                        

                    }
                }
            }

            // only reaches this point if the carrier is not assigned to any order
            if (!_carrierExists) { TaskHandlerNewCarrier(carrierID, task); }

        }

        private void TaskHandlerNewCarrier(ushort carrierID, string task)
        {

            Console.WriteLine("\nCarrier {0} is not assigned to any order, assigning to first order in queue.", carrierID);

            // console write all orders
            Console.WriteLine("\nOrders: ");
            foreach (Order order in MainWindowForm.mesSystem.Orders)
            {
                Console.WriteLine("Order number {0} by customer {1}", order.OrderNumber, order.OrderCustomer);
            }
            Console.WriteLine("\n");

            // get first order in queue and set as current order
            if(MainWindowForm.mesSystem.Orders.Count > 0)
            {
                _currentOrder = MainWindowForm.mesSystem.Orders.ElementAt(0);
                _currentOrder.OrderStartTime = DateTime.Now;
                _currentOrder.OrderState = OrderState.BUSY;
                // get the first carrier in CarriersInOrder list and set as new carrier
                _carrierInOrder = currentOrder.CarriersInOrder.ElementAt(0);


                // assign the carrier to the order
                _carrierInOrder.CarrierID = carrierID;
                Console.WriteLine("Carrier {0} assigned to order {1}", carrierID, _currentOrder.OrderNumber);

                // add the carrier to the list of carriers in production
                carrierInOrder.CarrierState = OrderState.BUSY;
                currentOrder.CarriersInProductionList.AddLast(carrierInOrder);
                Console.WriteLine("Carrier {0} added to production list", _carrierInOrder.CarrierID);


                // remove the carrier from the list of carriers in order
                currentOrder.CarriersInOrder.Remove(carrierInOrder);
                Console.WriteLine("Carrier {0} removed from order list", _carrierInOrder.CarrierID);

                // print carrier info
                carrierInOrder.PrintCarrierInfo();


                // check if the desired task is the first task in the queue, if not then pass the carrier on
                if (_carrierInOrder.TaskQueue.ElementAt(0).TaskName == task)
                {
                    // send the carrier to the PLC
                    OpcuaHandler("valid");
                    Console.WriteLine("Carrier {0} sent to PLC with command {1}", carrierInOrder.CarrierID, "valid");
                    _carrierInOrder.TaskQueue.ElementAt(0).Status = "in progress";
                    _carrierInOrder.TaskQueue.ElementAt(0).StartTime = DateTime.Now;
                    UpdateOrderForm();
                    // console write the production list and order list
                    //Console.WriteLine("Production list: ");
                    //Console.WriteLine(
                    //    string.Join(", ", currentOrder.CarriersInProductionList.Select(x => x.CarrierID).ToArray()));
                    //Console.WriteLine("Order list: ");
                    //Console.WriteLine(string.Join(", ", currentOrder.CarriersInOrder.Select(x => x.CarrierID).ToArray()));
                    return;
                }
                else
                {
                    Console.WriteLine("Carrier {0} does not have {1} as its first task, passing on to next module", carrierInOrder.CarrierID, task);
                    OpcuaHandler("pass");
                    return;
                }
            }
            else
            {
                Console.WriteLine("No more orders in production queue");
                OpcuaHandler("pass");
                return;
            }

            
        }

        

        private void ApplicationHandler(Session client, string state)
        {
            // set up switch cases to handle when application is starting, is ready, is running, and is finished
            switch (state)
            {
                case "starting":
                    Console.WriteLine("Application is starting");
                    break;
                case "ready":
                    Console.WriteLine("Application is ready");
                    break;
                case "running":
                    Console.WriteLine("Application is running");
                    break;
                case "passed":
                    Console.WriteLine("Application has passed carrier to next module");
                    break;
                case "done":
                    Console.WriteLine("Application is done");
                    // remove the current task from the carrier
                    carrierInOrder.CompleteFirstTaskInCarrierQueue();
                    carrierInOrder.PrintCarrierInfo();

                    if(_currentOrder.CarriersInOrder.Count <= 0)
                    {
                        _currentOrder.OrderEndTime = DateTime.Now;
                        _currentOrder.OrderState = OrderState.DONE;
                        //_currentOrder.SendOrderInfoToDatabase();
                        MainWindowForm.mesSystem.Orders.Remove(_currentOrder);
                        UpdateProductionQueueForm();
                    }

                    OpcuaHandler("transfer");
                    break;
            }
        }

        // function to handle the commands sent to the PLC
        public void OpcuaHandler(string serverCommand)
        {
            ModifyNodeValue("ServerCommand", serverCommand);
        }



        public void ModifyNodeValue(string variableName, string newValue)
        {
            // Create a NodeId object from the string nodeId
            NodeId node = new NodeId(String.Format("{0}.{1}", _nodeId, variableName));
            WriteValueCollection nodesToWrite = new WriteValueCollection();

            // write the current value of the node
            DataValue value = _clientSession.ReadValue(node);
            Console.WriteLine("\nModifying {0} in {1}, Current value is: {2}, Changing value to: {3}", variableName, node, value.Value, newValue);

            // Create a WriteValue object
            WriteValue writeValue = new WriteValue
            {
                NodeId = node,
                AttributeId = Attributes.Value,
                Value = new DataValue(new Variant(newValue))
            };

            // Add the WriteValue object to the WriteValueCollection
            nodesToWrite.Add(writeValue);


            // Write the new value to the node
            _clientSession.Write(null, nodesToWrite, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

            // Check if the write was successful

            if (StatusCode.IsGood(results[0]))
            {
                Console.WriteLine("Write succeeded");
            }
            else
            {
                Console.WriteLine("Write failed");

                // Display the error message
                Console.WriteLine("Error message: {0}", results[0]);

                // Display the diagnostic information
                Console.WriteLine("Diagnostic information: {0}", diagnosticInfos[0]);

            }
        }

        private void UpdateOrderForm()
        {
            OrderForm orderForm = Application.OpenForms.OfType<OrderForm>().FirstOrDefault();

            if (orderForm != null)
            {
                orderForm.UpdateOrderForm();
            }
        }

        private void UpdateProductionQueueForm()
        {
            ProductionQueueForm produtionQueueForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();

            if (produtionQueueForm != null)
            {
                produtionQueueForm.RefreshOrders();
            }
        }
    }
}