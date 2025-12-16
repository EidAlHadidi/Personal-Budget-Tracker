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
    public partial class frmAdminMainMenu : Form
    {
        public frmAdminMainMenu()
        {
            InitializeComponent();
        }

        public delegate void SignedOut(object sender);

        public event SignedOut onSignedOut;

        protected virtual void SignedOutClicked()
        {
            SignedOut handler = onSignedOut;
            if (handler != null)
            {
                handler?.Invoke(this);
            }
        }

        private void signOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SignedOutClicked();
            this.Close();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateUser();
            frm.ShowDialog();
        }

        private void createSystemUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateSystemUser();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmChangeUserPassword(UI.enMode.Admin, clsGlobal.LoggedInSystemUserID);
            frm.ShowDialog();
        }
    }

}
