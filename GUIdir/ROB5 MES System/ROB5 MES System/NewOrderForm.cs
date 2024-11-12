using CsvHelper;
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
    public partial class NewOrderForm : Form
    {
        public NewOrderForm()
        {
            InitializeComponent();
            ContainerTypeComboBox.SelectedIndex = 0;
            LoadNewOrderForm();
        }

        // function to load the new order form
        public void LoadNewOrderForm()
        {
            StartTimePicker.MinDate = DateTime.Now;
            int maxOrderID = MainWindowForm.currentOrders.Count > 0 ? MainWindowForm.currentOrders.Max(order => order.OrderID) : -1;
            OrderNumberDispLabel.Text = (maxOrderID + 1).ToString();
        }

        // event function for click on start order button
        private void StartOrderButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // pull data from input fields
                string containerType = ContainerTypeComboBox.Text;
                decimal containerAmount = ContainerAmountNumeric.Value;
                string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
                DateTime startTime = StartTimePicker.Value;

                // get maximum order id before adding a new order to the list incase the current orders list is empty
                // need to replace the way to get maximum order id as it should be based on all lists and not just the current orders one
                int maxOrderID = MainWindowForm.currentOrders.Count > 0 ? MainWindowForm.currentOrders.Max(order => order.OrderID) : -1;

                // add new order to current orders list
                MainWindowForm.currentOrders.Add(new Order()
                {
                    OrderID = maxOrderID + 1,
                    StartTime = startTime,
                    EndTime = startTime.AddMinutes(10),
                    ContainerAmount = Convert.ToInt32(containerAmount),
                    ContainerType = containerType,
                    CompanyName = companyName,
                    State = OrderState.PEND
                });

                // show confirmation dialogue of order being created
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                String caption = String.Format("Order {0} created", MainWindowForm.currentOrders.Max(order => order.OrderID));
                DialogResult result = MessageBox.Show(caption, caption, buttons, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    // reload new order form to update order id and reset input fields
                    LoadNewOrderForm();

                    // refresh the current orders form if it is open 
                    ProductionQueueForm currentOrdersForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();

                    if (currentOrdersForm != null)
                    {
                        currentOrdersForm.RefreshOrders();
                    }
                }
            }
        }

        // event function for click on plan order button
        private void PlanOrderButton_Click(object sender, EventArgs e)
        {
            string containerType = ContainerTypeComboBox.Text;
            decimal containerAmount = ContainerAmountNumeric.Value;
            string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
            DateTime startTime = StartTimePicker.Value;

            int maxOrderID = MainWindowForm.plannedOrders.Count > 0 ? MainWindowForm.plannedOrders.Max(order => order.OrderID) : -1;

            MainWindowForm.plannedOrders.Add(new Order()
            {
                OrderID = maxOrderID + 1,
                StartTime = startTime,
                EndTime = startTime.AddMinutes(10),
                ContainerAmount = Convert.ToInt32(containerAmount),
                ContainerType = containerType,
                CompanyName = companyName,
                State = OrderState.PEND
            });

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            String caption = String.Format("Order {0} created", MainWindowForm.plannedOrders.Max(order => order.OrderID));
            DialogResult result = MessageBox.Show(caption, caption, buttons, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                LoadNewOrderForm();

                PlannedOrdersForm plannedOrdersForm = Application.OpenForms.OfType<PlannedOrdersForm>().FirstOrDefault();

                if (plannedOrdersForm != null)
                {
                    plannedOrdersForm.RefreshOrders();
                }
            }
        }
    }
}
