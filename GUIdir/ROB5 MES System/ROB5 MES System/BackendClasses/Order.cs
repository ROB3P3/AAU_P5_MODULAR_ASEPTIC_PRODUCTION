using System;
using System.Collections.Generic;
using System.Web;

namespace MESBackendConsoleApp
{
    public class  Order
    {
        private int _orderNumber;
        private string _orderName;
        private string _orderDescription;
        private string _orderType; 
        private string _orderDate;
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
            int vialRemainder = 0;

            fullCarriers = vialAmount / 5;
            vialRemainder = vialAmount % 5;

            for (int i = 0; i < fullCarriers; i++)
            {
                Carrier carrier = new Carrier(i + 1, 5, vialType, _orderNumber);
                _carriersInOrder.AddLast(carrier);
                Console.WriteLine("Full carrier added");
            }
            _carriersInOrder.AddLast(new Carrier(fullCarriers+1, vialRemainder, vialType, _orderNumber));
            Console.WriteLine(string.Format("Remainder carrier added with {0} vials added", vialRemainder));
            Console.WriteLine(string.Format("{0} full carriers added and 1 renauinder carrier with {1} vials, making for {2} vials", fullCarriers, vialRemainder, vialAmount));

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
            _orderNumber = orderNumber;
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
