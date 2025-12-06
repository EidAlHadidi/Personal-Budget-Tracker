using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmAddAmountToGoal : Form
    {
        private int _goalID;
        private clsSavingGoal _goal;
        public frmAddAmountToGoal(int GoalID)
        {
            InitializeComponent();
            this._goalID = GoalID;
            _goal = clsSavingGoal.Find(_goalID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddAmountToGoal_Load(object sender, EventArgs e)
        {
            ctrlSavingGoalInfo1.FillData(_goalID);
            lblBalance.Text = clsGlobal.LoggedInUser.Balance.ToString();
            numericUpDown1.Maximum = (_goal.TargetAmount - _goal.CurrentAmount);
        }

        private void btnTransferToGoal_Click(object sender, EventArgs e)
        {
            //Validating
            decimal amount = numericUpDown1.Value;
            if(amount > clsGlobal.LoggedInUser.Balance)
            {
                MessageBox.Show("Amount exceeds your balance!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Processing

            // 1 Update saving goal record with the new current amount
            // 2 check if amount == current then make the goal completed

            // 3 create a transaction for the transfer process

            _goal.CurrentAmount += amount;
            if (_goal.TargetAmount == _goal.CurrentAmount)
                _goal.IsCompleted = true;
            else
                _goal.IsCompleted = false;

            if(!_goal.Save())
            {
                MessageBox.Show("Error while updating", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsGlobal.LoggedInUser.SubtractToBalance(amount);



            MessageBox.Show("Amount added successfully", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ctrlSavingGoalInfo1.Enabled = false;
            numericUpDown1.Enabled = false;
            btnTransferToGoal.Enabled = false;

            clsTransaction transaction = new clsTransaction();
            transaction.UserId = clsGlobal.LoggedInUserID;
            transaction.TransactionTypeID = 3;
            transaction.CategoryID = _goal.CategoryID;
            transaction.Date = DateTime.Now;
            transaction.Description = txtAmountDescription.Text;
            transaction.amount = amount;
            transaction.ReceiptImage = string.Empty;
            transaction.GoalID = _goal.SavingGoalID;

            if(!transaction.Save())
            {
                MessageBox.Show("Error while saving transaction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblBalance.Text = clsGlobal.LoggedInUser.Balance.ToString();

        }
    }
}
