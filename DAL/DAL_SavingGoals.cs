 using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DAL_SavingGoals
    {
        public static bool GetSavingGoalInfoByID(int SavingGoaID,ref int UserID, ref int CategoryID, ref string GoalName, ref decimal TargetAmount, ref decimal CurrentAmount, ref DateTime StartDate, ref DateTime EndDate, ref string Description, ref bool IsCompleted)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM SavingGoals WHERE SavingGoaID = @SavingGoaID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SavingGoaID", SavingGoaID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                SavingGoaID = (int)reader["SavingGoaID"];
                                CategoryID = (int)reader["CategoryID"];
                                UserID = (int)reader["UserID"];
                                GoalName = (string)reader["GoalName"];
                                TargetAmount = (decimal)reader["TargetAmount"];
                                CurrentAmount = (decimal)reader["CurrentAmount"];
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = reader["EndDate"] != DBNull.Value ? (DateTime)reader["EndDate"] : EndDate = default;
                                Description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : Description = default;
                                IsCompleted = (bool)reader["IsCompleted"];

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
        public static int AddNewSavingGoal(int UserID, int CategoryID, string GoalName, decimal TargetAmount, decimal CurrentAmount, DateTime StartDate, DateTime EndDate, string Description, bool IsCompleted)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO SavingGoals(UserID,CategoryID,GoalName
                        ,TargetAmount,CurrentAmount,StartDate,EndDate,Description,IsCompleted)
                        VALUES (@UserID,@CategoryID,@GoalName, 
                        @TargetAmount, @CurrentAmount, @StartDate, @EndDate, 
                        @Description, @IsCompleted);
                        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@GoalName", GoalName);

                        command.Parameters.AddWithValue("@TargetAmount", TargetAmount);

                        command.Parameters.AddWithValue("@CurrentAmount", CurrentAmount);

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        command.Parameters.AddWithValue("@StartDate", StartDate);

                        if (EndDate == null)
                            command.Parameters.AddWithValue("@EndDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@EndDate", EndDate);
                        if (Description == null)
                            command.Parameters.AddWithValue("@Description", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@IsCompleted", IsCompleted);




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


        public static bool UpdateSavingGoal(int SavingGoaID, int UserID,int CategoryID ,string GoalName, decimal TargetAmount, decimal CurrentAmount, DateTime StartDate, DateTime EndDate, string Description, bool IsCompleted)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE SavingGoals
	SET	UserID = @UserID,
	GoalName = @GoalName,
	TargetAmount = @TargetAmount,
	CurrentAmount = @CurrentAmount,
	StartDate = @StartDate,
	EndDate = @EndDate,
    CategoryID = @CategoryID,
	Description = @Description,
	IsCompleted = @IsCompleted	WHERE SavingGoaID = @SavingGoaID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@SavingGoaID", SavingGoaID);

                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@GoalName", GoalName);

                        command.Parameters.AddWithValue("@TargetAmount", TargetAmount);

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        command.Parameters.AddWithValue("@CurrentAmount", CurrentAmount);

                        command.Parameters.AddWithValue("@StartDate", StartDate);

                        if (EndDate == null)
                            command.Parameters.AddWithValue("@EndDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@EndDate", EndDate);
                        if (Description == null)
                            command.Parameters.AddWithValue("@Description", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@IsCompleted", IsCompleted);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteSavingGoal(int SavingGoaID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE SavingGoals WHERE SavingGoaID = @SavingGoaID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@SavingGoaID", SavingGoaID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return (rowsAffected > 0);

        }

        public static bool IsSavingGoalExist(int SavingGoaID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM SavingGoals WHERE SavingGoaID= @SavingGoaID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@SavingGoaID", SavingGoaID);

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

        public static DataTable GetAllSavingGoals()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM SavingGoals";
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

        public static DataTable GetSP_DisplayGoalsForUser(int userID)
        {
            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("SP_DisplayGoalsForUser",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserID", (object)userID ?? DBNull.Value);
                    using(SqlDataReader R = cmd.ExecuteReader())
                    {
                        if (R.HasRows)
                            dt.Load(R);
                    }
                }
            }

            return dt;
        }
    }

}