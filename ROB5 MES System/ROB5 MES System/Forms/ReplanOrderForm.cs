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
    public partial class ReplanOrderForm : Form
    {
        private Order editOrder;
        public ReplanOrderForm()
        {
            InitializeComponent();
        }

        public void UpdateReplanOrderForm(Order order)
        {
            plannedStartDateTimePicker.MinDate = DateTime.Now;
            this.Text = "Replan Order " + order.OrderNumber.ToString();
            OrderNumberDispLabel.Text = order.OrderNumber.ToString();
            if (order.OrderPlannedStartTime < DateTime.Now)
            {
                plannedStartDateTimePicker.Value = DateTime.Now;
                plannedEndDateTimePicker.Value = DateTime.Now.AddHours(1);
            }
            else
            {
                plannedStartDateTimePicker.Value = order.OrderPlannedStartTime;
                plannedEndDateTimePicker.Value = order.OrderPlannedEndTime;
            }

            editOrder = order;
        }

        private void plannedStartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            plannedEndDateTimePicker.Value = plannedStartDateTimePicker.Value.AddHours(1);
        }

        private void replanOrderButton_Click(object sender, EventArgs e)
        {
            if (editOrder != null)
            {
                if(plannedStartDateTimePicker.Value < DateTime.Now)
                {
                    editOrder.OrderPlannedStartTime = DateTime.Now;
                }
                else
                {
                    editOrder.OrderPlannedStartTime = plannedStartDateTimePicker.Value;
                }
                
                editOrder.OrderPlannedEndTime = editOrder.OrderPlannedStartTime.AddHours(1);

                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                String caption = String.Format("Order {0} replanned", editOrder.OrderNumber);
                DialogResult result = MessageBox.Show(caption, caption, messageBoxButtons, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    PlannedOrdersForm plannedOrdersForm = Application.OpenForms.OfType<PlannedOrdersForm>().FirstOrDefault();
                    if (plannedOrdersForm != null)
                    {
                        plannedOrdersForm.RefreshOrders();
                    }

                    this.Close();
                }
            }
        }
    }
}
