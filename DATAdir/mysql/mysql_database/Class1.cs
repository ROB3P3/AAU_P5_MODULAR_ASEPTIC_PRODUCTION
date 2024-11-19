using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Data;

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
                    CREATE TABLE IF NOT EXISTS order_data (
                    order_number INT,
                    amount INT,
                    order_state VARCHAR(255),
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
            Console.WriteLine("table production created ");

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
            cmd.Parameters.AddWithValue("carrierId", carrier_id);
            cmd.Parameters.AddWithValue("moduleUsed", modul_used);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted Into order");

            database_close();   
        }


        public void insert_data_order(int order_number, int amount, string order_state, string company,
                    string medicine_type)
        {
            string insertDataProduction = @"
            INSERT INTO order_data (
                order_number, amount, order_state, company,
                medicine_type
            )
            VALUES (
                @orderNumber, @amount, @orderState, @company,
                @medicineType
            );"
            ;

            connection();

            MySqlCommand cmd = new MySqlCommand(insertDataProduction, mysql);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.Parameters.AddWithValue("orderState", order_state);
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
    }
}