using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Web;

namespace ROB5_MES_System
{
    public class PLCInfo : INotifyPropertyChanged
    {
        private int _connectionStatus;
        private int _id;
        private int _placement;
        private string _appState;
        private string _nodeId;
        private string _type;

        public int ConnectionStatus
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

        public string NodeId
        {
            get { return _nodeId; }
            set { _nodeId = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string GenerateNodeId(int id)
        {
            return (id + 2).ToString();
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
            NodeId = GenerateNodeId(_id);
            Type = "Not yet registered";

            ConnectionStatus = 0;
        }
    }
}