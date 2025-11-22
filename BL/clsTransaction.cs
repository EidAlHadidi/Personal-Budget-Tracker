using System;
using System.Data;
using PBTDataAccessLayer;
namespace TransactionsBusinessLayer
{

    public class clsTransaction
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public short TransactionID { get; set; }
        public int UserId { get; set; }
        public int TransactionTypeID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal amount { get; set; }
        public int CategoryID { get; set; }
        public string ReceiptImage { get; set; }


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

        private clsTransaction(short TransactionID, int UserId, int TransactionTypeID, DateTime Date, string Description, decimal amount, int CategoryID, string ReceiptImage)
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

            this.TransactionID = clsTransactionsDataAccess.AddNewTransaction(this.UserId, this.TransactionTypeID, this.Date, this.Description, this.amount, this.CategoryID, this.ReceiptImage);

            return (this.TransactionID != -1);

        }

        private bool _UpdateTransaction()
        {
            //call DataAccess Layer 

            return clsTransactionsDataAccess.UpdateTransaction(this.TransactionID, this.UserId, this.TransactionTypeID, this.Date, this.Description, this.amount, this.CategoryID, this.ReceiptImage);

        }

        public static clsTransaction Find(short TransactionID)
        {
            int UserId = default;
            int TransactionTypeID = default;
            DateTime Date = default;
            string Description = default;
            decimal amount = default;
            int CategoryID = default;
            string ReceiptImage = default;


            if (clsTransactionsDataAccess.GetTransactionInfoByID(TransactionID, ref UserId, ref TransactionTypeID, ref Date, ref Description, ref amount, ref CategoryID, ref ReceiptImage))
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

        public static DataTable GetAllTransactions() { return clsTransactionsDataAccess.GetAllTransactions(); }

        public static bool DeleteTransaction(short TransactionID) { return clsTransactionsDataAccess.DeleteTransaction(TransactionID); }

        public static bool isTransactionExist(short TransactionID) { return clsTransactionsDataAccess.IsTransactionExist(TransactionID); }


    }

}