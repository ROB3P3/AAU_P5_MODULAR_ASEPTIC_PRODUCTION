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
        private bool _connectionStatus; // weather we are connected or not
        private int _id; // the id of the plc "hard coded"
        private int _placement; // The physical placement in the production system, given by an int to define the position
        private string _appState; // What the application is doing right now

        //private string _nodeId; // the path to find the opcua information on the node
        private string _type; // what type of application moduel is currently mounted [filling stubbering]
        private ushort _carrierID; // the id of the carrier that is currently being processed

        public bool ConnectionStatus
        {
            get { return _connectionStatus; }
            set 
            { 
                _connectionStatus = value;
                OnPropertyChanged(nameof(ConnectionStatus));
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

        public int Placement
        {
            get { return _placement; }
            set 
            { 
                _placement = value; 
                OnPropertyChanged(nameof(Placement));
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

        /*public string NodeId
        {
            get { return _nodeId; }
            set { _nodeId = value; }
        }*/

        private string GenerateNodeId(int PLCid)
        {
            // placeholder
            return (PLCid + 2).ToString();
        }

        public ushort CarrierID
        {
            get { return _carrierID; }
            set
            {
                _carrierID = value;
                OnPropertyChanged(nameof(CarrierID));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PLCInfo(int id, int placement)
        {
            Id = id;
            Placement = placement;
            //NodeId = nodeId;
            Type = "N/A";
            AppState = "N/A";
            CarrierID = 0;
        }
    }
}