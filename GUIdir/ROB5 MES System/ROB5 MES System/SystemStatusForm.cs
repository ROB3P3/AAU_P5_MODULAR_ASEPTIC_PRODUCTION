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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MainWindowForm.applications;
        }
    }
}
