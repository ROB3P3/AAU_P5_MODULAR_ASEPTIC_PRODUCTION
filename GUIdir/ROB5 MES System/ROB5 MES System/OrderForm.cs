using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROB5_MES_System
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        public void UpdateOrderForm(Order order)
        {
            this.Text = "Order " + order.OrderID;
            OrderNumberDispLabel.Text = order.OrderID.ToString();
            PlannedStartTimeDispLabel.Text = order.StartTime.ToString("yyyy/MM/dd hh:mm:ss");
            PlannedEndTimeDispLabel.Text = order.EndTime.ToString("yyyy/MM/dd hh:mm:ss");
            ContainerAmountDispLabel.Text = order.ContainerAmount.ToString();
            ContainerTypeDispLabel.Text = order.ContainerType.ToString();
        }
    }
}
