﻿using ROB5_MES_System.Classes;
using System.Collections.Generic;
using System.ComponentModel;

namespace ROB5_MES_System
{
    public class MESSystem
    {
        private LinkedList<Order> _orders; // liste af odre som er i queu
        private LinkedList<Order> _plannedOrders; // liste af de odre som er planlagt
        private LinkedList<Order> _finishedOrders; // liste af odre som er færdigproduceret
        public MESSystem()
        {
            _orders = new LinkedList<Order>();
            _plannedOrders = new LinkedList<Order>();
            _finishedOrders = new LinkedList<Order>();
        }

        public void AddOrderToEndOfProductionQueue(int numberOfContainers, string containerType, string customer, string medicineType, List<Operation> operationList)
        {
            Order order = new Order(numberOfContainers, containerType, customer, MainWindowForm.database.get_order_number(), OrderState.QUEUE, medicineType, operationList);
            _orders.AddLast(order);
            order.SendOrderInfoToDatabase();
        }
        // find en odre på et i en givet liste på det givende index
        public Order GetOrderAtIndex(int index, LinkedList<Order> list)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
            }

            var currentNode = list.First;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }

        public LinkedList<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public LinkedList<Order> PlannedOrders
        {
            get { return _plannedOrders; }
            set { _plannedOrders = value; }
        }

        public LinkedList<Order> FinishedOrders
        {
            get { return _finishedOrders; }
            set { _finishedOrders = value; }
        }
    }
}
