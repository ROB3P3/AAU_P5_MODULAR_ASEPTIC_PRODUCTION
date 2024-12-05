using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROB5_MES_System
{
    public partial class OrderForm : Form
    {

        private Order _assignedOrder;
        public OrderForm()
        {
            InitializeComponent();
        }

        public void LoadOrderForm(Order order)
        {
            _assignedOrder = order;
            UpdateOrderForm();
        }

        public void UpdateOrderForm()
        {
            if (InvokeRequired)
            {
                Invoke((Action)UpdateOrderForm);
                return;
            }

            this.Text = "Order " + _assignedOrder.OrderNumber;
            OrderNumberDispLabel.Text = _assignedOrder.OrderNumber.ToString();
            CustomerDispLabel.Text = _assignedOrder.OrderCustomer;
            MedicineDispLabel.Text = _assignedOrder.MedicineType;
            ActualStartDispLabel.Text = _assignedOrder.OrderStartTime.HasValue ? _assignedOrder.OrderStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "N/A";
            ActualEndDispLabel.Text = _assignedOrder.OrderEndTime.HasValue ? _assignedOrder.OrderEndTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "N/A";
            OrderStateDispLabel.Text = _assignedOrder.OrderState.ToString();
            ContainerAmountDispLabel.Text = _assignedOrder.ContainerAmount.ToString();
            ContainerTypeDispLabel.Text = _assignedOrder.ContainerType.ToString();
            CarrierAmountDispLabel.Text = _assignedOrder.CarriersTotal.ToString();

            CarrierTreeView.Nodes.Clear();

            foreach(var carrier in _assignedOrder.CarriersInOrder)
            {
                TreeNode carrierNode = new TreeNode();
                String carrierNodeString = "CID: " + carrier.CarrierID + " | Amount: " + carrier.ContainerAmount + " | State: " + carrier.CarrierState;
                if(carrier.CarrierState == OrderState.DONE)
                {
                    carrierNodeString += " | Start: " + carrier.StartTime.ToString("yyyy/MM/dd hh:mm:ss") + " | End: " + carrier.EndTime.ToString("yyyy/MM/dd hh:mm:ss");
                    carrierNode.BackColor = Color.FromArgb(255, 128, 128, 255);
                } else if(carrier.CarrierState == OrderState.BUSY)
                {
                    carrierNodeString += " | Start: " + carrier.StartTime.ToString("yyyy/MM/dd hh:mm:ss");
                    carrierNode.BackColor = Color.FromArgb(255, 255, 255, 128);
                    carrierNode.Expand();
                }

                carrierNode.Text = carrierNodeString;

                foreach(var task in carrier.CompletedTasks)
                {
                    String taskNodeString = "TID: " + task.TaskId.ToString() + " | Task: " + task.TaskName + " | State: " + task.Status + " | Start: " + task.StartTime + " | End: " + task.EndTime;

                    TreeNode taskNode = new TreeNode(taskNodeString);

                    taskNode.BackColor = Color.FromArgb(255, 128, 128, 255);

                    carrierNode.Nodes.Add(taskNode);
                }

                foreach (var task in carrier.TaskQueue)
                {
                    String taskNodeString = "TID: " + task.TaskId.ToString() + " | Task: " + task.TaskName + " | State: " + task.Status;

                    TreeNode taskNode = new TreeNode(taskNodeString);

                    carrierNode.Nodes.Add(taskNode);
                }

                CarrierTreeView.Nodes.Add(carrierNode);
            }

            foreach (var carrier in _assignedOrder.CarriersInProductionList)
            {
                TreeNode carrierNode = new TreeNode();
                String carrierNodeString = "CID: " + carrier.CarrierID + " | Amount: " + carrier.ContainerAmount + " | State: " + carrier.CarrierState;
                if (carrier.CarrierState == OrderState.DONE)
                {
                    carrierNodeString += " | Start: " + carrier.StartTime.ToString("yyyy/MM/dd hh:mm:ss") + " | End: " + carrier.EndTime.ToString("yyyy/MM/dd hh:mm:ss");
                    carrierNode.BackColor = Color.FromArgb(255, 128, 128, 255);
                }
                else if (carrier.CarrierState == OrderState.BUSY)
                {
                    carrierNodeString += " | Start: " + carrier.StartTime.ToString("yyyy/MM/dd hh:mm:ss");
                    carrierNode.BackColor = Color.FromArgb(255, 255, 255, 128);
                }

                carrierNode.Text = carrierNodeString;

                foreach (var task in carrier.CompletedTasks)
                {
                    String taskNodeString = "TID: " + task.TaskId.ToString() + " | Task: " + task.TaskName + " | State: " + task.Status + " | Start: " + task.StartTime + " | End: " + task.EndTime;

                    TreeNode taskNode = new TreeNode(taskNodeString);

                    taskNode.BackColor = Color.FromArgb(255, 128, 128, 255);

                    carrierNode.Nodes.Add(taskNode);
                }

                foreach (var task in carrier.TaskQueue)
                {
                    String taskNodeString = "TID: " + task.TaskId.ToString() + " | Task: " + task.TaskName + " | State: " + task.Status;

                    TreeNode taskNode = new TreeNode(taskNodeString);

                    carrierNode.Nodes.Add(taskNode);
                }

                CarrierTreeView.Nodes.Add(carrierNode);
            }
        }
    }
}
