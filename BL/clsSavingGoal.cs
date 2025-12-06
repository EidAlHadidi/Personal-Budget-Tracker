using System;
using System.Data;
using DAL;
namespace BL
{

    public class clsSavingGoal
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int SavingGoalID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }


        public clsSavingGoal()
        {
            this.SavingGoalID = default;
            this.UserID = default;
            this.GoalName = default;
            this.TargetAmount = default;
            this.CurrentAmount = default;
            this.StartDate = default;
            this.EndDate = default;
            this.Description = default;
            this.IsCompleted = default;
            this.CategoryID = default;

            Mode = enMode.AddNew;

        }

        private clsSavingGoal(int SavingGoalID, int UserID, int CategoryID ,string GoalName, decimal TargetAmount, decimal CurrentAmount, DateTime StartDate, DateTime EndDate, string Description, bool IsCompleted)
        {
            this.SavingGoalID = SavingGoalID;
            this.UserID = UserID;
            this.GoalName = GoalName;
            this.TargetAmount = TargetAmount;
            this.CurrentAmount = CurrentAmount;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Description = Description;
            this.IsCompleted = IsCompleted;
            this.CategoryID = CategoryID;

            Mode = enMode.Update;

        }

        private bool _AddNewSavingGoal()
        {
            //call DataAccess Layer 

            this.SavingGoalID = DAL_SavingGoals.AddNewSavingGoal(this.UserID, this.CategoryID,this.GoalName, this.TargetAmount, this.CurrentAmount, this.StartDate, this.EndDate, this.Description, this.IsCompleted);

            return (this.SavingGoalID != -1);

        }

        private bool _UpdateSavingGoal()
        {
            //call DataAccess Layer 

            return DAL_SavingGoals.UpdateSavingGoal(this.SavingGoalID, this.UserID, this.CategoryID,this.GoalName, this.TargetAmount, this.CurrentAmount, this.StartDate, this.EndDate, this.Description, this.IsCompleted);

        }

        public static clsSavingGoal Find(int SavingGoalID)
        {
            int UserID = default,CategoryID = default;
            string GoalName = default;
            decimal TargetAmount = default;
            decimal CurrentAmount = default;
            DateTime StartDate = default;
            DateTime EndDate = default;
            string Description = default;
            bool IsCompleted = default;


            if (DAL_SavingGoals.GetSavingGoalInfoByID(SavingGoalID, ref UserID, ref CategoryID,ref GoalName, ref TargetAmount, ref CurrentAmount, ref StartDate, ref EndDate, ref Description, ref IsCompleted))
                return new clsSavingGoal(SavingGoalID, UserID, CategoryID,GoalName, TargetAmount, CurrentAmount, StartDate, EndDate, Description, IsCompleted);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSavingGoal())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateSavingGoal();

            }




            return false;
        }

        public static DataTable GetAllSavingGoals() { return DAL_SavingGoals.GetAllSavingGoals(); }

        public static bool DeleteSavingGoal(int SavingGoalID) { return DAL_SavingGoals.DeleteSavingGoal(SavingGoalID); }

        public static bool isSavingGoalExist(int SavingGoalID) { return DAL_SavingGoals.IsSavingGoalExist(SavingGoalID); }

        //A stored procedure for getting all goals for a specific user 
        public static DataTable GetSP_DisplayGoalsForUser(int userID) => DAL_SavingGoals.GetSP_DisplayGoalsForUser(userID);

        public static bool GetTotalSavedMoney(int userID, ref decimal currentSavedMoney, ref decimal totalSavedMoney)
        {
            return DAL_SavingGoals.GetTotalSavedMoney(userID, ref currentSavedMoney, ref totalSavedMoney);
        }

    }

}