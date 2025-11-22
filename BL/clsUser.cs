using System;
using System.Data;
using DAL;
namespace BL
{

    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PrimaryCurrencyID { get; set; }
        public decimal Balance { get; set; }


        public clsUser()
        {
            this.UserID = default;
            this.Username = default;
            this.Password = default;
            this.PrimaryCurrencyID = default;
            this.Balance = default;


            Mode = enMode.AddNew;

        }

        private clsUser(int UserID, string Username, string Password, int PrimaryCurrencyID, decimal Balance)
        {
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.PrimaryCurrencyID = PrimaryCurrencyID;
            this.Balance = Balance;


            Mode = enMode.Update;

        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = DAL_Users.AddNewUser(this.Username, this.Password, this.PrimaryCurrencyID, this.Balance);

            return (this.UserID != -1);

        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return DAL_Users.UpdateUser(this.UserID, this.Username, this.Password, this.PrimaryCurrencyID, this.Balance);

        }

        public static clsUser Find(int UserID)
        {
            string Username = default;
            string Password = default;
            int PrimaryCurrencyID = default;
            decimal Balance = default;


            if (DAL_Users.GetUserInfoByID(UserID, ref Username, ref Password, ref PrimaryCurrencyID, ref Balance))
                return new clsUser(UserID, Username, Password, PrimaryCurrencyID, Balance);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }

        public static DataTable GetAllUsers() { return DAL_Users.GetAllUsers(); }

        public static bool DeleteUser(int UserID) { return DAL_Users.DeleteUser(UserID); }

        public static bool isUserExist(int UserID) { return DAL_Users.IsUserExist(UserID); }


    }

}