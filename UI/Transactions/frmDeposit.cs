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
    public partial class frmDeposit : Form
    {
        public frmDeposit()
        {
            InitializeComponent();
        }

        //clsUser user = clsGlobal.LoggedInUser;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            //Handle deposit logic
            decimal amount = decimal.Parse(txtDepositAmount.Text);

            if(!this.ValidateChildren())
            {
                MessageBox.Show("Not all fields filled correctly!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show($"Are you sure you want to deposit this " +
                $"{txtDepositAmount.Text.ToString()}$  ? ",
                "Confirm deposit",MessageBoxButtons.YesNo
                ,MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            //int transactionTypeID, DateTime date,
            //string description, decimal amount, int categoryID, string receiptImage
            clsTransaction transaction = new clsTransaction();
            transaction.UserId = clsGlobal.LoggedInUserID;
            transaction.TransactionTypeID = 1;
            transaction.Date = DateTime.Now;
            transaction.Description = txtDescription.Text.ToString();
            transaction.amount = amount;
            transaction.CategoryID = -1;
            transaction.ReceiptImage = null;

            if (!transaction.Save())
            {
                MessageBox.Show("Eror while saving the transaction record!", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!clsGlobal.LoggedInUser.AddToBalance(amount))
            {
                MessageBox.Show($"Error while adding {amount} to balance!", "Deposit error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Deposit succeeded.\nYour new balance is {clsGlobal.LoggedInUser.Balance}$", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDepositAmount.Enabled = false;
            txtDescription.Enabled = false;
            btnDeposit.Enabled = false;
            lblBalance.Text = clsGlobal.LoggedInUser.Balance.ToString();
        }

        private void txtDepositAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow digits
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // Allow only ONE decimal separator
            if (e.KeyChar == '.' && !txtDepositAmount.Text.Contains("."))
            {
                return;
            }

            // Everything else = blocked
            e.Handled = true;
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
            lblUsername.Text = clsGlobal.LoggedInUser.Username.ToString();
            lblBalance.Text = clsGlobal.LoggedInUser.Balance.ToString();
        }

        private void txtDepositAmount_Validating(object sender, CancelEventArgs e)
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
    }
}
