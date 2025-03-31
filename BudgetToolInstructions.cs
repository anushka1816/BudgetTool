using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetTool.Models;

namespace BudgetTool
{
    public partial class BudgetToolInstructions : Form
    {
        public BudgetToolInstructions()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BudgetToolInstructions_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BudgetUsers budgetUser = GetBudgetUser(); // Replace this with your actual method to get the BudgetUsers instance

            HomePage homePage = new HomePage(budgetUser);

            // Display the HomePage form
            homePage.Show();

            // Close the current BudgetToolInstructions form
            this.Close();

        }
        private BudgetUsers GetBudgetUser()
        {
            // Implement this method to return the actual BudgetUsers instance
            return new BudgetUsers();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SignOutPage signOutPage = new SignOutPage(); // Create an instance of SignOutPage
            signOutPage.Show();                          // Display the SignOutPage form
            this.Hide();
        }
    }
}
