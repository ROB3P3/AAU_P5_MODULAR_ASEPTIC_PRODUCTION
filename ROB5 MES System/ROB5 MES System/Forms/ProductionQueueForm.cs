﻿using System;
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

            currentOrdersDataGrid.DataSource = null;
            currentOrdersDataGrid.DataSource = MainWindowForm.mesSystem.Orders.ToList();

            currentOrdersDataGrid.Columns["OrderNumber"].HeaderText = "Order Number";
            currentOrdersDataGrid.Columns["OrderStartTime"].HeaderText = "Start Time";
            currentOrdersDataGrid.Columns["OrderEndTime"].HeaderText = "End Time";
            currentOrdersDataGrid.Columns["OrderCustomer"].HeaderText = "Customer";
            currentOrdersDataGrid.Columns["MedicineType"].HeaderText = "Medicine";
            currentOrdersDataGrid.Columns["OrderState"].HeaderText = "State";
            currentOrdersDataGrid.Columns["ContainerType"].HeaderText = "Container Type";
            currentOrdersDataGrid.Columns["ContainerAmount"].HeaderText = "Container Amount";
            currentOrdersDataGrid.Columns["CarriersTotal"].HeaderText = "Total Carriers";
            currentOrdersDataGrid.Columns["CarriersInProduction"].HeaderText = "Carriers in Production";
            currentOrdersDataGrid.Columns["CarriersProduced"].HeaderText = "Carriers Produced";
            currentOrdersDataGrid.Columns["OrderStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            currentOrdersDataGrid.Columns["OrderEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            currentOrdersDataGrid.Columns["ContainersInProduction"].Visible = false;
            currentOrdersDataGrid.Columns["ContainersProduced"].Visible = false;
            currentOrdersDataGrid.Columns["CarriersInOrder"].Visible = false;
            currentOrdersDataGrid.Columns["CarriersInProductionList"].Visible = false;
        }

        // function to show order details based on a clicked cell
        private void currentOrdersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Order clickedOrder = MainWindowForm.getOrderFromCell(currentOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex], MainWindowForm.mesSystem.Orders);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
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
                Order clickedOrder = MainWindowForm.getOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.Orders);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }

        // event function for disable order sub menu item in menu strip
        private void disableOrderToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rightClickedCell != null)
            {
                Order clickedOrder = MainWindowForm.getOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.Orders);
                if (clickedOrder.OrderState != OrderState.BUSY)
                {
                    MainWindowForm.mesSystem.Orders.Remove(clickedOrder);
                    clickedOrder.OrderState = OrderState.PEND;
                    MainWindowForm.mesSystem.PlannedOrders.AddLast(clickedOrder);

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
                Order clickedOrder = MainWindowForm.getOrderFromCell(rightClickedCell, MainWindowForm.mesSystem.Orders);

                if(clickedOrder.OrderState != OrderState.BUSY)
                {
                    MainWindowForm.mesSystem.Orders.Remove(clickedOrder);
                    MainWindowForm.database.delete_order(clickedOrder.OrderNumber);
                    RefreshOrders();
                }
            }
        }

        // event function for delete all orders button
        private void DeleteAllOrdersButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MainWindowForm.mesSystem.Orders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to delete all orders?", "Delete All Orders", messageBoxButtons, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        for(LinkedListNode<Order> node = MainWindowForm.mesSystem.Orders.First; node != null;)
                        {
                            LinkedListNode<Order> nextNode = node.Next;
                            if(node.Value.OrderState != OrderState.BUSY)
                            {
                                MainWindowForm.mesSystem.Orders.Remove(node.Value);
                                MainWindowForm.database.delete_order(node.Value.OrderNumber);
                            }
                            node = nextNode;
                        }
                        RefreshOrders();
                    }
                }
            }
        }

        // event function for the disable all orders button
        private void DisableAllOrdersButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MainWindowForm.mesSystem.Orders.Count > 0)
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to disable all orders?", "Disable All Orders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var currentNode = MainWindowForm.mesSystem.Orders.First;

                        while (currentNode != null)
                        {
                            var nextNode = currentNode.Next;
                            if (currentNode.Value.OrderState != OrderState.BUSY)
                            {
                                MainWindowForm.mesSystem.Orders.Remove(currentNode);
                                currentNode.Value.OrderState = OrderState.PEND;
                                MainWindowForm.mesSystem.PlannedOrders.AddLast(currentNode.Value);
                            }
                            currentNode = nextNode;
                        }

                        RefreshOrders();

                        PlannedOrdersForm plannedOrdersForm = Application.OpenForms.OfType<PlannedOrdersForm>().FirstOrDefault();
                        if (plannedOrdersForm != null)
                        {
                            plannedOrdersForm.RefreshOrders();
                        }
                    }
                }
            }
        }
    }
}
