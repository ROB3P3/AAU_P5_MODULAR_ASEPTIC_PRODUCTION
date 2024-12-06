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
                carrier_state VARCHAR(255),
                type_container VARCHAR(255),
                amount_in_carrier INT,
                start_time_carrier DATETIME,
                end_time_carrier DATETIME
                );
            "
            ;
            connection();

            MySqlCommand cmd = new MySqlCommand(createTableProduction, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("production_data table created");

            database_close();
        }

        public void create_table_tasks()
        {
            // Define your CREATE TABLE SQL query
            string createTableTask = @"
                CREATE TABLE IF NOT EXISTS task_data (
                order_number INT,
                carrier_id INT,
                task_id INT,
                task_state VARCHAR(255),
                task_start_time DATETIME,  
                task_end_time DATETIME
                );";
            connection();

            MySqlCommand cmd = new MySqlCommand(createTableTask, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("task table created");

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

        public void insert_data_production(int order_number, int carrier_id, OrderState carrier_state, string type_container, int amount_in_carrier,
                    DateTime start_time_carrier, DateTime end_time_carrier, LinkedList<Task> task_list)
        {
            string insertData = @"
            INSERT INTO production_data (
                order_number, carrier_id, carrier_state, type_container, amount_in_carrier,
                start_time_carrier, end_time_carrier
            )
            VALUES (
                @orderNumber, @carrierId, @carrierState, @typeContainer, @amountInCarrier,
                @startTimeCarrier, @endTimeCarrier
            );";

            connection();

            MySqlCommand cmd = new MySqlCommand(insertData, mysql);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
            cmd.Parameters.AddWithValue("carrierId", carrier_id);
            cmd.Parameters.AddWithValue("carrierState", carrier_state.ToString());
            cmd.Parameters.AddWithValue("typeContainer", type_container);
            cmd.Parameters.AddWithValue("amountInCarrier", amount_in_carrier);
            cmd.Parameters.AddWithValue("startTimeCarrier", start_time_carrier);
            cmd.Parameters.AddWithValue("endTimeCarrier", end_time_carrier);

            foreach(var task in task_list)
            {
                insert_data_tasks(order_number, carrier_id, task.TaskId, task.Status, task.StartTime, task.EndTime);
            }

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into production_data table");

            database_close();
        }

        public void insert_data_order(int order_number, string order_state, int amount, string container_type, string company,
                    string medicine_type, List<Operation> operation_list, DateTime? startTime = null, DateTime? endTime = null)
        {
            string insertDataOrder = @"
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

            MySqlCommand cmd = new MySqlCommand(insertDataOrder, mysql);
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
            Console.WriteLine("Data inserted into order_data table");
            database_close();
        }

        public void insert_data_tasks(int order_number, int carrier_id, int task_id, string task_state, DateTime task_start_time, DateTime task_end_time)
        {
            string insertDataTasks = @"
            INSERT INTO task_data (
                order_number, carrier_id, task_id, task_state, task_start_time, task_end_time
            )
            VALUES (
                @orderNumber, @carrierID, @taskID, @taskState, @taskStartTime, @taskEndTime
            );"
            ;

            connection();

            MySqlCommand cmd = new MySqlCommand(insertDataTasks, mysql);

            cmd.Parameters.AddWithValue("orderNumber", order_number);
            cmd.Parameters.AddWithValue("carrierID", carrier_id);
            cmd.Parameters.AddWithValue("taskID", task_id);
            cmd.Parameters.AddWithValue("taskState", task_state);
            cmd.Parameters.AddWithValue("taskStartTime", task_start_time);
            cmd.Parameters.AddWithValue("taskEndTime", task_end_time);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into task_data table");
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
            string sqlCommand = "SELECT * FROM production.order_data WHERE order_state = 'QUEUE' OR order_state = 'BUSY'";
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
                OrderState orderState = Enum.Parse<OrderState>(reader.GetString("order_state"));
                List<int> operationIds = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                List<Operation> operationList = operationIds.Select(id => MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == id)).ToList();

                Order order = new Order(containerAmount, containerType, company, orderNumber, orderState, medicineType, operationList);
                if(orderState == OrderState.BUSY)
                {
                    order = insert_production_data_to_order(order);
                    order.OrderStartTime = reader.GetDateTime("start_time");
                    MainWindowForm.mesSystem.Orders.AddFirst(order);
                }
                else
                {
                    MainWindowForm.mesSystem.Orders.AddLast(order);
                }
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

            MainWindowForm.mesSystem.FinishedOrders.Clear();

            string baseQueryCommand = @"
                SELECT
                    o.order_number,
                    o.amount AS order_amount,
                    o.container_type,
                    o.company,
                    o.medicine_type,
                    o.operation_list,
                    o.start_time as order_start_time,
                    o.end_time as order_end_time,
                    c.carrier_id,
                    c.carrier_state,
                    c.type_container as carrier_container_type,
                    c.amount_in_carrier as carrier_container_amount,
                    c.start_time_carrier,
                    c.end_time_carrier,
                    t.task_id,
                    t.task_state,
                    t.task_start_time,
                    t.task_end_time
                FROM
                    production.order_data o
                LEFT JOIN
                    production.production_data c ON o.order_number = c.order_number
                LEFT JOIN
                    production.task_data t ON c.order_number = t.order_number AND c.carrier_id = t.carrier_id
                WHERE
                    o.order_state = 'DONE'
            ";

            if(startDate.HasValue && endDate.HasValue)
            {
                baseQueryCommand += " AND o.start_time BETWEEN '" + startDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + endDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            List<Order> finishedOrders = new List<Order>();

            using(MySqlCommand cmd = new MySqlCommand(baseQueryCommand, mysql))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    Dictionary<int, Order> orderMap = new Dictionary<int, Order>();

                    while (reader.Read())
                    {
                        int orderNumber = reader.GetInt32("order_number");

                        if(!orderMap.TryGetValue(orderNumber, out Order order))
                        {
                            order = new Order(
                                reader.GetInt32("order_amount"),
                                reader.GetString("container_type"),
                                reader.GetString("company"),
                                orderNumber,
                                OrderState.DONE,
                                reader.GetString("medicine_type"),
                                JsonConvert.DeserializeObject<List<int>>(reader.GetString("operation_list"))
                                    .Select(id => MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == id))
                                    .ToList()
                            )
                            {
                                OrderStartTime = reader.GetDateTime("order_start_time"),
                                OrderEndTime = reader.GetDateTime("order_end_time"),
                                CarriersInProductionList = new LinkedList<Carrier>(),
                            };
                            order.CarriersInOrder.Clear();

                            finishedOrders.Add(order);
                            MainWindowForm.mesSystem.FinishedOrders.AddLast(order);
                            orderMap[orderNumber] = order;
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("carrier_id"))) {
                            int carrierID = reader.GetInt32("carrier_id");
                            Carrier carrier = new Carrier(
                                carrierID,
                                reader.GetInt32("carrier_container_amount"),
                                reader.GetString("carrier_container_type"),
                                orderNumber,
                                Enum.Parse<OrderState>(reader.GetString("carrier_state")),
                                reader.GetDateTime("start_time_carrier"),
                                reader.GetDateTime("end_time_carrier")
                            );

                            order.CarriersInProductionList.AddLast(carrier);

                            if (!reader.IsDBNull(reader.GetOrdinal("task_id")))
                            {
                                Task task = new Task(
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("task_id")).OperationName,
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("task_id")).OperationDescription,
                                    reader.GetInt32("task_id"),
                                    reader.GetString("task_state"),
                                    reader.GetDateTime("task_start_time"),
                                    reader.GetDateTime("task_end_time")
                                );

                                carrier.CompletedTasks.AddLast(task);
                            }
                        }
                    }
                }
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

        public Order insert_production_data_to_order(Order order)
        {
            int orderNumber = order.OrderNumber;
            int totalContainerAmount = order.ContainerAmount;
            int containersProduced = 0;

            connection();

            string baseQueryCommand = @"
                SELECT
                    c.carrier_id,
                    c.carrier_state,
                    c.type_container as carrier_container_type,
                    c.amount_in_carrier as carrier_container_amount,
                    c.start_time_carrier,
                    c.end_time_carrier,
                    t.task_id,
                    t.task_state,
                    t.task_start_time,
                    t.task_end_time 
                FROM
                    production.production_data c
                LEFT JOIN
                    production.task_data t ON c.order_number = t.order_number AND c.carrier_id = t.carrier_id
                WHERE
                    c.order_number = @orderNumber
            ";

            using(MySqlCommand cmd = new MySqlCommand(baseQueryCommand, mysql)){
                cmd.Parameters.AddWithValue("@orderNumber", orderNumber);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("carrier_id")))
                        {
                            int carrierID = reader.GetInt32("carrier_id");
                            Carrier carrier = new Carrier(
                                carrierID,
                                reader.GetInt32("carrier_container_amount"),
                                reader.GetString("carrier_container_type"),
                                orderNumber,
                                Enum.Parse<OrderState>(reader.GetString("carrier_state")),
                                reader.GetDateTime("start_time_carrier"),
                                reader.GetDateTime("end_time_carrier")
                            );

                            containersProduced += reader.GetInt32("carrier_container_amount");
                            order.CarriersInProductionList.AddLast(carrier);

                            if (!reader.IsDBNull(reader.GetOrdinal("task_id")))
                            {
                                Task task = new Task(
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("task_id")).OperationName,
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("task_id")).OperationDescription,
                                    reader.GetInt32("task_id"),
                                    reader.GetString("task_state"),
                                    reader.GetDateTime("task_start_time"),
                                    reader.GetDateTime("task_end_time")
                                );

                                carrier.CompletedTasks.AddLast(task);
                            }
                        }
                    }
                }
            }

            order.CarriersInOrder.Clear();
            int remainingContainers = totalContainerAmount - containersProduced;
            if(remainingContainers > 0)
            {
                order.GenerateCarriers(order.ContainerType, remainingContainers);

                foreach(var operation in order.OperationList)
                {
                    order.AddTaskToCarriers(operation.OperationName, operation.OperationDescription, operation.OperationID);
                }
            }

            database_close();

            return order;
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
                insert_data_order(order.OrderNumber, order.OrderState.ToString(), order.ContainerAmount, order.ContainerType, order.OrderCustomer, order.MedicineType, order.OperationList, order.OrderStartTime, order.OrderEndTime);
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
