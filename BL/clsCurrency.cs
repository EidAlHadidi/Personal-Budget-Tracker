using System;
using System.Data;
using DAL;
namespace BL
{

    public class clsCurrency
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }


        public clsCurrency()
        {
            this.CurrencyID = default;
            this.CurrencyCode = default;
            this.CurrencyName = default;


            Mode = enMode.AddNew;

        }

        private clsCurrency(int CurrencyID, string CurrencyCode, string CurrencyName)
        {
            this.CurrencyID = CurrencyID;
            this.CurrencyCode = CurrencyCode;
            this.CurrencyName = CurrencyName;


            Mode = enMode.Update;

        }


        public static clsCurrency Find(int CurrencyID)
        {
            string CurrencyCode = default;
            string CurrencyName = default;


            if (DAL_Currencies.GetCurrencyInfoByID(CurrencyID, ref CurrencyCode, ref CurrencyName))
                return new clsCurrency(CurrencyID, CurrencyCode, CurrencyName);
            else
                return null;

        }


        public static DataTable GetAllCurrencies() { return DAL_Currencies.GetAllCurrencies(); }


        public static bool isCurrencyExist(int CurrencyID) { return DAL_Currencies.IsCurrencyExist(CurrencyID); }


    }

}