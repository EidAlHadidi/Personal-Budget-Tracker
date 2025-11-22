using System;
using System.Data;
using PBTDataAccessLayer;
namespace SavingGoalsBusinessLayer
{

    public class clsSavingGoa
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int SavingGoaID { get; set; }
        public int UserID { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }


        public clsSavingGoa()
        {
            this.SavingGoaID = default;
            this.UserID = default;
            this.GoalName = default;
            this.TargetAmount = default;
            this.CurrentAmount = default;
            this.StartDate = default;
            this.EndDate = default;
            this.Description = default;
            this.IsCompleted = default;


            Mode = enMode.AddNew;

        }

        private clsSavingGoa(int SavingGoaID, int UserID, string GoalName, decimal TargetAmount, decimal CurrentAmount, DateTime StartDate, DateTime EndDate, string Description, bool IsCompleted)
        {
            this.SavingGoaID = SavingGoaID;
            this.UserID = UserID;
            this.GoalName = GoalName;
            this.TargetAmount = TargetAmount;
            this.CurrentAmount = CurrentAmount;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Description = Description;
            this.IsCompleted = IsCompleted;


            Mode = enMode.Update;

        }

        private bool _AddNewSavingGoa()
        {
            //call DataAccess Layer 

            this.SavingGoaID = clsSavingGoalsDataAccess.AddNewSavingGoa(this.UserID, this.GoalName, this.TargetAmount, this.CurrentAmount, this.StartDate, this.EndDate, this.Description, this.IsCompleted);

            return (this.SavingGoaID != -1);

        }

        private bool _UpdateSavingGoa()
        {
            //call DataAccess Layer 

            return clsSavingGoalsDataAccess.UpdateSavingGoa(this.SavingGoaID, this.UserID, this.GoalName, this.TargetAmount, this.CurrentAmount, this.StartDate, this.EndDate, this.Description, this.IsCompleted);

        }

        public static clsSavingGoa Find(int SavingGoaID)
        {
            int UserID = default;
            string GoalName = default;
            decimal TargetAmount = default;
            decimal CurrentAmount = default;
            DateTime StartDate = default;
            DateTime EndDate = default;
            string Description = default;
            bool IsCompleted = default;


            if (clsSavingGoalsDataAccess.GetSavingGoaInfoByID(SavingGoaID, ref UserID, ref GoalName, ref TargetAmount, ref CurrentAmount, ref StartDate, ref EndDate, ref Description, ref IsCompleted))
                return new clsSavingGoa(SavingGoaID, UserID, GoalName, TargetAmount, CurrentAmount, StartDate, EndDate, Description, IsCompleted);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSavingGoa())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateSavingGoa();

            }




            return false;
        }

        public static DataTable GetAllSavingGoals() { return clsSavingGoalsDataAccess.GetAllSavingGoals(); }

        public static bool DeleteSavingGoa(int SavingGoaID) { return clsSavingGoalsDataAccess.DeleteSavingGoa(SavingGoaID); }

        public static bool isSavingGoaExist(int SavingGoaID) { return clsSavingGoalsDataAccess.IsSavingGoaExist(SavingGoaID); }


    }

}