using FinancialLedgerProject.Core.ExtendedObjects;
namespace FinancialLedgerProject.Accounts
{
    partial class ZaAccountDialog
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
            this.accountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.originalBalanceTextBox = new FinancialLedgerProject.Core.ExtendedObjects.ZaNumericTextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(194, 54);
            this.okButton.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(284, 54);
            this.cancelButton.TabIndex = 3;
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(12, 25);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(173, 20);
            this.accountName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Original Balance";
            // 
            // originalBalanceTextBox
            // 
            this.originalBalanceTextBox.Location = new System.Drawing.Point(191, 25);
            this.originalBalanceTextBox.Name = "originalBalanceTextBox";
            this.originalBalanceTextBox.Size = new System.Drawing.Size(169, 20);
            this.originalBalanceTextBox.TabIndex = 1;
            // 
            // ZaAccountDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 88);
            this.Controls.Add(this.originalBalanceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accountName);
            this.Name = "ZaAccountDialog";
            this.Text = "Create an account";
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.accountName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.originalBalanceTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ZaNumericTextBox originalBalanceTextBox;
    }
}