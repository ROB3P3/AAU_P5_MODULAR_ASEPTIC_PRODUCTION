using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace databaseSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string db_host = "localhost";
            string db_user = "root";
            string db_password = "mysqltest";
            string db_name = "production";

            database db = new database(db_host, db_user, db_password, db_name);

            db.create_table_order();

            db.create_table_production();

            db.insert_data_production(2, 1, "vial", 5, DateTime.Now, DateTime.Now.AddHours(1), DateTime.Now.AddMinutes(2), DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "modules used");

            db.insert_data_order(2, 2, "start", "sus", "df");

            Console.WriteLine("jeg er færdig");
        }
    }
}