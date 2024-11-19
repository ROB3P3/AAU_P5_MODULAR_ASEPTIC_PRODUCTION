using System;
using System.Collections.Generic;
using System.Web;

namespace ROB5_MES_System
{
    public class PLCInfo
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
            set { _connectionStatus = value; }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("PLC ID can not 0 or less than 0");
                _id = value;
            }
        }

        public int Placement
        {
            get { return _placement; }
            set { _placement = value; }
        }

        public string AppState
        {
            get { return _appState; }
            set { _appState = value; }
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