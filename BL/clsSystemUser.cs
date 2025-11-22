using System;
using System.Data;
using DAL;
namespace BL
{

    public class clsSystemUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int SystemUserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }


        public clsSystemUser()
        {
            this.SystemUserID = default;
            this.Username = default;
            this.Password = default;
            this.Permissions = default;


            Mode = enMode.AddNew;

        }

        private clsSystemUser(int SystemUserID, string Username, string Password, int Permissions)
        {
            this.SystemUserID = SystemUserID;
            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;


            Mode = enMode.Update;

        }

        private bool _AddNewSystemUser()
        {
            //call DataAccess Layer 

            this.SystemUserID = DAL_SystemUsers.AddNewSystemUser(this.Username, this.Password, this.Permissions);

            return (this.SystemUserID != -1);

        }

        private bool _UpdateSystemUser()
        {
            //call DataAccess Layer 

            return DAL_SystemUsers.UpdateSystemUser(this.SystemUserID, this.Username, this.Password, this.Permissions);

        }

        public static clsSystemUser Find(int SystemUserID)
        {
            string Username = default;
            string Password = default;
            int Permissions = default;


            if (DAL_SystemUsers.GetSystemUserInfoByID(SystemUserID, ref Username, ref Password, ref Permissions))
                return new clsSystemUser(SystemUserID, Username, Password, Permissions);
            else
                return null;

        }

        public static clsSystemUser Find(string username,string password)
        {
            int permissions = -1;
            int systemUserID = -1;


            if (DAL_SystemUsers.GetSystemUserInfoByUsernameAndPassword(username,password,ref systemUserID,ref permissions))
                return new clsSystemUser(systemUserID, username, password, permissions);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSystemUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateSystemUser();

            }




            return false;
        }

        public static DataTable GetAllSystemUsers() { return DAL_SystemUsers.GetAllSystemUsers(); }

        public static bool DeleteSystemUser(int SystemUserID) { return DAL_SystemUsers.DeleteSystemUser(SystemUserID); }

        public static bool isSystemUserExist(int SystemUserID) { return DAL_SystemUsers.IsSystemUserExist(SystemUserID); }


    }

}