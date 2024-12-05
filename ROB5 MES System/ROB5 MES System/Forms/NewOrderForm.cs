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
            // replace max order number with current max order number from all lists
            int maxOrderNumber = MainWindowForm.database.get_order_number();
            OrderNumberDispLabel.Text = maxOrderNumber.ToString();

            OperationsListBox.Items.Clear();
            OperationsListBox.DisplayMember = "DisplayText";
            OperationsListBox.ValueMember = "OperationID";
            OperationsComboBox.DataSource = MainWindowForm.operations;
            OperationsComboBox.DisplayMember = "DisplayText";
            OperationsComboBox.ValueMember = "OperationID";
        }

        // event function for click on start order button
        private void StartOrderButton_Click(object sender, EventArgs e)
        {
            // pull data from input fields
            List<Operation> orderOperations = OperationsListBox.Items.Cast<Operation>().ToList();
            if(orderOperations.Count > 0)
            {
                string containerType = ContainerTypeComboBox.Text;
                int containerAmount = Convert.ToInt32(ContainerAmountNumeric.Value);
                string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
                string medicineType = MedicineTypeBox.Text.Length == 0 ? "No Medicine" : MedicineTypeBox.Text;

                int maxOrderNumber = MainWindowForm.database.get_order_number();
                MainWindowForm.mesSystem.AddOrderToEndOfProductionQueue(containerAmount, containerType, companyName, medicineType, orderOperations);

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
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                String caption = "At least 1 operation must be selected";
                DialogResult result = MessageBox.Show(caption, caption, buttons, MessageBoxIcon.Warning);
            }
        }

        // event function for click on plan order button
        private void PlanOrderButton_Click(object sender, EventArgs e)
        {
            List<Operation> orderOperations = OperationsListBox.Items.Cast<Operation>().ToList();
            if(orderOperations.Count > 0)
            {
                string containerType = ContainerTypeComboBox.Text;
                int containerAmount = Convert.ToInt32(ContainerAmountNumeric.Value);
                string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
                string medicineType = MedicineTypeBox.Text.Length == 0 ? "No Medicine" : MedicineTypeBox.Text;

                int maxOrderNumber = MainWindowForm.database.get_order_number();
                Order order = new Order(containerAmount, containerType, companyName, maxOrderNumber, OrderState.PEND, medicineType, orderOperations);
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
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                String caption = "At least 1 operation must be selected";
                DialogResult result = MessageBox.Show(caption, caption, buttons, MessageBoxIcon.Warning);
            }
        }

        private void AddOperationButton_Click(object sender, EventArgs e)
        {
            if (OperationsComboBox.SelectedItem != null)
            {
                OperationsListBox.Items.Add(OperationsComboBox.SelectedItem);
            }
        }

        private void RemoveOperationButton_Click(object sender, EventArgs e)
        {
            if (OperationsListBox.SelectedItem != null)
            {
                OperationsListBox.Items.Remove(OperationsListBox.SelectedItem);
            }
        }
    }
}
