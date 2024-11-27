using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ROB5_MES_System.Classes
{
    public class Operation
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
            }
        }

        public Operation(int operationID, string operationName, string operationDescription)
        {
            OperationID = operationID;
            OperationName = operationName;
            OperationDescription = operationDescription;
        }
    }
}
