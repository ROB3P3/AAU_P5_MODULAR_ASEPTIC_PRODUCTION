using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using static System.Collections.Specialized.BitVector32;

namespace OPCUA
{
    class Program
{
        static void Main(string[] args)
        {
            // Setup the endpoint URL
            var endpointUrl = "opc.tcp://172.20.1.1:4840";
            // Create the application configuration
            var applicationConfiguration = CreateApplicationConfiguration();
            // Create the endpoint
            var endpoint = CreateEndpoint(applicationConfiguration, endpointUrl);


            // Connect to the server, read 2 nodes and write a new value to another node
            using (var client = Session.Create(applicationConfiguration, endpoint, false, "OPCUAClient", 60000, null, null).Result)
            {
                DisplayNodeValue(client, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC13_MAIN.PLCid", "PLCid");
                DisplayNodeValue(client, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC13_MAIN.AppType", "AppType");
                ModifyNodeValue(client, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC13_MAIN.CarrierID", "CarrierID");
            }
        }



        private static ApplicationConfiguration CreateApplicationConfiguration()
        {
            // Create a ApplicationConfiguration object
            return new ApplicationConfiguration()
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

        private static ConfiguredEndpoint CreateEndpoint(ApplicationConfiguration applicationConfiguration, string endpointUrl)
        {
            // Create an endpoint configuration using the application configuration, said so online!
            var endpointConfiguration = EndpointConfiguration.Create(applicationConfiguration);

            // Select the endpoint using the provided URL and disable security, let us get hacked lmao
            var selectedEndpoint = CoreClientUtils.SelectEndpoint(endpointUrl, useSecurity: false);

            // Return a configured endpoint with the selected endpoint and endpoint configuration
            return new ConfiguredEndpoint(null, selectedEndpoint, endpointConfiguration);
        }

    private static void DisplayNodeValue(Session client, string nodeId, string variableName)
    {
        // Create a NodeId object from the string nodeId
        NodeId node = new NodeId(nodeId);

        // Read the value of the node
        DataValue value = client.ReadValue(node);

        // Display the value
        Console.WriteLine("{0} is: {1}", variableName, value.Value);
    }

    private static void ModifyNodeValue(Session client, string nodeId, string variableName)
    {
        // Create a NodeId object from the string nodeId
        NodeId node = new NodeId(nodeId);
        WriteValueCollection nodesToWrite = new WriteValueCollection();

        // write which node we are going to modify
        Console.WriteLine("Modifying {0}", variableName);

        // write the current value of the node
        DataValue value = client.ReadValue(node);
        Console.WriteLine("Current value is: {0}", value.Value);


        // Ask user for new value, allow only uint16 values, otherwise try again
        Console.WriteLine("Enter new uint16 value: ");
        string newValueString = Console.ReadLine();
        ushort newValue;
        while (!ushort.TryParse(newValueString, out newValue))
        {
            Console.WriteLine("Invalid value, please enter a valid uint16 value: ");
            newValueString = Console.ReadLine();
        }



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
}
}