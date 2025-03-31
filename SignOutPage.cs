using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetTool.Models;

namespace BudgetTool
{
    public partial class SignOutPage : Form
    {
        public SignOutPage()
        {
            InitializeComponent();
        }

        private void SignOutPage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogIn logInPage = new LogIn();

            // Display the LogIn form
            logInPage.Show();

            // Close the current SignOutPage form
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BudgetUsers budgetUser = GetBudgetUser(); // Replace this with your actual method to get the BudgetUsers instance

            HomePage homePage = new HomePage(budgetUser);

            // Display the HomePage form
            homePage.Show();

            // Close the current SignOutPage form
            this.Close();
        }
        private BudgetUsers GetBudgetUser()
        {
            // Implement this method to return the actual BudgetUsers instance
            return new BudgetUsers();
        }
    }
}
