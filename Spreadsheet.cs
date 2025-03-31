using BudgetTool.DesignPatterns.Repository;
using BudgetTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
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

            // Format the Amount column as currency and right-align
            DataGridViewColumn amountColumn = this.dgvBudgetTracker.Columns["Amount"];
            amountColumn.DefaultCellStyle.Format = "C2"; // Currency format
            amountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Change the font size of the DataGridView
            this.dgvBudgetTracker.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);

            // Adjust column widths to fill the available space
            this.dgvBudgetTracker.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.SetEntryCount();

            this.UpdateTotalAmount();
        }

        private void SetEntryCount()
        {
            int iCount = this.dgvBudgetTracker.Rows.Count;
            this.lblEntries.Text = "Total Entries: " + (iCount - 1);
        }

        private void dgvBudgetTracker_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.SetEntryCount();
            this.UpdateTotalAmount();
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

        private void UpdateTotalAmount()
        {
            double totalAmount = 0;

            foreach (DataGridViewRow row in dgvBudgetTracker.Rows)
            {
                // Skip the new row placeholder
                if (row.IsNewRow) continue;

                if (row.Cells["Amount"].Value != null)
                {
                    totalAmount += Convert.ToDouble(row.Cells["Amount"].Value);
                }
            }

            // Format as currency
            this.txtAmount.Text = $"Total Amount: {totalAmount:C2}";
            this.txtAmount.Enabled = false;
            this.txtAmount.TextAlign = HorizontalAlignment.Right;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Close current form
            this.Close();
            //Create a thread to RUN a NEW application with the desired form
            Thread t = new Thread(new ThreadStart(HomePageForm));
            t.Start();
        }

        private void HomePageForm()
        {
            //RUNs a NEW application with the desired form
            Application.Run(new HomePage(budgetUsers));
        }
    }
}
