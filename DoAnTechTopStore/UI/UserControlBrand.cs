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
    public partial class UserControlBrand : UserControl
    {
        private string Id = "";
        public UserControlBrand()
        {
            InitializeComponent();
        }

        public void EmptyBox()
        {
            txtBrandName.Clear();
            cmbStatus.SelectedIndex = 0;
        }

        private void EmptyBox1()
        {
            txtBrandName1.Clear();
            cmbStatus1.SelectedIndex = 0;
            Id = "";
        }

        private void picSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(picSearch, "Search");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBrandName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter brand name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            { 
                Brand brand = new Brand(txtBrandName.Text.Trim(), cmbStatus.SelectedItem.ToString());
                Computer.AddBrand(brand);
                EmptyBox();
            }
        }

        private void tpAddBrand_Enter(object sender, EventArgs e)
        {
            EmptyBox();
        }

        private void tpManageBrand_Enter(object sender, EventArgs e)
        {
            txtSearchBrandName.Clear();
            dgvBrand.Columns[0].Visible = false;
            Computer.DisplayAndSearch("Select * from Brand", dgvBrand);
            lblTotal.Text = dgvBrand.Rows.Count.ToString();
        }

        private void txtSearchBrandName_TextChanged(object sender, EventArgs e)
        {
            Computer.DisplayAndSearch("Select * from Brand where Brand_Name like '%" + txtSearchBrandName.Text + "%'", dgvBrand);
            lblTotal.Text = dgvBrand.Rows.Count.ToString();
        }

        private void dgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvBrand.Rows[e.RowIndex];
                Id = row.Cells[0].Value.ToString();
                txtBrandName1.Text = row.Cells[1].Value.ToString();
                cmbStatus1.SelectedItem = row.Cells[2].Value.ToString();
                tcBrand.SelectedTab = tpOptions;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(Id == "")
            {
                MessageBox.Show("First select row from table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtBrandName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter brand name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Brand brand = new Brand(txtBrandName1.Text.Trim(), cmbStatus1.SelectedItem.ToString());
                Computer.ChangeBrand(brand, Id);
                EmptyBox1();
                tcBrand.SelectedTab = tpManageBrand;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (Id == "")
            {
                MessageBox.Show("First select row from table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtBrandName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter brand name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to remove this brand?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Computer.RemoveBrand(Id);
                    EmptyBox1();
                    tcBrand.SelectedTab = tpManageBrand;
                }
            }
        }

        private void tpOptions_Enter(object sender, EventArgs e)
        {
            if (Id == "")
                tcBrand.SelectedTab = tpManageBrand;
        }

        private void tpOptions_Leave(object sender, EventArgs e)
        {
            EmptyBox1();
        }
    }
}
