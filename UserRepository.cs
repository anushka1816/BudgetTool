using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace BudgetTool
{
    internal class UserRepository
    {
        private readonly string connectionString;

        public UserRepository(string dbPath)
        {
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
        }


        public void AddUser(string userId, string name, string email, string username, string password)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                string query = $"INSERT INTO Users (UserID, Name, Email, Username, Password) VALUES " +
                               $"('{userId}', '{name}', '{email}', '{username}', '{password}')";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
