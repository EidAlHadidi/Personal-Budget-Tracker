using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DAL_Categories
    {
        public static bool GetCategoryInfoByID(int CategoryID, ref string CategoryName)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Categories WHERE CategoryID = @CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                CategoryID = (int)reader["CategoryID"];
                                CategoryName = (string)reader["CategoryName"];

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
        public static int AddNewCategory(string CategoryName)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO Categories VALUES (@CategoryName)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@CategoryName", CategoryName);




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


        public static bool UpdateCategory(int CategoryID, string CategoryName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE Categories
	SET	CategoryName = @CategoryName	WHERE CategoryID = @CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        command.Parameters.AddWithValue("@CategoryName", CategoryName);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteCategory(int CategoryID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE Categories WHERE CategoryID = @CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return (rowsAffected > 0);

        }

        public static bool IsCategoryExist(int CategoryID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Categories WHERE CategoryID= @CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

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

        public static DataTable GetAllCategories()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Categories";
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