using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROB5_MES_System
{
    public partial class SystemStatusForm : Form
    {
        private BindingSource plcBindingSource = new BindingSource();
        public SystemStatusForm()
        {
            InitializeComponent();
            LoadApplications();
        }

        /// <summary>
        /// Load the PLCs/Applications into the system status data grid
        /// </summary>
        public void LoadApplications()
        {
            // clear the data grid
            systemStatusDataGrid.DataSource = null;
            // sort the list of plcs by their placement in the production system
            MainWindowForm.plcs.Sort((x, y) => x.Placement.CompareTo(y.Placement));

            // using a bindingsource for the data grid so it updates by itself
            plcBindingSource.DataSource = MainWindowForm.plcs;

            systemStatusDataGrid.DataSource = plcBindingSource;
            systemStatusDataGrid.AutoGenerateColumns = true;
        }

        // event function for when start production button is clicked
        private void startProductionButton_Click(object sender, EventArgs e)
        {
            if (MainWindowForm.mesSystem.OrderQueue.Count > 0)
            {
                MainWindowForm.mesSystem.OrderQueue.First.Value.StartOrderProduction();
            }
        }
    }
}
