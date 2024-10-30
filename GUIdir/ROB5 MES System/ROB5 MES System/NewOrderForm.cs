using CsvHelper;
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
    public partial class NewOrderForm : Form
    {
        public NewOrderForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public class CsvText
        {
            public string ContainerType { get; set; }
            public decimal ContainerAmount { get; set; }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string containerType = comboBox1.Text;
                decimal containerAmount = numericUpDown1.Value;

                var records = new List<CsvText>
                {
                    new CsvText {ContainerType = containerType, ContainerAmount = containerAmount}
                };

                var filePath = "orders.csv";
                bool fileExists = File.Exists(filePath);

                using (var writer = new StreamWriter(filePath, append: true))
                using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                {
                    if (!fileExists)
                    {
                        csv.WriteHeader<CsvText>();
                        csv.NextRecord();
                    }

                    foreach (var record in records)
                    {
                        csv.WriteRecord(record);
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}
