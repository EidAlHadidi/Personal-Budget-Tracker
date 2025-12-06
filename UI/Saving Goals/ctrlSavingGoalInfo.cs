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
    public partial class ctrlSavingGoalInfo : UserControl
    {
        public ctrlSavingGoalInfo()
        {
            InitializeComponent();
        }

        public void FillData(int GoalID)
        {
            clsSavingGoal goal = clsSavingGoal.Find(GoalID);
            lblGoalID.Text = goal.SavingGoalID.ToString();
            lblUsername.Text = clsGlobal.LoggedInUser.Username;
            lblCategory.Text = clsCategory.Find(goal.CategoryID).CategoryName.ToString();
            lblGoalName.Text = goal.GoalName.ToString();    
            lblTargetAmount.Text = goal.TargetAmount.ToString();
            lblCurrentAmount.Text = goal.CurrentAmount.ToString();
            txtDescription.Text = goal.Description.ToString();
            lblStartDate.Text = goal.StartDate.ToShortDateString();
            lblEndDate.Text = goal.EndDate.ToShortDateString();
            lblIsCompleted.Text = goal.IsCompleted ? "YES" : "NO";
            lblProgress.Text = ((goal.CurrentAmount / goal.TargetAmount) * 100).ToString("0.00") + "%";
        }

    }
}
