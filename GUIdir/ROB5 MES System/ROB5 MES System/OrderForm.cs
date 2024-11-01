using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            OrderNumberDispLabel.Text = order.OrderID.ToString();
            PlannedStartTimeDispLabel.Text = order.startTime.ToString();
            PlannedEndTimeDispLabel.Text = order.endTime.ToString();
            ContainerAmountDispLabel.Text = order.ContainerAmount.ToString();
            ContainerTypeDispLabel.Text = order.ContainerType.ToString();
        }
    }
}
