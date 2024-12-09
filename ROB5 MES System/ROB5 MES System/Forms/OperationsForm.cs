using ROB5_MES_System.Classes;
using ROB5_MES_System.Forms;
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

namespace ROB5_MES_System
{
    public partial class OperationsForm : Form
    {
        public OperationsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the operations into the tree view
        /// </summary>
        public void LoadOperations()
        {
            // clear the operations tree view before refreshing
            OperationsTreeView.Nodes.Clear();

            foreach (var operation in MainWindowForm.operations)
            {
                TreeNode operationNode = new TreeNode();
                operationNode.Text = operation.OperationID + " | " + operation.OperationName;

                OperationsTreeView.Nodes.Add(operationNode);
            }
        }

        // Event function for when the operations form is loaded
        private void OperationsForm_Load(object sender, EventArgs e)
        {
            LoadOperations();
        }

        // Event function for when an operation is selected in the tree view
        private void OperationsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Index >= 0)
            {
                // Update the operation details in the form
                Operation operation = MainWindowForm.operations[e.Node.Index];
                OperationNumberDispLabel.Text = operation.OperationID.ToString();
                OperationNameTextBox.Text = operation.OperationName;
                OperationDescriptionTextBox.Text = operation.OperationDescription;
            }
        }

        // Event function for when the add operation button is clicked
        private void AddOperationButton_Click(object sender, EventArgs e)
        {
            AddOperationForm addOperationForm = new AddOperationForm();
            addOperationForm.ShowDialog();
        }

        // Event function for when the delete operation button is clicked
        private void DeleteOperationButton_Click(object sender, EventArgs e)
        {
            // check that an item is selected in the tree view
            if (OperationsTreeView.SelectedNode != null)
            {
                // show dialog box to confirm deletion
                Operation selectedOperation = MainWindowForm.operations[OperationsTreeView.SelectedNode.Index];
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(String.Format("Are you sure you want to delete operation {0}?", selectedOperation.OperationID), String.Format("Delete Operation {0}", selectedOperation.OperationID.ToString()), messageBoxButtons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // remove operation from operation list and from all planned orders and orders in production queue that contains the operation
                    MainWindowForm.operations.Remove(selectedOperation);
                    MainWindowForm.database.RemoveOperationFromOrders(selectedOperation.OperationID);
                    LoadOperations();
                    // reset these fields as it can happen that no operation is left to be selected
                    OperationNumberDispLabel.Text = "";
                    OperationNameTextBox.Text = "";
                    OperationDescriptionTextBox.Text = "";
                }
            }
        }

        // Event function for when the save operation button is clicked
        // this function is used to update information about a selected operation
        private void SaveOperationButton_Click(object sender, EventArgs e)
        {
            // check that an item is selected in the tree view
            if (OperationsTreeView.SelectedNode != null)
            {
                // check that the operation name and description fields are not empty
                if (OperationNameTextBox.Text.Length > 0 && OperationDescriptionTextBox.Text.Length > 0)
                {
                    // update the operation in the operation list
                    Operation selectedOperation = MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == Convert.ToInt32(OperationNumberDispLabel.Text));
                    selectedOperation.OperationName = OperationNameTextBox.Text;
                    selectedOperation.OperationDescription = OperationDescriptionTextBox.Text;
                    LoadOperations();
                }
            }
        }
    }
}
