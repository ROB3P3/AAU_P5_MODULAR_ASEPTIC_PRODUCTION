using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ROB5_MES_System;

namespace ROB5_MES_System
{
    public partial class CurrentOrdersForm : Form
    {
        public CurrentOrdersForm()
        {
            InitializeComponent();
        }

        private OrderForm orderForm;
        private void ShowOrderForm(Order clickedOrder)
        {
            if(orderForm == null || orderForm.IsDisposed)
            {
                orderForm = new OrderForm();
                orderForm.MdiParent = this.MdiParent;
                orderForm.Show();
            }
            else
            {
                orderForm.BringToFront();
            }
            orderForm.UpdateOrderForm(clickedOrder);
        }

        private void CurrentOrdersForm_Load(object sender, EventArgs e)
        {
            var orderList = MainWindowForm.orders;

            dataGridView1.DataSource = orderList;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("cell doubleclicked");
            Debug.WriteLine(String.Format("{0} {1} {2}", e.RowIndex.ToString(), e.ColumnIndex.ToString(), dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()));

            DataGridViewCellCollection cells = dataGridView1.Rows[e.RowIndex].Cells;

            Order clickedOrder = new Order()
            {
                OrderID = Convert.ToInt32(cells["OrderID"].Value),
                startTime = Convert.ToDateTime(cells["startTime"].Value),
                endTime = Convert.ToDateTime(cells["endTime"].Value),
                ContainerAmount = Convert.ToInt32(cells["ContainerAmount"].Value),
                ContainerType = cells["ContainerType"].Value?.ToString() ?? string.Empty,
                OrderState = cells["OrderState"].Value?.ToString() ?? string.Empty
            }; 

            ShowOrderForm(clickedOrder);
        }
    }
}
