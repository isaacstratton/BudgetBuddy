using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        public bool RegisterUser(string firstName, string lastName, string email, string username, string password)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    // Check if username or email already exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, cnn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Username or email already exists.");
                            return false;
                        }
                    }

                    string query = "INSERT INTO users (first_name, last_name, email, username, password) VALUES (@first_name, @last_name, @email, @username, @password)";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int result = cmd.ExecuteNonQuery();
                        isSuccess = result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return isSuccess;
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
                using (SqlConnection cnn = new SqlConnection(connectionString))
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
            bool isSuccess = false;

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = "INSERT INTO income (transaction_date, category_id, net_income_amt, income_source, user_id) " +
                                   "VALUES (@transaction_date, @category_id, @amount, @description, " +
                                   "(SELECT user_id FROM users WHERE username = @username))";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@transaction_date", transactionDate);
                        cmd.Parameters.AddWithValue("@category_id", categoryId);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@username", username);

                        int result = cmd.ExecuteNonQuery();
                        isSuccess = result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return isSuccess;
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
