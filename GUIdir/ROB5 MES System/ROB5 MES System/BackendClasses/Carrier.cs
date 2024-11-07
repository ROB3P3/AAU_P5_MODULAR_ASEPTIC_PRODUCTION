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
        private int _quantityOfCompletedTasks;
        private int _vialAmount;
        private string _vialType;
        private LinkedList<Task> _taskQueue;
        private LinkedList<Task> _completedTasks;

        // Her skal gerne være en dubble linked list af tasks så der kan laves en dynamisk version af køen
        public void AddTaskToStartOfCarrier(Task taskToBeAdded)
        {
            _taskQueue.AddFirst(taskToBeAdded);
            _quantityOfTasks++;
        }
        public void AddTaskToEndOfCarrier(Task taskToBeAdded)
        {
            _taskQueue.AddLast(taskToBeAdded);
            _quantityOfTasks++;
        }
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
        public void CompleteFirstTaskInCarrierQueue()
        {
            if (_quantityOfTasks <= 0) throw new ArgumentException("You can't remove a task from an empty carrier queu");
            Task completeTask = _taskQueue.First.Value;
            _completedTasks.AddLast(completeTask);
            _taskQueue.RemoveFirst();
            _quantityOfTasks --;
            _quantityOfCompletedTasks ++;
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
            for (var node = _taskQueue.First; node != null; node = node.Next)
            {
                Console.Write(node.Value.TaskName + " ");
            }
            Console.Write(" ]");
            Console.WriteLine("\n");
        }
        public Carrier(int id, int vialAmount, string vialType, int orderId)
        {
            _taskQueue = new LinkedList<Task>();
            _completedTasks = new LinkedList<Task>();
            _quantityOfTasks = 0;
            _quantityOfCompletedTasks = 0;
            _id = id;
            _orderId = orderId;
            _vialAmount = vialAmount;
            _vialType = vialType;
        }
    }
}
