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
    public enum enMode { Admin,User}
    public partial class frmChangeUserPassword : Form
    {
        private enMode mode;
        clsUser _user = null;
        clsSystemUser _systemUser = null;
        int _userID = -1;

        public frmChangeUserPassword(enMode mode, int userID)
        {
            InitializeComponent();
            this.mode = mode;
            this._userID = userID;
        }

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

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Not all fields filled correctly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtPassword.Text != txtRepeatPassword.Text)
            {
                MessageBox.Show("Passwords does not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mode == enMode.Admin)
            {
                _systemUser = clsSystemUser.Find(_userID);
                _systemUser.Password = clsGlobal.ComputeHash(txtPassword.Text);
                if(!_systemUser.Save())
                {
                    MessageBox.Show("Error while changing password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Password changed successfully", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Enabled = false;
                txtRepeatPassword.Enabled = false;
                btnChange.Enabled = false;
            }
            else if (mode == enMode.User)
            {
                _user = clsUser.Find(_userID);
                _user.Password = clsGlobal.ComputeHash(txtPassword.Text);
                if (!_user.Save())
                {
                    MessageBox.Show("Error while changing password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Password changed successfully", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Enabled = false;
                txtRepeatPassword.Enabled = false;
                btnChange.Enabled = false;
            }
            else
                return;

        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            if(mode == enMode.Admin)
            {
                clsSystemUser systemUser = clsSystemUser.Find(_userID);
                lblUserID.Text = systemUser.SystemUserID.ToString();
                lblUsername.Text = systemUser.Username.ToString();
            }
            else if(mode == enMode.User)
            {
                clsUser user = clsUser.Find(_userID);
                lblUserID.Text = user.UserID.ToString();
                lblUsername.Text = user.Username.ToString();
            }
        }
    }


}
