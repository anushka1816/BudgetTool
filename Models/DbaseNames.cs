using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTool.Models
{
    public static class DbaseNames
    {
        /*********************************************************
         * 1. Right click on the project name
         * 2. Select Properties
         * 3. Go To Build
         * 4. Uncheck "Prefer 32-bit"
         *********************************************************/

        public static string UserDbase { get; } = "UserDatabase.accdb";
        public static string UserDriver { get; } = "{Microsoft Access Driver (*.mdb, *.accdb)}";
        //public static string DSNName { get; } = "MSAccessDSN64.dsn";
    }
}
