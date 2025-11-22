using System;
using System.Data;
using DAL;
namespace BL
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

            this.TransactionTypeID = DAL_TransactionTypes.AddNewTransactionType(this.TransactionTypeName);

            return (this.TransactionTypeID != -1);

        }

        private bool _UpdateTransactionType()
        {
            //call DataAccess Layer 

            return DAL_TransactionTypes.UpdateTransactionType(this.TransactionTypeID, this.TransactionTypeName);

        }

        public static clsTransactionType Find(int TransactionTypeID)
        {
            string TransactionTypeName = default;


            if (DAL_TransactionTypes.GetTransactionTypeInfoByID(TransactionTypeID, ref TransactionTypeName))
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

        public static DataTable GetAllTransactionTypes() { return DAL_TransactionTypes.GetAllTransactionTypes(); }

        public static bool DeleteTransactionType(int TransactionTypeID) { return DAL_TransactionTypes.DeleteTransactionType(TransactionTypeID); }

        public static bool isTransactionTypeExist(int TransactionTypeID) { return DAL_TransactionTypes.IsTransactionTypeExist(TransactionTypeID); }


    }

}