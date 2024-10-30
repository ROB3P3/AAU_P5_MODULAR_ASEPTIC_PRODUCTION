using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ROB5_MES_System;

namespace ROB5_MES_System
{
    public partial class CurrentOrdersForm : Form
    {
        public CurrentOrdersForm()
        {
            InitializeComponent();
        }

        private void CurrentOrdersForm_Load(object sender, EventArgs e)
        {
            MainWindowForm mainWindowForm = new MainWindowForm();
            var orderList = mainWindowForm.orders;

            dataGridView1.DataSource = orderList;
        }
    }
}
