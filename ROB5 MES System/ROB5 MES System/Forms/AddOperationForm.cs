using ROB5_MES_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROB5_MES_System.Forms
{
    public partial class AddOperationForm : Form
    {
        public AddOperationForm()
        {
            InitializeComponent();
            int maxOperationNumber = MainWindowForm.operations.Max(operation => operation.OperationID);
            OperationNumberNumeric.Value = maxOperationNumber < 999 ? maxOperationNumber + 1 : 1;
        }

        private void AddOperationButton_Click(object sender, EventArgs e)
        {
            if (OperationNameTextBox.Text.Length > 0 && OperationDescriptionTextBox.Text.Length > 0)
            {
                if (!MainWindowForm.operations.Any(operation => operation.OperationID == Convert.ToInt32(OperationNumberNumeric.Value)))
                {
                    Operation newOperation = new Operation(Convert.ToInt32(OperationNumberNumeric.Value), OperationNameTextBox.Text, OperationDescriptionTextBox.Text);
                    MainWindowForm.operations.Add(newOperation);

                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                    String caption = String.Format("Operation {0} added", newOperation.OperationID);
                    DialogResult result = MessageBox.Show(caption, caption, messageBoxButtons, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
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