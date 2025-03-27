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
    public class SpreadsheetRepository
    {
        private static string connectionString;

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

        public static List<SheetUsers> GetSpreadsheetsById(string UserId)
        {
            List<SheetUsers> sheetUsers = new List<SheetUsers>();

            using (var connection = new OdbcConnection(connectionString))
            {
                string query = @"SELECT SpreadsheetID, UserID, EntryType, Amount
                                             FROM Spreadsheet
                                             WHERE UserID = ?";

                using (var command = new OdbcCommand(query, connection))
                {
                    command.Parameters.Add(new OdbcParameter("@UserID", OdbcType.NVarChar) { Value = UserId });

                    //command.Parameters.AddWithValue("?", UserId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sheetUsers.Add(new SheetUsers
                            {
                                SpreadsheetID = reader.GetInt32(0),
                                UserID = reader.GetString(1),
                                EntryType = reader.GetString(2),
                                Amount = reader.GetDouble(3)
                            });
                        }
                    }
                }
            }

            return sheetUsers;
        }

        public static void AddEntry(string userID, string type, double amount)
        {
            try
            {
                using (var connection = new OdbcConnection(connectionString))
                {
                    string query = @"INSERT INTO Spreadsheet
                                               (UserID, EntryType, Amount)
                                               VALUES 
                                               (?, ?, ?)";

                    using (var command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.Add(new OdbcParameter("@UserID", OdbcType.NVarChar) { Value = userID });
                        command.Parameters.Add(new OdbcParameter("@EntryType", OdbcType.VarChar) { Value = type }); 
                        command.Parameters.Add(new OdbcParameter("@Amount", OdbcType.Double) { Value = amount }); 

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

        public static void DeleteEntries(string UserID)
        {
            using (var connection = new OdbcConnection(connectionString))
            {
                //Use ? as the placeholder for the parameter
                string query = @"DELETE FROM Spreadsheet 
                                           WHERE UserID = ?";

                using (var command = new OdbcCommand(query, connection))
                {
                    //Add the parameter (no need for parameter name, just value)
                    command.Parameters.AddWithValue("?", UserID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
