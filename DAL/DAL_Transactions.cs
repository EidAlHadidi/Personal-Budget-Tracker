using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DAL_Transactions
    {
        public static bool GetTransactionInfoByID(short TransactionID, ref int UserId, ref int TransactionTypeID, ref DateTime Date, ref string Description, ref decimal amount, ref int CategoryID, ref string ReceiptImage)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Transactions WHERE TransactionID = @TransactionID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                TransactionID = (short)reader["TransactionID"];
                                UserId = (int)reader["UserId"];
                                TransactionTypeID = (int)reader["TransactionTypeID"];
                                Date = (DateTime)reader["Date"];
                                Description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : Description = default;
                                amount = (decimal)reader["amount"];
                                CategoryID = (int)reader["CategoryID"];
                                ReceiptImage = reader["ReceiptImage"] != DBNull.Value ? (string)reader["ReceiptImage"] : ReceiptImage = default;

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
        public static int AddNewTransaction(int UserId, int TransactionTypeID, DateTime Date, string Description, decimal amount, int CategoryID, string ReceiptImage)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO Transactions VALUES (@UserId, @TransactionTypeID, @Date, @Description, @amount, @CategoryID, @ReceiptImage)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@UserId", UserId);

                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

                        command.Parameters.AddWithValue("@Date", Date);

                        if (Description == null)
                            command.Parameters.AddWithValue("@Description", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@amount", amount);

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        if (ReceiptImage == null)
                            command.Parameters.AddWithValue("@ReceiptImage", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReceiptImage", ReceiptImage);



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


        public static bool UpdateTransaction(short TransactionID, int UserId, int TransactionTypeID, DateTime Date, string Description, decimal amount, int CategoryID, string ReceiptImage)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE Transactions
	SET	UserId = @UserId,
	TransactionTypeID = @TransactionTypeID,
	Date = @Date,
	Description = @Description,
	amount = @amount,
	CategoryID = @CategoryID,
	ReceiptImage = @ReceiptImage	WHERE TransactionID = @TransactionID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

                        command.Parameters.AddWithValue("@UserId", UserId);

                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

                        command.Parameters.AddWithValue("@Date", Date);

                        if (Description == null)
                            command.Parameters.AddWithValue("@Description", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@amount", amount);

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        if (ReceiptImage == null)
                            command.Parameters.AddWithValue("@ReceiptImage", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReceiptImage", ReceiptImage);

                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteTransaction(short TransactionID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE Transactions WHERE TransactionID = @TransactionID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }

        public static bool IsTransactionExist(short TransactionID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Transactions WHERE TransactionID= @TransactionID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

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

        public static DataTable GetAllTransactions()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Transactions";
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