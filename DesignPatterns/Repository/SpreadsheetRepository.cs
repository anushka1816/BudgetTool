using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetTool.Models;

namespace BudgetTool.DesignPatterns.Repository
{
    internal class SpreadsheetRepository
    {

        private readonly string connectionString;

        public SpreadsheetRepository()
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

        public List<SheetUsers> GetAllUsers()
        {
            var bu = new List<SheetUsers>();

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
                            bu.Add(new SheetUsers
                            {
                                SpreadsheetID = reader.GetString(0),
                                UserID = reader.GetString(1),
                                EntryNo = reader.GetInt32(2),
                                EntryType = reader.GetString(3),
                                Amount = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }

            return bu;
        }

        public void AddEntry(string spreadsheetId, string userID, int num, string type, int amount)
        {
            //OleDbConnection connection = new OleDbConnection(connectionString);
            /*
            connection.Open();
            string query = $"INSERT INTO Users (UserID, Name, Email, Username, Password) VALUES " +
                            $"('{userId}', '{name}', '{email}', '{username}', '{password}')";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.ExecuteNonQuery();
            */

            try
            {
                using (var connection = new OdbcConnection(connectionString))
                {
                    string query = @"INSERT INTO Spreadsheet
                                               (SpreadsheetID, UserID, EntryNo, EntryType, Amount)
                                               VALUES 
                                               (?, ?, ?, ?, ?)";

                    using (var command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.Add(new OdbcParameter("@UserID", OdbcType.NVarChar) { Value = spreadsheetId });
                        command.Parameters.Add(new OdbcParameter("@NameOfUser", OdbcType.NVarChar) { Value = userID });
                        command.Parameters.Add(new OdbcParameter("@Email", OdbcType.Int) { Value = num }); // Updated for integer
                        command.Parameters.Add(new OdbcParameter("@Username", OdbcType.VarChar) { Value = type });
                        command.Parameters.Add(new OdbcParameter("@Password", OdbcType.Int) { Value = amount }); // Updated for integer


                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*
            finally
            {
                connection.Close();
            }
            */
        }






    }
}
