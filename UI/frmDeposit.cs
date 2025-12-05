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

        clsUser user = clsGlobal.LoggedInUser;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            //Handle deposit logic
            if(!this.ValidateChildren())
            {
                return;
            }
            
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
            lblUsername.Text = user.Username.ToString();
            lblBalance.Text = user.Balance.ToString();
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
