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

        //Method to load categories to the forms
        public DataTable LoadCategories(string categoryType)
        {
            DataTable categories = new DataTable();

            try
            {
                using (cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = "SELECT category_id, category_name FROM categories WHERE category_type = @categoryType";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@categoryType", categoryType);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(categories);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return categories;
        }

        //Method to add income to the database
        public bool AddIncome(DateTime transactionDate, int categoryId, decimal amount, string description, string username)
        {
            bool incomeAdded = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = "INSERT INTO income (income_source, net_income_amt, transaction_date, user_id, category_id) " +
                                   "VALUES (@description, @amount, @transactionDate, (SELECT user_id FROM users WHERE username = @username), @categoryId)";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@transactionDate", transactionDate);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        incomeAdded = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return incomeAdded;
        }

        //Method to add expenses to the database
        public bool AddExpense(DateTime transactionDate, int categoryId, decimal amount, string description, string username)
        {
            bool expenseAdded = false;
            try
                {
                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        string query = "INSERT INTO expenses (transaction_date, amt_spent, expense_note, user_id, category_id) " +
                                       "VALUES (@transactionDate, @amount, @description, (SELECT user_id FROM users WHERE username = @username), @categoryId)";
                        using (SqlCommand cmd = new SqlCommand(query, cnn))
                        {
                            cmd.Parameters.AddWithValue("@transactionDate", transactionDate);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@categoryId", categoryId);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            expenseAdded = rowsAffected > 0;
                        }
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return expenseAdded;
        }

    }
}
