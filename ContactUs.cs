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
    public partial class ContactUs : Form
    {
        public ContactUs()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            SignOutPage signOutPage = new SignOutPage();
            signOutPage.Show();
            this.Hide();
        }

        private void ContactUs_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
