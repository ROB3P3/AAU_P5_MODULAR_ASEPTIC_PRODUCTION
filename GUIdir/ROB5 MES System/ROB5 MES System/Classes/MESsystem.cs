using System.Collections.Generic;
using System.ComponentModel;

namespace ROB5_MES_System
{
    public class MESSystem
    {
        private LinkedList<Order> _orders;
        private LinkedList<Order> _plannedOrders;
        private LinkedList<Order> _finishedOrders;
        private int _productionStatus;
        public MESSystem()
        {
            _orders = new LinkedList<Order>();
            _plannedOrders = new LinkedList<Order>();
            _finishedOrders = new LinkedList<Order>();
        }

        public void SendNextOrderToProduction(Order order)
        {
            _productionStatus = 1;
        }
        public void AddOrderToEndOfProductionQueue(int numberOfContainers, string containerType, string customer, DateTime orderDate)
        {
            // Get current odre nr from DB and add one for the order 
            Order order = new Order(numberOfContainers, containerType, customer, MainWindowForm.database.get_order_number(), orderDate, OrderState.QUEUE);
            _orders.AddLast(order);
            order.SendOrderInfoToDatabase();
        }

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
