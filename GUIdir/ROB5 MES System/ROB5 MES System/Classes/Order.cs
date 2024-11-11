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
        private DateTime _orderStartTime; // brugt
        private DateTime _orderEndTime; // brugt
        private string _orderCustomer; // brugt
        private OrderState _orderState; // brugt

        private string _vialType; // brugt
        private int _vialAmount; // brugt
        private int _vialsInProduction;
        private int _vialsProduced;

        private int _carriersTotal; // brugt
        private int _carriersInProduction; // brugt 
        private int _carriersProduced; // brugt

        private LinkedList<Carrier> _carriersInOrder; // brugt

        private void GenerateCarriers(string vialType, int vialAmount)
        {
            int fullCarriers = 0;
            int vialRemainder = 0;

            fullCarriers = vialAmount / 5;
            vialRemainder = vialAmount % 5;

            for (int i = 0; i < fullCarriers; i++)
            {
                Carrier carrier = new Carrier(i + 1, 5, vialType, _orderNumber);
                _carriersInOrder.AddLast(carrier);
                Console.WriteLine("Full carrier added");
            }

            _carriersTotal = fullCarriers;

            if (vialRemainder != 0)
            {
                _carriersInOrder.AddLast(new Carrier(fullCarriers + 1, vialRemainder, vialType, _orderNumber));
                _carriersTotal += 1;
                Console.WriteLine(string.Format("Remainder carrier added with {0} vials added", vialRemainder));
            }

            Console.WriteLine(string.Format("{0} full carriers added and 1 remainder carrier with {1} vials, making for {2} vials", fullCarriers, vialRemainder, vialAmount));

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

        public string VialType
        {
            get { return _vialType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Vial type cannot be empty.");
                _vialType = value;
            }
        }

        public int VialAmount
        {
            get { return _vialAmount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Vial amount must be greater than zero.");
                _vialAmount = value;
            }
        }

        public int VialsInProduction
        {
            get { return _vialsInProduction; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Vials in production cannot be negative.");
                _vialsInProduction = value;
            }
        }

        public int VialsProduced
        {
            get { return _vialsProduced; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Vials produced cannot be negative.");
                _vialsProduced = value;
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

        public Order(int vialAmount, string vialType, string customer, int orderNumber, DateTime orderDate)
        {
            _vialAmount = vialAmount;
            _orderNumber = orderNumber;
            _vialType = vialType;
            _orderCustomer = customer;
            _orderStartTime = orderDate;
            _orderState = OrderState.PEND;
            _carriersInOrder = new LinkedList<Carrier>();
            GenerateCarriers(_vialType, _vialAmount);
            AddTaskToCarriers("fill", "Fills up the vials", "action on product", 1, "Not yet started");
            AddTaskToCarriers("stopper", "Seals the vials", "action on product", 2, "Not yet started");
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
