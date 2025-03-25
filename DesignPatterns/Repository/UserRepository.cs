using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using BudgetTool.Models;
using System.IO;
using System.Configuration;
using System.Data.Odbc;

namespace BudgetTool
{
    internal class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
            //Gets and Builds the Application Path of the applicatino location
            string basePath = CurrentPath.GetDbasePath() + "\\";
            //Gets name of the database
            string dbName = DbaseNames.UserDbase;
            //Combines the Path with the Database
            string path = Path.Combine(basePath, dbName); // Safely combines paths

            //Gets the Connection String from the App.Config file
            string dbase = ConfigurationManager.ConnectionStrings["UserDbaseConnection"].ConnectionString;

            //Replaces {0} and {1} with correct values
            string cs = string.Format(dbase, DbaseNames.UserDriver, path);

            //Connection String we will use
            connectionString = cs;
        }

        public List<BudgetUsers> GetAllUsers()
        {
            var bu = new List<BudgetUsers>();

            using (var connection = new OdbcConnection(connectionString))
            {
                string query = @"SELECT [UserID], [NameOfUser], [Email], 
                                            [Username], [Password]
                                            FROM UserInfo;";

                using (var command = new OdbcCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bu.Add(new BudgetUsers
                            {
                                UserID = reader.GetInt32(0),
                                NameOfUser = reader.GetString(1),
                                Email = reader.GetString(2),
                                Username = reader.GetString(3),
                                Password = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return bu;
        }

        public UserRepository(string dbPath)
        {

            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\kmani\Documents;";

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

        public bool AuthenticateUser(string username, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar(); 

                    return count > 0;
                }
            }
        }
    }
}
