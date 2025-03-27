namespace BudgetTool
{
    partial class Spreadsheet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBudgetTracker = new System.Windows.Forms.DataGridView();
            this.lblEntries = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetTracker)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBudgetTracker
            // 
            this.dgvBudgetTracker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudgetTracker.Location = new System.Drawing.Point(25, 54);
            this.dgvBudgetTracker.Name = "dgvBudgetTracker";
            this.dgvBudgetTracker.Size = new System.Drawing.Size(537, 226);
            this.dgvBudgetTracker.TabIndex = 0;
            this.dgvBudgetTracker.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBudgetTracker_RowValidating);
            // 
            // lblEntries
            // 
            this.lblEntries.AutoSize = true;
            this.lblEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntries.ForeColor = System.Drawing.Color.Blue;
            this.lblEntries.Location = new System.Drawing.Point(28, 20);
            this.lblEntries.Name = "lblEntries";
            this.lblEntries.Size = new System.Drawing.Size(70, 25);
            this.lblEntries.TabIndex = 1;
            this.lblEntries.Text = "label1";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(420, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 39);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Spreadsheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(595, 351);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblEntries);
            this.Controls.Add(this.dgvBudgetTracker);
            this.Name = "Spreadsheet";
            this.Text = "Spreadsheet";
            this.Load += new System.EventHandler(this.Spreadsheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetTracker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBudgetTracker;
        private System.Windows.Forms.Label lblEntries;
        private System.Windows.Forms.Button btnSave;
    }
}