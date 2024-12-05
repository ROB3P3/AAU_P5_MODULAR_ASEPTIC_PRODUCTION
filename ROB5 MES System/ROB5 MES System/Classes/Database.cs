using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ROB5_MES_System.Classes
{
    public class Database
    {
        // Få anton til at lave kommentare - Frederik 
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
                Console.WriteLine("Database server opened");
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
                    start_time DATETIME,
                    end_time DATETIME,
                    container_type VARCHAR(255),
                    company VARCHAR(255),
                    medicine_type VARCHAR(255),
                    operation_list JSON,
                    PRIMARY KEY (order_number)
                );
            ";
            
            connection();

            MySqlCommand cmd = new MySqlCommand(createTableOrder, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("order_data table created");

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
            Console.WriteLine("production_data table created");

            database_close();
        }

        public void create_table_operations()
        {
            // Define your CREATE TABLE SQL query
            string createTableOperation = @"
                CREATE TABLE IF NOT EXISTS operations (
                operation_id INT,
                operation_name VARCHAR(255),
                operation_description VARCHAR(255),
                PRIMARY KEY (operation_id)
                );";
            connection();

            MySqlCommand cmd = new MySqlCommand(createTableOperation, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("operations table created");

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
            Console.WriteLine("Data inserted into order_data table");

            database_close();
        }

        public void insert_data_order(int order_number, string order_state, int amount, string container_type, string company,
                    string medicine_type, List<Operation> operation_list, DateTime? startTime = null, DateTime? endTime = null)
        {
            string insertDataProduction = @"
            INSERT INTO order_data (
                order_number, order_state, amount, start_time, end_time, container_type, company,
                medicine_type, operation_list
            )
            VALUES (
                @orderNumber, @orderState, @amount, @startTime, @endTime, @containerType, @company,
                @medicineType, @operationList
            );"
            ;

            connection();

            MySqlCommand cmd = new MySqlCommand(insertDataProduction, mysql);
            var operationIds = operation_list.Select(operation => operation.OperationID).ToList();
            string jsonArray = JsonConvert.SerializeObject(operationIds);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
            cmd.Parameters.AddWithValue("orderState", order_state);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.Parameters.AddWithValue("containerType", container_type);
            cmd.Parameters.AddWithValue("company", company);
            cmd.Parameters.AddWithValue("medicineType", medicine_type);
            cmd.Parameters.AddWithValue("operationList", jsonArray);
            cmd.Parameters.AddWithValue("startTime", startTime);
            cmd.Parameters.AddWithValue("endTime", endTime);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into production_data table");
            database_close();
        }

        public void insert_data_operations(int operation_id, string operation_name, string operaton_description) { 
            string insertDataOperations = @"
            INSERT INTO operations (
                operation_id, operation_name, operation_description
            )
            VALUES (
                @operationId, @operationName, @operationDescription
            );"
            ;

            connection();

            MySqlCommand cmd = new MySqlCommand(insertDataOperations, mysql);

            cmd.Parameters.AddWithValue("operationId", operation_id);
            cmd.Parameters.AddWithValue("operationName", operation_name);
            cmd.Parameters.AddWithValue("operationDescription", operaton_description);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into operations table");
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
                string jsonArray = reader.GetString("operation_list");
                List<int> operationIds = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                List<Operation> operationList = operationIds.Select(id => MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == id)).ToList();

                Order order = new Order(containerAmount, containerType, company, orderNumber, OrderState.QUEUE, medicineType, operationList);
                MainWindowForm.mesSystem.Orders.AddLast(order);
            }

            Console.WriteLine("Production queue loaded from database");

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
                string jsonArray = reader.GetString("operation_list");
                List<int> operationIds = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                List<Operation> operationList = operationIds.Select(id => MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == id)).ToList();

                Order order = new Order(containerAmount, containerType, company, orderNumber, OrderState.PEND, medicineType, operationList);
                MainWindowForm.mesSystem.PlannedOrders.AddLast(order);
            }

            Console.WriteLine("Planned orders loaded from database");

            database_close();
        }

        public List<Order> get_finished_orders(DateTime? startDate = null, DateTime? endDate = null)
        {
            connection();
            List<Order> finishedOrders = new List<Order>();
            string sqlCommand = "SELECT * FROM production.order_data WHERE order_state = 'DONE'";

            if(startDate.HasValue && endDate.HasValue)
            {
                sqlCommand += " AND start_time BETWEEN '" + startDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + endDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderNumber = reader.GetInt32("order_number");
                int containerAmount = reader.GetInt32("amount");
                string containerType = reader.GetString("container_type");
                string company = reader.GetString("company");
                string medicineType = reader.GetString("medicine_type");
                string jsonArray = reader.GetString("operation_list");
                List<int> operationIds = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                List<Operation> operationList = operationIds.Select(id => MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == id)).ToList();

                Order order = new Order(containerAmount, containerType, company, orderNumber, OrderState.DONE, medicineType, operationList);
                order.OrderStartTime = reader.GetDateTime("start_time");
                order.OrderEndTime = reader.GetDateTime("end_time");
                MainWindowForm.mesSystem.FinishedOrders.AddLast(order);
                finishedOrders.Add(order);
            }

            Console.WriteLine("Finished orders loaded from database");

            database_close();
            return finishedOrders;
        }

        public void get_operations()
        {
            connection();
            string sqlCommand = "SELECT * FROM production.operations";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int operationID = reader.GetInt32("operation_id");
                string operationName = reader.GetString("operation_name");
                string operationDescription = reader.GetString("operation_description");

                Operation operation = new Operation(operationID, operationName, operationDescription);
                MainWindowForm.operations.Add(operation);
            }

            Console.WriteLine("Operations loaded from database");

            database_close();
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
            string get_amount = "SELECT amount FROM production.order_data WHERE order_number = @latest_Order_number;";


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

            string get_amount = "SELECT amount_in_carrier FROM production.production_data WHERE order_number = @latest_Order_number;";
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
            string delete_order = "DELETE FROM production.order_data WHERE order_number = @input_order_delete;";
            MySqlCommand cmd = new MySqlCommand(delete_order, mysql);
            cmd.Parameters.AddWithValue("@input_order_delete", input_order_delete);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Order deleted from database");

            database_close();
        }

        public void update_order_data(LinkedList<Order> orders)
        {
            connection();
            string deleteData = "DELETE FROM production.order_data where order_state != 'DONE';";
            MySqlCommand cmd = new MySqlCommand(deleteData, mysql);
            cmd.ExecuteNonQuery();

            create_table_order();
            foreach(var order in orders)
            {
                insert_data_order(order.OrderNumber, order.OrderState.ToString(), order.ContainerAmount, order.ContainerType, order.OrderCustomer, order.MedicineType, order.OperationList);
            }

            Console.WriteLine("Order data updated in database");

            database_close();
        }
        
        public void update_operations_data(BindingList<Operation> operations)
        {
            connection();
            string deleteData = "DELETE FROM production.operations;";
            MySqlCommand cmd = new MySqlCommand(deleteData, mysql);
            cmd.ExecuteNonQuery();

            create_table_operations();
            foreach(var operation in operations)
            {
                insert_data_operations(operation.OperationID, operation.OperationName, operation.OperationDescription);
            }

            Console.WriteLine("Operations data updated in database");

            database_close();
        }

        public void remove_operation_from_orders(int operationID)
        {
            connection();
            string sqlCommand = "SELECT order_number, operation_list FROM production.order_data";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);
            cmd.ExecuteNonQuery();

            var updatedList = new List<(int order_number, string jsonArray)>();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int order_number = reader.GetInt32("order_number");
                string jsonArray = reader.GetString("operation_list");

                var operationList = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                operationList.RemoveAll(id => id == operationID);

                string updatedJsonArray = JsonConvert.SerializeObject(operationList);

                updatedList.Add((order_number, updatedJsonArray));
            }

            Console.WriteLine(updatedList);

            reader.Close();

            foreach(var (order_number, updatedJsonArray) in updatedList)
            {
                string updateQuery = "UPDATE production.order_data SET operation_list = @updatedJsonArray WHERE order_number = @order_number";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, mysql);
                updateCmd.Parameters.AddWithValue("updatedJsonArray", updatedJsonArray);
                updateCmd.Parameters.AddWithValue("order_number", order_number);
                updateCmd.ExecuteNonQuery();
            }

            foreach(var order in MainWindowForm.mesSystem.Orders)
            {
                order.OperationList.RemoveAll(operation => operation.OperationID == operationID);
            }

            foreach(var order in MainWindowForm.mesSystem.PlannedOrders)
            {
                order.OperationList.RemoveAll(operation => operation.OperationID == operationID);
            }

            Console.WriteLine("Operation {0} removed from all orders", operationID);
            database_close();
        }

        public void database_close()
        {
            if (mysql.State == ConnectionState.Open)
                mysql.Close();
            Console.WriteLine("Database server closed");
        }
    }
}
