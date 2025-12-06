using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmManageSavingGoals : Form
    {
        private int userID;
        private DateTime chosenDate;

        BindingSource BS = new BindingSource();

        private void refreshNumberOfRecords() => lblNumberOfRecords.Text = dgvSavingGoals.Rows.Count.ToString();

        private void refreshRecords()
        {
            BS.DataSource = clsSavingGoal.GetSP_DisplayGoalsForUser(userID);
            dgvSavingGoals.DataSource = BS;
            refreshNumberOfRecords();
        }

        public frmManageSavingGoals(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void loadData()
        {
            cbFilterBy.SelectedIndex = 0;
            refreshRecords();
        }

        private void frmManageSavingGoals_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSavingGoal_Click(object sender, EventArgs e)
        {
            //call "add new saving goal" form...
            var frm = new frmAddSavingGoal();
            frm.ShowDialog();
            refreshRecords();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)    
        {
            txtFilterBy.Clear();
            cbIsCompleted.SelectedIndex = 0;

            if(cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = cbIsCompleted.Visible = false;
            }
            else
            {
                txtFilterBy.Visible = (cbFilterBy.Text != "Is Completed");
                cbIsCompleted.Visible = (cbFilterBy.Text == "Is Completed");

                if (cbFilterBy.Text == "Start date" || cbFilterBy.Text == "End date")
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

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterBy.Text == string.Empty)
            {
                BS.RemoveFilter();
                refreshNumberOfRecords();
                return;
            }
            BS.RemoveFilter();

            switch (cbFilterBy.Text)
            {
                case "Category":
                    BS.Filter = $"CategoryName like '{txtFilterBy.Text}%'";
                    break;
                case "Target amount or less than":
                    BS.Filter = $"TargetAmount <= {(txtFilterBy.Text)}";
                    break;
                case "Current amount or less than":
                    BS.Filter = $"CurrentAmount <= {(txtFilterBy.Text)}";
                    break;
                case "Start date":
                    BS.Filter = $"StartDate <= #{chosenDate:MM/dd/yyyy}#";
                    break;
                case "End date":
                    BS.Filter = $"EndDate >= #{chosenDate:MM/dd/yyyy}#";
                    break;
            }
            refreshNumberOfRecords();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Target amount or less than" ||
                cbFilterBy.Text == "Current amount or less than")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsCompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            BS.RemoveFilter();
            if(cbIsCompleted.Text == "Yes")
            {
                BS.Filter = "IsCompleted = true";
            }
            else if(cbIsCompleted.Text == "No")
            {
                BS.Filter = "IsCompleted = false";
            }

            refreshNumberOfRecords();
        }
    }
}
