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
    public partial class AddTransactionForm : Form
    {
        public Transaction Transaction { get; private set; }

        public AddTransactionForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Ensure input validation before parsing
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                Transaction = new Transaction
                {
                    Date = dateTimePicker1.Value,
                    Description = txtDescription.Text,
                    Amount = amount,
                    Category = cmbCategory.SelectedItem.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
