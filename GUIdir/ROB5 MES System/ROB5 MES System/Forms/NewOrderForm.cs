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
using ROB5_MES_System.Classes;

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
            ContainerAmountNumeric.Value = 1;
            CompanyNameTextBox.Text = "";
            ContainerTypeComboBox.SelectedIndex = 0;
            // replace max order number with current max order number from all lists
            int maxOrderNumber = MainWindowForm.database.get_order_number();
            OrderNumberDispLabel.Text = maxOrderNumber.ToString();
        }

        // event function for click on start order button
        private void StartOrderButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // pull data from input fields
                string containerType = ContainerTypeComboBox.Text;
                int containerAmount = Convert.ToInt32(ContainerAmountNumeric.Value);
                string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
                DateTime startTime = StartTimePicker.Value;

                // get maximum order id before adding a new order to the list incase the current orders list is empty
                // need to replace the way to get maximum order id as it should be based on all lists and not just the current orders one

                int maxOrderNumber = MainWindowForm.database.get_order_number();
                MainWindowForm.mesSystem.AddOrderToEndOfProductionQueue(containerAmount, containerType, companyName, startTime);

                // show confirmation dialogue of order being created
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                String caption = String.Format("Order {0} created", maxOrderNumber);
                DialogResult result = MessageBox.Show(caption, caption, buttons, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    // reload new order form to update order id and reset input fields
                    LoadNewOrderForm();

                    // refresh the current orders form if it is open 
                    ProductionQueueForm productionQueueForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();

                    if (productionQueueForm != null)
                    {
                        productionQueueForm.RefreshOrders();
                    }
                }
            }
        }

        // event function for click on plan order button
        private void PlanOrderButton_Click(object sender, EventArgs e)
        {
            string containerType = ContainerTypeComboBox.Text;
            int containerAmount = Convert.ToInt32(ContainerAmountNumeric.Value);
            string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
            DateTime startTime = StartTimePicker.Value;

            int maxOrderNumber = MainWindowForm.database.get_order_number();
            Order order = new Order(containerAmount, containerType, companyName, maxOrderNumber, startTime, OrderState.PEND);
            MainWindowForm.mesSystem.PlannedOrders.AddLast(order);
            order.SendOrderInfoToDatabase();

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            String caption = String.Format("Order {0} created", maxOrderNumber);
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
