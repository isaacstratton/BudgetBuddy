using System;
using System.Data.SqlClient;

namespace BudgetBuddy
{
    public class Controller
    {
        private string connectionString;
        private int userId;

        // Default Constructor
        public Controller()
        {
            connectionString = "Server=localhost\\SQLEXPRESS;Database=BudgetBuddy;Trusted_Connection=True;TrustServerCertificate=True;Connection Timeout=30;";
        }

        // Constructor that takes a DB connection string
        public Controller(string conn)
        {
            connectionString = conn;
        }

        // Method to handle user login
        public bool UserLogin(string username, string password)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = "SELECT user_id FROM users WHERE username=@username AND password=@password";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            userId = Convert.ToInt32(result);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine("Error during login: " + ex.Message);
                return false;
            }
        }

        // Method to load user's income
        public decimal LoadIncome()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = "SELECT SUM(net_income_amt) FROM income WHERE user_id=@user_id";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Error loading income: " + ex.Message);
                return 0;
            }
        }

        // Method to load user's expenses
        public decimal LoadExpenses()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = "SELECT SUM(amt_spent) FROM expenses WHERE user_id=@user_id";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Error loading expenses: " + ex.Message);
                return 0;
            }
        }

        // Method to calculate net balance
        public decimal CalculateNetBalance(decimal income, decimal expenses)
        {
            return income - expenses;
        }
    }
}