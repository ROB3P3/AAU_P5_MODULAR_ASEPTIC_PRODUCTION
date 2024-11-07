using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ROB5_MES_System
{
    public partial class MainWindowForm : Form
    {
        // orders that are currently in queue to be processed
        public static List<Order> currentOrders { get; set; }
        // orders that are planned to be processed
        public static List<Order> plannedOrders { get; set; }
        // orders that have been processed - pull this data from database upon initialization of program
        // then update it as orders are processed
        public static List<Order> finishedOrders { get; set; }
        // applications/modules that are connected to the system
        public static List<ApplicationClass> applications { get; set; }
        public MainWindowForm()
        {
            currentOrders = GetOrders();
            plannedOrders = GetOrders();
            applications = GetApplications();
            InitializeComponent();

            // test timer for every second to update the date label
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:MM:ss");
        }

        // function to test order list by manually adding orders
        // can change function to pull finished/planned/current orders from database upon initialization
        private List<Order>? GetOrders()
        {
            var orderList = new List<Order>();

            orderList.Add(new Order() { OrderID = 0, StartTime = DateTime.Now, EndTime = DateTime.Now, ContainerAmount = 10, ContainerType = "vials", CompanyName = "N/A", State = OrderState.DONE });
            orderList.Add(new Order() { OrderID = 1, StartTime = DateTime.Now, EndTime = DateTime.Now, ContainerAmount = 29, ContainerType = "pre-filled syringes", CompanyName = "N/A", State = OrderState.PEND });
            orderList.Add(new Order() { OrderID = 2, StartTime = DateTime.Now, EndTime = DateTime.Now, ContainerAmount = 100, ContainerType = "syringes", CompanyName = "N/A", State = OrderState.PEND });
            orderList.Add(new Order() { OrderID = 3, StartTime = DateTime.Now, EndTime = DateTime.Now, ContainerAmount = 1, ContainerType = "vials", CompanyName = "N/A", State = OrderState.BUSY });
            orderList.Add(new Order() { OrderID = 4, StartTime = DateTime.Now, EndTime = DateTime.Now, ContainerAmount = 5, ContainerType = "syringes", CompanyName = "N/A", State = OrderState.DONE });

            return orderList;
        }

        // function to test application list by manually adding applications
        // can change function to pull applications from database upon initialization
        private List<ApplicationClass>? GetApplications()
        {
            var applicationList = new List<ApplicationClass>();

            applicationList.Add(new ApplicationClass() { ID = 0, Name = "Filling", Connected = true });
            applicationList.Add(new ApplicationClass() { ID = 1, Name = "Stoppering", Connected = false });

            return applicationList;
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
        private CurrentOrdersForm currentOrdersForm;
        private void CurrentOrdersSubMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrdersForm == null || currentOrdersForm.IsDisposed)
            {
                currentOrdersForm = new CurrentOrdersForm();
                currentOrdersForm.MdiParent = this;
                currentOrdersForm.Show();
            }
            else
            {
                currentOrdersForm.Activate();
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
            if(operationsForm == null || operationsForm.IsDisposed)
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
    }
}
