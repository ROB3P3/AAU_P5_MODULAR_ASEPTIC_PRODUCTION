using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROB5_MES_System
{
    public partial class PlannedOrdersForm : Form
    {
        public PlannedOrdersForm()
        {
            InitializeComponent();
            RefreshOrders();
        }

        // function to refresh the planned orders data grid
        public void RefreshOrders()
        {
            // clears the planned orders data grid
            plannedOrdersDataGrid.DataSource = null;

            // loads the planned orders
            plannedOrdersDataGrid.DataSource = MainWindowForm.mesSystem.PlannedOrders.ToList();

            // fix text in all the columns headers
            plannedOrdersDataGrid.Columns["OrderNumber"].HeaderText = "Order Number";
            plannedOrdersDataGrid.Columns["OrderCustomer"].HeaderText = "Customer";
            plannedOrdersDataGrid.Columns["MedicineType"].HeaderText = "Medicine";
            plannedOrdersDataGrid.Columns["OrderState"].HeaderText = "State";
            plannedOrdersDataGrid.Columns["ContainerType"].HeaderText = "Container Type";
            plannedOrdersDataGrid.Columns["ContainerAmount"].HeaderText = "Container Amount";
            plannedOrdersDataGrid.Columns["ProductsTotal"].HeaderText = "Total Products";
            plannedOrdersDataGrid.Columns["OrderStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            plannedOrdersDataGrid.Columns["OrderEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            plannedOrdersDataGrid.Columns["OrderStartTime"].Visible = false;
            plannedOrdersDataGrid.Columns["OrderEndTime"].Visible = false;
            plannedOrdersDataGrid.Columns["ProductsInOrderList"].Visible = false;
            plannedOrdersDataGrid.Columns["ProductsInProduction"].Visible = false;
            plannedOrdersDataGrid.Columns["ProductsProduced"].Visible = false;
            plannedOrdersDataGrid.Columns["ProductsInProductionList"].Visible = false;
        }

        // event function for whenever the delete all orders button is clicked
        private void DeleteAllOrdersButton_Click(object sender, EventArgs e)
        {
            // checks that there are any orders to delete
            if (MainWindowForm.mesSystem.PlannedOrders.Count > 0)
            {
                // shows a message box to confirm the deletion of all orders
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure you want to delete all planned orders?", "Delete All Planned Orders", messageBoxButtons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // deletes all planned orders from the MES system and the database
                    for (LinkedListNode<Order> node = MainWindowForm.mesSystem.PlannedOrders.First; node != null;)
                    {
                        LinkedListNode<Order> nextNode = node.Next;
                        MainWindowForm.mesSystem.PlannedOrders.Remove(node.Value);
                        MainWindowForm.database.DeleteOrder(node.Value.OrderNumber);
                        node = nextNode;
                    }
                    RefreshOrders();
                }
            }
        }

        // event function for whenever the send all orders to production queue button is clicked
        private void SendOrdersToQueueButton_Click(object sender, EventArgs e)
        {
            // checks that there are any orders to send to the production queue
            if (MainWindowForm.mesSystem.PlannedOrders.Count > 0)
            {
                // shows a message box to confirm the sending of all orders to the production queue
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure you want to enable all planned orders?", "Enable All Planned Orders", messageBoxButtons, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // moves all planned orders to the production queue and clear the planned orders list
                    foreach (var order in MainWindowForm.mesSystem.PlannedOrders)
                    {
                        order.OrderState = OrderState.QUEUE;
                        MainWindowForm.mesSystem.OrderQueue.AddLast(order);
                    }
                    MainWindowForm.mesSystem.PlannedOrders.Clear();

                    RefreshOrders();

                    // refreshes the production queue form if open
                    ProductionQueueForm currentOrdersForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();

                    if (currentOrdersForm != null)
                    {
                        currentOrdersForm.RefreshOrders();
                    }
                }
            }
        }

        // event function for whenever a cell in the data grid is double clicked
        private void plannedOrdersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(plannedOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex], MainWindowForm.mesSystem.PlannedOrders);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }

        // event function to show right click menu strip when a cell is right clicked
        private DataGridViewCell rightClickedCell;
        private void plannedOrdersDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                rightClickedCell = plannedOrdersDataGrid.CurrentCell = plannedOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                orderRightClickMenuStrip.Show(Control.MousePosition);
            }
        }

        // event function for enable order sub menu item in menu strip
        private void enableOrderToolMenuStripItem_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.PlannedOrders);

                // move order from planned orders to production queue
                MainWindowForm.mesSystem.PlannedOrders.Remove(clickedOrder);
                clickedOrder.OrderState = OrderState.QUEUE;
                MainWindowForm.mesSystem.OrderQueue.AddLast(clickedOrder);

                RefreshOrders();

                // update the production queue form if open
                ProductionQueueForm productionQueueForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();
                if (productionQueueForm != null)
                {
                    productionQueueForm.RefreshOrders();
                }
            }
        }

        // event function for delete order sub menu item in menu strip
        private void deleteOrderToolMenuStripItem_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.PlannedOrders);

                // remove order from planned orders and delete from database
                MainWindowForm.mesSystem.PlannedOrders.Remove(clickedOrder);
                MainWindowForm.database.DeleteOrder(clickedOrder.OrderNumber);

                RefreshOrders();
            }
        }

        // event function for show details sub menu item in menu strip
        private void showDetailsToolMenuStripItem_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.PlannedOrders);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }
    }
}
