namespace ROB5_MES_System
{
    public class Process
    {
        private int _processID; // id of process
        private string _processName; // name of process
        private string _processDescription; // description of process
        private OrderState _processState; // state of process
        private DateTime _processStartTime; // process's start time
        private DateTime _processEndTime; // process's end time

        public string ProcessName
        {
            get { return _processName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("process name can not be empty");
                _processName = value;
            }
        }

        public string ProcessDescription
        {
            get { return _processDescription; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("process description can not be empty");
                _processDescription = value;
            }
        }

        public int ProcessID
        {
            get { return _processID; }
            set
            {
                if (value == 0)
                    throw new ArgumentNullException("process ID can not be empty");
                _processID = value;
            }
        }

        public OrderState ProcessState
        {
            get { return _processState; }
            set { _processState = value; }
        }

        public DateTime ProcessStartTime
        {
            get { return _processStartTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentNullException("Start time is null");
                _processStartTime = value;
            }
        }

        public DateTime ProcessEndTime
        {
            get { return _processEndTime; }
            set
            {
                if (value < DateTime.MinValue || value > DateTime.MaxValue)
                    throw new ArgumentNullException("End time is null");
                _processEndTime = value;
            }
        }

        /// <summary>
        /// Constructor of process class
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="processDescription"></param>
        /// <param name="processID"></param>
        /// <param name="processState"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Process(string processName, string processDescription, int processID, OrderState processState, DateTime? startTime = null, DateTime? endTime = null)
        {
            _processName = processName;
            _processDescription = processDescription;
            _processID = processID;
            _processState = processState;
            if (startTime != null) _processStartTime = startTime.Value;
            if (endTime != null) _processEndTime = endTime.Value;
        }
    }
}
