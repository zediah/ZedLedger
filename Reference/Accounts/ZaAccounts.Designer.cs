namespace FinancialLedgerProject.Reference
{
    partial class ZaAccounts
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
            this.zaAccountsReference = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.zaAccountsReference)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.Location = new System.Drawing.Point(13, 317);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(94, 317);
            // 
            // zaAccountsReference
            // 
            this.zaAccountsReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.zaAccountsReference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaAccountsReference.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.zaAccountsReference.Location = new System.Drawing.Point(13, 12);
            this.zaAccountsReference.Name = "zaAccountsReference";
            this.zaAccountsReference.RowHeadersVisible = false;
            this.zaAccountsReference.Size = new System.Drawing.Size(332, 299);
            this.zaAccountsReference.TabIndex = 0;
            this.zaAccountsReference.UseRedAsIncome = false;
            this.zaAccountsReference.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.zaAccountsReference_ColumnWidthChanged);
            // 
            // ZaAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(357, 345);
            this.Controls.Add(this.zaAccountsReference);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ZaAccounts";
            this.Text = "Manage Accounts";
            this.Load += new System.EventHandler(this.ReferenceWindow_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.zaAccountsReference, 0);
            ((System.ComponentModel.ISupportInitialize)(this.zaAccountsReference)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.ExtendedObjects.ZaDataGridView zaAccountsReference;
    }
}