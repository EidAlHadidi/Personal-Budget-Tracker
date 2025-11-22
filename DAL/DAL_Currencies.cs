using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class clsCurrenciesDataAccess
    {
        public static bool GetCurrencyInfoByID(int CurrencyID, ref string CurrencyCode, ref string CurrencyName)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Currencies WHERE CurrencyID = @CurrencyID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                CurrencyID = (int)reader["CurrencyID"];
                                CurrencyCode = (string)reader["CurrencyCode"];
                                CurrencyName = (string)reader["CurrencyName"];

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

        public static bool IsCurrencyExist(int CurrencyID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT Found=1 FROM Currencies WHERE CurrencyID= @CurrencyID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

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

        public static DataTable GetAllCurrencies()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Currencies";
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