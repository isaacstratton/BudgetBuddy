using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetBuddy
{
    public partial class MainForm : Form
    {
        private List<Transaction> transactions;

        public MainForm()
        {
            InitializeComponent();

            // Show Login Form
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    // If login fails or is cancelled, close the application
                    this.Close();
                    return;
                }
            }

            transactions = new List<Transaction>();
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = transactions;
        }

        private void btnAddTransaction1_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddTransactionForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    transactions.Add(addForm.Transaction);
                    LoadTransactions();
                }
            }
        }
    }
}











