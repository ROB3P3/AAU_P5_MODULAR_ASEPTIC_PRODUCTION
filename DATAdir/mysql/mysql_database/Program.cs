using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ROB5_MES_System.Classes;

namespace databaseSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string db_host = "localhost";
            string db_user = "anton";
            string db_password = "anton";
            string db_name = "production";

            Database db = new Database(db_host, db_user, db_password, db_name);

            db.create_table_order();
            db.create_table_production();

            db.insert_data_production(
                3, 101, "Plastic Container", 5,
                DateTime.Now, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2),
                DateTime.Now, DateTime.Now.AddHours(1), DateTime.Now.AddMinutes(30),
                DateTime.Now, DateTime.Now.AddMinutes(45), DateTime.Now.AddMinutes(20),
                "Module A"
            );
        }
    }
}












 