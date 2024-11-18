using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.X500;

namespace databaseSQL
{
    internal class database
    {
        private string _db_host;
        private string _db_user;
        private string _db_password;
        private string _db_name;
        private MySqlConnection mysql;


        public database(string _db_host, string _db_user, string _db_password, string _db_name)
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
            if (mysql.State != ConnectionState.Open) {
                mysql.Open();
                Console.WriteLine("open server");
            }

        }


        public void create_table_order()
        {
            // Define your CREATE TABLE SQL query
            string createTableOrder = @"
                    CREATE TABLE IF NOT EXISTS hahah (
                    order_number INT,
                    amount INT,
                    company VARCHAR(255),
                    medicine_type VARCHAR(255)
                );
            "
            ;
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
                CREATE TABLE IF NOT EXISTS nejnej (
                order_number INT,
                type_container VARCHAR(255),
                amount_in_carrier INT,
                start_time_full_system INT,
                end_time_full_system INT,
                Manufacturing_Lead_Time INT,
                start_time_modul_1 INT,
                end_time_modul_1 INT,
                used_time_modul_1 INT,
                start_time_modul_2 INT,
                end_time_modul_2 INT,
                used_time_modul_2 INT,
                carrier_id INT,
                modul_used VARCHAR(255)
                );
            "
            ;
            connection();

            MySqlCommand cmd = new MySqlCommand(createTableProduction, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("table production created ");

            database_close();


        }

        public void insert_data_order(int order_number, string type_container, int amount_in_carrier,
                    int start_time_full_system, int end_time_full_system,
                    int manufacturing_lead_time, int start_time_modul_1,
                    int end_time_modul_1, int used_time_modul_1, int start_time_modul_2,
                    int end_time_modul_2, int used_time_modul_2, int carrier_id, string modul_used)
        {
            string insertData = @"
            INSERT INTO nejnej (
                order_number, type_container, amount_in_carrier,
                start_time_full_system, end_time_full_system,
                Manufacturing_Lead_Time, start_time_modul_1, end_time_modul_1,
                used_time_modul_1, start_time_modul_2, end_time_modul_2,
                used_time_modul_2, carrier_id, modul_used
            )
            VALUES (
                @orderNumber, @typeContainer, @amountInCarrier,
                @startTimeFullSystem, @endTimeFullSystem,
                @manufacturingLeadTime, @startTimeModule1, @endTimeModule1,
                @usedTimeModule1, @startTimeModule2, @endTimeModule2,
                @usedTimeModule2, @carrierId, @moduleUsed
            );";
            // Ensure the connection is open before executing the command

            connection();

            MySqlCommand cmd = new MySqlCommand(insertData, mysql);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
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
            cmd.Parameters.AddWithValue("carrierId", carrier_id);
            cmd.Parameters.AddWithValue("moduleUsed", modul_used);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted Into order");

            database_close();

        }


        public void insert_data_production(int order_number, int amount, string company,
                    string medicine_type)
        {
            string insertDataProduction = @"
            INSERT INTO hahah (
                order_number, amount, company,
                medicine_type
            )
            VALUES (
                @orderNumber, @amount, @company,
                @medicineType
            );"
            ;

            connection();

            MySqlCommand cmd = new MySqlCommand(insertDataProduction, mysql);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.Parameters.AddWithValue("company", company);
            cmd.Parameters.AddWithValue("medicineType", medicine_type);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted Into production");
            database_close();
        }
        public void database_close()
        {
            if (mysql.State == ConnectionState.Open)

                mysql.Close();
            Console.WriteLine("close server");
        }

        public int get_order_number()
        {
            connection();
            Console.WriteLine("starter get_order_number");
            string get_order_number = "SELECT order_number FROM nejnej ORDER BY order_number DESC LIMIT 1; ";
            MySqlCommand cmd = new MySqlCommand(get_order_number, mysql);
            MySqlDataReader rdr = cmd.ExecuteReader();


            int latest_Order_number = 0;
            while (rdr.Read())
            {

                latest_Order_number = Convert.ToInt32(rdr[0]);
                Console.WriteLine(latest_Order_number);
            }
            rdr.Close();
            database_close();
            return latest_Order_number;

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
        {   connection();
            string delete_order = "DELETE FROM hahah WHERE order_number = @input_order_delete;";
            MySqlCommand cmd = new MySqlCommand(delete_order, mysql);
            cmd.Parameters.AddWithValue("@input_order_delete", input_order_delete);  // Correct parameter name
            cmd.ExecuteNonQuery();
            database_close();
        }










    }







}