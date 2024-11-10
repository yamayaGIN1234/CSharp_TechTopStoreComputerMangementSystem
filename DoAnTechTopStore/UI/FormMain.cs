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
    public partial class FormMain : Form
    {
        public string name = "{?}";
        public FormMain()
        {
            InitializeComponent();
        }
 
        private void FormMain_Load(object sender, EventArgs e)
        {
            lblUsername.Text = name;
            timerDateAndTime.Start();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to log out?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                timerDateAndTime.Stop();
                Close();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            userControlDashBoard1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlBrand1.EmptyBox();
            userControlBrand1.Visible = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            userControlDashBoard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlProduct1.Visible = false;
            userControlCategory1.EmptyBox();
            userControlCategory1.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            userControlDashBoard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.EmptyBox();
            userControlProduct1.Visible = true;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            userControlDashBoard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.Visible = false;
            userControlOrder1.EmptyBox();
            userControlOrder1.Visible = true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            userControlDashBoard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlUser1.Visible = false;
            userControlReport1.Visible = true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            userControlDashBoard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.EmptyBox();
            userControlUser1.Visible = true;
        }

        private void timerDateAndTime_Tick(object sender, EventArgs e)
        {
            lblTimeAndDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
