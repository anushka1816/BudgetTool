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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            RegPage regPage = new RegPage(); // Create an instance of RegPage
            regPage.Show(); // Show the RegPage form
            this.Hide();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SupportPage supportPage = new SupportPage(); 
            supportPage.Show();                         
            this.Hide();                                
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignOutPage signOutPage = new SignOutPage(); // Create an instance of SignOutPage
            signOutPage.Show();                          // Display the SignOutPage form
            this.Hide();
        }
    }
}
