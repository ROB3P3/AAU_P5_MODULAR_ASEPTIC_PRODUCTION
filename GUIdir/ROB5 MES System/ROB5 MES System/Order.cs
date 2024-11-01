using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROB5_MES_System
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int ContainerAmount { get; set; }
        public string ContainerType { get; set; }
        public string OrderState { get; set; }
    }
}
