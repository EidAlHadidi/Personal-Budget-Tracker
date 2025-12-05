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
    public partial class frmManageTransactions : Form
    {
        private int userID;
        private DateTime chosenDate;

        BindingSource BS = new BindingSource();

        private void refreshNumberOfRecords() => lblNumberOfRecords.Text = dgvTransactions.Rows.Count.ToString();

        private void refreshRecords()
        {
            BS.DataSource = clsTransaction.GetSP_DisplayTransactionsForUser(userID);
            dgvTransactions.DataSource = BS;
            refreshNumberOfRecords();
        }

        public frmManageTransactions(int UserID)
        {
            InitializeComponent();
            this.userID = UserID;
        }

        private void loadData()
        {
            cbFilterBy.SelectedIndex = 0;
            refreshRecords();
        }

        private void frmManageTransactions_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Clear();
            
            txtFilterBy.Visible = (cbFilterBy.Text != "None");
            
            if (cbFilterBy.Text == "Date Before" || cbFilterBy.Text == "Date After")
            {
                btnChooseDate.Visible = true;
                txtFilterBy.Enabled = false;
            }
            else
            {
                btnChooseDate.Visible = false;
                txtFilterBy.Enabled = true;
            }
        }

        private void HandleDateChoosing(DateTime chosenDate)
        {
            this.chosenDate = chosenDate;
            txtFilterBy.Text = chosenDate.ToShortDateString();
        }

        private void btnChooseDate_Click(object sender, EventArgs e)
        {
            var frm = new frmChooseDate();
            frm.onDateChosen += HandleDateChoosing;
            frm.ShowDialog();
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterBy.Text == string.Empty)
            {
                BS.RemoveFilter();
                refreshNumberOfRecords();
                return;
            }
            BS.RemoveFilter();
            switch (cbFilterBy.Text)
            {
                case "Transaction ID":
                    BS.Filter = $"TransactionID = {txtFilterBy.Text}";
                    break;
                case "Transaction Type":
                    BS.Filter = $"TransactionTypeName like '{txtFilterBy.Text}%'";
                    break;
                case "Category":
                    BS.Filter = $"CategoryName like '{txtFilterBy.Text}%'";
                    break;
                case "Date Before":
                    BS.Filter = $"Date <= #{chosenDate:MM/dd/yyyy}#";
                    break;
                case "Date After":
                    BS.Filter = $"Date >= #{chosenDate:MM/dd/yyyy}#";
                    break;
                case "Amount Less Than":
                    BS.Filter = $"Amount <= {(txtFilterBy.Text)}";
                    break;
                case "Amount More Than":
                    BS.Filter = $"Amount >= {(txtFilterBy.Text)}";
                    break;
            }
            refreshNumberOfRecords();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Amount Less Than" ||
                cbFilterBy.Text == "Amount More Than" ||
                cbFilterBy.Text == "Transaction ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            var frm = new frmDeposit();
            frm.ShowDialog();
            refreshRecords();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            var frm = new frmWithdraw();
            frm.ShowDialog();
            refreshRecords();
        }

    }
}
