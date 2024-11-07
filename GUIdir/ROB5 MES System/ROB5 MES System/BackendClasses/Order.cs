using System;
using System.Collections.Generic;
using System.Web;

namespace MESBackendConsoleApp
{
    public class  Order
    {
        private int _ordernumber;
        private string _ordername;
        private string _orderdescription;
        private string _ordertype; 
        private string _orderdate;
        private string _orderedBy;

        private string _vialType;
        private int _vialAmount;
        private int _vialsInProduction;
        private int _vialsProduced;

        private int _carriersTotal;
        private int _carriersInProduction;
        private int _carriersProduced;

        private LinkedList<Carrier> _carriersInOrder;

        private void GenerateCarriers(string vialType, int vialAmount)
        {
            int fullCarriers = 0;
            int vialRemaineder = 0;

            fullCarriers = vialAmount / 5;
            vialRemaineder = vialAmount % 5;

            for (int i = 0; i < fullCarriers; i++)
            {
                Carrier carrier = new Carrier(i + 1, 5, vialType, _ordernumber);
                _carriersInOrder.AddLast(carrier);
                Console.WriteLine("Full carrier added");
            }
            _carriersInOrder.AddLast(new Carrier(fullCarriers+1, vialRemaineder, vialType, _ordernumber));
            Console.WriteLine(string.Format("Remainder carrier added with {0} vials added", vialRemaineder));
            Console.WriteLine(string.Format("{0} full carriers added and 1 renauinder carrier with {1} vials, making for {2} vials", fullCarriers, vialRemaineder, vialAmount));

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
        public Order(int vialAmaount, string vialType, string costumer, int orderNumber)
        {
            _vialAmount = vialAmaount;
            _ordernumber = orderNumber;
            _vialType = vialType;
            _orderedBy = costumer;
            _carriersInOrder = new LinkedList<Carrier>();
            GenerateCarriers(_vialType, _vialAmount);
            AddTaskToCarriers("fill", "Fills up the vials", "action on product", 1, "Not yet started");
            AddTaskToCarriers("stubber", "Seals the vials", "action on product", 2, "Not yet started");
            foreach (var carrier in _carriersInOrder)
            {
                carrier.PrintCarrierInfo();
            }
        }
    }
}
