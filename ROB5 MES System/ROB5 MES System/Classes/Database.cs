using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ROB5_MES_System.Classes
{
    public class Database
    {
        private string _dbHost;
        private string _dbUser;
        private string _dbPassword;
        private string _dbName;
        private MySqlConnection mysql;

        public Database(string dbHost, string dbUser, string dbPassword, string dbName)
        {
            _dbHost = dbHost;
            _dbUser = dbUser;
            _dbPassword = dbPassword;
            _dbName = dbName;
            DatabaseConnection();
        }

        /// <summary>
        /// Function to open connection to MySQL database
        /// </summary>
        private void DatabaseConnection()
        {
            string myConnectionString = "server=" + _dbHost + ";uid=" + _dbUser + ";pwd=" + _dbPassword + ";database=" + _dbName;
            mysql = new MySqlConnection(myConnectionString);
            if (mysql.State != ConnectionState.Open)
            {
                mysql.Open();
                Console.WriteLine("MySQL Database server opened");
            }
        }

        /// <summary>
        /// Function to create the order data table in the database
        /// </summary>
        public void CreateTableOrderData()
        {
            // sql query for creating order data table
            string createTableOrder = @"
                    CREATE TABLE IF NOT EXISTS order_data (
                    order_number INT NOT NULL,
                    order_state VARCHAR(255),
                    start_time DATETIME,
                    end_time DATETIME,
                    container_amount INT,
                    container_type VARCHAR(255),
                    company VARCHAR(255),
                    medicine_type VARCHAR(255),
                    operation_list JSON,
                    PRIMARY KEY (order_number)
                );
            ";

            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(createTableOrder, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("order_data table created");

            DatabaseClose();
        }

        /// <summary>
        /// Function to create the production data table in the database
        /// </summary>
        public void CreateTableProductionData()
        {
            // sql query for creating production data table
            string createTableProduction = @"
                CREATE TABLE IF NOT EXISTS production_data (
                order_number INT,
                product_id INT,
                product_state VARCHAR(255),
                container_type VARCHAR(255),
                container_amount INT,
                start_time_product DATETIME,
                end_time_product DATETIME
                );
            ";
            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(createTableProduction, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("production_data table created");

            DatabaseClose();
        }

        /// <summary>
        /// Function to create the process data table in the database
        /// </summary>
        public void CreateTableProcessData()
        {
            // sql query for creating process data table
            string createTableProcess = @"
                CREATE TABLE IF NOT EXISTS process_data (
                order_number INT,
                product_id INT,
                process_id INT,
                process_state VARCHAR(255),
                process_start_time DATETIME,  
                process_end_time DATETIME
                );
            ";

            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(createTableProcess, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("process_data table created");

            DatabaseClose();
        }

        public void CreateTableOperations()
        {
            // sql query for creating operations table
            string createTableOperation = @"
                CREATE TABLE IF NOT EXISTS operations (
                operation_id INT,
                operation_name VARCHAR(255),
                operation_description VARCHAR(255),
                PRIMARY KEY (operation_id)
                );
            ";

            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(createTableOperation, mysql);
            cmd.ExecuteNonQuery();
            Console.WriteLine("operations table created");

            DatabaseClose();
        }

        /// <summary>
        /// Function to insert data into the order data table
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="orderState"></param>
        /// <param name="containerAmount"></param>
        /// <param name="containerType"></param>
        /// <param name="company"></param>
        /// <param name="medicineType"></param>
        /// <param name="operationList"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public void InsertDataOrder(int orderNumber, string orderState, int containerAmount, string containerType, string company,
                    string medicineType, List<Operation> operationList, DateTime? startTime = null, DateTime? endTime = null)
        {
            // sql query for inserting data into order data table
            string insertDataOrder = @"
            INSERT INTO order_data (
                order_number, order_state, start_time, end_time, container_amount, container_type, company,
                medicine_type, operation_list
            )
            VALUES (
                @orderNumber, @orderState, @startTime, @endTime, @containerAmount, @containerType, @company,
                @medicineType, @operationList
            );"
            ;

            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(insertDataOrder, mysql);

            // Convert list of operations to JSON array to store in database
            var operationIds = operationList.Select(operation => operation.OperationID).ToList();
            string jsonArray = JsonConvert.SerializeObject(operationIds);

            cmd.Parameters.AddWithValue("orderNumber", orderNumber);
            cmd.Parameters.AddWithValue("orderState", orderState);
            cmd.Parameters.AddWithValue("startTime", startTime);
            cmd.Parameters.AddWithValue("endTime", endTime);
            cmd.Parameters.AddWithValue("containerAmount", containerAmount);
            cmd.Parameters.AddWithValue("containerType", containerType);
            cmd.Parameters.AddWithValue("company", company);
            cmd.Parameters.AddWithValue("medicineType", medicineType);
            cmd.Parameters.AddWithValue("operationList", jsonArray);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into order_data table");
            DatabaseClose();
        }

        /// <summary>
        /// Function to insert data into the production data table
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="productID"></param>
        /// <param name="productState"></param>
        /// <param name="containerType"></param>
        /// <param name="containerAmount"></param>
        /// <param name="productStartTime"></param>
        /// <param name="productEndTime"></param>
        /// <param name="processList"></param>
        public void InsertDataProduction(int orderNumber, int productID, OrderState productState, string containerType, int containerAmount,
                    DateTime productStartTime, DateTime productEndTime, LinkedList<Process> processList)
        {
            // sql query for inserting data into production data table
            string insertData = @"
            INSERT INTO production_data (
                order_number, product_id, product_state, container_type, container_amount,
                start_time_product, end_time_product
            )
            VALUES (
                @orderNumber, @productId, @productState, @containerType, @containerAmount,
                @startTimeProduct, @endTimeProduct
            );";

            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(insertData, mysql);

            cmd.Parameters.AddWithValue("orderNumber", orderNumber);
            cmd.Parameters.AddWithValue("productId", productID);
            cmd.Parameters.AddWithValue("productState", productState.ToString());
            cmd.Parameters.AddWithValue("containerType", containerType);
            cmd.Parameters.AddWithValue("containerAmount", containerAmount);
            cmd.Parameters.AddWithValue("startTimeProduct", productStartTime);
            cmd.Parameters.AddWithValue("endTimeProduct", productEndTime);

            // insert each process in the process list into the process_data table
            foreach (var process in processList)
            {
                InsertDataProcess(orderNumber, productID, process.ProcessID, process.ProcessState.ToString(), process.ProcessStartTime, process.ProcessEndTime);
            }

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into production_data table");

            DatabaseClose();
        }

        /// <summary>
        /// Function to insert data into the process data table
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="productID"></param>
        /// <param name="processID"></param>
        /// <param name="processState"></param>
        /// <param name="processStartTime"></param>
        /// <param name="processEndTime"></param>
        public void InsertDataProcess(int orderNumber, int productID, int processID, string processState, DateTime processStartTime, DateTime processEndTime)
        {
            // sql query for inserting data into process data table
            string insertDataProcesses = @"
            INSERT INTO process_data (
                order_number, product_id, process_id, process_state, process_start_time, process_end_time
            )
            VALUES (
                @orderNumber, @productID, @processID, @processState, @processStartTime, @processEndTime
            );"
            ;

            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(insertDataProcesses, mysql);

            cmd.Parameters.AddWithValue("orderNumber", orderNumber);
            cmd.Parameters.AddWithValue("productID", productID);
            cmd.Parameters.AddWithValue("processID", processID);
            cmd.Parameters.AddWithValue("processState", processState);
            cmd.Parameters.AddWithValue("processStartTime", processStartTime);
            cmd.Parameters.AddWithValue("processEndTime", processEndTime);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into process_data table");
            DatabaseClose();
        }

        /// <summary>
        /// Function to insert data into the operations table
        /// </summary>
        /// <param name="operationID"></param>
        /// <param name="operationName"></param>
        /// <param name="operationDescription"></param>
        public void InsertDateOperations(int operationID, string operationName, string operationDescription)
        {
            // sql query for inserting data into operations table
            string insertDataOperations = @"
            INSERT INTO operations (
                operation_id, operation_name, operation_description
            )
            VALUES (
                @operationId, @operationName, @operationDescription
            );"
            ;

            DatabaseConnection();

            MySqlCommand cmd = new MySqlCommand(insertDataOperations, mysql);

            cmd.Parameters.AddWithValue("operationId", operationID);
            cmd.Parameters.AddWithValue("operationName", operationName);
            cmd.Parameters.AddWithValue("operationDescription", operationDescription);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted into operations table");
            DatabaseClose();
        }

        /// <summary>
        /// Function to get maximum order number from the database
        /// </summary>
        /// <returns></returns>
        public int GetMaxOrderNumber()
        {
            int maxOrderNumber = 0;

            if (OrderDataNotEmpty())
            {
                DatabaseConnection();
                string sqlCommand = "SELECT MAX(order_number) as max_order_number from production.order_data";

                MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    maxOrderNumber = reader.GetInt32("max_order_number");
                }

                reader.Close();
                DatabaseClose();
            }

            return maxOrderNumber + 1;
        }

        /// <summary>
        /// Function to get orders for the production queue from the database
        /// </summary>
        public void GetProductionQueueData()
        {
            DatabaseConnection();
            // sql query to get orders from the database
            string sqlCommand = "SELECT * FROM production.order_data WHERE order_state = 'QUEUE' OR order_state = 'BUSY'";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // get order data from the database
                int orderNumber = reader.GetInt32("order_number");
                int containerAmount = reader.GetInt32("container_amount");
                string containerType = reader.GetString("container_type");
                string company = reader.GetString("company");
                string medicineType = reader.GetString("medicine_type");
                string jsonArray = reader.GetString("operation_list");
                OrderState orderState = Enum.Parse<OrderState>(reader.GetString("order_state"));

                // convert JSON array to list of operations
                List<int> operationIds = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                List<Operation> operationList = operationIds.Select(id => MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == id)).ToList();

                Order order = new Order(containerAmount, containerType, company, orderNumber, orderState, medicineType, operationList);

                // if the order was in production, add the production data to the order
                if (orderState == OrderState.BUSY)
                {
                    order = AddProductionDataToOrder(order);
                    order.OrderStartTime = reader.GetDateTime("start_time");
                    // adds the order to the front of the queue since it was in the middle of production
                    MainWindowForm.mesSystem.OrderQueue.AddFirst(order);
                }
                else
                {
                    MainWindowForm.mesSystem.OrderQueue.AddLast(order);
                }
            }

            Console.WriteLine("Production queue loaded from database");

            DatabaseClose();
        }

        /// <summary>
        /// Function to get planned orders from the database
        /// </summary>
        public void GetPlannedOrdersData()
        {
            DatabaseConnection();
            // sql query to get planned orders from the database
            string sqlCommand = "SELECT * FROM production.order_data WHERE order_state = 'PEND'";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderNumber = reader.GetInt32("order_number");
                int containerAmount = reader.GetInt32("container_amount");
                string containerType = reader.GetString("container_type");
                string company = reader.GetString("company");
                string medicineType = reader.GetString("medicine_type");
                string jsonArray = reader.GetString("operation_list");
                // convert JSON array to list of operations
                List<int> operationIds = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                List<Operation> operationList = operationIds.Select(id => MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == id)).ToList();

                Order order = new Order(containerAmount, containerType, company, orderNumber, OrderState.PEND, medicineType, operationList);
                MainWindowForm.mesSystem.PlannedOrders.AddLast(order);
            }

            Console.WriteLine("Planned orders loaded from database");

            DatabaseClose();
        }

        /// <summary>
        /// Function to get finished orders from the database
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void GetFinishedOrdersData(DateTime? startDate = null, DateTime? endDate = null)
        {
            DatabaseConnection();

            MainWindowForm.mesSystem.FinishedOrders.Clear();

            // sql query to get finished orders from the database
            // doing it as a JOIN command as the finished orders need to get data from all order_data, production_data, and process_data
            string baseQueryCommand = @"
                SELECT
                    o.order_number,
                    o.container_amount,
                    o.container_type,
                    o.company,
                    o.medicine_type,
                    o.operation_list,
                    o.start_time as order_start_time,
                    o.end_time as order_end_time,
                    c.product_id,
                    c.product_state,
                    c.container_type as product_container_type,
                    c.container_amount as product_container_amount,
                    c.start_time_product,
                    c.end_time_product,
                    t.process_id,
                    t.process_state,
                    t.process_start_time,
                    t.process_end_time
                FROM
                    production.order_data o
                LEFT JOIN
                    production.production_data c ON o.order_number = c.order_number
                LEFT JOIN
                    production.process_data t ON c.order_number = t.order_number AND c.product_id = t.product_id
                WHERE
                    o.order_state = 'DONE'
            ";

            // if a start date and end date is provided, add it to the query
            if (startDate.HasValue && endDate.HasValue)
            {
                baseQueryCommand += " AND o.start_time BETWEEN '" + startDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + endDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            using (MySqlCommand cmd = new MySqlCommand(baseQueryCommand, mysql))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // creating an order map to not add an order multiple times (though there shouldn't be multiples in the database anyways)
                    Dictionary<int, Order> orderMap = new Dictionary<int, Order>();

                    while (reader.Read())
                    {
                        int orderNumber = reader.GetInt32("order_number");

                        if (!orderMap.TryGetValue(orderNumber, out Order order))
                        {
                            order = new Order(
                                reader.GetInt32("container_amount"),
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
                                ProductsInProductionList = new LinkedList<Product>(),
                            };
                            order.ProductsInOrderList.Clear();

                            MainWindowForm.mesSystem.FinishedOrders.AddLast(order);
                            orderMap[orderNumber] = order;
                        }

                        // checking that there are products associated to the order, and adding them
                        if (!reader.IsDBNull(reader.GetOrdinal("product_id")))
                        {
                            // checking that there are processs associated to the product, and adding them
                            Process process = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("process_id")))
                            {
                                process = new Process(
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("process_id")).OperationName,
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("process_id")).OperationDescription,
                                    reader.GetInt32("process_id"),
                                    Enum.Parse<OrderState>(reader.GetString("process_state")),
                                    reader.GetDateTime("process_start_time"),
                                    reader.GetDateTime("process_end_time")
                                );

                            }

                            int productID = reader.GetInt32("product_id");
                            if (order.ProductsInProductionList.Any(product => product.ProductID == productID))
                            {
                                order.ProductsInProductionList.First.Value.ProductCompletedProcesses.AddFirst(process);
                                continue;
                            }
                            Product product = new Product(
                                productID,
                                reader.GetInt32("product_container_amount"),
                                reader.GetString("product_container_type"),
                                orderNumber,
                                Enum.Parse<OrderState>(reader.GetString("product_state")),
                                reader.GetDateTime("start_time_product"),
                                reader.GetDateTime("end_time_product")
                            );

                            product.ProductCompletedProcesses.AddFirst(process);

                            order.ProductsInProductionList.AddFirst(product);
                        }
                    }
                }
            }

            Console.WriteLine("Finished orders loaded from database");
            DatabaseClose();
        }

        /// <summary>
        /// Function to get operations data from the database
        /// </summary>
        public void GetOperationsData()
        {
            DatabaseConnection();
            // sql query to get operations from the database
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

            DatabaseClose();
        }

        /// <summary>
        /// Function to check if the order_data table is not empty
        /// </summary>
        /// <returns></returns>
        public bool OrderDataNotEmpty()
        {
            DatabaseConnection();
            string checkIfEmpty = "SELECT 1 FROM production.order_data LIMIT 1;";

            MySqlCommand checkCmd = new MySqlCommand(checkIfEmpty, mysql);

            bool isEmpty = true;

            if (checkCmd.ExecuteScalar() == null)
            {
                isEmpty = false;
            }

            DatabaseClose();
            return isEmpty;
        }

        /// <summary>
        /// Function to add production data to an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order AddProductionDataToOrder(Order order)
        {
            int orderNumber = order.OrderNumber;
            int totalContainerAmount = order.ContainerAmount;
            int containersProduced = 0;

            DatabaseConnection();

            // sql query to get production data from the database
            // using a JOIN query to get data from both production_data and process_data
            string baseQueryCommand = @"
                SELECT
                    c.product_id,
                    c.product_state,
                    c.container_type as product_container_type,
                    c.container_amount as product_container_amount,
                    c.start_time_product,
                    c.end_time_product,
                    t.process_id,
                    t.process_state,
                    t.process_start_time,
                    t.process_end_time 
                FROM
                    production.production_data c
                LEFT JOIN
                    production.process_data t ON c.order_number = t.order_number AND c.product_id = t.product_id
                WHERE
                    c.order_number = @orderNumber
            ";

            using (MySqlCommand cmd = new MySqlCommand(baseQueryCommand, mysql))
            {
                cmd.Parameters.AddWithValue("@orderNumber", orderNumber);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // checking that there are products associated to the order, and adding them
                        if (!reader.IsDBNull(reader.GetOrdinal("product_id")))
                        {
                            // checking that there are processs associated to the product, and adding them
                            Process process = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("process_id")))
                            {
                                process = new Process(
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("process_id")).OperationName,
                                    MainWindowForm.operations.FirstOrDefault(item => item.OperationID == reader.GetInt32("process_id")).OperationDescription,
                                    reader.GetInt32("process_id"),
                                    Enum.Parse<OrderState>(reader.GetString("process_state")),
                                    reader.GetDateTime("process_start_time"),
                                    reader.GetDateTime("process_end_time")
                                );
                            }

                            int productID = reader.GetInt32("product_id");
                            if (order.ProductsInProductionList.Any(product => product.ProductID == productID))
                            {
                                order.ProductsInProductionList.First.Value.ProductCompletedProcesses.AddFirst(process);
                                continue;
                            }

                            Product product = new Product(
                                productID,
                                reader.GetInt32("product_container_amount"),
                                reader.GetString("product_container_type"),
                                orderNumber,
                                Enum.Parse<OrderState>(reader.GetString("product_state")),
                                reader.GetDateTime("start_time_product"),
                                reader.GetDateTime("end_time_product")
                            );

                            // adding the containers from the product to the total amount produced
                            containersProduced += reader.GetInt32("product_container_amount");
                            order.ProductsInProductionList.AddFirst(product);
                            product.ProductCompletedProcesses.AddFirst(process);
                        }
                    }
                }
            }

            // if the order is not fully produced, add the remaining products to the order
            // first clearing the products in the order to avoid duplicates
            order.ProductsInOrderList.Clear();
            int remainingContainers = totalContainerAmount - containersProduced;
            if (remainingContainers > 0)
            {
                // adding the remaining products to the order
                order.GenerateProducts(remainingContainers);

                // adding operations to these products
                foreach (var operation in order.OperationList)
                {
                    order.AddProcessToAllProducts(operation.OperationName, operation.OperationDescription, operation.OperationID);
                }
            }

            DatabaseClose();

            return order;
        }

        /// <summary>
        /// Function to delete an order from the database
        /// </summary>
        /// <param name="orderID"></param>
        public void DeleteOrder(int orderID)
        {
            DatabaseConnection();
            string deleteOrderQuery = "DELETE FROM production.order_data WHERE order_number = @input_order_delete;";
            MySqlCommand cmd = new MySqlCommand(deleteOrderQuery, mysql);
            cmd.Parameters.AddWithValue("@input_order_delete", orderID);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Order deleted from database");

            DatabaseClose();
        }

        /// <summary>
        /// Update the order data in the database
        /// </summary>
        /// <param name="orders"></param>
        public void UpdateOrderData(LinkedList<Order> orders)
        {
            DatabaseConnection();
            // delete all order data that is not in the DONE state
            string deleteDataQuery = "DELETE FROM production.order_data where order_state != 'DONE';";
            MySqlCommand cmd = new MySqlCommand(deleteDataQuery, mysql);
            cmd.ExecuteNonQuery();

            // create the order data table and insert the new order data
            CreateTableOrderData();
            foreach (var order in orders)
            {
                InsertDataOrder(order.OrderNumber, order.OrderState.ToString(), order.ContainerAmount, order.ContainerType, order.OrderCustomer, order.MedicineType, order.OperationList, order.OrderStartTime, order.OrderEndTime);
            }

            Console.WriteLine("Order data updated in database");

            DatabaseClose();
        }

        /// <summary>
        /// Update the operations data in the database
        /// </summary>
        /// <param name="operations"></param>
        public void UpdateOperationsData(BindingList<Operation> operations)
        {
            DatabaseConnection();
            string deleteDataQuery = "DELETE FROM production.operations;";
            MySqlCommand cmd = new MySqlCommand(deleteDataQuery, mysql);
            cmd.ExecuteNonQuery();

            // create the operations table and insert the new operations data
            CreateTableOperations();
            foreach (var operation in operations)
            {
                InsertDateOperations(operation.OperationID, operation.OperationName, operation.OperationDescription);
            }

            Console.WriteLine("Operations data updated in database");

            DatabaseClose();
        }

        /// <summary>
        /// Function to remove an operation from all orders in the database that contain it
        /// </summary>
        /// <param name="operationID"></param>
        public void RemoveOperationFromOrders(int operationID)
        {
            DatabaseConnection();
            // get all orders from the database
            string sqlCommand = "SELECT order_number, operation_list FROM production.order_data";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mysql);
            cmd.ExecuteNonQuery();

            var updatedList = new List<(int order_number, string jsonArray)>();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int orderNumber = reader.GetInt32("order_number");
                string jsonArray = reader.GetString("operation_list");

                // convert JSON array to list of operations
                // and removing the operation from the list
                var operationList = JsonConvert.DeserializeObject<List<int>>(jsonArray);
                operationList.RemoveAll(id => id == operationID);

                // convert the list back to JSON array
                string updatedJsonArray = JsonConvert.SerializeObject(operationList);

                updatedList.Add((orderNumber, updatedJsonArray));
            }

            reader.Close();

            // update the orders in the database with the updated operations list
            foreach (var (order_number, updatedJsonArray) in updatedList)
            {
                string updateQuery = "UPDATE production.order_data SET operation_list = @updatedJsonArray WHERE order_number = @order_number";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, mysql);
                updateCmd.Parameters.AddWithValue("updatedJsonArray", updatedJsonArray);
                updateCmd.Parameters.AddWithValue("order_number", order_number);
                updateCmd.ExecuteNonQuery();
            }

            // remove the operation from the orders in the production queue and planned orders
            foreach (var order in MainWindowForm.mesSystem.OrderQueue)
            {
                order.OperationList.RemoveAll(operation => operation.OperationID == operationID);
            }

            foreach (var order in MainWindowForm.mesSystem.PlannedOrders)
            {
                order.OperationList.RemoveAll(operation => operation.OperationID == operationID);
            }

            Console.WriteLine("Operation {0} removed from all orders", operationID);
            DatabaseClose();
        }

        /// <summary>
        /// Function to close the connection to the MySQL database
        /// </summary>
        public void DatabaseClose()
        {
            if (mysql.State == ConnectionState.Open)
                mysql.Close();
            Console.WriteLine("Database server closed");
        }
    }
}
