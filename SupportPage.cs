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
    public partial class SupportPage : Form
    {
        public SupportPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContactUs contactUsPage = new ContactUs();

            // Display the ContactUs form
            contactUsPage.Show();

            // Close the current SupportPage form
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SupportPage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Assuming you have a BudgetUsers instance available
            BudgetUsers budgetUser = GetBudgetUser(); // Replace this with your actual method to get the BudgetUsers instance

            HomePage homePage = new HomePage(budgetUser);

            // Display the HomePage form
            homePage.Show();

            // Close the current SupportPage form
            this.Close();

        }

        private BudgetUsers GetBudgetUser()
        {
            // Implement this method to return the actual BudgetUsers instance
            return new BudgetUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignOutPage signOutPage = new SignOutPage();

            // Display the SignOutPage form
            signOutPage.Show();

            // Hide the current ContactUs form
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BudgetToolInstructions instructionsPage = new BudgetToolInstructions();

            // Display the BudgetToolInstructions form
            instructionsPage.Show();

            // Close the current SupportPage form
            this.Close();
        }
    }
}
