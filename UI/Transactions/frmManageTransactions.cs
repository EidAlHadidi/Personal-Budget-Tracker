using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class frmManageTransactions : Form
    {
        public enum enMode { All=0,Deposits=1,Expenses=2,Transfers=3};
        public static enMode Mode;

        private int userID;
        private DateTime chosenDate;

        BindingSource BS = new BindingSource();
        private void refreshNumberOfRecords() => lblNumberOfRecords.Text = dgvTransactions.Rows.Count.ToString();

        private bool CheckForDataRows(DataRow[] rows)
        {
            if(rows.Length == 0)
            {
                MessageBox.Show("No data found for this screen, enter 'All' or another screen has data", "No data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        //private DataTable MakeDataSource(enMode Mode)
        //{
        //    DataTable DataSource = clsTransaction.GetSP_DisplayTransactionsForUser(userID);
        //    if(DataSource.Rows.Count == 0 && Mode != enMode.All)
        //    {
        //        MessageBox.Show("No data exist, choose only 'all' screen");
        //        this.Close();
        //        return null;
        //    }

        //    switch (Mode)
        //    {
        //        case enMode.Deposits:
        //            if (!CheckForDataRows(DataSource.Select("[TransactionTypeName] = 'Income'")))
        //                this.Close();
        //            DataSource = DataSource.Select("[TransactionTypeName] = 'Income'").CopyToDataTable();
        //            break;
        //        case enMode.Expenses:
        //            if (!CheckForDataRows(DataSource.Select("[TransactionTypeName] = 'Expense'")))
        //                this.Close();
        //            DataSource = DataSource.Select("[TransactionTypeName] = 'Expense'").CopyToDataTable();
        //            break;
        //        case enMode.Transfers:
        //            if (!CheckForDataRows(DataSource.Select("[TransactionTypeName] = 'Transfer'")))
        //                this.Close();
        //            DataSource = DataSource.Select("[TransactionTypeName] = 'Transfer'").CopyToDataTable();
        //            break;
        //    }

        //    return DataSource;
        //}

        private DataTable MakeDataSource(enMode Mode)
        {
            DataTable dataSource = clsTransaction.GetSP_DisplayTransactionsForUser(userID);

            // If no data and not ALL mode, stop
            if (dataSource.Rows.Count == 0 && Mode != enMode.All)
            {
                MessageBox.Show("No data exist, choose only 'all' screen");
                this.Close();
                return null; // VERY IMPORTANT
            }

            // Build filter based on Mode
            string filter = null;

            if (Mode == enMode.Deposits)
                filter = "[TransactionTypeName] = 'Income'";
            else if (Mode == enMode.Expenses)
                filter = "[TransactionTypeName] = 'Expense'";
            else if (Mode == enMode.Transfers)
                filter = "[TransactionTypeName] = 'Transfer'";

            // If ALL mode or filter is null, return original
            if (filter == null)
                return dataSource;

            // Filter rows
            DataRow[] rows = dataSource.Select(filter);

            // No matching rows
            if (rows.Length == 0)
            {
                MessageBox.Show("No data match this screen");
                this.Close();
                return null; // STOP EXECUTION — prevents exception
            }

            // Safe: rows have at least 1 item
            return rows.CopyToDataTable();
        }


        private void refreshRecords()
        {
            BS.DataSource = MakeDataSource(Mode);
            dgvTransactions.DataSource = BS;
            refreshNumberOfRecords();
        }

        public frmManageTransactions(int UserID,enMode mode)
        {
            InitializeComponent();
            this.userID = UserID;
            Mode = mode;
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
