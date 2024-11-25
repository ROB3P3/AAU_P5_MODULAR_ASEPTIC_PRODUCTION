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

            db.insert_data_production(3, "type_container", 3,
                    2, 1, 2,
                    DateTime.Now, DateTime.Now.AddHours(1),2,
                    DateTime.Now, DateTime.Now.AddHours(2), 1,
                    1, "type_container");

            
            db.insert_data_order(7, 500, "AstraZeneca", "Tagrisso");

            int latest_ordernummer=db.get_order_number();

            int amount=db.amount(latest_ordernummer);

            db.amount_left(latest_ordernummer, amount);
            
            //db.delete_order();












        }
    }
}