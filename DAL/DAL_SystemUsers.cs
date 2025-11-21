using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PBTDataAccessLayer
{
    public static class DAL_SystemUsers
    {
        public static bool GetSystemUserInfoByID(int SystemUserID, ref string Username, ref string Password, ref int Permissions)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM SystemUsers WHERE SystemUserID = @SystemUserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SystemUserID", SystemUserID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                SystemUserID = (int)reader["SystemUserID"];
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                Permissions = (int)reader["Permissions"];

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
        public static int AddNewSystemUser(string Username, string Password, int Permissions)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO SystemUsers VALUES (@Username, @Password, @Permissions)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@Username", Username);

                        command.Parameters.AddWithValue("@Password", Password);

                        command.Parameters.AddWithValue("@Permissions", Permissions);




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


        public static bool UpdateSystemUser(int SystemUserID, string Username, string Password, int Permissions)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE SystemUsers
	SET	Username = @Username,
	Password = @Password,
	Permissions = @Permissions	WHERE SystemUserID = @SystemUserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@SystemUserID", SystemUserID);

                        command.Parameters.AddWithValue("@Username", Username);

                        command.Parameters.AddWithValue("@Password", Password);

                        command.Parameters.AddWithValue("@Permissions", Permissions);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteSystemUser(int SystemUserID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE SystemUsers WHERE SystemUserID = @SystemUserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@SystemUserID", SystemUserID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }

        public static bool IsSystemUserExist(int SystemUserID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM SystemUsers WHERE SystemUserID= @SystemUserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@SystemUserID", SystemUserID);

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

        public static DataTable GetAllSystemUsers()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM SystemUsers";
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
        `

    }

}