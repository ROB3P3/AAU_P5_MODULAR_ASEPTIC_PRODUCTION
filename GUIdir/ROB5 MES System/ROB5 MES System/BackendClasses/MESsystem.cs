using System.Collections.Generic;

namespace MESBackendConsoleApp
{
    public class MESsystem
    {
        private LinkedList<Order> _orders;
        public MESsystem()
        {
            _orders = new LinkedList<Order>();
        }

        public void AddOrderToEndOfProductionQueu(int numberOfVials, string vialType)
        {
            _orders.AddLast(new Order(numberOfVials, vialType, "Novo nordisk",1));
        }
    }
}
