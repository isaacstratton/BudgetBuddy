using System;
using System.Windows.Forms;

namespace BudgetBuddy
{
    public partial class LoginForm : Form
    {
        private Controller controller;

        public LoginForm()
        {
            InitializeComponent();
            controller = new Controller(); // Ensure the Controller is initialized here
        }

  

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (controller.UserLogin(username, password))
            {
                MessageBox.Show("Login successful!");
                // Pass the existing Controller instance to DashboardForm
                DashboardForm dashboard = new DashboardForm(username, controller);
                dashboard.Show();
                this.Hide(); // Optionally hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the entire application
        }
    }
}
