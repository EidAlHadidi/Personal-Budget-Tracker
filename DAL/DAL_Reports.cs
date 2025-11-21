using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PBTDataAccessLayer
{
    public static class DAL_Reports
    {
        public static bool GetReportInfoByID(int ReportID, ref int UserID, ref int ReportTypeID, ref string ReportData, ref DateTime GeneratedAt, ref string Description)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Reports WHERE ReportID = @ReportID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReportID", ReportID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                ReportID = (int)reader["ReportID"];
                                UserID = (int)reader["UserID"];
                                ReportTypeID = (int)reader["ReportTypeID"];
                                ReportData = (string)reader["ReportData"];
                                GeneratedAt = (DateTime)reader["GeneratedAt"];
                                Description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : Description = default;

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
        public static int AddNewReport(int UserID, int ReportTypeID, string ReportData, DateTime GeneratedAt, string Description)
        {

            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"INSERT INTO Reports VALUES (@UserID, @ReportTypeID, @ReportData, @GeneratedAt, @Description)
        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@ReportTypeID", ReportTypeID);

                        command.Parameters.AddWithValue("@ReportData", ReportData);

                        command.Parameters.AddWithValue("@GeneratedAt", GeneratedAt);

                        if (Description == null)
                            command.Parameters.AddWithValue("@Description", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Description", Description);



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


        public static bool UpdateReport(int ReportID, int UserID, int ReportTypeID, string ReportData, DateTime GeneratedAt, string Description)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"UPDATE Reports
	SET	UserID = @UserID,
	ReportTypeID = @ReportTypeID,
	ReportData = @ReportData,
	GeneratedAt = @GeneratedAt,
	Description = @Description	WHERE ReportID = @ReportID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@ReportID", ReportID);

                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@ReportTypeID", ReportTypeID);

                        command.Parameters.AddWithValue("@ReportData", ReportData);

                        command.Parameters.AddWithValue("@GeneratedAt", GeneratedAt);

                        if (Description == null)
                            command.Parameters.AddWithValue("@Description", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Description", Description);

                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { throw ex; }
            return (rowsAffected > 0);

        }
        public static bool DeleteReport(int ReportID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE Reports WHERE ReportID = @ReportID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ReportID", ReportID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return (rowsAffected > 0);

        }

        public static bool IsReportExist(int ReportID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Reports WHERE ReportID= @ReportID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ReportID", ReportID);

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

        public static DataTable GetAllReports()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Reports";
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