using System;
using System.Collections.Generic;
using System.Web;

namespace ROB5_MES_System
{
    public class Order
    {
        private int _orderNumber; // brugt
        private string _orderName;
        private string _orderDescription;
        private string _orderType; 
        private DateTime _orderPlannedStartTime; // brugt
        private DateTime _orderPlannedEndTime; // brugt
        private DateTime _orderStartTime; // brugt
        private DateTime _orderEndTime; // brugt
        private string _orderCustomer; // brugt
        private OrderState _orderState; // brugt

        private string _containerType; // brugt
        private int _containerAmount; // brugt
        private int _containersInProduction;
        private int _containersProduced;

        private int _carriersTotal; // brugt
        private int _carriersInProduction; // brugt 
        private int _carriersProduced; // brugt

        private LinkedList<Carrier> _carriersInOrder; // brugt

        private void GenerateCarriers(string containerType, int containerAmount)
        {
            int fullCarriers = containerAmount / 5;
            int containerRemainder = containerAmount % 5;

            for (int i = 0; i < fullCarriers; i++)
            {
                Carrier carrier = new Carrier(i + 1, 5, containerType, _orderNumber);
                _carriersInOrder.AddLast(carrier);
                Console.WriteLine("Full carrier added");
            }

            _carriersTotal = fullCarriers;

            if (containerRemainder != 0)
            {
                _carriersInOrder.AddLast(new Carrier(fullCarriers + 1, containerRemainder, containerType, _orderNumber));
                _carriersTotal += 1;
                Console.WriteLine(string.Format("Remainder carrier added with {0} containers added", containerRemainder));
            }

            Console.WriteLine(string.Format("{0} full carriers added and 1 remainder carrier with {1} containers, making for {2} containers", fullCarriers, containerRemainder, containerAmount));

        }
        private void AddTaskToCarriers(string taskName, string taskDescription, string taskType, int taskId, string statusDescription)
        {
            foreach (var carrier in _carriersInOrder)
            {   
                Task task = new Task(taskName, taskDescription, taskType, taskId, "Not yet started", statusDescription);
                carrier.AddTaskToEndOfCarrier(task);
            }
        }
        private void SendOrderInfoToDatabase()
        {
            // Anton shit
        }
        private void StartOrderProduction()
        {

        }
        private void ProductionHandeler()
        {

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

        public string OrderName
        {
            get { return _orderName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Order name cannot be empty.");
                _orderName = value;
            }
        }

        public string OrderDescription
        {
            get { return _orderDescription; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Order description cannot be empty.");
                _orderDescription = value;
            }
        }

        public string OrderType
        {
            get { return _orderType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Order type cannot be empty.");
                _orderType = value;
            }
        }

        public DateTime OrderPlannedStartTime
        {
            get { return _orderPlannedStartTime; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Order date cannot be in the past.");

                _orderPlannedStartTime = value;
            }
        }

        public DateTime OrderPlannedEndTime
        {
            get { return _orderPlannedEndTime; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Order date cannot be in the past.");

                _orderPlannedEndTime = value;
            }
        }

        public DateTime OrderStartTime
        {
            get { return _orderStartTime; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Order date cannot be in the past.");

                _orderStartTime = value;
            }
        }

        public DateTime OrderEndTime
        {
            get { return _orderEndTime; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Order date cannot be in the past.");

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

        public int ContainersInProduction
        {
            get { return _containersInProduction; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Containers in production cannot be negative.");
                _containersInProduction = value;
            }
        }

        public int ContainersProduced
        {
            get { return _containersProduced; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Containers produced cannot be negative.");
                _containersProduced = value;
            }
        }

        public int CarriersTotal
        {
            get { return _carriersTotal; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total carriers cannot be negative.");
                _carriersTotal = value;
            }
        }

        public int CarriersInProduction
        {
            get { return _carriersInProduction; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Carriers in production cannot be negative.");
                _carriersInProduction = value;
            }
        }

        public int CarriersProduced
        {
            get { return _carriersProduced; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Carriers produced cannot be negative.");
                _carriersProduced = value;
            }
        }

        public LinkedList<Carrier> CarriersInOrder
        {
            get { return _carriersInOrder; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Carriers in order cannot be null.");
                _carriersInOrder = value;
            }
        }

        public Order(int containerAmount, string containerType, string customer, int orderNumber, DateTime orderDate)
        {
            _containerAmount = containerAmount;
            _orderNumber = orderNumber;
            _containerType = containerType;
            _orderCustomer = customer;
            _orderPlannedStartTime = orderDate;
            _orderState = OrderState.PEND;
            _carriersInOrder = new LinkedList<Carrier>();
            GenerateCarriers(_containerType, _containerAmount);
            AddTaskToCarriers("fill", "Fills up the containers", "action on product", 1, "Not yet started");
            AddTaskToCarriers("stopper", "Seals the containers", "action on product", 2, "Not yet started");
            foreach (var carrier in _carriersInOrder)
            {
                carrier.PrintCarrierInfo();
            }
        }
    }

    public enum OrderState
    {
        PEND,
        BUSY,
        DONE
    }
}
