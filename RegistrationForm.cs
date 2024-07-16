using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetBuddy
{
    public partial class RegistrationForm : Form
    {
        private Controller controller;
        private LoginForm loginForm;
        public RegistrationForm(Controller controller, LoginForm loginForm)
        {
            InitializeComponent();
            this.controller = controller; // Use the passed Controller instance
            this.loginForm = loginForm;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;
            string email = txtBoxEmail.Text;
            string username = txtBoxUsername.Text;
            string password = txtBoxPassword.Text;
            string confirmPassword = txtBoxPasswordConfirm.Text;

            if (!checkBoxTerms.Checked)
            {
                MessageBox.Show("You must agree to the terms and conditions to use this application");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            bool success = controller.RegisterUser(firstName, lastName, email, username, password);
            if (success)
            {
                MessageBox.Show("Registration successful!");
                this.Close();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Error during registration. Please try again.");
            }
        }
    }
}
