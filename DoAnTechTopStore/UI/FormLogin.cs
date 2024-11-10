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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void EmptyBox()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if(picShow.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                picShow.Visible = false;
                picHide.Visible = true;
            }
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = true;
                picShow.Visible = true;
                picHide.Visible = false;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Trim() == string.Empty) 
            {
                MessageBox.Show("Please enter user name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                bool check = Computer.IsValidNamePass(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (check) 
                {
                    FormMain formMain = new FormMain();
                    formMain.name = txtUsername.Text;
                    formMain.ShowDialog();
                    EmptyBox();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            FormForgotPassword formForgotPassword = new FormForgotPassword();
            formForgotPassword.ShowDialog();
        }
    }
}
