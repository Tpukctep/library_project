using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            reportHistoryClassBindingSource1.DataSource = GetReportDataClass.GetResult(dateStart.Value.ToString(), dateEnd.Value.ToString());
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            buttonImport.Enabled = false;
            ExportToExcelClass.ExportToXLSX(dataGridView);
            buttonImport.Enabled = true;
        }
    }
}
