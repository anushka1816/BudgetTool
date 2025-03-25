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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text; 
            string password = textBox4.Text; 

            UserRepository userRepository = new UserRepository(@"Data\UserDatabase.accdb");

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
