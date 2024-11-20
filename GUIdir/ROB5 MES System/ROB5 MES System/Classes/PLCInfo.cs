using System;
using System.Collections.Generic;
using System.Web;
using ROB5_MES_System.Classes;

namespace ROB5_MES_System
{
    public class PLCInfo
    {
        private int _connectionStatus; // weather we are connected or not
        private int _id; // the id of the plc "hard coded"
        private int _placement; // The physical placement in the production system, given by an int to define the position
        private string _appState; // What the application is doing right now

        private string _nodeId; // the path to find the opcua information on the node
        private string _type; // what type of application moduel is currently mounted [filling stubbering]

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



        public string Type
        {
            get { return _type; }
            set { _type = value; }
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

        private string GenerateNodeId(int PLCid)
        {
            // placeholder
            return (PLCid + 2).ToString();
        }

        public PLCInfo(int id, int placement, string nodeId, string endpointURL)
        {

            OPCUA opcua = new OPCUA(endpointURL);

            Id = id;
            Placement = placement;
            NodeId = nodeId;
            Type = opcua.AppTypeTest;
            AppState = "Waiting";

            ConnectionStatus = 0;
        }
    }
}