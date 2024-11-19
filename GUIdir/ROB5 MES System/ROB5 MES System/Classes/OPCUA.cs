using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using static System.Collections.Specialized.BitVector32;

namespace ROB5_MES_System.Classes
{
    public class OPCUA
    {
        private string _appType;
        public string AppTypeTest
        {
            get { return _appType; }
            set { _appType = value; }
        }

        public OPCUA(string endpointUrl)
        {

            // Create the application configuration
            var applicationConfiguration = CreateApplicationConfiguration();
            // Create the endpoint
            var endpoint = CreateEndpoint(applicationConfiguration, endpointUrl);


            // Connect to the server, read 2 nodes and write a new value to another node
            using (var client = Session.Create(applicationConfiguration, endpoint, false, "OPCUAClient", 60000, null, null).Result)
            {
                this.AppTypeTest = (string)DisplayNodeValue(client, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC09_MAIN.AppType", "appType");
                //SubscribeNodeValue(client, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC13_MAIN.AppState", "appState");
                //SubscribeNodeValue(client, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC13_MAIN.CarrierID", "carrierID");

                // wait for the user to press a key
                //Console.WriteLine("Press any key to exit");
                //Console.ReadKey();
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
            //Console.WriteLine("{0} is: {1}", variableName, value.Value);

            // Return the value
            return (string)value.Value;
        }

        private static void SubscribeNodeValue(Session client, string nodeId, string variableName)
        {
            // write which node we are subscribing to and if connection is successful
            Console.WriteLine("Subscribing to {0}", variableName);

            // Create a NodeId object from the string nodeId
            NodeId node = new NodeId(nodeId);

            // create a subscription to the ApplicationState node
            var subscription = new Subscription(client.DefaultSubscription);

            // create a monitored item for the ApplicationState node
            var monitoredItem = new MonitoredItem(subscription.DefaultItem)
            {
                StartNodeId = node,
                AttributeId = Attributes.Value
            };

            // add the monitored item to the subscription
            subscription.AddItem(monitoredItem);

            // create a callback for the DataChanged event
            monitoredItem.Notification += (item, eventArgs) =>
            {
                // get the value of the ApplicationState node
                var value = ((MonitoredItemNotification)eventArgs.NotificationValue).Value.Value;
                // display the value
                //Console.WriteLine("{0} is: {1}", variableName, value);
                switch (variableName)
                {
                    case "carrierID":
                        if ((ushort)value != 0)
                        {
                            Console.WriteLine("Carrier found, {0} is: {1}", variableName, value);
                            CarrierHandler(client, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC13_MAIN.ServerCommand", "ServerCommand", (ushort)value);
                        }
                        else
                        {
                            Console.WriteLine("Carrier not found");
                        }
                        break;
                    case "appState":
                        Console.WriteLine("Application state is: {0}", value);
                        break;
                }
            };

            // add the subscription to the session
            client.AddSubscription(subscription);
            // start the subscription
            subscription.Create();


        }


        private static void CarrierHandler(Session client, string nodeId, string variableName, ushort value)
        {
            //Console.WriteLine("Carrier handler, carrier ID is {0}", value);

            string serverCommand = "begin";
            ModifyNodeValue(client, nodeId, variableName, serverCommand);

        }

        private static void ApplicationStateHandler(Session client, string nodeId, string variableName, string value)
        {
            return;
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