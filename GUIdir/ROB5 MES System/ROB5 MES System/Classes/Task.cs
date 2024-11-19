using System;

namespace ROB5_MES_System
{
    public class Task
    {
        private string _taskName;
        private string _taskDescription;
        private string _taskType;
        private int _taskId;
        private string _status;
        private string _statusDescription;
        private DateTime _startTime;
        private DateTime _endTime;
        private int _itemsInCarrier;
        private string _itemType;
        private int _carrierId;

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
        public string TaskType
        {
            get { return _taskType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Task type can not be empty");
                _taskType = value;
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
        public string StatusDescription
        {
            get { return _statusDescription; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Status description can not be empty");
                _statusDescription = value;
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

        public Task(string taskName, string taskDescription, string taskType, int taskId, string status, string statusDescription)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskType = taskType;
            TaskId = taskId;
            Status = status;
            StatusDescription = statusDescription;
        }

        public string GetTaskInfo()
        {
            return (string.Format(
                "Task name: {0}\n" +
                "Task description: {1}\n" +
                "Task type: {2}\n" +
                "Task id: {3}\n" +
                "Task status: {4}\n" +
                "Task status description: {5}\n", TaskName, TaskDescription, TaskType, TaskId, Status, StatusDescription));
        }

    }
}
