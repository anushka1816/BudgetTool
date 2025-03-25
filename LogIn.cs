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
            List<BudgetUsers> budgetUsers = userRepository.GetAllUsers();

            bool isAuthenticated = userRepository.AuthenticateUser(username, password);

            if (isAuthenticated)
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
