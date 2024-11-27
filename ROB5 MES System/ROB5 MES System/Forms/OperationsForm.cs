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
            foreach(var operation in MainWindowForm.operations)
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Index >= 0)
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
    }
}
