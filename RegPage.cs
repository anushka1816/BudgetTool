using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BudgetTool
{
    public partial class RegPage : Form
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void RegPage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn logInPage = new LogIn(); 
            logInPage.Show();          
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text; 

            UserRepository userRepository = new UserRepository(@"Data\UserDatabase.accdb");
            userRepository.AddUser(Guid.NewGuid().ToString(), name, email, username, password);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
