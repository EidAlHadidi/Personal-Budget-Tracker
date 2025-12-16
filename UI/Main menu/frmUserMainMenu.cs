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
    public partial class frmUserMainMenu : Form
    {
        clsUser _user;
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

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDeposit();
            frm.ShowDialog();
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmWithdraw();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmManageSavingGoals(clsGlobal.LoggedInUserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var frm = new frmAddSavingGoal();
            frm.ShowDialog();
        }

        private void showTotalAmountSavedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal CurrentSavedMoney = -1;
            decimal TotalSavedMoney = -1;
            bool Saved = clsSavingGoal.GetTotalSavedMoney(clsGlobal.LoggedInUserID, ref CurrentSavedMoney, ref TotalSavedMoney);
            if (Saved)
            {
                MessageBox.Show($"Current Saved Money = {CurrentSavedMoney:F2}\n" +
                                $"Total Saved Money = {TotalSavedMoney:F2}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No information available", "No info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmManageTransactions(clsGlobal.LoggedInUserID,frmManageTransactions.enMode.All);
            frm.ShowDialog();
        }

        private void depositsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmManageTransactions(clsGlobal.LoggedInUserID, frmManageTransactions.enMode.Deposits);
            frm.ShowDialog();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmManageTransactions(clsGlobal.LoggedInUserID, frmManageTransactions.enMode.Expenses);
            frm.ShowDialog();
        }

        private void transfersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmManageTransactions(clsGlobal.LoggedInUserID, frmManageTransactions.enMode.Transfers);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmChangeUserPassword(UI.enMode.User, clsGlobal.LoggedInUserID);
            frm.ShowDialog();
        }

        private void frmUserMainMenu_Load(object sender, EventArgs e)
        {
            _user = clsUser.Find(clsGlobal.LoggedInUserID);
            lblUserID.Text = _user.UserID.ToString();
            lblUsername.Text = _user.Username.ToString();
            lblBalance.Text = _user.Balance.ToString();

            decimal CurrentSavedMoney = -1;
            decimal TotalSavedMoney = -1;
            bool Succeed = clsSavingGoal.GetTotalSavedMoney(clsGlobal.LoggedInUserID, ref CurrentSavedMoney, ref TotalSavedMoney);
            if (Succeed)
            {
                lblCurrentMoneySaved.Text = CurrentSavedMoney.ToString();
                lblTotalMoneySaved.Text = TotalSavedMoney.ToString();
            }
            else
            {
                lblCurrentMoneySaved.ResetText();
                lblTotalMoneySaved.ResetText();
            }
        }
    }
}
