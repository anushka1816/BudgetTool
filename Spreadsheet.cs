using BudgetTool.DesignPatterns.Repository;
using BudgetTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BudgetTool
{
    public partial class Spreadsheet : Form
    {
        BudgetUsers budgetUsers = new BudgetUsers();
        SpreadsheetRepository spreadsheetRepository = new SpreadsheetRepository();
        List<SheetUsers> sheetUsers = new List<SheetUsers>();

        public Spreadsheet(BudgetUsers bu)
        {
            InitializeComponent();
            budgetUsers = bu;
        }

        private void Spreadsheet_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
        }

        private void SetControls()
        {
            List<SheetUsers> sheetUsers = SpreadsheetRepository.GetSpreadsheetsById(budgetUsers.UserID);

            if (sheetUsers == null)
            {
                sheetUsers = new List<SheetUsers>();

                sheetUsers.Add(new SheetUsers()
                {
                    UserID = budgetUsers.UserID,
                    EntryType = string.Empty,
                    Amount = 0
                });
            }

            // Use BindingList to allow adding, editing, and deleting
            BindingList<SheetUsers> bindingList = new BindingList<SheetUsers>(sheetUsers);
            BindingSource source = new BindingSource(bindingList, null);

            this.dgvBudgetTracker.DataSource = source;

            // Hide the UserID and SpreadsheetID columns
            this.dgvBudgetTracker.Columns["UserID"].Visible = false;
            this.dgvBudgetTracker.Columns["SpreadsheetID"].Visible = false;

            // Allow user to add, edit, and delete rows
            this.dgvBudgetTracker.AllowUserToAddRows = true;
            this.dgvBudgetTracker.AllowUserToDeleteRows = true;
            this.dgvBudgetTracker.ReadOnly = false;

            this.SetEntryCount();
        }

        private void SetEntryCount()
        {
            int iCount = this.dgvBudgetTracker.Rows.Count;
            this.lblEntries.Text = "Entries: " + (iCount - 1);
        }

        private void dgvBudgetTracker_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.SetEntryCount();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SpreadsheetRepository.DeleteEntries(budgetUsers.UserID);

            foreach (DataGridViewRow row in dgvBudgetTracker.Rows)
            {
                // Skip the new row placeholder
                if (row.IsNewRow) continue;

                string entryType = row.Cells["EntryType"].Value?.ToString();
                double amount = Convert.ToDouble(row.Cells["Amount"].Value);

                // Process the values as needed, e.g., save to the database
                SpreadsheetRepository.AddEntry(budgetUsers.UserID, entryType, amount);
            }
        }
    }
}
