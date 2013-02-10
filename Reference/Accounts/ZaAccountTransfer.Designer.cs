using FinancialLedgerProject.Core.ExtendedObjects;

namespace FinancialLedgerProject.Reference.Accounts
{
    partial class ZaAccountTransfer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboOriginalAccount = new System.Windows.Forms.ComboBox();
            this.comboThroughAccount = new System.Windows.Forms.ComboBox();
            this.comboDestinationAccount = new System.Windows.Forms.ComboBox();
            this.textBox1 = new FinancialLedgerProject.Core.ExtendedObjects.ZaNumericTextBox();
            this.dateTimeDateOfTransfer = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(234, 163);
            this.okButton.Size = new System.Drawing.Size(87, 23);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(339, 163);
            this.cancelButton.Size = new System.Drawing.Size(87, 23);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Originating Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Through (Optional)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Destination Account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Amount ($)";
            // 
            // comboOriginalAccount
            // 
            this.comboOriginalAccount.FormattingEnabled = true;
            this.comboOriginalAccount.Location = new System.Drawing.Point(148, 10);
            this.comboOriginalAccount.Name = "comboOriginalAccount";
            this.comboOriginalAccount.Size = new System.Drawing.Size(255, 21);
            this.comboOriginalAccount.TabIndex = 7;
            this.comboOriginalAccount.SelectionChangeCommitted += new System.EventHandler(this.comboDestinationAccount_SelectionChangeCommitted);
            // 
            // comboThroughAccount
            // 
            this.comboThroughAccount.FormattingEnabled = true;
            this.comboThroughAccount.Location = new System.Drawing.Point(148, 38);
            this.comboThroughAccount.Name = "comboThroughAccount";
            this.comboThroughAccount.Size = new System.Drawing.Size(255, 21);
            this.comboThroughAccount.TabIndex = 8;
            this.comboThroughAccount.SelectionChangeCommitted += new System.EventHandler(this.comboDestinationAccount_SelectionChangeCommitted);
            // 
            // comboDestinationAccount
            // 
            this.comboDestinationAccount.FormattingEnabled = true;
            this.comboDestinationAccount.Location = new System.Drawing.Point(148, 67);
            this.comboDestinationAccount.Name = "comboDestinationAccount";
            this.comboDestinationAccount.Size = new System.Drawing.Size(255, 21);
            this.comboDestinationAccount.TabIndex = 9;
            this.comboDestinationAccount.SelectionChangeCommitted += new System.EventHandler(this.comboDestinationAccount_SelectionChangeCommitted);
            // 
            // textBox1
            // 
            this.textBox1.AllowSpace = false;
            this.textBox1.Location = new System.Drawing.Point(148, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 10;
            // 
            // dateTimeDateOfTransfer
            // 
            this.dateTimeDateOfTransfer.Location = new System.Drawing.Point(148, 123);
            this.dateTimeDateOfTransfer.Name = "dateTimeDateOfTransfer";
            this.dateTimeDateOfTransfer.Size = new System.Drawing.Size(255, 20);
            this.dateTimeDateOfTransfer.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Date Of Transfer";
            // 
            // ZaAccountTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 196);
            this.Controls.Add(this.dateTimeDateOfTransfer);
            this.Controls.Add(this.comboDestinationAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboThroughAccount);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboOriginalAccount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ZaAccountTransfer";
            this.ShowInTaskbar = false;
            this.Text = "Account Funds Transfer";
            this.Load += new System.EventHandler(this.ZaAccountTransfer_Load);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.comboOriginalAccount, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.comboThroughAccount, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.comboDestinationAccount, 0);
            this.Controls.SetChildIndex(this.dateTimeDateOfTransfer, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboOriginalAccount;
        private System.Windows.Forms.ComboBox comboThroughAccount;
        private System.Windows.Forms.ComboBox comboDestinationAccount;
        private ZaNumericTextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimeDateOfTransfer;
        private System.Windows.Forms.Label label5;
    }
}