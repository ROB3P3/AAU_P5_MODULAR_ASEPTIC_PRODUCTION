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

namespace ROB5_MES_System
{
    public partial class FinishedOrdersForm : Form
    {
        public FinishedOrdersForm()
        {
            InitializeComponent();
            fromDateTimePicker.Value = toDateTimePicker.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            toDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
        }

        public void loadFinishedOrders()
        {
            finishedOrdersDataGrid.DataSource = null;
            if (showAllCheckBox.Checked)
            {
                finishedOrdersDataGrid.DataSource = MainWindowForm.database.get_finished_orders();
            }
            else
            {
                finishedOrdersDataGrid.DataSource = MainWindowForm.database.get_finished_orders(fromDateTimePicker.Value, toDateTimePicker.Value);
            }

            finishedOrdersDataGrid.Columns["OrderNumber"].HeaderText = "Order Number";
            finishedOrdersDataGrid.Columns["OrderPlannedStartTime"].HeaderText = "Planned Start Time";
            finishedOrdersDataGrid.Columns["OrderPlannedEndTime"].HeaderText = "Planned End Time";
            finishedOrdersDataGrid.Columns["OrderStartTime"].HeaderText = "Start Time";
            finishedOrdersDataGrid.Columns["OrderEndTime"].HeaderText = "End Time";
            finishedOrdersDataGrid.Columns["OrderCustomer"].HeaderText = "Customer";
            finishedOrdersDataGrid.Columns["MedicineType"].HeaderText = "Medicine";
            finishedOrdersDataGrid.Columns["OrderState"].HeaderText = "State";
            finishedOrdersDataGrid.Columns["ContainerType"].HeaderText = "Container Type";
            finishedOrdersDataGrid.Columns["ContainerAmount"].HeaderText = "Container Amount";
            finishedOrdersDataGrid.Columns["CarriersTotal"].HeaderText = "Total Carriers";
            finishedOrdersDataGrid.Columns["CarriersInProduction"].HeaderText = "Carriers in Production";
            finishedOrdersDataGrid.Columns["CarriersProduced"].HeaderText = "Carriers Produced";
            finishedOrdersDataGrid.Columns["OrderPlannedStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            finishedOrdersDataGrid.Columns["OrderPlannedEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            finishedOrdersDataGrid.Columns["OrderStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            finishedOrdersDataGrid.Columns["OrderEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            finishedOrdersDataGrid.Columns["ContainersInProduction"].Visible = false;
            finishedOrdersDataGrid.Columns["ContainersProduced"].Visible = false;
            finishedOrdersDataGrid.Columns["CarriersInOrder"].Visible = false;
        }

        private void FinishedOrders_Load(object sender, EventArgs e)
        {
            // load data from database here and display it in the dataGridView
            loadFinishedOrders();
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (fromDateTimePicker.Value > toDateTimePicker.Value)
            {
                toDateTimePicker.Value = fromDateTimePicker.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            toDateTimePicker.MinDate = fromDateTimePicker.Value;
            loadFinishedOrders();
        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            loadFinishedOrders();
        }

        private void showAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(showAllCheckBox.Checked)
            {
                fromDateTimePicker.Enabled = false;
                toDateTimePicker.Enabled = false;
            }
            else
            {
                fromDateTimePicker.Enabled = true;
                toDateTimePicker.Enabled = true;
            }
            loadFinishedOrders();
        }
    }
}
