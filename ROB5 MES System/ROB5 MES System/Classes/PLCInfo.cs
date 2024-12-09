using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Web;
using ROB5_MES_System.Classes;

namespace ROB5_MES_System
{
    public class PLCInfo : INotifyPropertyChanged
    {
        private bool _connectionStatus; // determines connection status to PLC
        private int _placement; // the physical placement in the production system, given by an int to define the position
        private int _id; // the id of the plc "hard coded"
        private string _appState; // what the application is doing right now

        private string _type; // what type of application module is currently mounted [filling or stoppering]
        private ushort _productID; // the id of the product that is currently being processed

        public bool ConnectionStatus
        {
            get { return _connectionStatus; }
            set 
            { 
                _connectionStatus = value;
                OnPropertyChanged(nameof(ConnectionStatus));
            }
        }

        public int Placement
        {
            get { return _placement; }
            set
            {
                _placement = value;
                OnPropertyChanged(nameof(Placement));
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("PLC ID can not 0 or less than 0");
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Type
        {
            get { return _type; }
            set 
            { 
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string AppState
        {
            get { return _appState; }
            set 
            { 
                _appState = value;
                OnPropertyChanged(nameof(AppState));
            }
        }

        public ushort ProductID
        {
            get { return _productID; }
            set
            {
                _productID = value;
                OnPropertyChanged(nameof(ProductID));
            }
        }

        // an event handler that runs when a variable in the class is changed
        // is used to automatically update the SystemStatus form upon changes in the PLCInfo class
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Constructor of the PLCInfo class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="placement"></param>
        public PLCInfo(int id, int placement)
        {
            Placement = placement;
            Id = id;
            Type = "N/A";
            AppState = "N/A";
            ProductID = 0;
        }
    }
}