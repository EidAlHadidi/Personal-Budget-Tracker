using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public static class clsGlobal
    {
        public static int LoggedInUserID { get; set; }
        public static clsUser LoggedInUser
        {
            get
            {
                return clsUser.Find(LoggedInUserID);
            }
        }

        public static int LoggedInSystemUserID { get; set; }
        public static clsSystemUser LoggedInSystemUser
        {
            get
            {
                return clsSystemUser.Find(LoggedInSystemUserID);
            }
        }
        
        public enum enLoginMode { Admin,User};
        public static enLoginMode LoginMode = enLoginMode.User;

        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
