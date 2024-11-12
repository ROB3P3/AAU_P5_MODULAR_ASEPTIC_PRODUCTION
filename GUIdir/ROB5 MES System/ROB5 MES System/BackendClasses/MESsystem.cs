using System.Collections.Generic;
using System.ComponentModel;

namespace MESBackendConsoleApp
{
    public class MESsystem
    {
        private LinkedList<Order> _orders;
        private int _productionStatus;
        public MESsystem()
        {
            _orders = new LinkedList<Order>();
        }
        public void SendNextOrderToProduction(Order order)
        {
            _productionStatus = 1;
        }
        public void AddOrderToEndOfProductionQueue(int numberOfVials, string vialType, string costumer)
        {
            // Get current odre nr from DB and add one for the order 
            _orders.AddLast(new Order(numberOfVials, vialType, "Novo nordisk", 1));
        }
    }
}
