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
        public SystemStatusForm()
        {
            InitializeComponent();
            LoadApplications();
        }

        public void LoadApplications()
        {
            systemStatusDataGrid.DataSource = null;
            MainWindowForm.plcs.Sort((x, y) => x.Placement.CompareTo(y.Placement));

            BindingSource plcBindingSource = new BindingSource();
            plcBindingSource.DataSource = MainWindowForm.plcs;

            systemStatusDataGrid.DataSource = plcBindingSource;
        }

        private void startProductionButton_MouseClick(object sender, MouseEventArgs e)
        {
            if(MainWindowForm.mesSystem.Orders.Count > 0)
            {
                MainWindowForm.mesSystem.Orders.First.Value.StartOrderProduction();
            }
        }
    }
}
