using System;
using System.Diagnostics;
using System.Windows.Forms;
using ROB5_MES_System.Classes;

namespace ROB5_MES_System
{
    public partial class MainWindowForm : Form
    {
        public static Database database = new Database("localhost", "volle", "volle", "production");
        public static MESSystem mesSystem;
        // applications/modules that are connected to the system
        public static List<PLCInfo> plcs { get; set; } 
        public MainWindowForm()
        {
            mesSystem = new MESSystem();
            plcs = plcList();

            InitializeComponent();

            database.get_production_queue();
            database.get_planned_orders();

            // test timer for every second to update the date label
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:MM:ss");
        }

        public List<PLCInfo> plcList()
        {
            List<PLCInfo> plcList = new List<PLCInfo>();
            // add the plc modules to the list
            // PLC 09
            plcList.Add(new PLCInfo(9, 1, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC09_MAIN", "opc.tcp://172.20.13.1:4840"));
            // PLC 08
            plcList.Add(new PLCInfo(8, 2, "ns=2;s=|var|CECC-LK.Application.MODULE_PLC08_MAIN", "opc.tcp://172.20.1.1:4840"));

            return plcList;
        }


        /// <summary>
        /// timer tick event to update the date label every second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        // event function to show submenu items under production control of left menubar 
        private void ProductionControlMenuItem_Click(object sender, EventArgs e)
        {
            SystemStatusSubMenuItem.Visible = !SystemStatusSubMenuItem.Visible;
            OperationsSubMenuItem.Visible = !OperationsSubMenuItem.Visible;
            WorkPlansSubMenuItem.Visible = !WorkPlansSubMenuItem.Visible;
        }

        // event function to show submenu items under order management of left menubar
        private void OrderManagementMenuItem_Click(object sender, EventArgs e)
        {
            CurrentOrdersSubMenuItem.Visible = !CurrentOrdersSubMenuItem.Visible;
            PlannedOrdersSubMenuItem.Visible = !PlannedOrdersSubMenuItem.Visible;
            NewOrderSubMenuItem.Visible = !NewOrderSubMenuItem.Visible;
            FinishedOrdersSubMenuItem.Visible = !FinishedOrdersSubMenuItem.Visible;
        }

        private void exitToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Close();
            }
        }

        // event function to show system status form
        private SystemStatusForm systemStatusForm;
        private void SystemStatusSubMenuItem_Click(object sender, EventArgs e)
        {
            if (systemStatusForm == null || systemStatusForm.IsDisposed)
            {
                systemStatusForm = new SystemStatusForm();
                systemStatusForm.MdiParent = this;
                systemStatusForm.Show();
            }
            else
            {
                systemStatusForm.Activate();
            }
        }

        // event function to show current orders form
        private ProductionQueueForm productionQueueForm;
        private void CurrentOrdersSubMenuItem_Click(object sender, EventArgs e)
        {
            if (productionQueueForm == null || productionQueueForm.IsDisposed)
            {
                productionQueueForm = new ProductionQueueForm();
                productionQueueForm.MdiParent = this;
                productionQueueForm.Show();
            }
            else
            {
                productionQueueForm.Activate();
            }
        }

        // event function to show new order form
        private NewOrderForm newOrderForm;
        private void NewOrderSubMenuItem_Click(object sender, EventArgs e)
        {
            if (newOrderForm == null || newOrderForm.IsDisposed)
            {
                newOrderForm = new NewOrderForm();
                newOrderForm.MdiParent = this;
                newOrderForm.Show();
            }
            else
            {
                newOrderForm.Activate();
            }
        }

        // event function to show planned orders form
        private PlannedOrdersForm plannedOrdersForm;
        private void PlannedOrdersSubMenuItem_Click(object sender, EventArgs e)
        {
            if (plannedOrdersForm == null || plannedOrdersForm.IsDisposed)
            {
                plannedOrdersForm = new PlannedOrdersForm();
                plannedOrdersForm.MdiParent = this;
                plannedOrdersForm.Show();
            }
            else
            {
                plannedOrdersForm.Activate();
            }
        }

        // event function to show finished orders form
        private FinishedOrdersForm finishedOrdersForm;
        private void FinishedOrdersSubMenuItem_Click(object sender, EventArgs e)
        {
            if (finishedOrdersForm == null || finishedOrdersForm.IsDisposed)
            {
                finishedOrdersForm = new FinishedOrdersForm();
                finishedOrdersForm.MdiParent = this;
                finishedOrdersForm.Show();
            }
            else
            {
                finishedOrdersForm.Activate();
            }
        }

        // event function to show operations form
        private OperationsForm operationsForm;
        private void OperationsSubMenuItem_Click(object sender, EventArgs e)
        {
            if (operationsForm == null || operationsForm.IsDisposed)
            {
                operationsForm = new OperationsForm();
                operationsForm.MdiParent = this;
                operationsForm.Show();
            }
            else
            {
                operationsForm.Activate();
            }
        }

        // event function to show work plans form
        private WorkPlansForm workPlansForm;
        private void WorkPlansSubMenuItem_Click(object sender, EventArgs e)
        {
            if (workPlansForm == null || workPlansForm.IsDisposed)
            {
                workPlansForm = new WorkPlansForm();
                workPlansForm.MdiParent = this;
                workPlansForm.Show();
            }
            else
            {
                workPlansForm.Activate();
            }
        }

        // function to show the order details form
        private static OrderForm orderForm;
        public static void ShowOrderForm(Order clickedOrder, Form mdiParent)
        {
            if (orderForm == null || orderForm.IsDisposed)
            {
                orderForm = new OrderForm();
                orderForm.MdiParent = mdiParent;
                orderForm.Show();
            }
            else
            {
                orderForm.BringToFront();
            }
            orderForm.UpdateOrderForm(clickedOrder);
        }

        public static Order getOrderFromCell(DataGridViewCell cell, LinkedList<Order> list)
        {
            return mesSystem.GetOrderAtIndex(cell.RowIndex, list);
        }
    }
}
