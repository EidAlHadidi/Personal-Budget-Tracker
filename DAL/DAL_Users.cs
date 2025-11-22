using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DAL_Users
    {
        public static bool GetUserInfoByID(int UserID, ref string Username, ref string Password, ref int PrimaryCurrencyID, ref decimal Balance)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                UserID = (int)reader["UserID"];
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                PrimaryCurrencyID = (int)reader["PrimaryCurrencyID"];
                                Balance = (decimal)reader["Balance"];

                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return isFound;

        }
        public static int AddNewUser(string Username, string Password, int PrimaryCurrencyID, decimal Balance)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO Users VALUES (@Username, @Password, @PrimaryCurrencyID, @Balance)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@Username", Username);

                        command.Parameters.AddWithValue("@Password", Password);

                        command.Parameters.AddWithValue("@PrimaryCurrencyID", PrimaryCurrencyID);

                        command.Parameters.AddWithValue("@Balance", Balance);




                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return ID;

        }


        public static bool UpdateUser(int UserID, string Username, string Password, int PrimaryCurrencyID, decimal Balance)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE Users
	SET	Username = @Username,
	Password = @Password,
	PrimaryCurrencyID = @PrimaryCurrencyID,
	Balance = @Balance	WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@Username", Username);

                        command.Parameters.AddWithValue("@Password", Password);

                        command.Parameters.AddWithValue("@PrimaryCurrencyID", PrimaryCurrencyID);

                        command.Parameters.AddWithValue("@Balance", Balance);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }

        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Users WHERE UserID= @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return isFound;

        }

        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Users";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                            reader.Close();
                        }
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return dt;
        }


    }

}