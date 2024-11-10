using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace DoAnTechTopStore.UI
{
    public partial class UserControlProduct : UserControl
    {
        private string id = "";
        byte[] image;
        ImageConverter imageConverter;
        MemoryStream memoryStream;

        public UserControlProduct()
        {
            InitializeComponent();
            imageConverter = new ImageConverter();
            EmptyBox();
            ComboBoxAutoFill();
        }

        private void ImageUpload(PictureBox picture)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    picture.Image = Image.FromFile(openFileDialog.FileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Image upload error: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EmptyBox()
        {
            txtProductName.Clear();
            picPhoto.Image = null;
            nudRate.Value = 0;
            nudQuantity.Value = 0;
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("-- SELECT --");
            Computer.BrandCategoryProduct("SELECT Brand_Name FROM Brand WHERE Brand_Status = 'Available' ORDER BY Brand_Name;", cmbBrand);
            cmbBrand.SelectedIndex = 0;
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("-- SELECT --");
            Computer.BrandCategoryProduct("SELECT Category_Name FROM Category WHERE Category_Status = 'Available' ORDER BY Category_Name;", cmbCategory);
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void EmptyBox1()
        {
            txtProductName.Clear();
            picPhoto1.Image = null;
            nudRate1.Value = 0;
            nudQuantity1.Value = 0;

            cmbStatus1.SelectedIndex = 0;
            id = "";
        }

        private void ComboBoxAutoFill()
        {
            cmbBrand1.Items.Clear();
            cmbBrand1.Items.Add("-- SELECT --");
            Computer.BrandCategoryProduct("SELECT Brand_Name FROM Brand WHERE Brand_Status = 'Available' ORDER BY Brand_Name;", cmbBrand1);
            cmbBrand1.SelectedIndex = 0;
            cmbCategory1.Items.Clear();
            cmbCategory1.Items.Add("-- SELECT --");
            Computer.BrandCategoryProduct("SELECT Category_Name FROM Category WHERE Category_Status = 'Available' ORDER BY Category_Name;", cmbCategory1);
            cmbCategory1.SelectedIndex = 0;
        }
        private void picSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(picSearch, "Search");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageUpload(picPhoto1);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ImageUpload(picPhoto);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtProductName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter product name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (picPhoto.Image == null)
            {
                MessageBox.Show("Please select image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudRate.Value == 0)
            {
                MessageBox.Show("Please enter rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudQuantity.Value == 0)
            {
                MessageBox.Show("Please enter quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please select brand", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please select status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Product product = new Product(txtProductName.Text.Trim(), (byte[])imageConverter.ConvertTo(picPhoto.Image, typeof(byte[])), Convert.ToInt32(nudRate.Value), Convert.ToInt32(nudQuantity.Value), cmbBrand.SelectedItem.ToString(), cmbCategory.SelectedItem.ToString(), cmbStatus.SelectedItem.ToString());
                Computer.AddProduct(product);
                EmptyBox();
            }
        }

        private void tpAddCategory_Enter(object sender, EventArgs e)
        {
            EmptyBox();
        }

        private void tpManageProduct_Enter(object sender, EventArgs e)
        {
            txtSearchProductName.Clear();
            dgvProduct.Columns[0].Visible = false;
            Computer.DisplayAndSearch("SELECT * FROM Product;", dgvProduct);
            lblTotal.Text = dgvProduct.Rows.Count.ToString();
        }

        private void txtSearchProductName_TextChanged(object sender, EventArgs e)
        {
            Computer.DisplayAndSearch("Select * from Product where Product_Name like '%" + txtSearchProductName.Text + "%'", dgvProduct);
            lblTotal.Text = dgvProduct.Rows.Count.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBoxAutoFill();
            DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
            id = row.Cells[0].Value.ToString();
            txtProductName1.Text = row.Cells[1].Value.ToString();

            if (row.Cells[2].Value != DBNull.Value)
            {
                image = (byte[])row.Cells[2].Value;
                memoryStream = new MemoryStream(image);
                picPhoto1.Image = Image.FromStream(memoryStream);
            }
            else
            {
                picPhoto1.Image = null; // or set a default image
            }

            nudRate1.Value = Convert.ToInt32(row.Cells[3].Value.ToString());
            nudQuantity1.Value = Convert.ToInt32(row.Cells[4].Value.ToString());
            cmbBrand1.SelectedItem = row.Cells[5].Value.ToString();
            cmbCategory1.SelectedItem = row.Cells[6].Value.ToString();
            cmbStatus1.SelectedItem = row.Cells[7].Value.ToString();
            tcProduct.SelectedTab = tpOptions;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("Please select row from table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtProductName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter product name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (picPhoto1.Image == null)
            {
                MessageBox.Show("Please select image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudRate1.Value == 0)
            {
                MessageBox.Show("Please enter rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudQuantity1.Value == 0)
            {
                MessageBox.Show("Please enter quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbBrand1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select brand", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbCategory1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Product product = new Product(txtProductName1.Text.Trim(), (byte[])imageConverter.ConvertTo(picPhoto1.Image, typeof(byte[])), Convert.ToInt32(nudRate1.Value), Convert.ToInt32(nudQuantity1.Value), cmbBrand1.SelectedItem.ToString(), cmbCategory1.SelectedItem.ToString(), cmbStatus1.SelectedItem.ToString());
                Computer.ChangeProduct(product, id);
                EmptyBox1();
                tcProduct.SelectedTab = tpManageProduct;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("Please select row from table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtProductName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter product name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (picPhoto1.Image == null)
            {
                MessageBox.Show("Please select image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudRate1.Value == 0)
            {
                MessageBox.Show("Please enter rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudQuantity1.Value == 0)
            {
                MessageBox.Show("Please enter quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbBrand1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select brand", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbCategory1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to remove this product?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Computer.RemoveProduct(id);
                    EmptyBox1();
                    tcProduct.SelectedTab = tpManageProduct;
                }
            }
        }

        private void tpOptions_Enter(object sender, EventArgs e)
        {
            if (id == "")
            {
                tcProduct.SelectedTab = tpManageProduct;
            }
        }

        private void tpOptions_Leave(object sender, EventArgs e)
        {
            EmptyBox1();
        }
    }
}
