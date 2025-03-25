using BudgetTool.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BudgetTool
{
    public partial class LogIn : Form
    {

        BudgetUsers budgetUsers = new BudgetUsers();

        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnLogn_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text; 
            string password = textBox4.Text;

            //UserRepository userRepository = new UserRepository(@"Data\UserDatabase.accdb");
            UserRepository userRepository = new UserRepository();

            //Get All Users in the Databse
            List<BudgetUsers> budgetUsers = userRepository.GetAllUsers();

            if (budgetUsers.Count == 0)
            {
                MessageBox.Show("No Users in the Database.", Titles.AppName, 
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var foundUser = budgetUsers.Find(x => x.Username == username && x.Password == password);

            //bool isAuthenticated = userRepository.AuthenticateUser(username, password);

            //if (isAuthenticated)
            if (foundUser != null)
            {
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegPage regPage = new RegPage();
            regPage.Show();
            this.Hide();
        }
    }
}
