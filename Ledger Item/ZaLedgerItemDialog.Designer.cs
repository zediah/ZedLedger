namespace FinancialLedgerProject.Ledger_Item
{
    partial class ZaLedgerItemDialog
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
            this.purchasePriceNumeric = new FinancialLedgerProject.Core.ExtendedObjects.ZaNumericTextBox();
            this.purchaseDatePicker = new System.Windows.Forms.DateTimePicker();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.accountCombo = new System.Windows.Forms.ComboBox();
            this.expenseTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.secondaryExpenseTypeCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(192, 215);
            this.okButton.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(282, 215);
            this.cancelButton.TabIndex = 7;
            // 
            // purchasePriceNumeric
            // 
            this.purchasePriceNumeric.AllowSpace = false;
            this.purchasePriceNumeric.Location = new System.Drawing.Point(151, 6);
            this.purchasePriceNumeric.Name = "purchasePriceNumeric";
            this.purchasePriceNumeric.Size = new System.Drawing.Size(114, 20);
            this.purchasePriceNumeric.TabIndex = 0;
            // 
            // purchaseDatePicker
            // 
            this.purchaseDatePicker.Location = new System.Drawing.Point(151, 118);
            this.purchaseDatePicker.Name = "purchaseDatePicker";
            this.purchaseDatePicker.Size = new System.Drawing.Size(200, 20);
            this.purchaseDatePicker.TabIndex = 4;
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(151, 144);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(200, 50);
            this.descriptionText.TabIndex = 5;
            // 
            // accountCombo
            // 
            this.accountCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountCombo.FormattingEnabled = true;
            this.accountCombo.Location = new System.Drawing.Point(151, 90);
            this.accountCombo.Name = "accountCombo";
            this.accountCombo.Size = new System.Drawing.Size(200, 21);
            this.accountCombo.TabIndex = 3;
            // 
            // expenseTypeCombo
            // 
            this.expenseTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expenseTypeCombo.FormattingEnabled = true;
            this.expenseTypeCombo.Location = new System.Drawing.Point(151, 33);
            this.expenseTypeCombo.Name = "expenseTypeCombo";
            this.expenseTypeCombo.Size = new System.Drawing.Size(200, 21);
            this.expenseTypeCombo.TabIndex = 1;
            this.expenseTypeCombo.SelectedIndexChanged += new System.EventHandler(this.expenseTypeCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Purchase Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Expense Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Purchase Price";
            // 
            // secondaryExpenseTypeCombo
            // 
            this.secondaryExpenseTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondaryExpenseTypeCombo.FormattingEnabled = true;
            this.secondaryExpenseTypeCombo.Location = new System.Drawing.Point(151, 63);
            this.secondaryExpenseTypeCombo.Name = "secondaryExpenseTypeCombo";
            this.secondaryExpenseTypeCombo.Size = new System.Drawing.Size(200, 21);
            this.secondaryExpenseTypeCombo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Secondary Expense Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "$";
            // 
            // ZaLedgerItemDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.ClientSize = new System.Drawing.Size(365, 248);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.purchasePriceNumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondaryExpenseTypeCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.expenseTypeCombo);
            this.Controls.Add(this.purchaseDatePicker);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accountCombo);
            this.Name = "ZaLedgerItemDialog";
            this.Text = "New Ledger Item";
            this.Load += new System.EventHandler(this.ZaLedgerItemDialog_Load);
            this.Controls.SetChildIndex(this.accountCombo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.descriptionText, 0);
            this.Controls.SetChildIndex(this.purchaseDatePicker, 0);
            this.Controls.SetChildIndex(this.expenseTypeCombo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.secondaryExpenseTypeCombo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.purchasePriceNumeric, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.ExtendedObjects.ZaNumericTextBox purchasePriceNumeric;
        private System.Windows.Forms.DateTimePicker purchaseDatePicker;
        private System.Windows.Forms.TextBox descriptionText;
        private System.Windows.Forms.ComboBox accountCombo;
        private System.Windows.Forms.ComboBox expenseTypeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox secondaryExpenseTypeCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}