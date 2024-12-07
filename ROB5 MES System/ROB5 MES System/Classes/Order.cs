﻿using ROB5_MES_System.Classes;
using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;

namespace ROB5_MES_System
{
    public class Order
    {
        private int _orderNumber; // brugt | odrenummer som er gemt i DB
        private DateTime? _orderStartTime; // brugt
        private DateTime? _orderEndTime; // brugt
        private string _orderCustomer; // brugt
        private string _medicineType; // brugt
        private OrderState _orderState; // brugt

        private string _containerType; // brugt | hvilken type af container er denn odre 
        private int _containerAmount; // brugt | hvor mange containere har kunden bestilt
        private int _containersInProduction;
        private int _containersProduced;

        private int _carriersTotal; // brugt | hvor mange carrieres er gennerert til denne odre
        private int _carriersInProduction; // brugt | hvor mange carrieres er i produktion lige nu
        private int _carriersProduced; // brugt | hvor mange carrieres er færdigproduceret 

        private LinkedList<Carrier> _carriersInOrder; // brugt | en liste af de carriere objekter som er i odren
        private LinkedList<Carrier> _carriersInProductionList;

        private List<Operation> _operationList;

        private Thread _productionThread;
        public void GenerateCarriers(string containerType, int containerAmount)
        {
            //generates carriers based on the amount of containers in the order
            int fullCarriers = containerAmount / 5; // 5 containers per carrier
            int containerRemainder = containerAmount % 5; // remainder of containers that do not fit in a full carrier

            for (int i = 0; i < fullCarriers; i++)
            {
                Carrier carrier = new Carrier(-1, 5, containerType, _orderNumber); // her bliver carriersne genereret med 5 containere og et id
                _carriersInOrder.AddLast(carrier);
            }

            _carriersTotal = fullCarriers;

            if (containerRemainder != 0) // if there is a remainder of containers that do not fit in a full carrier
            {
                _carriersInOrder.AddLast(new Carrier(-1, containerRemainder, containerType, _orderNumber)); // add a carrier with the remainder of containers
                _carriersTotal += 1;
            }

            Console.WriteLine(string.Format("{0} full carriers added and 1 remainder carrier with {1} containers, making for {2} containers", fullCarriers, containerRemainder, containerAmount));

        }
        // tilfæjer et task objekt til køen af tasks på denne carriere
        public void AddTaskToCarriers(string taskName, string taskDescription, int taskId)
        {
            foreach (var carrier in _carriersInOrder)
            {   
                Task task = new Task(taskName, taskDescription, taskId, "Not yet started");
                carrier.AddTaskToEndOfCarrier(task);
            }
        }

        public void SendOrderInfoToDatabase()
        {
            MainWindowForm.database.insert_data_order(_orderNumber, _orderState.ToString(), _containerAmount, _containerType, _orderCustomer, _medicineType, _operationList, _orderStartTime, _orderEndTime);
        }

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

            // send start bånd komando
            string _command = "begin";
            OpcuaHandler(_command);
            // afvent første carriere informatiopn fra filling station. 
            // tag første carriere far carrieres in order og send den til carrieres in production list
            // tjek om denne carrier skal fyldes
            // send svar til filling station "start" eller "pass it on"
            // Slet filling opgave fra carriern

        }

        private void OpcuaHandler(string serverCommand)
        {
            MainWindowForm.opcuaPLC09.ModifyNodeValue("ServerCommand", serverCommand);
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

        public LinkedList<Carrier> CarriersInProductionList
        {
            get { return _carriersInProductionList; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Carriers in production list cannot be null.");
                _carriersInProductionList = value;
            }
        }

        public Order(int containerAmount, string containerType, string customer, int orderNumber, OrderState orderState, string medicineType, List<Operation> operationList)
        {
            _containerAmount = containerAmount;
            _orderNumber = orderNumber;
            _containerType = containerType;
            _orderCustomer = customer;
            _orderState = orderState;
            _medicineType = medicineType;
            _carriersInOrder = new LinkedList<Carrier>();
            _carriersInProductionList = new LinkedList<Carrier>();
            _operationList = operationList;
            _orderStartTime = null;
            _orderEndTime = null;
            GenerateCarriers(_containerType, _containerAmount);
            foreach (var operation in operationList)
            {
                AddTaskToCarriers(operation.OperationName, operation.OperationDescription, operation.OperationID);
            }
            
            foreach (var carrier in _carriersInOrder)
            {
                carrier.PrintCarrierInfo();
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
