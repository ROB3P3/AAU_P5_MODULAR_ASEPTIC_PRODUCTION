using ROB5_MES_System.Classes;
using System.Diagnostics;


namespace ROB5_MES_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // MySQL database setup
            Database database = new Database("localhost", "volle", "volle", "production");
            database.create_table_order();
            database.create_table_production();

            // OPC UA setup
            // Setup the endpoint URL for plc09
            //string plc09EndpointUrl = "opc.tcp://172.20.13.1:4840";
            //OPCUA plc09OpcUa = new OPCUA(plc09EndpointUrl);
            // Setup the endpoint URL for plc08 (not used currently)
            //var stopperingEndpointUrl = "opc.tcp://172.20.1.1:4840";
            // OPCUA stopperingOpcUa = new OPCUA(stopperingEndpointUrl);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindowForm());




            database.database_close();


        }
    }
}