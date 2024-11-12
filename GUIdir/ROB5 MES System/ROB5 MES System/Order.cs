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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ContainerAmount { get; set; }
        public string ContainerType { get; set; }
        public string CompanyName { get; set; }
        public OrderState State { get; set; }
    }

    public enum OrderState
    {
        PEND,
        BUSY,
        DONE
    }
}
