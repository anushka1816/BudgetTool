using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BudgetTool
{
    public partial class Spreadsheet : Form
    {

        public Spreadsheet()
        {
            InitializeComponent();
   
        }

       
        private void Spreadsheet_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }


    }
}
