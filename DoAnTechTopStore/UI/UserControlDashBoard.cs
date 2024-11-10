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
    public partial class UserControlDashBoard : UserControl
    {
        public UserControlDashBoard()
        {
            InitializeComponent();
        }
        public void Count()
        {
            lblTotalProduct.Text = Computer.Count("SELECT COUNT(*)FROM PRODUCT;").ToString();
            lblTotalOrders.Text = Computer.Count("SELECT COUNT(*)FROM Orders WHERE Payment Satus = 'Not Paid';").ToString();
            lblLowStock.Text = Computer.Count("SELECT COUNT(*) FROM Product Status = 'Not Available';").ToString();
            lblTotalRevenue.Text = Computer.Count("SELECT SUM(Grand Total) FROM Orders;").ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            Count();
        }
    }
}
