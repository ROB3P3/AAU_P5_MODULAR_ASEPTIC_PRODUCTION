using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ROB5_MES_System
{
    public partial class MainWindowForm : Form
    {
        public static List<Order> orders { get; set; }
        public MainWindowForm()
        {
            orders = GetOrders();
            InitializeComponent();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:MM:ss");
        }

        private List<Order>? GetOrders()
        {
            var orderList = new List<Order>();

            orderList.Add(new Order() { OrderID = 0, startTime = DateTime.Now, endTime = DateTime.Now, ContainerAmount = 10, ContainerType = "vials", OrderState = "Finished" });
            orderList.Add(new Order() { OrderID = 1, startTime = DateTime.Now, endTime = DateTime.Now, ContainerAmount = 29, ContainerType = "pre-filled syringes", OrderState = "Started" });
            orderList.Add(new Order() { OrderID = 2, startTime = DateTime.Now, endTime = DateTime.Now, ContainerAmount = 100, ContainerType = "syringes", OrderState = "Filling" });
            orderList.Add(new Order() { OrderID = 3, startTime = DateTime.Now, endTime = DateTime.Now, ContainerAmount = 1, ContainerType = "vials", OrderState = "Stoppering" });
            orderList.Add(new Order() { OrderID = 4, startTime = DateTime.Now, endTime = DateTime.Now, ContainerAmount = 5, ContainerType = "syringes", OrderState = "Finished" });

            return orderList;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void ProductionControlMenuItem_Click(object sender, EventArgs e)
        {
            //Form popup = new Form();
            //popup.Text = "Popup Window";
            //popup.StartPosition = FormStartPosition.CenterParent;

            //popup.Width = 300;
            //popup.Height = 200;
            //popup.TopMost = true;
            //popup.Owner = this;
            //popup.Show();
        }

        private void ProductionControlMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Control.MousePosition);
            }

            if (e.Button == MouseButtons.Left)
            {
                ResourcesSubMenuItem.Visible = !ResourcesSubMenuItem.Visible;
            }
        }

        private void OrderManagementMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentOrdersSubMenuItem.Visible = !CurrentOrdersSubMenuItem.Visible;
                PlannedOrdersSubMenuItem.Visible = !PlannedOrdersSubMenuItem.Visible;
                NewOrderSubMenuItem.Visible = !NewOrderSubMenuItem.Visible;
                FinishedOrdersSubMenuItem.Visible = !FinishedOrdersSubMenuItem.Visible;
            }
        }

        private void QualityManagementMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EfficiencyReportSubMenuItem.Visible = !EfficiencyReportSubMenuItem.Visible;
                OEEReportSubMenuItem.Visible = !OEEReportSubMenuItem.Visible;
            }
        }

        private void MasterDataMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PartsSubMenuItem.Visible = !PartsSubMenuItem.Visible;
                WorkPlansSubMenuItem.Visible = !WorkPlansSubMenuItem.Visible;
                ResourcesSubMenuItem2.Visible = !ResourcesSubMenuItem2.Visible;
                OperationsSubMenuItem.Visible = !OperationsSubMenuItem.Visible;
            }
        }

        private void exitToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Debug.WriteLine("Exit button clicked");
                Close();
            }
        }

        private NewOrderForm f2;
        private void NewOrderSubMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (f2 == null || f2.IsDisposed)
                {
                    f2 = new NewOrderForm();
                    f2.MdiParent = this;
                    f2.Show();
                }
                else
                {
                    f2.Activate();
                }
            }
        }

        private CurrentOrdersForm f3;
        private void CurrentOrdersSubMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (f3 == null || f3.IsDisposed)
                {
                    f3 = new CurrentOrdersForm();
                    f3.MdiParent = this;
                    f3.Show();
                }
                else
                {
                    f3.Activate();
                }
            }
        }

        private FinishedOrders f4;
        private void FinishedOrdersSubMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (f4 == null || f4.IsDisposed)
                {
                    f4 = new FinishedOrders();
                    f4.MdiParent = this;
                    f4.Show();
                }
                else
                {
                    f4.Activate();
                }
            }
        }
    }
}
