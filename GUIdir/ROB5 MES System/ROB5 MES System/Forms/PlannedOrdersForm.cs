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
            plannedOrdersDataGrid.DataSource = null;
            plannedOrdersDataGrid.DataSource = MainWindowForm.mesSystem.PlannedOrders.ToList();

            plannedOrdersDataGrid.Columns["OrderNumber"].HeaderText = "Order Number";
            plannedOrdersDataGrid.Columns["OrderPlannedStartTime"].HeaderText = "Planned Start Time";
            plannedOrdersDataGrid.Columns["OrderPlannedEndTime"].HeaderText = "Planned End Time";
            plannedOrdersDataGrid.Columns["OrderCustomer"].HeaderText = "Customer";
            plannedOrdersDataGrid.Columns["MedicineType"].HeaderText = "Medicine";
            plannedOrdersDataGrid.Columns["OrderState"].HeaderText = "State";
            plannedOrdersDataGrid.Columns["ContainerType"].HeaderText = "Container Type";
            plannedOrdersDataGrid.Columns["ContainerAmount"].HeaderText = "Container Amount";
            plannedOrdersDataGrid.Columns["CarriersTotal"].HeaderText = "Total Carriers";
            plannedOrdersDataGrid.Columns["CarriersInProduction"].HeaderText = "Carriers in Production";
            plannedOrdersDataGrid.Columns["CarriersProduced"].HeaderText = "Carriers Produced";
            plannedOrdersDataGrid.Columns["OrderPlannedStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            plannedOrdersDataGrid.Columns["OrderPlannedEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            plannedOrdersDataGrid.Columns["OrderStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            plannedOrdersDataGrid.Columns["OrderEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            plannedOrdersDataGrid.Columns["OrderName"].Visible = false;
            plannedOrdersDataGrid.Columns["OrderDescription"].Visible = false;
            plannedOrdersDataGrid.Columns["OrderType"].Visible = false;
            plannedOrdersDataGrid.Columns["OrderStartTime"].Visible = false;
            plannedOrdersDataGrid.Columns["OrderEndTime"].Visible = false;
            plannedOrdersDataGrid.Columns["ContainersInProduction"].Visible = false;
            plannedOrdersDataGrid.Columns["ContainersProduced"].Visible = false;
            plannedOrdersDataGrid.Columns["CarriersInOrder"].Visible = false;
        }

        // event function for click on delete all orders button
        private void DeleteAllOrdersButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MainWindowForm.mesSystem.PlannedOrders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to delete all planned orders?", "Delete All Planned Orders", messageBoxButtons, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        for (LinkedListNode<Order> node = MainWindowForm.mesSystem.PlannedOrders.First; node != null;)
                        {
                            LinkedListNode<Order> nextNode = node.Next;
                            MainWindowForm.mesSystem.PlannedOrders.Remove(node.Value);
                            MainWindowForm.database.delete_order(node.Value.OrderNumber);
                            node = nextNode;
                        }
                        RefreshOrders();
                    }
                }
            }
        }

        // event function for enable all orders button
        private void SendOrdersToQueueButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MainWindowForm.mesSystem.PlannedOrders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to enable all planned orders?", "Enable All Planned Orders", messageBoxButtons, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        foreach (var order in MainWindowForm.mesSystem.PlannedOrders)
                        {
                            order.OrderState = OrderState.QUEUE;
                            MainWindowForm.mesSystem.Orders.AddLast(order);
                        }
                        MainWindowForm.mesSystem.PlannedOrders.Clear();

                        RefreshOrders();

                        ProductionQueueForm currentOrdersForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();

                        if (currentOrdersForm != null)
                        {
                            currentOrdersForm.RefreshOrders();
                        }
                    }
                }
            }
        }

        private void plannedOrdersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Order clickedOrder = MainWindowForm.getOrderFromCell(plannedOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex], MainWindowForm.mesSystem.PlannedOrders);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }

        // function to show right click menu strip when a cell is right clicked
        private DataGridViewCell rightClickedCell;
        private void plannedOrdersDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                rightClickedCell = plannedOrdersDataGrid.CurrentCell = plannedOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                orderRightClickMenuStrip.Show(Control.MousePosition);
            }
        }

        private void showDetailsToolMenuStripItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.getOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.PlannedOrders);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }

        private void enableOrderToolMenuStripItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.getOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.PlannedOrders);

                MainWindowForm.mesSystem.PlannedOrders.Remove(clickedOrder);
                clickedOrder.OrderState = OrderState.QUEUE;
                MainWindowForm.mesSystem.Orders.AddLast(clickedOrder);

                RefreshOrders();

                ProductionQueueForm productionQueueForm = Application.OpenForms.OfType<ProductionQueueForm>().FirstOrDefault();
                if (productionQueueForm != null)
                {
                    productionQueueForm.RefreshOrders();
                }
            }
        }

        private void deleteOrderToolMenuStripItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.getOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.PlannedOrders);

                MainWindowForm.mesSystem.PlannedOrders.Remove(clickedOrder);
                MainWindowForm.database.delete_order(clickedOrder.OrderNumber);

                RefreshOrders();
            }
        }

        private void replanOrderToolMenuStripItem_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                ReplanOrderForm replanOrderForm = new ReplanOrderForm();
                replanOrderForm.UpdateReplanOrderForm(MainWindowForm.getOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.PlannedOrders));
                replanOrderForm.ShowDialog();
            }
        }
    }
}
