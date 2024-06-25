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
    public partial class ExpenseForm : Form
    {
        private Controller controller;
        private string username;

        public ExpenseForm(string username, Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.username = username;
            LoadExpenseCategories();
        }
        
}
