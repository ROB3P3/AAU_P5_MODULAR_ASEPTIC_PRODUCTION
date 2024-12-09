using ROB5_MES_System.Classes;
using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;

namespace ROB5_MES_System
{
    public class Order
    {
        private int _orderNumber; // order number 
        private DateTime? _orderStartTime; // order start time
        private DateTime? _orderEndTime; // order end time
        private string _orderCustomer; // order's customer
        private string _medicineType; // medicine type associated with the order
        private OrderState _orderState; // current state of the order

        private string _containerType; // container type associated with the order
        private int _containerAmount; // container amount in the order

        private LinkedList<Product> _productsInOrderList; // list of products in the order (not in production or finished)
        private LinkedList<Product> _productsInProductionList; // list of products in the order that are in production or finished

        private List<Operation> _operationList; // a process list associated with the order

        private Thread _productionThread; // seperate thread for handling production of the order
        /// <summary>
        /// Generate products to an order based on a number of containers
        /// </summary>
        /// <param name="containerAmount"></param>
        public void GenerateProducts(int containerAmount)
        {
            int fullProducts = containerAmount / 5; // there can be 5 containers in on a product
            int containerRemainder = containerAmount % 5; // remainder of containers that do not fit into a full product

            for (int i = 0; i < fullProducts; i++)
            {
                Product product = new Product(-1, 5, _containerType, _orderNumber); // here the products are generated with 5 containers each
                _productsInOrderList.AddLast(product);
            }

            if (containerRemainder != 0) // if there is a remainder of containers that do not fit in a full product
            {
                _productsInOrderList.AddLast(new Product(-1, containerRemainder, _containerType, _orderNumber)); // add a product with the remainder of containers
            }

            Console.WriteLine(string.Format("{0} full products added and 1 remainder product with {1} containers, making for {2} containers", fullProducts, containerRemainder, containerAmount));

        }

        /// <summary>
        /// Assign a process to the products in the order's product list
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="processDescription"></param>
        /// <param name="processId"></param>
        public void AddProcessToAllProducts(string processName, string processDescription, int processId)
        {
            foreach (var product in _productsInOrderList)
            {   
                Process process = new Process(processName, processDescription, processId, OrderState.QUEUE);
                product.AddProcessToEndOfProduct(process);
            }
        }

        /// <summary>
        /// Send order information to the database
        /// </summary>
        public void SendOrderInfoToDatabase()
        {
            MainWindowForm.database.InsertDataOrder(_orderNumber, _orderState.ToString(), _containerAmount, _containerType, _orderCustomer, _medicineType, _operationList, _orderStartTime, _orderEndTime);
        }

        /// <summary>
        /// Start the production of the order
        /// This starts a new thread for the ProdutionHandler, if no thread for it exists already
        /// </summary>
        public void StartOrderProduction()
        {
            // create new thread for productionhandler if no thread for it exists
            if (_productionThread == null || !_productionThread.IsAlive)
            {
                _productionThread = new Thread(ProductionHandler);
                _productionThread.Start();
            }
        }

        private void ProductionHandler()
        {
            MainWindowForm.isProductionRunning = true;

            // send start transport belt command
            string _command = "begin";
            OpcuaHandler(_command);
        }

        private void OpcuaHandler(string serverCommand)
        {
            MainWindowForm.opcuaPLC09.ModifyNodeValue("ServerCommand", serverCommand);
            MainWindowForm.opcuaPLC08.ModifyNodeValue("ServerCommand", serverCommand);
        }

        public int OrderNumber
        {
            get { return _orderNumber; }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("Order number cannot be less than 0");
                _orderNumber = value;
            }
        }

        public DateTime? OrderStartTime
        {
            get { return _orderStartTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentException("Order date is null.");

                _orderStartTime = value;
            }
        }

        public DateTime? OrderEndTime
        {
            get { return _orderEndTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentException("Order date is null.");

                _orderEndTime = value;
            }
        }

        public string OrderCustomer
        {
            get { return _orderCustomer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Ordered by cannot be empty.");
                _orderCustomer = value;
            }
        }

        public string MedicineType
        {
            get { return _medicineType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Medicine type cannot be empty.");
                _medicineType = value;
            }
        }

        public OrderState OrderState
        {
            get { return _orderState; }
            set { _orderState = value; }
        }

        public string ContainerType
        {
            get { return _containerType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Container type cannot be empty.");
                _containerType = value;
            }
        }

        public int ContainerAmount
        {
            get { return _containerAmount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Container amount must be greater than zero.");
                _containerAmount = value;
            }
        }

        public int ProductsTotal
        {
            get { return _productsInOrderList.Count + _productsInProductionList.Count; }
        }

        public int ProductsInProduction
        {
            get { return _productsInProductionList.Count(product => product.ProductState == OrderState.BUSY); }
        }

        public int ProductsProduced
        {
            get { return _productsInProductionList.Count(product => product.ProductState == OrderState.DONE); }
        }

        public LinkedList<Product> ProductsInOrderList
        {
            get { return _productsInOrderList; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Products in order cannot be null.");
                _productsInOrderList = value;
            }
        }

        public List<Operation> OperationList
        {
            get { return _operationList; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("Operation list cannot be null.");
                _operationList = value;
            }
        }

        public LinkedList<Product> ProductsInProductionList
        {
            get { return _productsInProductionList; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Products in production list cannot be null.");
                _productsInProductionList = value;
            }
        }

        /// <summary>
        /// Constructor for Order class
        /// </summary>
        /// <param name="containerAmount"></param>
        /// <param name="containerType"></param>
        /// <param name="customer"></param>
        /// <param name="orderNumber"></param>
        /// <param name="orderState"></param>
        /// <param name="medicineType"></param>
        /// <param name="operationList"></param>
        public Order(int containerAmount, string containerType, string customer, int orderNumber, OrderState orderState, string medicineType, List<Operation> operationList)
        {
            _containerAmount = containerAmount;
            _orderNumber = orderNumber;
            _containerType = containerType;
            _orderCustomer = customer;
            _orderState = orderState;
            _medicineType = medicineType;
            _productsInOrderList = new LinkedList<Product>();
            _productsInProductionList = new LinkedList<Product>();
            _operationList = operationList;
            _orderStartTime = null;
            _orderEndTime = null;
            GenerateProducts(_containerAmount);

            foreach (var operation in operationList)
            {
                AddProcessToAllProducts(operation.OperationName, operation.OperationDescription, operation.OperationID);
            }
            
            foreach (var product in _productsInOrderList)
            {
                product.PrintProductInfo();
            }
        }
    }

    public enum OrderState
    {
        PEND,
        QUEUE,
        BUSY,
        DONE
    }
}
