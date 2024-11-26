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
            //Database database = new Database("localhost", "MES", "MES", "production");
            //database.create_table_order();
            //database.create_table_production();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindowForm());






            //database.database_close();


        }
    }
}