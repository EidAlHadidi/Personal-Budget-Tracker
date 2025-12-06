using System;
using System.Data;
using DAL;
namespace BL
{

    public class clsTransaction
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int TransactionID { get; set; }
        public int UserId { get; set; }
        public int TransactionTypeID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal amount { get; set; }
        public int CategoryID { get; set; }
        public string ReceiptImage { get; set; }

        public int GoalID { get; set; } = -1;
        public clsTransaction()
        {
            this.TransactionID = default;
            this.UserId = default;
            this.TransactionTypeID = default;
            this.Date = default;
            this.Description = default;
            this.amount = default;
            this.CategoryID = default;
            this.ReceiptImage = default;


            Mode = enMode.AddNew;

        }

        private clsTransaction(int TransactionID, int UserId, int TransactionTypeID, DateTime Date, string Description, decimal amount, int CategoryID, string ReceiptImage)
        {
            this.TransactionID = TransactionID;
            this.UserId = UserId;
            this.TransactionTypeID = TransactionTypeID;
            this.Date = Date;
            this.Description = Description;
            this.amount = amount;
            this.CategoryID = CategoryID;
            this.ReceiptImage = ReceiptImage;


            Mode = enMode.Update;

        }

        private bool _AddNewTransaction()
        {
            //call DataAccess Layer 
            this.TransactionID = Convert.ToInt32(DAL_Transactions.
                AddNewTransaction_Modified(this.UserId, this.TransactionTypeID, this.Date,
                this.Description, this.amount, this.CategoryID, this.ReceiptImage,this.GoalID));
            return (this.TransactionID != -1);
        }

        private bool _UpdateTransaction()
        {
            //call DataAccess Layer 

            return DAL_Transactions.UpdateTransaction(this.TransactionID, this.UserId, this.TransactionTypeID, this.Date, this.Description, this.amount, this.CategoryID, this.ReceiptImage);

        }

        public static clsTransaction Find(short TransactionID)
        {
            int UserId = default,GoalID = -1;
            int TransactionTypeID = default;
            DateTime Date = default;
            string Description = default;
            decimal amount = default;
            int CategoryID = default;
            string ReceiptImage = default;
            TimeSpan TS = TimeSpan.Zero;

            if (DAL_Transactions.GetTransactionInfoByID(TransactionID, ref UserId, ref TransactionTypeID, ref Date, ref TS,ref Description, ref amount, ref CategoryID, ref ReceiptImage, ref GoalID))
                return new clsTransaction(TransactionID, UserId, TransactionTypeID, Date, Description, amount, CategoryID, ReceiptImage);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransaction())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTransaction();

            }

            return false;
        }

        public static DataTable GetAllTransactions() { return DAL_Transactions.GetAllTransactions(); }

        public static DataTable GetSP_DisplayTransactionsForUser(int UserID)
        {
            return DAL_Transactions.GetSP_DisplayTransactionsForUser(UserID);
        }

        public static bool DeleteTransaction(short TransactionID) { return DAL_Transactions.DeleteTransaction(TransactionID); }

        public static bool isTransactionExist(short TransactionID) { return DAL_Transactions.IsTransactionExist(TransactionID); }


    }

}