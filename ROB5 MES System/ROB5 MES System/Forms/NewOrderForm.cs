using System.Data;
using ROB5_MES_System.Classes;

namespace ROB5_MES_System
{
    public partial class NewOrderForm : Form
    {
        public NewOrderForm()
        {
            InitializeComponent();
            ContainerTypeComboBox.SelectedIndex = 0;
            OperationsListBox.Items.Clear();
            OperationsListBox.DisplayMember = "DisplayText";
            OperationsListBox.ValueMember = "OperationID";
            OperationsComboBox.DataSource = MainWindowForm.operations;
            OperationsComboBox.DisplayMember = "DisplayText";
            OperationsComboBox.ValueMember = "OperationID";
            LoadNewOrderForm();
        }

        /// <summary>
        /// Load the New Order form
        /// </summary>
        public void LoadNewOrderForm()
        {
            // replace max order number with current max order number from all lists
            int maxOrderNumber = MainWindowForm.database.GetMaxOrderNumber();
            OrderNumberDispLabel.Text = maxOrderNumber.ToString();

            // replace operations list with new operations list incase new operations have been added
            //OperationsListBox.Items.Clear();
            //OperationsListBox.DisplayMember = "DisplayText";
            //OperationsListBox.ValueMember = "OperationID";
            //OperationsComboBox.DataSource = MainWindowForm.operations;
            //OperationsComboBox.DisplayMember = "DisplayText";
            //OperationsComboBox.ValueMember = "OperationID";
        }

        // event function for click on start order button
        private void StartOrderButton_Click(object sender, EventArgs e)
        {
            // get all operations from the operations list box and check if there is at least 1 operation added
            List<Operation> orderOperations = OperationsListBox.Items.Cast<Operation>().ToList();
            if (orderOperations.Count > 0)
            {
                // pull data from input fields
                string containerType = ContainerTypeComboBox.Text;
                int containerAmount = Convert.ToInt32(ContainerAmountNumeric.Value);
                string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
                string medicineType = MedicineTypeBox.Text.Length == 0 ? "No Medicine" : MedicineTypeBox.Text;
                int maxOrderNumber = MainWindowForm.database.GetMaxOrderNumber();

                MainWindowForm.mesSystem.AddOrderToEndOfProductionQueue(containerAmount, containerType, companyName, medicineType, orderOperations);

                // show confirmation dialogue of order being created
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                String caption = String.Format("Order {0} created", maxOrderNumber);
                DialogResult result = MessageBox.Show(caption, caption, buttons, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    // reload new order form to update order id
                    LoadNewOrderForm();

                    // refresh the production queue form if it is open 
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
            // get all operations from the operations list box and check if there is at least 1 operation added
            List<Operation> orderOperations = OperationsListBox.Items.Cast<Operation>().ToList();
            if (orderOperations.Count > 0)
            {
                // pull data from input fields
                string containerType = ContainerTypeComboBox.Text;
                int containerAmount = Convert.ToInt32(ContainerAmountNumeric.Value);
                string companyName = CompanyNameTextBox.Text.Length == 0 ? "No Company" : CompanyNameTextBox.Text;
                string medicineType = MedicineTypeBox.Text.Length == 0 ? "No Medicine" : MedicineTypeBox.Text;
                int maxOrderNumber = MainWindowForm.database.GetMaxOrderNumber();

                MainWindowForm.mesSystem.AddOrderToEndOfPlannedOrders(containerAmount, containerType, companyName, medicineType, orderOperations);

                // show confirmation dialogue of order being created
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                String caption = String.Format("Order {0} created", maxOrderNumber);
                DialogResult result = MessageBox.Show(caption, caption, buttons, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    // reload new order form to update order id
                    LoadNewOrderForm();

                    // refresh the planned orders form if it is open 
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

        // event function for click on add operation button
        private void AddOperationButton_Click(object sender, EventArgs e)
        {
            if (OperationsComboBox.SelectedItem != null)
            {
                OperationsListBox.Items.Add(OperationsComboBox.SelectedItem);
            }
        }

        // event function for click on remove operation button
        private void RemoveOperationButton_Click(object sender, EventArgs e)
        {
            if (OperationsListBox.SelectedItem != null)
            {
                OperationsListBox.Items.Remove(OperationsListBox.SelectedItem);
            }
        }
    }
}
