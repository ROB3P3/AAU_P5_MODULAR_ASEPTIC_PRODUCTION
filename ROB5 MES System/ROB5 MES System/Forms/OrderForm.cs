﻿using System;
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
        public OrderForm()
        {
            InitializeComponent();
        }

        public void UpdateOrderForm(Order order)
        {
            this.Text = "Order " + order.OrderNumber;
            OrderNumberDispLabel.Text = order.OrderNumber.ToString();
            CustomerDispLabel.Text = order.OrderCustomer;
            MedicineDispLabel.Text = order.MedicineType;
            OrderStateDispLabel.Text = order.OrderState.ToString();
            PlannedStartTimeDispLabel.Text = order.OrderPlannedStartTime.ToString("yyyy/MM/dd hh:mm:ss");
            PlannedEndTimeDispLabel.Text = order.OrderPlannedStartTime.AddHours(1).ToString("yyyy/MM/dd hh:mm:ss");
            ContainerAmountDispLabel.Text = order.ContainerAmount.ToString();
            ContainerTypeDispLabel.Text = order.ContainerType.ToString();
            CarrierAmountDispLabel.Text = order.CarriersTotal.ToString();

            CarrierTreeView.Nodes.Clear();

            foreach(var carrier in order.CarriersInOrder)
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
        }
    }
}
