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
        public ushort CarrierID
        {
            get { return _carrierID; }
            set { _carrierID = value; }
        }

        public OPCUA(string endpointUrl, string nodeId, PLCInfo plcinfo)
        {
            // Create the application configuration
            var applicationConfiguration = CreateApplicationConfiguration();
            // Create the endpoint
            var endpoint = CreateEndpoint(applicationConfiguration, endpointUrl);

            // Connect to the server
            _clientSession = Session.Create(applicationConfiguration, endpoint, false, "OPCUAClient", 60000, null, null).Result;
            // read application type
            this.AppType = (string)DisplayNodeValue(_clientSession, String.Format("{0}.AppType", nodeId), "AppType");
            plcinfo.Type = this.AppType;
            // subscribe to application state
            SubscribeNodeValue(_clientSession, String.Format("{0}.AppState", nodeId), "AppState", plcinfo);
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
                // display the value
                Console.WriteLine("{0} is: {1}", variableName, value);
                //plcinfo.UpdatePLCInfo((string)value, "N/A");
                plcinfo.AppState = (string)value;
            };

            // add the subscription to the session
            client.AddSubscription(_subscription);
            // start the subscription
            _subscription.Create();
        }

        public void Dispose()
        {
            _subscription?.Delete(true);
            _clientSession?.Close();
            _clientSession?.Dispose();
        }

        private static void ModifyNodeValue(Session client, string nodeId, string variableName, string newValue)
        {
            // Create a NodeId object from the string nodeId
            NodeId node = new NodeId(nodeId);
            WriteValueCollection nodesToWrite = new WriteValueCollection();

            // write which node we are going to modify
            //Console.WriteLine("Modifying {0}", variableName);

            // write the current value of the node
            DataValue value = client.ReadValue(node);
            //Console.WriteLine("Current value is: {0}", value.Value);

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
            client.Write(null, nodesToWrite, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

            // Check if the write was successful
            /*
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

            }*/
        }
    }
}