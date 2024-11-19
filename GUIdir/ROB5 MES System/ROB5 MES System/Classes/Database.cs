using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ROB5_MES_System.Classes
{
    public class Database
    {
        private string _db_host;
        private string _db_user;
        private string _db_password;
        private string _db_name;
        private MySqlConnection mysql;

        public Database(string _db_host, string _db_user, string _db_password, string _db_name)
        {
            this._db_host = _db_host;
            this._db_user = _db_user;
            this._db_password = _db_password;
            this._db_name = _db_name;
            connection();
        }

        private void connection()
        {
            string myConnectionString = "server=" + this._db_host + ";uid=" + this._db_user + ";pwd=" + this._db_password + ";database=" + this._db_name;
            mysql = new MySqlConnection(myConnectionString);
            if (mysql.State != ConnectionState.Open)
            {
                mysql.Open();
                Console.WriteLine("open server");
            }

        }

        public void create_table_order()
        {
            // Define your CREATE TABLE SQL query
            string createTableOrder = @"
                    CREATE TABLE IF NOT EXISTS order_data (
                    order_number INT NOT NULL,
                    order_state VARCHAR(255),
                    amount INT,
                    container_type VARCHAR(255),
                    company VARCHAR(255),
                    medicine_type VARCHAR(255),
                    PRIMARY KEY (order_number)
                );
            ";
            
            connection();

            MySqlCommand cmd = new MySqlCommand(createTableOrder, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("orderData table created");

            database_close();
        }

        public void create_table_production()
        {
            // Define your CREATE TABLE SQL query
            string createTableProduction = @"
                CREATE TABLE IF NOT EXISTS production_data (
                order_number INT,
                carrier_id INT,
                type_container VARCHAR(255),
                amount_in_carrier INT,
                start_time_full_system DATETIME,
                end_time_full_system DATETIME,
                Manufacturing_Lead_Time DATETIME,
                start_time_modul_1 DATETIME,
                end_time_modul_1 DATETIME,
                used_time_modul_1 DATETIME,
                start_time_modul_2 DATETIME,
                end_time_modul_2 DATETIME,
                used_time_modul_2 DATETIME,
                modul_used VARCHAR(255)
                );
            "
            ;
            connection();

            MySqlCommand cmd = new MySqlCommand(createTableProduction, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("table production created");

            database_close();
        }

        public void insert_data_production(int order_number, int carrier_id, string type_container, int amount_in_carrier,
                    DateTime start_time_full_system, DateTime end_time_full_system,
                    DateTime manufacturing_lead_time, DateTime start_time_modul_1,
                    DateTime end_time_modul_1, DateTime used_time_modul_1, DateTime start_time_modul_2,
                    DateTime end_time_modul_2, DateTime used_time_modul_2, string modul_used)
        {
            string insertData = @"
            INSERT INTO production_data (
                order_number, carrier_id, type_container, amount_in_carrier,
                start_time_full_system, end_time_full_system,
                Manufacturing_Lead_Time, start_time_modul_1, end_time_modul_1,
                used_time_modul_1, start_time_modul_2, end_time_modul_2,
                used_time_modul_2, modul_used
            )
            VALUES (
                @orderNumber, @carrierId, @typeContainer, @amountInCarrier,
                @startTimeFullSystem, @endTimeFullSystem,
                @manufacturingLeadTime, @startTimeModule1, @endTimeModule1,
                @usedTimeModule1, @startTimeModule2, @endTimeModule2,
                @usedTimeModule2, @moduleUsed
            );";
            // Ensure the connection is open before executing the command

            connection();

            MySqlCommand cmd = new MySqlCommand(insertData, mysql);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
            cmd.Parameters.AddWithValue("carrierId", carrier_id);
            cmd.Parameters.AddWithValue("typeContainer", type_container);
            cmd.Parameters.AddWithValue("amountInCarrier", amount_in_carrier);
            cmd.Parameters.AddWithValue("startTimeFullSystem", start_time_full_system);
            cmd.Parameters.AddWithValue("endTimeFullSystem", end_time_full_system);
            cmd.Parameters.AddWithValue("manufacturingLeadTime", manufacturing_lead_time);
            cmd.Parameters.AddWithValue("startTimeModule1", start_time_modul_1);
            cmd.Parameters.AddWithValue("endTimeModule1", end_time_modul_1);
            cmd.Parameters.AddWithValue("usedTimeModule1", used_time_modul_1);
            cmd.Parameters.AddWithValue("startTimeModule2", start_time_modul_2);
            cmd.Parameters.AddWithValue("endTimeModule2", end_time_modul_2);
            cmd.Parameters.AddWithValue("usedTimeModule2", used_time_modul_2);
            cmd.Parameters.AddWithValue("moduleUsed", modul_used);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted Into order");

            database_close();
        }

        public void insert_data_order(int order_number, string order_state, int amount, string container_type, string company,
                    string medicine_type)
        {
            string insertDataProduction = @"
            INSERT INTO order_data (
                order_number, order_state, amount, container_type, company,
                medicine_type
            )
            VALUES (
                @orderNumber, @orderState, @amount, @containerType, @company,
                @medicineType
            );"
            ;

            connection();

            MySqlCommand cmd = new MySqlCommand(insertDataProduction, mysql);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
            cmd.Parameters.AddWithValue("orderState", order_state);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.Parameters.AddWithValue("containerType", container_type);
            cmd.Parameters.AddWithValue("company", company);
            cmd.Parameters.AddWithValue("medicineType", medicine_type);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted Into production");
            database_close();
        }

        public int get_order_number()
        {
            int maxOrderNumber = 0;

            if (order_data_not_empty())
            {
                connection();
                string sqlCommand = "SELECT MAX(order_number) as max_order_number from production.order_data";

                MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    maxOrderNumber = reader.GetInt32("max_order_number");
                }

                reader.Close();
                database_close();
            }

            return maxOrderNumber + 1;
        }

        public void get_production_queue()
        {
            connection();
            string sqlCommand = "SELECT * FROM production.order_data WHERE order_state = 'QUEUE'";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderNumber = reader.GetInt32("order_number");
                int containerAmount = reader.GetInt32("amount");
                string containerType = reader.GetString("container_type");
                string company = reader.GetString("company");
                string medicineType = reader.GetString("medicine_type");

                Order order = new Order(containerAmount, containerType, company, orderNumber, DateTime.Now, OrderState.QUEUE);
                MainWindowForm.mesSystem.Orders.AddLast(order);
            }

            database_close();
        }

        public void get_planned_orders()
        {
            connection();
            string sqlCommand = "SELECT * FROM production.order_data WHERE order_state = 'PEND'";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderNumber = reader.GetInt32("order_number");
                int containerAmount = reader.GetInt32("amount");
                string containerType = reader.GetString("container_type");
                string company = reader.GetString("company");
                string medicineType = reader.GetString("medicine_type");

                Order order = new Order(containerAmount, containerType, company, orderNumber, DateTime.Now, OrderState.PEND);
                MainWindowForm.mesSystem.PlannedOrders.AddLast(order);
            }

            database_close();
        }

        public List<Order> get_finished_orders()
        {
            connection();
            List<Order> finishedOrders = new List<Order>();
            string sqlCommand = "SELECT * FROM production.order_data WHERE order_state = 'DONE'";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderNumber = reader.GetInt32("order_number");
                int containerAmount = reader.GetInt32("amount");
                string containerType = reader.GetString("container_type");
                string company = reader.GetString("company");
                string medicineType = reader.GetString("medicine_type");

                Order order = new Order(containerAmount, containerType, company, orderNumber, DateTime.Now, OrderState.PEND);
                finishedOrders.Add(order);
            }

            database_close();
            return finishedOrders;
        }

        public bool order_data_not_empty()
        {
            connection();
            string checkIfEmpty = "SELECT 1 FROM production.order_data LIMIT 1;";

            MySqlCommand checkCmd = new MySqlCommand(checkIfEmpty, mysql);

            bool isEmpty = true;

            if(checkCmd.ExecuteScalar() == null)
            {
                isEmpty = false;
            }

            database_close();
            return isEmpty;
        }

        public bool production_data_not_empty()
        {
            connection();
            string checkIfEmpty = "SELECT 1 FROM production.production_data LIMIT 1;";

            MySqlCommand checkCmd = new MySqlCommand(checkIfEmpty, mysql);

            bool isEmpty = true;

            if (checkCmd.ExecuteScalar() == null)
            {
                isEmpty = false;
            }

            database_close();
            return isEmpty;
        }

        public int amount(int latest_Order_number)
        {
            connection();
            Console.WriteLine("starter getamount");
            string get_amount = "SELECT amount FROM hahah WHERE order_number = @latest_Order_number;";


            MySqlCommand cmd = new MySqlCommand(get_amount, mysql);
            cmd.Parameters.AddWithValue("@latest_Order_number", latest_Order_number);
            MySqlDataReader rdr = cmd.ExecuteReader();


            int amountInOrder = 0;
            if (rdr.Read()) // Move to the first row of results
            {
                amountInOrder = rdr.GetInt32("amount"); // Read the value
                Console.WriteLine("Amount in Carrier: " + amountInOrder);
            }
            rdr.Close();
            database_close();
            return amountInOrder;
        }

        public int amount_left(int latest_Order_number, int amountInOrder)
        {
            connection();
            Console.WriteLine("starter amount left");

            string get_amount = "SELECT amount_in_carrier FROM nejnej WHERE order_number = @latest_Order_number;";
            MySqlCommand cmd = new MySqlCommand(get_amount, mysql);
            cmd.Parameters.AddWithValue("@latest_Order_number", latest_Order_number);
            MySqlDataReader rdr = cmd.ExecuteReader();

            int carrier_in_carrier = 0;
            while (rdr.Read()) // Move to the first row of results
            {
                carrier_in_carrier = rdr.GetInt32("amount_in_carrier");
                amountInOrder = amountInOrder - carrier_in_carrier;
                Console.WriteLine("Amount in Carrier: " + carrier_in_carrier);
            }
            rdr.Close();
            database_close();
            Console.WriteLine(amountInOrder);
            return amountInOrder;
        }

        public void delete_order(int input_order_delete)
        {
            connection();
            string delete_order = "DELETE FROM hahah WHERE order_number = @input_order_delete;";
            MySqlCommand cmd = new MySqlCommand(delete_order, mysql);
            cmd.Parameters.AddWithValue("@input_order_delete", input_order_delete);
            cmd.ExecuteNonQuery();
            database_close();
        }

        public void database_close()
        {
            if (mysql.State == ConnectionState.Open)
                mysql.Close();
            Console.WriteLine("close server");
        }
    }
}
