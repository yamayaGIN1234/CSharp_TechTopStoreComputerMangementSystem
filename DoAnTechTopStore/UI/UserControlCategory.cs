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
    public partial class UserControlCategory : UserControl
    {
        private string id = "";
        public UserControlCategory()
        {
            InitializeComponent();
        }

        public void EmptyBox()
        {
            txtCategoryName.Clear();
            cmbStatus.SelectedIndex = 0;
        }
        public void EmptyBox1()
        {
            txtCategoryName1.Clear();
            cmbStatus1.SelectedIndex = 0;
            id = "";
        }

        private void picSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(picSearch, "Search");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter category name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please choose status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Category category = new Category(txtCategoryName.Text.Trim(), cmbStatus.SelectedItem.ToString());
                Computer.AddCategory(category);
                EmptyBox();
            }
        }

        private void tpAddCategory_Enter(object sender, EventArgs e)
        {
            EmptyBox();
        }

        private void tpManageCategory_Enter(object sender, EventArgs e)
        {
            txtCategoryName.Clear();
            dgvCategory.Columns[0].Visible = false; 
            Computer.DisplayAndSearch("SELECT * FROM Category", dgvCategory);
            lblTotal.Text = dgvCategory.Rows.Count.ToString();
        }

        private void txtSearchCategoryName_TextChanged(object sender, EventArgs e)
        {
            Computer.DisplayAndSearch("SELECT * FROM Category WHERE CategoryName LIKE '%" + txtSearchCategoryName.Text + "%'", dgvCategory);
            lblTotal.Text = dgvCategory.Rows.Count.ToString();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                txtCategoryName1.Text = row.Cells[1].Value.ToString();
                cmbStatus1.SelectedItem = row.Cells[2].Value.ToString();
                tcCategory.SelectedTab = tpOptions;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("First select row from table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtCategoryName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Category name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Category Category = new Category(txtCategoryName1.Text.Trim(), cmbStatus1.SelectedItem.ToString());
                Computer.ChangeCategory(Category, id);
                EmptyBox1();
                tcCategory.SelectedTab = tpManageCategory;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("First select row from table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtCategoryName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Category name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to remove this Category?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Computer.RemoveCategory(id);
                    EmptyBox1();
                    tcCategory.SelectedTab = tpManageCategory;
                }
            }
        }

        private void tpOptions_Enter(object sender, EventArgs e)
        {
            if (id == "")
                tcCategory.SelectedTab = tpManageCategory;
        }

        private void tpOptions_Leave(object sender, EventArgs e)
        {
            EmptyBox1();
        }
    }
}
