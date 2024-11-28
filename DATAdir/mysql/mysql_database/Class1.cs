using System;
using System.Data;
using MySql.Data.MySqlClient;
using ROB5_MES_System.Classes;

namespace ROB5_MES_System.Classes
{
    public class Database
    {
        private string _db_host;
        private string _db_user;
        private string _db_password;
        private string _db_name;
        private MySqlConnection mysql;

        public Database(string db_host, string db_user, string db_password, string db_name)
        {
            this._db_host = db_host;
            this._db_user = db_user;
            this._db_password = db_password;
            this._db_name = db_name;
            connection();
        }

        private void connection()
        {
            if (mysql == null)
            {
                string myConnectionString = $"server={_db_host};uid={_db_user};pwd={_db_password};database={_db_name}";
                mysql = new MySqlConnection(myConnectionString);
            }
            if (mysql.State != ConnectionState.Open)
            {
                mysql.Open();
                Console.WriteLine("Connected to the server.");
            }
        }

        public void create_table_order()
        {
            try
            {
                string createTableOrder = @"
                    CREATE TABLE IF NOT EXISTS order_data (
                        order_number INT NOT NULL,
                        order_state VARCHAR(255),
                        amount INT,
                        start_time DATETIME,
                        end_time DATETIME,
                        container_type VARCHAR(255),
                        company VARCHAR(255),
                        medicine_type VARCHAR(255),
                        PRIMARY KEY (order_number)
                    );
                ";
                connection();
                MySqlCommand cmd = new MySqlCommand(createTableOrder, mysql);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table 'order_data' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating table 'order_data': {ex.Message}");
            }
            finally
            {
                database_close();
            }
        }

        public void create_table_production()
        {
            try
            {
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
                        modul_used VARCHAR(255),
                        PRIMARY KEY (order_number, carrier_id)
                    );
                ";
                connection();
                MySqlCommand cmd = new MySqlCommand(createTableProduction, mysql);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table 'production_data' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating table 'production_data': {ex.Message}");
            }
            finally
            {
                database_close();
            }
        }

        public void insert_data_production(
            int order_number, int carrier_id, string type_container, int amount_in_carrier,
            DateTime start_time_full_system, DateTime end_time_full_system,
            DateTime manufacturing_lead_time, DateTime start_time_modul_1,
            DateTime end_time_modul_1, DateTime used_time_modul_1,
            DateTime start_time_modul_2, DateTime end_time_modul_2,
            DateTime used_time_modul_2, string modul_used)
        {
            try
            {
                string insertData = @"
                    INSERT INTO production_data (
                        order_number, carrier_id, type_container, amount_in_carrier,
                        start_time_full_system, end_time_full_system,
                        Manufacturing_Lead_Time, start_time_modul_1, end_time_modul_1,
                        used_time_modul_1, start_time_modul_2, end_time_modul_2,
                        used_time_modul_2, modul_used
                    ) VALUES (
                        @orderNumber, @carrierId, @typeContainer, @amountInCarrier,
                        @startTimeFullSystem, @endTimeFullSystem,
                        @manufacturingLeadTime, @startTimeModule1, @endTimeModule1,
                        @usedTimeModule1, @startTimeModule2, @endTimeModule2,
                        @usedTimeModule2, @moduleUsed
                    );
                ";
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
                Console.WriteLine("Data inserted into 'production_data'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into 'production_data': {ex.Message}");
            }
            finally
            {
                database_close();
            }
        }

        public void database_close()
        {
            if (mysql != null && mysql.State == ConnectionState.Open)
            {
                mysql.Close();
                Console.WriteLine("Server connection closed.");
            }
        }
    }
}

