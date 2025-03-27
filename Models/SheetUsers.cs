using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTool.Models
{
    public class SheetUsers
    {
        public int SpreadsheetID { get; set; }
        public string UserID { get; set; }
        public string EntryType { get; set; }
        public double Amount { get; set; }
    }
}
