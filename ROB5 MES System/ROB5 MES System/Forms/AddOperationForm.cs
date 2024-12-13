using ROB5_MES_System.Classes;

namespace ROB5_MES_System.Forms
{
    public partial class AddOperationForm : Form
    {
        /// <summary>
        /// Constructor for the AddOperationForm.
        /// The form is used to add a new operation to the system
        /// </summary>
        public AddOperationForm()
        {
            InitializeComponent();
            // gets the maximum operation number from the operations list and sets the operation number to the next available number
            int maxOperationNumber = MainWindowForm.operations.Count > 0 ? MainWindowForm.operations.Max(operation => operation.OperationID) : 0;
            OperationNumberNumeric.Value = maxOperationNumber < 999 ? maxOperationNumber + 1 : 1;
        }

        // Event function for whenever the add operation button is clicked
        private void AddOperationButton_Click(object sender, EventArgs e)
        {
            if (OperationNameTextBox.Text.Length > 0 && OperationDescriptionTextBox.Text.Length > 0)
            {
                // checks if an operation with the same operation id already exists 
                if (!MainWindowForm.operations.Any(operation => operation.OperationID == Convert.ToInt32(OperationNumberNumeric.Value)))
                {
                    // creates a new operation and adds it to the operations list
                    Operation newOperation = new Operation(Convert.ToInt32(OperationNumberNumeric.Value), OperationNameTextBox.Text, OperationDescriptionTextBox.Text);
                    MainWindowForm.operations.Add(newOperation);

                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                    String caption = String.Format("Operation {0} added", newOperation.OperationID);
                    DialogResult result = MessageBox.Show(caption, caption, messageBoxButtons, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        // updates the operation form if it is open
                        OperationsForm operationsForm = Application.OpenForms.OfType<OperationsForm>().FirstOrDefault();
                        if (operationsForm != null)
                        {
                            operationsForm.LoadOperations();
                        }

                        this.Close();
                    }
                }
                else
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                    String caption = String.Format("Operation {0} already exists", Convert.ToInt32(OperationNumberNumeric.Value));
                    DialogResult result = MessageBox.Show(caption, caption, messageBoxButtons, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                String caption = "Operation name and description must be at least 1 character long";
                DialogResult result = MessageBox.Show(caption, caption, messageBoxButtons, MessageBoxIcon.Warning);
            }
        }
    }
}