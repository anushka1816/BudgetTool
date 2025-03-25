using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            HomePage homePage = new HomePage(); // Create an instance of the HomePage form
            homePage.Show();                   // Show the HomePage form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignOutPage signOutPage = new SignOutPage(); // Create an instance of SignOutPage
            signOutPage.Show();                          // Display the SignOutPage form
            this.Hide();
        }
    }
}
