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

        private void FinishedOrders_Load(object sender, EventArgs e)
        {
            // load data from database here and display it in the dataGridView
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (fromDateTimePicker.Value > toDateTimePicker.Value)
            {
                toDateTimePicker.Value = fromDateTimePicker.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            toDateTimePicker.MinDate = fromDateTimePicker.Value;

            // update finished orders data grid
        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // update finished orders data grid
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
        }
    }
}
