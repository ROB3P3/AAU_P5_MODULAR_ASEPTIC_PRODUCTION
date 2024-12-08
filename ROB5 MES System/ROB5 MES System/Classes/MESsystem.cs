using ROB5_MES_System.Classes;
using System.Collections.Generic;
using System.ComponentModel;

namespace ROB5_MES_System
{
    public class MESSystem
    {
        private LinkedList<Order> _orderQueue; // list of orders in the production queue
        private LinkedList<Order> _plannedOrders; // list of planned orders
        private LinkedList<Order> _finishedOrders; // list of finished orders

        public MESSystem()
        {
            _orderQueue = new LinkedList<Order>();
            _plannedOrders = new LinkedList<Order>();
            _finishedOrders = new LinkedList<Order>();
        }

        /// <summary>
        /// Add an order to the end of the production queue
        /// </summary>
        /// <param name="containerAmount"></param>
        /// <param name="containerType"></param>
        /// <param name="customer"></param>
        /// <param name="medicineType"></param>
        /// <param name="operationList"></param>
        public void AddOrderToEndOfProductionQueue(int containerAmount, string containerType, string customer, string medicineType, List<Operation> operationList)
        {
            Order order = new Order(containerAmount, containerType, customer, MainWindowForm.database.GetMaxOrderNumber(), OrderState.QUEUE, medicineType, operationList);
            _orderQueue.AddLast(order);
            order.SendOrderInfoToDatabase();
        }

        /// <summary>
        /// Add an order to the end of the planned orders
        /// </summary>
        /// <param name="containerAmount"></param>
        /// <param name="containerType"></param>
        /// <param name="customer"></param>
        /// <param name="medicineType"></param>
        /// <param name="operationList"></param>
        public void AddOrderToEndOfPlannedOrders(int containerAmount, string containerType, string customer, string medicineType, List<Operation> operationList)
        {
            Order order = new Order(containerAmount, containerType, customer, MainWindowForm.database.GetMaxOrderNumber(), OrderState.PEND, medicineType, operationList);
            _plannedOrders.AddLast(order);
            order.SendOrderInfoToDatabase();
        }

        /// <summary>
        /// Find an order in a given list based on a given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        public LinkedList<Order> OrderQueue
        {
            get { return _orderQueue; }
            set { _orderQueue = value; }
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
