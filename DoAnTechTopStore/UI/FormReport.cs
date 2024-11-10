using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAnTechTopStore.UI
{
    public partial class FormReport : Form
    {
        internal static FormReport formReport;
        public DateTime startDate, endDate;

        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.dataSet.Orders);
            // TODO: This line of code loads data into the 'dataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.FillByDate(this.dataSet.Orders, startDate, endDate);

            this.reportViewer1.RefreshReport();
        }

        public FormReport()
        {
            InitializeComponent();
        }
    }
}
