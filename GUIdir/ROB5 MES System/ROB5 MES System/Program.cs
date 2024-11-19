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
            Database database = new Database("localhost", "root", "mysqltest", "production");
            database.create_table_order();
            database.create_table_production();

            // OPC UA setup
            // Setup the endpoint URL
            var endpointUrl = "opc.tcp://172.20.13.1:4840";
            OPCUA OpcUa = new OPCUA(endpointUrl);


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindowForm());

            database.database_close();


        }
    }
}