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
    public partial class PlannedOrdersForm : Form
    {
        public PlannedOrdersForm()
        {
            InitializeComponent();
            RefreshOrders();
        }

        public void RefreshOrders()
        {
            plannedOrdersDataGrid.DataSource = null;
            plannedOrdersDataGrid.DataSource = MainWindowForm.plannedOrders;
        }

        private void DeleteAllOrdersButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MainWindowForm.plannedOrders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to delete all planned orders?", "Delete All Planned Orders", messageBoxButtons, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        MainWindowForm.plannedOrders.Clear();
                        RefreshOrders();
                    }
                }
            }
        }

        private void EnableAllOrdersButton_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(MainWindowForm.plannedOrders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to enable all planned orders?", "Enable All Planned Orders", messageBoxButtons, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        MainWindowForm.currentOrders.AddRange(MainWindowForm.plannedOrders);
                        MainWindowForm.plannedOrders.Clear();
                        RefreshOrders();

                        CurrentOrdersForm currentOrdersForm = Application.OpenForms.OfType<CurrentOrdersForm>().FirstOrDefault();

                        if (currentOrdersForm != null)
                        {
                            currentOrdersForm.RefreshOrders();
                        }
                    }
                }
            }
        }
    }
}
