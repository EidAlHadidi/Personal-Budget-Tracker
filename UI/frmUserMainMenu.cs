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
    public partial class frmUserMainMenu : Form
    {
        public frmUserMainMenu()
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

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignedOutClicked();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmManageTransactions(clsGlobal.LoggedInUserID);
            frm.ShowDialog();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDeposit();
            frm.ShowDialog();
        }
    }
}
