using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DAL_Transactions
    {
        public static bool GetTransactionInfoByID(int TransactionID, ref int UserId, ref int TransactionTypeID, ref DateTime Date,ref TimeSpan Time ,ref string Description, ref decimal amount, ref int CategoryID, ref string ReceiptImage)
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
                                Time = (TimeSpan)reader["Time"];
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

                    string query = @"INSERT INTO
                            Transactions 
                            (UserID,TransactionTypeID,CategoryID,Date,Time,Description,Amount,ReceiptImage)
                            VALUES (@UserId, @TransactionTypeID, cast(@Date as date),@Time, @Description, @amount, @CategoryID, @ReceiptImage)
                            SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@UserId", UserId);

                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

                        command.Parameters.AddWithValue("@Date", Date);

                        command.Parameters.AddWithValue("@Time", Date.TimeOfDay);

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

        public static bool UpdateTransaction(int TransactionID, int UserId, int TransactionTypeID, DateTime Date, string Description, decimal amount, int CategoryID, string ReceiptImage)
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
    Time = @Time,
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

                        command.Parameters.AddWithValue("@Time", Date.TimeOfDay);

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
        public static bool DeleteTransaction(int TransactionID)
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

        public static bool IsTransactionExist(int TransactionID)
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

        public static DataTable GetSP_DisplayTransactionsForUser(int UserID)
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("SP_DisplayTransactionsForUser",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserID", (object)UserID ?? DBNull.Value);
                    using(SqlDataReader R = cmd.ExecuteReader())
                    {
                        if (R.HasRows)
                        {
                            dt.Load(R);
                        }
                    }
                }
            }

            return dt;
        }

        //Modified version of add new method
        public static int AddNewTransaction_Modified(int userId,int transactionTypeID,DateTime date,string description,decimal amount,int categoryID,string receiptImage)
        {
            int InsertedID = -1;

            string query = @"
        INSERT INTO dbo.Transactions
        (UserID, TransactionTypeID, CategoryID, [Date], [Time], Description, Amount, ReceiptImage)
        VALUES
        (@UserID, @TransactionTypeID, @CategoryID, CAST(@Date AS DATE), @Time, @Description, @Amount, @ReceiptImage);

        SELECT CAST(SCOPE_IDENTITY() AS INT);
    ";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);

                            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value =
                                categoryID != -1 ? (object)categoryID : DBNull.Value;

                            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
                            cmd.Parameters.Add("@Time", SqlDbType.Time).Value = date.TimeOfDay;

                            if (string.IsNullOrEmpty(description))
                            {
                                cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                            } else
                                cmd.Parameters.AddWithValue("@Description", description);

                            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;

                            if (string.IsNullOrEmpty(receiptImage))
                            {
                                cmd.Parameters.AddWithValue("@ReceiptImage", DBNull.Value);
                            }
                            else
                                cmd.Parameters.AddWithValue("@ReceiptImage", receiptImage);

                            object R = cmd.ExecuteScalar();
                            InsertedID = Convert.ToInt32(R);

                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); // important for debugging
                        transaction.Rollback();
                        return -1;
                    }
                }
            }

            return InsertedID;
        }


    }

}