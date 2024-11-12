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
            currentOrdersDataGrid.DataSource = null;
            currentOrdersDataGrid.DataSource = MainWindowForm.currentOrders;
        }

        // function to get an order based on a cell clicked in the current orders data grid
        public Order getOrderFromCell(DataGridViewCell cell)
        {
            DataGridViewCellCollection rowCells = currentOrdersDataGrid.Rows[cell.RowIndex].Cells;

            Order order = new Order()
            {
                OrderID = Convert.ToInt32(rowCells["OrderID"].Value),
                StartTime = Convert.ToDateTime(rowCells["startTime"].Value),
                EndTime = Convert.ToDateTime(rowCells["endTime"].Value),
                ContainerAmount = Convert.ToInt32(rowCells["ContainerAmount"].Value),
                ContainerType = rowCells["ContainerType"].Value?.ToString() ?? string.Empty,
                CompanyName = rowCells["CompanyName"].Value?.ToString() ?? string.Empty,
                State = Enum.TryParse<OrderState>(rowCells["State"].Value.ToString(), out OrderState state) ? state : OrderState.PEND
            };

            return order;
        }

        // function to show the order details form
        private OrderForm orderForm;
        private void ShowOrderForm(Order clickedOrder)
        {
            if (orderForm == null || orderForm.IsDisposed)
            {
                orderForm = new OrderForm();
                orderForm.MdiParent = this.MdiParent;
                orderForm.Show();
            }
            else
            {
                orderForm.BringToFront();
            }
            orderForm.UpdateOrderForm(clickedOrder);
        }

        // function to show order details based on a clicked cell
        private void currentOrdersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Order clickedOrder = getOrderFromCell(currentOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                ShowOrderForm(clickedOrder);
            }
        }

        // function to show right click menu strip when a cell is right clicked
        private DataGridViewCell rightClickedCell;
        private void currentOrdersDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                rightClickedCell = currentOrdersDataGrid.CurrentCell = currentOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                orderRightClickMenuStrip.Show(Control.MousePosition);
            }
        }

        // event function for show details sub menu item in menu strip
        private void showDetailsToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                Order clickedOrder = getOrderFromCell(rightClickedCell);

                ShowOrderForm(clickedOrder);
            }
        }

        // event function for disable order sub menu item in menu strip
        private void disableOrderToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                Order clickedOrder = getOrderFromCell(rightClickedCell);
                if(clickedOrder.State != OrderState.BUSY)
                {
                    MainWindowForm.currentOrders.RemoveAll(order => order.OrderID == clickedOrder.OrderID);
                    MainWindowForm.plannedOrders.Add(clickedOrder);

                    RefreshOrders();

                    PlannedOrdersForm plannedOrdersForm = Application.OpenForms.OfType<PlannedOrdersForm>().FirstOrDefault();
                    if (plannedOrdersForm != null)
                    {
                        plannedOrdersForm.RefreshOrders();
                    }
                }
            }
        }

        // event function for delete order sub menu item in menu strip
        private void deleteOrderToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                Order clickedOrder = getOrderFromCell(rightClickedCell);

                MainWindowForm.currentOrders.RemoveAll(order => order.OrderID == clickedOrder.OrderID);

                RefreshOrders();
            }
        }

        // event function for delete all orders button
        private void DeleteAllOrdersButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MainWindowForm.currentOrders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to delete all orders?", "Delete All Orders", messageBoxButtons, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        MainWindowForm.currentOrders.Clear();
                        RefreshOrders();
                    }
                }
            }
        }

        // event function for the disable all orders button
        private void DisableAllOrdersButton_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(MainWindowForm.currentOrders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to disable all orders?", "Disable All Orders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(result == DialogResult.Yes)
                    {
                        var selectedOrders = MainWindowForm.currentOrders.Where(order => order.State != OrderState.BUSY).ToList();
                        MainWindowForm.currentOrders = MainWindowForm.currentOrders.Except(selectedOrders).ToList();
                        MainWindowForm.plannedOrders.AddRange(selectedOrders);
                        RefreshOrders();

                        PlannedOrdersForm plannedOrdersForm = Application.OpenForms.OfType<PlannedOrdersForm>().FirstOrDefault();
                        if(plannedOrdersForm != null)
                        {
                            plannedOrdersForm.RefreshOrders();
                        }
                    }
                }
            }
        }
    }
}
