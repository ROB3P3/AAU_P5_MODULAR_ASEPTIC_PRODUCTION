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
            string db_user = "anton";
            string db_password = "anton";
            string db_name = "pets";

            database db = new database(db_host, db_user, db_password, db_name);

            db.create_table_order();

            db.create_table_production();

            db.insert_data_order(8, "string type_container", 3,
                    2, 1,
                    2, 1,
                    1, 2, 1,
                    1, 2, 2, "modul_used");

            db.insert_data_production(2, 2, "sus", "df");

            db.get_order_number();

            Console.WriteLine("jeg er færdig");




        }
    }
}