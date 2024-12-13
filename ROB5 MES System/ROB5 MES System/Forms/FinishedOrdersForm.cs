namespace ROB5_MES_System
{
    public partial class FinishedOrdersForm : Form
    {
        public FinishedOrdersForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the finished orders data grid from the database
        /// </summary>
        public void LoadFinishedOrders()
        {
            // clears the finished orders data grid 
            finishedOrdersDataGrid.DataSource = null;

            // loads the finished orders based on showing all or within a date range
            if (showAllCheckBox.Checked)
            {
                MainWindowForm.database.GetFinishedOrdersData();
                finishedOrdersDataGrid.DataSource = MainWindowForm.mesSystem.FinishedOrders.ToList();
            }
            else
            {
                MainWindowForm.database.GetFinishedOrdersData(fromDateTimePicker.Value, toDateTimePicker.Value);
                finishedOrdersDataGrid.DataSource = MainWindowForm.mesSystem.FinishedOrders.ToList();
            }

            // fix text in all the columns headers
            finishedOrdersDataGrid.Columns["OrderNumber"].HeaderText = "Order Number";
            finishedOrdersDataGrid.Columns["OrderStartTime"].HeaderText = "Start Time";
            finishedOrdersDataGrid.Columns["OrderEndTime"].HeaderText = "End Time";
            finishedOrdersDataGrid.Columns["OrderCustomer"].HeaderText = "Customer";
            finishedOrdersDataGrid.Columns["MedicineType"].HeaderText = "Medicine";
            finishedOrdersDataGrid.Columns["OrderState"].HeaderText = "State";
            finishedOrdersDataGrid.Columns["ContainerType"].HeaderText = "Container Type";
            finishedOrdersDataGrid.Columns["ContainerAmount"].HeaderText = "Container Amount";
            finishedOrdersDataGrid.Columns["ProductsTotal"].HeaderText = "Total Products";
            finishedOrdersDataGrid.Columns["OrderStartTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            finishedOrdersDataGrid.Columns["OrderEndTime"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            finishedOrdersDataGrid.Columns["ProductsInOrderList"].Visible = false;
            finishedOrdersDataGrid.Columns["ProductsInProduction"].Visible = false;
            finishedOrdersDataGrid.Columns["ProductsProduced"].Visible = false;
            finishedOrdersDataGrid.Columns["ProductsInProductionList"].Visible = false;
        }

        // Event function that runs whenever the form is loaded
        private void FinishedOrders_Load(object sender, EventArgs e)
        {
            fromDateTimePicker.Value = toDateTimePicker.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            toDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
            LoadFinishedOrders();
        }

        // Event function that runs whenever the from date time picker value is changed
        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (fromDateTimePicker.Value > toDateTimePicker.Value)
            {
                // if the from date time picker is greater than the to date time picker, set the to date time picker to the end of the day of the from date time picker
                toDateTimePicker.Value = fromDateTimePicker.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            // set the min date of the to date time picker to the from date time picker, so it can't be chosen to be lower than the from date time picker
            toDateTimePicker.MinDate = fromDateTimePicker.Value;
            LoadFinishedOrders();
        }

        // Event function that runs whenever the to date time picker value is changed
        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadFinishedOrders();
        }

        // Event function that runs whenever the show all finished orders check box is checked
        private void showAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showAllCheckBox.Checked)
            {
                fromDateTimePicker.Enabled = false;
                toDateTimePicker.Enabled = false;
            }
            else
            {
                fromDateTimePicker.Enabled = true;
                toDateTimePicker.Enabled = true;
            }
            LoadFinishedOrders();
        }

        // Event function that runs whenever an order is double clicked in the finished orders data grid
        private void finishedOrdersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Order clickedOrder = MainWindowForm.GetOrderFromCell(finishedOrdersDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex], MainWindowForm.mesSystem.FinishedOrders);

                MainWindowForm.ShowOrderForm(clickedOrder, this.MdiParent);
            }
        }
    }
}
