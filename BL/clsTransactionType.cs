using System;
using System.Data;
using PBTDataAccessLayer;
namespace TransactionTypesBusinessLayer
{

    public class clsTransactionType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }


        public clsTransactionType()
        {
            this.TransactionTypeID = default;
            this.TransactionTypeName = default;


            Mode = enMode.AddNew;

        }

        private clsTransactionType(int TransactionTypeID, string TransactionTypeName)
        {
            this.TransactionTypeID = TransactionTypeID;
            this.TransactionTypeName = TransactionTypeName;


            Mode = enMode.Update;

        }

        private bool _AddNewTransactionType()
        {
            //call DataAccess Layer 

            this.TransactionTypeID = clsTransactionTypesDataAccess.AddNewTransactionType(this.TransactionTypeName);

            return (this.TransactionTypeID != -1);

        }

        private bool _UpdateTransactionType()
        {
            //call DataAccess Layer 

            return clsTransactionTypesDataAccess.UpdateTransactionType(this.TransactionTypeID, this.TransactionTypeName);

        }

        public static clsTransactionType Find(int TransactionTypeID)
        {
            string TransactionTypeName = default;


            if (clsTransactionTypesDataAccess.GetTransactionTypeInfoByID(TransactionTypeID, ref TransactionTypeName))
                return new clsTransactionType(TransactionTypeID, TransactionTypeName);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransactionType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTransactionType();

            }




            return false;
        }

        public static DataTable GetAllTransactionTypes() { return clsTransactionTypesDataAccess.GetAllTransactionTypes(); }

        public static bool DeleteTransactionType(int TransactionTypeID) { return clsTransactionTypesDataAccess.DeleteTransactionType(TransactionTypeID); }

        public static bool isTransactionTypeExist(int TransactionTypeID) { return clsTransactionTypesDataAccess.IsTransactionTypeExist(TransactionTypeID); }


    }

}