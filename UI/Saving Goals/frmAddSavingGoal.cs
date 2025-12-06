using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace UI
{
    public partial class frmAddSavingGoal : Form
    {
        private DateTime _startingDate;
        private DateTime _endingDate;

        private void FillCategoriesInComboBox()
        {
            DataTable categories = clsCategory.GetAllCategories();
            cbCategories.Items.Add("None");
            foreach(DataRow R in categories.Rows)
            {
                cbCategories.Items.Add(R[1].ToString());
            }
        }

        private void HandleDate(DateTime chosenDate,string which)
        {
            if(which == "start")
            {
                this._startingDate = chosenDate;
                txtStartDate.Text = _startingDate.ToShortDateString();
            }
            else if(which == "end") 
            {
                this._endingDate = chosenDate;
                txtEndDate.Text = _endingDate.ToShortDateString();
            }
        }

        public frmAddSavingGoal()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddSavingGoal_Load(object sender, EventArgs e)
        {
            FillCategoriesInComboBox();
            cbCategories.SelectedIndex = 0;
        }

        private void btnChooseStartDate_Click(object sender, EventArgs e)
        {
            var frm = new frmChooseDate();
            frm.onDateChosen += (date) => HandleDate(date, "start");
            frm.ShowDialog();
        }

        private void btnChooseEndDate_Click(object sender, EventArgs e)
        {
            var frm = new frmChooseDate();
            frm.onDateChosen += (date) => HandleDate(date, "end");
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                return;
            }
            bool OpenEndingDate = false;
            if(txtStartDate.Text.Length == 0)
            {
                MessageBox.Show("No starting date chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtEndDate.Text.Length == 0)
            {
                if (MessageBox.Show("Ending date is not set, do you want to " +
                    "make the goal with open ending date?"
                    , "Open ending date", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OpenEndingDate = true;
                }
                else
                {
                    MessageBox.Show("Fill the ending date with appropriate value", "End date not set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(this._startingDate > this._endingDate && !OpenEndingDate)
            {
                MessageBox.Show("Ending date is before starting date!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if(cbCategories.SelectedIndex == 0)
            {
                MessageBox.Show("You should select a saving goal category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtTargetAmount.Text.Length == 0 || decimal.Parse(txtTargetAmount.Text) == 0)
            {
                MessageBox.Show("Target amount cannot be empty or zero!");
                return;
            }

            decimal amount = decimal.Parse(txtTargetAmount.Text.ToString());


            clsSavingGoal goal = new clsSavingGoal();
            goal.UserID = clsGlobal.LoggedInUserID;
            goal.CategoryID = cbCategories.SelectedIndex;
            goal.GoalName = txtGoalName.Text;
            goal.Description = txtGoalDescription.Text;
            goal.TargetAmount = amount;
            goal.CurrentAmount = 0m;
            goal.StartDate = _startingDate;
            if (!OpenEndingDate)
                goal.EndDate = _endingDate;
            else
                goal.EndDate = DateTime.MaxValue;
            goal.IsCompleted = false;

            if(!goal.Save())
            {
                MessageBox.Show("Error while saving the goal", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Goal saved successfully", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbCategories.Enabled = txtGoalName.Enabled = txtGoalDescription.Enabled
                = txtTargetAmount.Enabled = btnChooseEndDate.Enabled = btnChooseStartDate.Enabled =
                btnClearEndingDate.Enabled = btnClearStartingDate.Enabled = btnSave.Enabled = false;

            lblTitle.Text = $"Saving Goal = {goal.SavingGoalID}";

        }

        private void btnClearStartingDate_Click(object sender, EventArgs e)
        {
            txtStartDate.Clear();
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

        private void txtTargetAmount_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == '.' && !txtTargetAmount.Text.Contains("."))
            {
                return;
            }

            // Everything else = blocked
            e.Handled = true;
        }

        private void btnClearEndingDate_Click(object sender, EventArgs e)
        {
            txtEndDate.Clear();
        }
    }
}
