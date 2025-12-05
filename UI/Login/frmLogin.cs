using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class frmLogin : Form
    {
        static string userPath = @"C:\Users\Eid AlHadidi\Documents\Study\1_PROGRAMMING_ADVICES_AND_MORE\C# Projects\Personal finance and budget tracker\PersonalBudgetTracker\UI\LogInfo.txt";
        static string adminPath = @"C:\Users\Eid AlHadidi\Documents\Study\1_PROGRAMMING_ADVICES_AND_MORE\C# Projects\Personal finance and budget tracker\PersonalBudgetTracker\UI\LogInfoAdmin.txt";
        static string logPath = userPath;
        const char separator = '#';

        int systemUserID = -1;
        int userID = -1;
        clsUser user;
        clsSystemUser systemUser;

        private void loadUsernameAndPassword()
        {
            StreamReader SR = new StreamReader(logPath);
            using (SR)
            {
                string line = SR.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    string[] fields = line.Split(separator);
                    txtUsername.Text = fields[0];
                    txtPassword.Text = fields[1];
                }
            }
        }

        private bool checkUserAndPassword(clsGlobal.enLoginMode LoginMode)
        {
            bool loginSucceed = false;
            if (LoginMode == clsGlobal.enLoginMode.User)
            {
                string password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
                user = clsUser.Find(txtUsername.Text.Trim(), password);
                if (user == null)
                    loginSucceed = false;
                else
                {
                    loginSucceed = true;
                    userID = user.UserID;

                    //assigning systemUser and its ID to null
                    systemUser = null;
                    systemUserID = -1;

                }
            }
            else
            {
                string password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
                systemUser = clsSystemUser.Find(txtUsername.Text.Trim(), password);
                if (systemUser == null)
                    loginSucceed = false;
                else
                {
                    loginSucceed = true;
                    systemUserID = systemUser.SystemUserID;

                    //assigning user and userID to null
                    user = null;
                    userID = -1;
                }
            }

                return loginSucceed;
        }

        private void clearTextBoxes()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void changeLoginMode()
        {
            if (clsGlobal.LoginMode == clsGlobal.enLoginMode.User)
            {
                clsGlobal.LoginMode = clsGlobal.enLoginMode.Admin;
                btnMode.Text = " --> User Screen";
                lblLoginMode.Text = "Admin Login Screen";
                logPath = adminPath;
                pbAdminPicture.Visible = true;
            }
            else
            {
                clsGlobal.LoginMode = clsGlobal.enLoginMode.User;
                btnMode.Text = " --> Admin Screen";
                lblLoginMode.Text = "User Login Screen";
                logPath = userPath;
                pbAdminPicture.Visible = false;
            }
            clearTextBoxes();
            loadUsernameAndPassword();
        }

        private void HandleSignOut(object sender)
        {
            this.Show();
        }

        private void LogIn()
        {
            if(clsGlobal.LoginMode == clsGlobal.enLoginMode.User)
            {
                clsGlobal.LoggedInUserID = userID;
                var frm = new frmUserMainMenu();
                this.Hide();
                frm.Show();
                frm.onSignedOut += HandleSignOut;
            }
            else
            {
                clsGlobal.LoggedInSystemUserID = systemUserID;
                var frm = new frmAdminMainMenu();
                this.Hide();
                frm.Show();
                frm.onSignedOut += HandleSignOut;
            }
        }

        private void rememberMe(string UserName, string Password)
        {
            StreamWriter SW = new StreamWriter(logPath);
            if (UserName == string.Empty && Password == string.Empty)
            {
                return;
            }
            using (SW)
            {
                SW.WriteLine(UserName + separator + Password);
            }
            SW.Close();
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            changeLoginMode();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsGlobal.LoginMode = clsGlobal.enLoginMode.User;
            loadUsernameAndPassword();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!checkUserAndPassword(clsGlobal.LoginMode))
            {
                MessageBox.Show("Invalid Username/Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (cbRememberMe.Checked)
                {
                    rememberMe(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                    rememberMe("", "");
                    LogIn();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
