using System;
using MySql.Data.MySqlClient;


    class DatabaseOperations
    {
        private string connectionString;

        public DatabaseOperations(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int AddBusiness(string businessName)
        {
            int businessId = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO business (nameBusiness) VALUES (@businessName)", conn);
                cmd.Parameters.AddWithValue("@businessName", businessName);
                cmd.ExecuteNonQuery();
                businessId = (int)cmd.LastInsertedId;
            }
            return businessId;
        }

        // other methods for adding customers and other database operations
    }
