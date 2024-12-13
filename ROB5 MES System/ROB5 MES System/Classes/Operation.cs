using System.ComponentModel;

namespace ROB5_MES_System.Classes
{
    public class Operation : INotifyPropertyChanged
    {
        private int _operationID;
        private string _operationName;
        private string _operationDescription;

        public int OperationID
        {
            get { return _operationID; }
            set
            {
                if (value == 0)
                    throw new ArgumentNullException("Operation ID can not be empty");
                _operationID = value;
                OnPropertyChanged(nameof(_operationID));
            }
        }

        public string OperationName
        {
            get { return _operationName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Operation name can not be empty");
                _operationName = value;
                OnPropertyChanged(nameof(_operationName));
            }
        }

        public string OperationDescription
        {
            get { return _operationDescription; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Operation description can not be empty");
                _operationDescription = value;
                OnPropertyChanged(nameof(_operationDescription));
            }
        }

        public string DisplayText
        {
            get
            {
                return $"{OperationID} | {OperationName}";
            }
        }

        // event handler for changing values of Operation class
        // this is used to update the UI automatically when a value is changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Constructor for the Operation class
        /// </summary>
        public Operation(int operationID, string operationName, string operationDescription)
        {
            OperationID = operationID;
            OperationName = operationName;
            OperationDescription = operationDescription;
        }
    }
}
