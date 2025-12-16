using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCreateSystemUser : Form
    {
        public frmCreateSystemUser()
        {
            InitializeComponent();
        }

        clsSystemUser _user;
        
        private void ValidateEmptyString(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "This field is required!");
            }
            else
                errorProvider1.SetError(txt, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Not all fields filled correctly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsSystemUser.isSystemUserExist(txtUsername.Text))
            {
                MessageBox.Show("There is a system user with this username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user = new clsSystemUser();
            _user.Username = txtUsername.Text.Trim();
            _user.Password = clsGlobal.ComputeHash(txtPassword.Text);
            _user.Permissions = 1;

            if (!_user.Save())
            {
                MessageBox.Show("Error while creating new user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"User created successfully with \nID: {_user.SystemUserID}", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblUser.Text = _user.SystemUserID.ToString();
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnCreateUser.Enabled = false;
        }
    }
}
