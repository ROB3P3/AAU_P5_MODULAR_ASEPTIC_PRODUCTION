using Opc.Ua;
using Opc.Ua.Client;

namespace ROB5_MES_System.Classes
{
    public class OPCUA
    {
        private string _appType;
        private string _appState;
        private ushort _productID;
        private Session _clientSession;
        private Subscription _subscription;
        private string _nodeID;
        private PLCInfo _plcInfo;
        private Order _currentOrder;
        private Product _productInOrder;

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
        public ushort ProductIdentifier
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string NodeIdentifier
        {
            get { return _nodeID; }
            set { _nodeID = value; }
        }
        public PLCInfo PlcInfo
        {
            get { return _plcInfo; }
            set { _plcInfo = value; }
        }

        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set { _currentOrder = value; }
        }
        public Product ProductInOrder
        {
            get { return _productInOrder; }
            set { _productInOrder = value; }
        }

        /// <summary>
        /// Constructor for the OPCUA class.
        /// Attempts to connect to the server and subscribe to the application state and product id
        /// </summary>
        /// <param name="endpointUrl"></param>
        /// <param name="nodeId"></param>
        /// <param name="plcinfo"></param>
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
                // subscribe to application state and product id
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

        /// <summary>
        /// Create an application configuration object
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Create an endpoint object
        /// </summary>
        /// <param name="applicationConfiguration"></param>
        /// <param name="endpointUrl"></param>
        /// <returns></returns>
        private static ConfiguredEndpoint CreateEndpoint(Opc.Ua.ApplicationConfiguration applicationConfiguration, string endpointUrl)
        {
            // Create an endpoint configuration using the application configuration, said so online!
            var endpointConfiguration = EndpointConfiguration.Create(applicationConfiguration);

            // Select the endpoint using the provided URL and disable security, let us get hacked lmao
            var selectedEndpoint = CoreClientUtils.SelectEndpoint(endpointUrl, useSecurity: false);

            // Return a configured endpoint with the selected endpoint and endpoint configuration
            return new ConfiguredEndpoint(null, selectedEndpoint, endpointConfiguration);
        }

        /// <summary>
        /// Display the value of a node
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nodeId"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Subsrcibe to a node value
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nodeId"></param>
        /// <param name="variableName"></param>
        /// <param name="plcinfo"></param>
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
                        plcinfo.ProductID = (ushort)value;
                        Console.WriteLine("{0} is: {1}\n", variableName, value);
                        // only do something if productID is not 0 and production is running
                        if (plcinfo.ProductID != 0 && MainWindowForm.isProductionRunning) { ProductHandler((ushort)value, plcinfo.Type); }
                        break;
                }
            };

            // add the subscription to the session
            client.AddSubscription(_subscription);
            // start the subscription
            _subscription.Create();
        }

        /// <summary>
        /// Function to handle when the productID is read by the RFID reader
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="process"></param>
        private void ProductHandler(ushort productID, string process)
        {
            Console.WriteLine("\nProduct {0} found, checking if assigned to order.", productID);
            // goes through all orders to see if productID is in production, then adds it to the list if it isn't

            bool _productExists = false;
            foreach (Order order in MainWindowForm.mesSystem.OrderQueue)
            {
                //Console.WriteLine("Order: {0}", order);
                foreach (Product product in order.ProductsInProductionList)
                {
                    // if the product is already assigned to the order, tell PLC to pass it on
                    if (product.ProductID == productID)
                    {
                        Console.WriteLine("Product {0} is already assigned to order {1}, checking if the first process is the desired process", productID, order);
                        _productExists = true;
                        
                        // check if the product has any processs left
                        if (product.ProductProcessQueue.Count > 0)
                        {
                            // if the product is already assigned to the order, check if the first process is the desired process
                            if (product.ProductProcessQueue.ElementAt(0).ProcessName == process)
                            {
                                Console.WriteLine("Product {0} has {1} as its first process, performing the process", productID, process);
                                product.ProductProcessQueue.ElementAt(0).ProcessState = OrderState.BUSY;
                                product.ProductProcessQueue.ElementAt(0).ProcessStartTime = DateTime.Now;
                                UpdateOrderForm();
                                // send the product to the PLC
                                // letting the PLC know that the process is valid
                                OpcuaHandler("valid");
                                return;
                            }
                            else
                            {
                                // passing the product on to the next module if it doesn't have the desired process as the first process
                                Console.WriteLine("Product {0} does not have {1} as its first process, passing on to next module", productID, process);
                                OpcuaHandler("pass");
                                return;
                            }
                        }
                        else
                        {
                            // if the product has no processs left, pass it on
                            Console.WriteLine("Product {0} does not have anymore processs, passing it on", productID);
                            OpcuaHandler("pass");
                            return;
                        }
                    }
                }
            }

            // only reaches this point if the product is not assigned to any order
            if (!_productExists) { ProcessHandlerNewProduct(productID, process); }
        }

        /// <summary>
        /// Function to handle when a new product is found by the RFID reader
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="process"></param>
        private void ProcessHandlerNewProduct(ushort productID, string process)
        {

            Console.WriteLine("\nProduct {0} is not assigned to any order, assigning to first order in queue.", productID);

            // console write all orders
            Console.WriteLine("\nOrders: ");
            foreach (Order order in MainWindowForm.mesSystem.OrderQueue)
            {
                Console.WriteLine("Order number {0} by customer {1}", order.OrderNumber, order.OrderCustomer);
            }
            Console.WriteLine("\n");

            // check if there are any orders left in the production queue
            if (MainWindowForm.mesSystem.OrderQueue.Count > 0)
            {
                // get first order in queue and set as current order
                _currentOrder = MainWindowForm.mesSystem.OrderQueue.ElementAt(0);
                _currentOrder.OrderState = OrderState.BUSY;

                // set the order start time if it is null (this is to ensure it does not get overwritten)
                if (_currentOrder.OrderStartTime == null)
                {
                    _currentOrder.OrderStartTime = DateTime.Now;
                }
                UpdateProductionQueueForm();
                
                // get the first product in ProductsInOrder list and set as new product
                _productInOrder = CurrentOrder.ProductsInOrderList.ElementAt(0);

                // assign the productID the RFID read to the product in the order
                _productInOrder.ProductID = productID;
                Console.WriteLine("Product {0} assigned to order {1}", productID, _currentOrder.OrderNumber);

                // add the product to the list of products in production
                _productInOrder.ProductState = OrderState.BUSY;
                if(_productInOrder.ProductStartTime == DateTime.MinValue)
                {
                    _productInOrder.ProductStartTime = DateTime.Now;
                }
                _currentOrder.ProductsInProductionList.AddLast(ProductInOrder);
                Console.WriteLine("Product {0} added to order's product production list", _productInOrder.ProductID);

                // remove the product from the list of products in order that are not in production
                _currentOrder.ProductsInOrderList.Remove(ProductInOrder);
                Console.WriteLine("Product {0} removed from the order's product order list", _productInOrder.ProductID);

                // print product info
                _productInOrder.PrintProductInfo();

                // check if the desired process is the first process in the queue, if not then pass the product on
                if (_productInOrder.ProductProcessQueue.ElementAt(0).ProcessName == process)
                {
                    // send the product to the PLC
                    Console.WriteLine("Product {0} sent to PLC with command {1}", ProductInOrder.ProductID, "valid");
                    _productInOrder.ProductProcessQueue.ElementAt(0).ProcessState = OrderState.BUSY;
                    _productInOrder.ProductProcessQueue.ElementAt(0).ProcessStartTime = DateTime.Now;
                    UpdateOrderForm();

                    OpcuaHandler("valid");
                    return;
                }
                else
                {
                    // pass the product on to the next module if the first process is not the desired process
                    Console.WriteLine("Product {0} does not have {1} as its first process, passing on to next module", ProductInOrder.ProductID, process);
                    OpcuaHandler("pass");
                    return;
                }
            }
            else
            {
                // if there are no orders left in the production queue, pass the product
                Console.WriteLine("No more orders in production queue");
                OpcuaHandler("pass");
                return;
            }
        }

        /// <summary>
        /// Function to handle the application state
        /// </summary>
        /// <param name="client"></param>
        /// <param name="state"></param>
        private void ApplicationHandler(Session client, string state)
        {
            // set up switch cases to handle when application is starting, is ready, is running, is passing, and is finished
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
                    Console.WriteLine("Application has passed product to next module");
                    break;
                case "done":
                    Console.WriteLine("Application is done");
                    // remove the current process from the product
                    // print the order info
                    Console.WriteLine("reached here1");
                    ProductInOrder.CompleteFirstProcessInProductQueue();
                    Console.WriteLine("reached her2");
                    ProductInOrder.PrintProductInfo();
                    Console.WriteLine("reached her3");

                    // check if there are any products left in the order's product list and that all products in the order's product production list are done
                    if (_currentOrder.ProductsInOrderList.Count <= 0 && _currentOrder.ProductsInProductionList.All(product => product.ProductState == OrderState.DONE))
                    {
                        Console.WriteLine("reached here 4");

                        // set the order end time and state to done
                        _currentOrder.OrderEndTime = DateTime.Now;
                        _currentOrder.OrderState = OrderState.DONE;
                        // remove the order from the database and readd it as a finished order
                        MainWindowForm.database.DeleteOrder(_currentOrder.OrderNumber);
                        _currentOrder.SendOrderInfoToDatabase();
                        // remove the order from the production queue
                        MainWindowForm.mesSystem.OrderQueue.Remove(_currentOrder);
                        UpdateProductionQueueForm();
                        UpdateOrderForm();
                    }

                    OpcuaHandler("transfer");
                    break;
            }
        }

        /// <summary>
        /// Function to handle the commands sent to the PLC
        /// </summary>
        /// <param name="serverCommand"></param>
        public void OpcuaHandler(string serverCommand)
        {
            ModifyNodeValue("ServerCommand", serverCommand);
        }

        /// <summary>
        /// Function to modify the node value
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="newValue"></param>
        public void ModifyNodeValue(string variableName, string newValue)
        {
            // Create a NodeId object from the string nodeId
            NodeId node = new NodeId(String.Format("{0}.{1}", _nodeID, variableName));
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

        /// <summary>
        /// Function to update the order form if open
        /// </summary>
        private void UpdateOrderForm()
        {
            Console.WriteLine("Updating Order Form");
            OrderForm orderForm = Application.OpenForms.OfType<OrderForm>().FirstOrDefault();

            if (orderForm != null)
            {
                orderForm.UpdateOrderForm();
            }
        }

        /// <summary>
        /// Function to update the production queue form if open
        /// </summary>
        private void UpdateProductionQueueForm()
        {
            Console.WriteLine("Updating Production Queue Form");
            ProductionQueueForm produtionQueueForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();

            if (produtionQueueForm != null)
            {
                produtionQueueForm.RefreshOrders();
            }
        }
    }
}