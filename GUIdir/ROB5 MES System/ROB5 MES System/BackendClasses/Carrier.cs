using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace MESBackendConsoleApp
{
    public class Carrier
    {
        private int _id;
        private int _orderId;
        private int _quantityOfTasks;
        private int _quantityOfCompletetTasks;
        private int _vialAmount;
        private string _vialType;
        private LinkedList<Task> _queue;
        private LinkedList<Task> _completetTasks;

        // Her skal gerne være en dubble linked list af tasks så der kan laves en dynamisk version af køen
        public void AddTaskToStartOfCarrier(Task taskToBeAdded)
        {
            _queue.AddFirst(taskToBeAdded);
            _quantityOfTasks++;
        }
        public void AddTaskToEndOfCarrier(Task taskToBeAdded)
        {
            _queue.AddLast(taskToBeAdded);
            _quantityOfTasks++;
        }
        public void AddTaskToCarrierAfterTask(int IdOfTaskToInsertAfter, Task taskToBeAdded)
        {
            if (_quantityOfTasks == 0) throw new ArgumentException("You can't indrt task in the queu after the given task, queu is empty. Use Add task to start or end method");
            if (_quantityOfTasks < IdOfTaskToInsertAfter || IdOfTaskToInsertAfter < 0) throw new ArgumentException("invalid insertion index");
            for (var node = _queue.First; node != null; node = node.Next)
            {
                if (node.Value.TaskId == IdOfTaskToInsertAfter)
                {
                    _queue.AddAfter(node, taskToBeAdded); 
                    break;
                }
            }

        }
        public void DeleteTaskFromCarrier(int taskId)
        {
            if (_quantityOfTasks == 0) throw new ArgumentException("You can't delete a task when the task queu is empty");
            for (var node = _queue.First; node != null; node = node.Next)
            {
                if (node.Value.TaskId == taskId)
                {
                    _queue.Remove(node);
                    break;
                }
            }
        }
        public void CompleteFirstTaskInCarrierQueu()
        {
            if (_quantityOfTasks <= 0) throw new ArgumentException("You can't remove a task from an empty carrier queu");
            Task completeTask = _queue.First.Value;
            _completetTasks.AddLast(completeTask);
            _queue.RemoveFirst();
            _quantityOfTasks --;
            _quantityOfCompletetTasks ++;
        }
        public void TerminateCarrier()
        {
            Console.WriteLine("Terminating carrier");
            /* Send shit til anton*/ 
        }
        public void PrintCarrierInfo()
        {
            Console.WriteLine(string.Format("Order ID: {0} \n" +
                "Carrier ID {1}\n"+
                "number of tasks: {2}",_orderId, _id, _quantityOfTasks));

            Console.Write("Task in queu: [ ");
            for (var node = _queue.First; node != null; node = node.Next)
            {
                Console.Write(node.Value.TaskName + " ");
            }
            Console.Write(" ]");
            Console.WriteLine("\n");
        }
        public Carrier(int id, int vialAmount, string vialType, int orderId)
        {
            _queue = new LinkedList<Task>();
            _completetTasks = new LinkedList<Task>();
            _quantityOfTasks = 0;
            _quantityOfCompletetTasks = 0;
            _id = id;
            _orderId = orderId;
            _vialAmount = vialAmount;
            _vialType = vialType;
        }
    }
}
