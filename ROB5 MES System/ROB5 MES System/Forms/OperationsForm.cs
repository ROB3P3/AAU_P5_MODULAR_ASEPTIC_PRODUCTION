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

        public void LoadOperations()
        {
            OperationsTreeView.Nodes.Clear();
            foreach (var operation in MainWindowForm.operations)
            {
                TreeNode operationNode = new TreeNode();
                operationNode.Text = operation.OperationID + " | " + operation.OperationName;

                OperationsTreeView.Nodes.Add(operationNode);
            }
        }

        private void OperationsForm_Load(object sender, EventArgs e)
        {
            LoadOperations();
        }

        private void OperationsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Index >= 0)
            {
                Operation operation = MainWindowForm.operations[e.Node.Index];
                OperationNumberDispLabel.Text = operation.OperationID.ToString();
                OperationNameTextBox.Text = operation.OperationName;
                OperationDescriptionTextBox.Text = operation.OperationDescription;
            }
        }

        private void AddOperationButton_Click(object sender, EventArgs e)
        {
            AddOperationForm addOperationForm = new AddOperationForm();
            addOperationForm.ShowDialog();
        }

        private void DeleteOperationButton_Click(object sender, EventArgs e)
        {
            if (OperationsTreeView.SelectedNode != null)
            {
                Operation selectedOperation = MainWindowForm.operations[OperationsTreeView.SelectedNode.Index];
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(String.Format("Are you sure you want to delete operation {0}?", selectedOperation.OperationID), String.Format("Delete Operation {0}", selectedOperation.OperationID.ToString()), messageBoxButtons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    MainWindowForm.operations.Remove(selectedOperation);
                    MainWindowForm.database.remove_operation_from_orders(selectedOperation.OperationID);
                    LoadOperations();
                    OperationNumberDispLabel.Text = "";
                    OperationNameTextBox.Text = "";
                    OperationDescriptionTextBox.Text = "";
                }
            }
        }

        private void SaveOperationButton_Click(object sender, EventArgs e)
        {
            if(OperationsTreeView.SelectedNode != null)
            {
                if(OperationNameTextBox.Text.Length > 0 && OperationDescriptionTextBox.Text.Length > 0)
                {
                    Operation selectedOperation = MainWindowForm.operations.FirstOrDefault(operation => operation.OperationID == Convert.ToInt32(OperationNumberDispLabel.Text));
                    selectedOperation.OperationName = OperationNameTextBox.Text;
                    selectedOperation.OperationDescription = OperationDescriptionTextBox.Text;
                    LoadOperations();
                }
            }
        }
    }
}
