using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DAL_TransactionTypes
    {
        public static bool GetTransactionTypeInfoByID(int TransactionTypeID, ref string TransactionTypeName)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM TransactionTypes WHERE TransactionTypeID = @TransactionTypeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                TransactionTypeID = (int)reader["TransactionTypeID"];
                                TransactionTypeName = (string)reader["TransactionTypeName"];

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
        public static int AddNewTransactionType(string TransactionTypeName)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO TransactionTypes VALUES (@TransactionTypeName)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@TransactionTypeName", TransactionTypeName);




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

        public static bool UpdateTransactionType(int TransactionTypeID, string TransactionTypeName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE TransactionTypes
	SET	TransactionTypeName = @TransactionTypeName	WHERE TransactionTypeID = @TransactionTypeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

                        command.Parameters.AddWithValue("@TransactionTypeName", TransactionTypeName);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteTransactionType(int TransactionTypeID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE TransactionTypes WHERE TransactionTypeID = @TransactionTypeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }

        public static bool IsTransactionTypeExist(int TransactionTypeID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM TransactionTypes WHERE TransactionTypeID= @TransactionTypeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

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

        public static DataTable GetAllTransactionTypes()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM TransactionTypes";
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