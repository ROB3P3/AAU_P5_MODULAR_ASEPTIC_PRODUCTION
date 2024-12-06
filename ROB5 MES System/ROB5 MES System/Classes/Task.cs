using System;

namespace ROB5_MES_System
{
    public class Task
    {
        private string _taskName; // hvad hedder denne task
        private string _taskDescription; // hvordan kan den beskrives
        private int _taskId; // ID på denne task 
        private string _status; // hvad er status på denne task 
        private DateTime _startTime; // start tid for denne task
        private DateTime _endTime; // slut tid for denne task
        private int _itemsInCarrier; // hvor mange containers der er i carriere
        private string _itemType; // hvilken type af container det er
        private int _carrierId; // Hvilken carriere denne opgave er på

        public string TaskName
        {
            get { return _taskName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Task name can not be empty");
                _taskName = value;
            }
        }
        public string TaskDescription
        {
            get { return _taskDescription; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Task description can not be empty");
                _taskDescription = value;
            }
        }
        public int TaskId
        {
            get { return _taskId; }
            set
            {
                if (value == 0)
                    throw new ArgumentNullException("Task ID can not be empty");
                _taskId = value;
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Status can not be empty");
                _status = value;
            }
        }
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentNullException("Start time is null");
                _startTime = value;
            }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentNullException("End time is null");
                _endTime = value;
            }
        }
        public int ItemsInCarrier
        {
            get { return _itemsInCarrier; }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("Number of containers is less than 0");
                _itemsInCarrier = value;
            }
        }
        public string ItemType
        {
            get { return _itemType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Item type can not be null");
                _itemType = value;
            }
        }
        public int CarrierId
        {
            get { return _carrierId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("Carrier ID can not be less than 0");
                _carrierId = value;
            }
        }

        public Task(string taskName, string taskDescription, int taskId, string status, DateTime? startTime = null, DateTime? endTime = null)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskId = taskId;
            Status = status;
            if (startTime != null) StartTime = startTime.Value;
            if (endTime != null) EndTime = endTime.Value;
        }
        // printer information omkring denne task
        public string GetTaskInfo()
        {
            return (string.Format(
                "Task name: {0}\n" +
                "Task description: {1}\n" +
                "Task type: {2}\n" +
                "Task id: {3}\n" +
                "Task status: {4}\n" +
                "Task status description: {5}\n", TaskName, TaskDescription, TaskId, Status));
        }

    }
}
