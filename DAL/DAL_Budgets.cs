using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PBTDataAccessLayer
{
    public static class DAL_Budgets
    {
        public static bool GetBudgetInfoByID(int BudgetID, ref int UserID, ref int CategoryID, ref decimal Amount, ref decimal TotalSpent, ref bool IsBudgetExceeded, ref DateTime StartDate, ref DateTime EndDate)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Budgets WHERE BudgetID = @BudgetID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BudgetID", BudgetID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                BudgetID = (int)reader["BudgetID"];
                                UserID = (int)reader["UserID"];
                                CategoryID = (int)reader["CategoryID"];
                                Amount = (decimal)reader["Amount"];
                                TotalSpent = reader["TotalSpent"] != DBNull.Value ? (decimal)reader["TotalSpent"] : TotalSpent = default;
                                IsBudgetExceeded = reader["IsBudgetExceeded"] != DBNull.Value ? (bool)reader["IsBudgetExceeded"] : IsBudgetExceeded = default;
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];

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
        public static int AddNewBudget(int UserID, int CategoryID, decimal Amount, decimal TotalSpent, bool IsBudgetExceeded, DateTime StartDate, DateTime EndDate)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO Budgets VALUES (@UserID, @CategoryID, @Amount, @TotalSpent?, @IsBudgetExceeded?, @StartDate, @EndDate)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        command.Parameters.AddWithValue("@Amount", Amount);

                        if (TotalSpent == null)
                            command.Parameters.AddWithValue("@TotalSpent", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@TotalSpent", TotalSpent);
                        if (IsBudgetExceeded == null)
                            command.Parameters.AddWithValue("@IsBudgetExceeded", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@IsBudgetExceeded", IsBudgetExceeded);
                        command.Parameters.AddWithValue("@StartDate", StartDate);

                        command.Parameters.AddWithValue("@EndDate", EndDate);




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


        public static bool UpdateBudget(int BudgetID, int UserID, int CategoryID, decimal Amount, decimal TotalSpent, bool IsBudgetExceeded, DateTime StartDate, DateTime EndDate)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE Budgets
	SET	UserID = @UserID,
	CategoryID = @CategoryID,
	Amount = @Amount,
	TotalSpent = @TotalSpent,
	IsBudgetExceeded = @IsBudgetExceeded,
	StartDate = @StartDate,
	EndDate = @EndDate	WHERE BudgetID = @BudgetID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@BudgetID", BudgetID);

                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        command.Parameters.AddWithValue("@Amount", Amount);

                        if (TotalSpent == null)
                            command.Parameters.AddWithValue("@TotalSpent", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@TotalSpent", TotalSpent);
                        if (IsBudgetExceeded == null)
                            command.Parameters.AddWithValue("@IsBudgetExceeded", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@IsBudgetExceeded", IsBudgetExceeded);
                        command.Parameters.AddWithValue("@StartDate", StartDate);

                        command.Parameters.AddWithValue("@EndDate", EndDate);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteBudget(int BudgetID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE Budgets WHERE BudgetID = @BudgetID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@BudgetID", BudgetID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return (rowsAffected > 0);

        }

        public static bool IsBudgetExist(int BudgetID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Budgets WHERE BudgetID= @BudgetID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@BudgetID", BudgetID);

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

        public static DataTable GetAllBudgets()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Budgets";
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