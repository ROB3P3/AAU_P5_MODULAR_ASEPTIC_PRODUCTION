using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace ROB5_MES_System
{
    public class Product
    {
        private int _orderID; // id of the order that the product is assigned to
        private int _productID; // id of the physical product (id of -1 means that the product has not been assigned to a product in the physical system)
        private OrderState _productState; // state of the product
        private int _containerAmount; // container amount on the product 
        private string _containerType; // container type on the product 
        private DateTime _productStartTime; // product's start time in production
        private DateTime _productEndTime; // product's end time in production 
        
        private LinkedList<Process> _productProcessQueue; // list of processs in queue to be performed on the product 
        private LinkedList<Process> _productCompletedProcesses; // list of completed processs on the product

        /// <summary>
        /// Add a process to the end of the product's process queue
        /// </summary>
        /// <param name="processToBeAdded"></param>
        public void AddProcessToEndOfProduct(Process processToBeAdded)
        {
            _productProcessQueue.AddLast(processToBeAdded);
        }

        /// <summary>
        /// Complete the first process in the product's process queue
        /// </summary>
        public void CompleteFirstProcessInProductQueue()
        {
            Console.WriteLine("Completing First Process In Porduction Queue");
            if (_productProcessQueue.Count > 0)
            {
                Process completeProcess = _productProcessQueue.First.Value;
                completeProcess.ProcessEndTime = DateTime.Now;
                completeProcess.ProcessState = OrderState.DONE;
                _productCompletedProcesses.AddLast(completeProcess);
                _productProcessQueue.RemoveFirst();
                if(_productProcessQueue.Count <= 0)
                {
                    _productEndTime = DateTime.Now;
                    _productState = OrderState.DONE;
                    TerminateProduct();
                }
                UpdateOrderForm();
            }
        }

        /// <summary>
        /// Terminate product when there are no longer any processs in its queue
        /// Sends product information to the database
        /// </summary>
        public void TerminateProduct()
        {
            Console.WriteLine("Terminating product");
            MainWindowForm.database.InsertDataProduction(_orderID, _productID, _productState, _containerType, _containerAmount, _productStartTime, _productEndTime, _productCompletedProcesses);
        }

        /// <summary>
        /// Update the Order form if it is open
        /// </summary>
        private void UpdateOrderForm()
        {
            OrderForm orderForm = Application.OpenForms.OfType<OrderForm>().FirstOrDefault();

            if (orderForm != null)
            {
                orderForm.UpdateOrderForm();
            }
        }

        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("Order number cannot be less than 0");
                _productID = value;
            }
        }

        public int OrderID
        {
            get { return _orderID; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Order ID cannot be less than or equal to 0.");
                _orderID = value;
            }
        }

        public OrderState ProductState
        {
            get { return _productState; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("Product state cannot be null.");
                _productState = value;
            }
        }

        public int ContainerAmount
        {
            get { return _containerAmount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Container amount must be greater than 0.");
                _containerAmount = value;
            }
        }

        public string ContainerType
        {
            get { return _containerType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Container type cannot be null or empty.");
                _containerType = value;
            }
        }

        public DateTime ProductStartTime
        {
            get { return _productStartTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentException("Order date is null.");

                _productStartTime = value;
            }
        }

        public DateTime ProductEndTime
        {
            get { return _productEndTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentException("Order date is null.");

                _productEndTime = value;
            }
        }

        public LinkedList<Process> ProductProcessQueue
        {
            get { return _productProcessQueue; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("ProcessQueue cannot be null.");
                _productProcessQueue = value;
            }
        }

        public LinkedList<Process> ProductCompletedProcesses
        {
            get { return _productCompletedProcesses; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("CompletedProcesss cannot be null.");
                _productCompletedProcesses = value;
            }
        }

        /// <summary>
        /// Constructor for product class
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="containerAmount"></param>
        /// <param name="containerType"></param>
        /// <param name="orderId"></param>
        /// <param name="state"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Product(int productID, int containerAmount, string containerType, int orderId, OrderState? state = null, DateTime? startTime = null, DateTime? endTime = null)
        {
            _productProcessQueue = new LinkedList<Process>();
            _productCompletedProcesses = new LinkedList<Process>();
            _productID = productID;
            _orderID = orderId;
            _containerAmount = containerAmount;
            _containerType = containerType;
            if (state != null) _productState = state.Value;
            if (startTime != null) _productStartTime = startTime.Value;
            if (endTime != null) _productEndTime = endTime.Value;
        }

        /// <summary>
        /// Prints information about the product to the console
        /// </summary>
        public void PrintProductInfo()
        {
            Console.WriteLine(string.Format("\nInformation on product {0}:\nOrder ID: {1}\nNumber of processs in queue: {2}\nNumber of completed processs: {3}\n",
                _productID, _orderID, _productProcessQueue.Count, _productCompletedProcesses.Count));

            Console.Write("Process in queue: [ ");
            
            foreach(var process in _productProcessQueue)
            {
                Console.Write(process.ProcessName + " ");
            }

            Console.Write(" ]\n");
        }
    }
}
