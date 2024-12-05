using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace ROB5_MES_System
{
    public class Carrier
    {
        private int _id; // brugt | Hvilket id der er på den fysiske carrier med disse atributter. 0 = ikke allokeret
        private int _orderId; 
        private OrderState _state;
        private int _quantityOfTasks;
        private int _quantityOfCompletedTasks;
        private int _containerAmount; // brugt | Hvor mange containere der er på denne carrier 
        private string _containerType;
        private DateTime _startTime; // brugt | Start for produktion
        private DateTime _endTime; // brugt | slut for produktion
        
        private LinkedList<Task> _taskQueue; // brugt | Hvilke opgaver der endnu ikke er udført på denne carrier 
        private LinkedList<Task> _completedTasks; // brugt | Opgaver som er blevet udført på denne carrier

        // Tilføjer et tak objekt til starten af carrierens produktionskø
        public void AddTaskToStartOfCarrier(Task taskToBeAdded)
        {
            _taskQueue.AddFirst(taskToBeAdded);
            _quantityOfTasks++;
        }
        // Tilføjer et task objekt til slutningen af carrierens produktionskø
        public void AddTaskToEndOfCarrier(Task taskToBeAdded)
        {
            _taskQueue.AddLast(taskToBeAdded);
            _quantityOfTasks++;
        }
        // Tilføjer et task objekt efter et givet index i produktionskøen
        public void AddTaskToCarrierAfterTask(int IdOfTaskToInsertAfter, Task taskToBeAdded)
        {
            if (_quantityOfTasks == 0) throw new ArgumentException("You can't insert task in the queue after the given task, queu is empty. Use Add task to start or end method");
            if (_quantityOfTasks < IdOfTaskToInsertAfter || IdOfTaskToInsertAfter < 0) throw new ArgumentException("invalid insertion index");
            for (var node = _taskQueue.First; node != null; node = node.Next)
            {
                if (node.Value.TaskId == IdOfTaskToInsertAfter)
                {
                    _taskQueue.AddAfter(node, taskToBeAdded); 
                    break;
                }
            }
        }
        // Sletter et taks objekt fra carrierens produktionskø
        public void DeleteTaskFromCarrier(int taskId)
        {
            if (_quantityOfTasks == 0) throw new ArgumentException("You can't delete a task when the task queu is empty");
            for (var node = _taskQueue.First; node != null; node = node.Next)
            {
                if (node.Value.TaskId == taskId)
                {
                    _taskQueue.Remove(node);
                    break;
                }
            }
        }
        // Færdiggøre den første task i carrierens produktionskø og flytter den til udførte opgave
        public void CompleteFirstTaskInCarrierQueue()
        {
            if (_quantityOfTasks > 0)
            {
                Task completeTask = _taskQueue.First.Value;
                completeTask.EndTime = DateTime.Now;
                completeTask.Status = "Completed";
                _completedTasks.AddLast(completeTask);
                _taskQueue.RemoveFirst();
                _quantityOfTasks--;
                _quantityOfCompletedTasks++;
                UpdateOrderForm();
            }
        }
        // sletter carrier "endnu ikke implementeret"
        public void TerminateCarrier()
        {
            Console.WriteLine("Terminating carrier");
            /* Send shit til anton*/
            //MainWindowForm.database.insert_data_production(_orderId, _id, _containerType, _containerAmount, _startTime, _endTime, (_endTime - _startTime), );
        }
        // Printer information om carrieren i konsollen
        public void PrintCarrierInfo()
        {

            Console.WriteLine(string.Format("\nInformation on Carrier {1}:\n" + 
                "Order ID: {0} \n" +
                "number of tasks: {2}",_orderId, _id, _quantityOfTasks));

            Console.Write("Task in queue: [ ");
            for (var node = _taskQueue.First; node != null; node = node.Next)
            {
                Console.Write(node.Value.TaskName + " ");
            }
            Console.Write(" ]");
            Console.WriteLine("\n");
        }

        public int CarrierID
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("Order number cannot be less than 0");
                _id = value;
            }
        }

        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Order ID cannot be less than or equal to 0.");
                _orderId = value;
            }
        }

        public int QuantityOfTasks
        {
            get { return _quantityOfTasks; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Quantity of tasks cannot be negative.");
                _quantityOfTasks = value;
            }
        }

        public OrderState CarrierState
        {
            get { return _state; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("Carrier state cannot be null.");
                _state = value;
            }
        }

        public int QuantityOfCompletedTasks
        {
            get { return _quantityOfCompletedTasks; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Quantity of completed tasks cannot be negative.");
                _quantityOfCompletedTasks = value;
            }
        }

        public int ContainerAmount
        {
            get { return _containerAmount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Container amount must be greater than 0.");
                _containerAmount = value;
            }
        }

        public string ContainerType
        {
            get { return _containerType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Container type cannot be null or empty.");
                _containerType = value;
            }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentException("Order date is null.");

                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentException("Order date is null.");

                _endTime = value;
            }
        }

        public LinkedList<Task> TaskQueue
        {
            get { return _taskQueue; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("TaskQueue cannot be null.");
                _taskQueue = value;
            }
        }

        public LinkedList<Task> CompletedTasks
        {
            get { return _completedTasks; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("CompletedTasks cannot be null.");
                _completedTasks = value;
            }
        }

        private void UpdateOrderForm()
        {
            OrderForm orderForm = Application.OpenForms.OfType<OrderForm>().FirstOrDefault();

            if (orderForm != null)
            {
                orderForm.UpdateOrderForm();
            }
        }

        // constructer tol Carrier klasse
        public Carrier(int id, int containerAmount, string containerType, int orderId)
        {
            _taskQueue = new LinkedList<Task>();
            _completedTasks = new LinkedList<Task>();
            _quantityOfTasks = 0;
            _quantityOfCompletedTasks = 0;
            _id = id;
            _orderId = orderId;
            _containerAmount = containerAmount;
            _containerType = containerType;
        }
    }
}
