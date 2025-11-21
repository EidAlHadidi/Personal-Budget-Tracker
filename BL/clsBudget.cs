using System;
using System.Data;
using DAL;
using PBTDataAccessLayer;
namespace BudgetsBusinessLayer
{

    public class clsBudget
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int BudgetID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalSpent { get; set; }
        public bool IsBudgetExceeded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public clsBudget()
        {
            this.BudgetID = default;
            this.UserID = default;
            this.CategoryID = default;
            this.Amount = default;
            this.TotalSpent = default;
            this.IsBudgetExceeded = default;
            this.StartDate = default;
            this.EndDate = default;


            Mode = enMode.AddNew;

        }

        private clsBudget(int BudgetID, int UserID, int CategoryID, decimal Amount, decimal TotalSpent, bool IsBudgetExceeded, DateTime StartDate, DateTime EndDate)
        {
            this.BudgetID = BudgetID;
            this.UserID = UserID;
            this.CategoryID = CategoryID;
            this.Amount = Amount;
            this.TotalSpent = TotalSpent;
            this.IsBudgetExceeded = IsBudgetExceeded;
            this.StartDate = StartDate;
            this.EndDate = EndDate;


            Mode = enMode.Update;

        }

        private bool _AddNewBudget()
        {
            //call DataAccess Layer 

            this.BudgetID = DAL_Budgets.AddNewBudget(this.UserID, this.CategoryID, this.Amount, this.TotalSpent, this.IsBudgetExceeded, this.StartDate, this.EndDate);

            return (this.BudgetID != -1);

        }

        private bool _UpdateBudget()
        {
            //call DataAccess Layer 

            return DAL_Budgets.UpdateBudget(this.BudgetID, this.UserID, this.CategoryID, this.Amount, this.TotalSpent, this.IsBudgetExceeded, this.StartDate, this.EndDate);

        }

        public static clsBudget Find(int BudgetID)
        {
            int UserID = default;
            int CategoryID = default;
            decimal Amount = default;
            decimal TotalSpent = default;
            bool IsBudgetExceeded = default;
            DateTime StartDate = default;
            DateTime EndDate = default;


            if (DAL_Budgets.GetBudgetInfoByID(BudgetID, ref UserID, ref CategoryID, ref Amount, ref TotalSpent, ref IsBudgetExceeded , ref StartDate, ref EndDate))
                return new clsBudget(BudgetID, UserID, CategoryID, Amount, TotalSpent , IsBudgetExceeded , StartDate, EndDate);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBudget())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateBudget();

            }




            return false;
        }

        public static DataTable GetAllBudgets() { return DAL_Budgets.GetAllBudgets(); }

        public static bool DeleteBudget(int BudgetID) { return DAL_Budgets.DeleteBudget(BudgetID); }

        public static bool isBudgetExist(int BudgetID) { return DAL_Budgets.IsBudgetExist(BudgetID); }


    }

}