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
    public partial class Spreadsheet : Form
    {
        public Spreadsheet()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Email", "Email");

            // Add rows to the DataGridView
            dataGridView1.Rows.Add(1, "Alice", "alice@example.com");
            dataGridView1.Rows.Add(2, "Bob", "bob@example.com");
            dataGridView1.Rows.Add(3, "Charlie", "charlie@example.com");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Spreadsheet_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
