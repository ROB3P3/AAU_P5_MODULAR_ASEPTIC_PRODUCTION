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
    public partial class ProductionQueueForm : Form
    {
        public ProductionQueueForm()
        {
            InitializeComponent();
            RefreshOrders();
        }

        // function to refresh the current orders data grid
        public void RefreshOrders()
        {
            if (InvokeRequired)
            {
                Invoke((Action)RefreshOrders);
                return;
            }

            // clear the current orders data grid
            currentOrdersDataGrid.DataSource = null;

            // load the current orders
            currentOrdersDataGrid.DataSource = MainWindowForm.mesSystem.OrderQueue.ToList();

            // fix text in all the columns headers
            currentOrdersDataGrid.Columns["OrderNumber"].HeaderText = "Order Number";
            currentOrdersDataGrid.Columns["OrderStartTime"].HeaderText = "Start Time";
            currentOrdersDataGrid.Columns["OrderEndTime"].HeaderText = "End Time";
            currentOrdersDataGrid.Columns["OrderCustomer"].HeaderText = "Customer";
            currentOrdersDataGrid.Columns["MedicineType"].HeaderText = "Medicine";
            currentOrdersDataGrid.Columns["OrderState"].HeaderText = "State";
            currentOrdersDataGrid.Columns["ContainerType"].HeaderText = "Container Type";
            currentOrdersDataGrid.Columns["ContainerAmount"].HeaderText = "Container Amount";
            currentOrdersDataGrid.Columns["ProductsTotal"].HeaderText = "Total Products";
            currentOrdersDataGrid.Columns["ProductsInProduction"].HeaderText = "Products in Production";
            currentOrdersDataGrid.Columns["ProductsProduced"].HeaderText = "Products Produced";
            currentOrdersDataGrid.Columns["OrderStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            currentOrdersDataGrid.Columns["OrderEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            currentOrdersDataGrid.Columns["ProductsInOrderList"].Visible = false;
            currentOrdersDataGrid.Columns["ProductsInProductionList"].Visible = false;
        }

        // function to show order details based on a clicked cell
        private void currentOrdersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(currentOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex], MainWindowForm.mesSystem.OrderQueue);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }

        // event function for delete all orders button
        private void DeleteAllOrdersButton_Click(object sender, EventArgs e)
        {
            // check if there are orders in the queue to delete
            if (MainWindowForm.mesSystem.OrderQueue.Count > 0)
            {
                // show a message box to confirm the deletion of all orders
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure you want to delete all orders?", "Delete All Orders", messageBoxButtons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // loop through all orders in the queue and remove them from the queue and database
                    for (LinkedListNode<Order> node = MainWindowForm.mesSystem.OrderQueue.First; node != null;)
                    {
                        LinkedListNode<Order> nextNode = node.Next;
                        if (node.Value.OrderState != OrderState.BUSY)
                        {
                            MainWindowForm.mesSystem.OrderQueue.Remove(node.Value);
                            MainWindowForm.database.DeleteOrder(node.Value.OrderNumber);
                        }
                        node = nextNode;
                    }
                    RefreshOrders();
                }
            }
        }

        // event function for disable all orders button
        private void DisableAllOrdersButton_Click(object sender, EventArgs e)
        {
            // check if there are orders in the queue to disable
            if (MainWindowForm.mesSystem.OrderQueue.Count > 0)
            {
                // show a message box to confirm the disabling of all orders
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure you want to disable all orders?", "Disable All Orders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var currentNode = MainWindowForm.mesSystem.OrderQueue.First;

                    // loop through all orders in the queue and move them to the planned orders list
                    // except for orders that are currently in production
                    while (currentNode != null)
                    {
                        var nextNode = currentNode.Next;
                        if (currentNode.Value.OrderState != OrderState.BUSY)
                        {
                            MainWindowForm.mesSystem.OrderQueue.Remove(currentNode);
                            currentNode.Value.OrderState = OrderState.PEND;
                            MainWindowForm.mesSystem.PlannedOrders.AddLast(currentNode.Value);
                        }
                        currentNode = nextNode;
                    }

                    RefreshOrders();

                    // refresh the planned orders form if open
                    PlannedOrdersForm plannedOrdersForm = Application.OpenForms.OfType<PlannedOrdersForm>().FirstOrDefault();
                    if (plannedOrdersForm != null)
                    {
                        plannedOrdersForm.RefreshOrders();
                    }
                }
            }
        }

        // event function to show right click menu strip when a cell is right clicked
        private DataGridViewCell rightClickedCell;
        private void currentOrdersDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                rightClickedCell = currentOrdersDataGrid.CurrentCell = currentOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                orderRightClickMenuStrip.Show(Control.MousePosition);
            }
        }

        // event function for disable order menu item
        private void disableOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.OrderQueue);
                // check if the order is not currently in production
                if (clickedOrder.OrderState != OrderState.BUSY)
                {
                    // move the order to the planned orders list
                    MainWindowForm.mesSystem.OrderQueue.Remove(clickedOrder);
                    clickedOrder.OrderState = OrderState.PEND;
                    MainWindowForm.mesSystem.PlannedOrders.AddLast(clickedOrder);

                    RefreshOrders();

                    // refresh the planned orders form if open
                    PlannedOrdersForm plannedOrdersForm = Application.OpenForms.OfType<PlannedOrdersForm>().FirstOrDefault();
                    if (plannedOrdersForm != null)
                    {
                        plannedOrdersForm.RefreshOrders();
                    }
                }
            }
        }

        // event function for delete order menu item
        private void deleteOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.OrderQueue);

                // check if the order is not currently in production
                if (clickedOrder.OrderState != OrderState.BUSY)
                {
                    // remove the order from the queue and delete it from the database
                    MainWindowForm.mesSystem.OrderQueue.Remove(clickedOrder);
                    MainWindowForm.database.DeleteOrder(clickedOrder.OrderNumber);
                    RefreshOrders();
                }
            }
        }

        // event function for show details menu item
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.OrderQueue);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }
    }
}
