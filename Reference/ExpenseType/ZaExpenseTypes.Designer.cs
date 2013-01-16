namespace FinancialLedgerProject.Reference
{
    partial class ZaExpenseTypes
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
            this.zaExpenseTypeView = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zaSecondaryExpenseTypes = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.zaExpenseTypeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaSecondaryExpenseTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.Location = new System.Drawing.Point(13, 331);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(94, 331);
            // 
            // zaExpenseTypeView
            // 
            this.zaExpenseTypeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.zaExpenseTypeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaExpenseTypeView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.zaExpenseTypeView.Location = new System.Drawing.Point(13, 12);
            this.zaExpenseTypeView.Name = "zaExpenseTypeView";
            this.zaExpenseTypeView.RowHeadersVisible = false;
            this.zaExpenseTypeView.Size = new System.Drawing.Size(334, 313);
            this.zaExpenseTypeView.TabIndex = 0;
            this.zaExpenseTypeView.UseRedAsIncome = false;
            this.zaExpenseTypeView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.zaGrid_ColumnWidthChanged);
            this.zaExpenseTypeView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.zaExpenseTypeView_DataError);
            // 
            // zaSecondaryExpenseTypes
            // 
            this.zaSecondaryExpenseTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.zaSecondaryExpenseTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaSecondaryExpenseTypes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.zaSecondaryExpenseTypes.Location = new System.Drawing.Point(353, 12);
            this.zaSecondaryExpenseTypes.Name = "zaSecondaryExpenseTypes";
            this.zaSecondaryExpenseTypes.RowHeadersVisible = false;
            this.zaSecondaryExpenseTypes.Size = new System.Drawing.Size(334, 313);
            this.zaSecondaryExpenseTypes.TabIndex = 2;
            this.zaSecondaryExpenseTypes.UseRedAsIncome = false;
            this.zaSecondaryExpenseTypes.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.zaGrid_ColumnWidthChanged);
            this.zaSecondaryExpenseTypes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.zaSecondaryExpenseTypes_DataError);
            // 
            // ZaExpenseTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(697, 357);
            this.ControlBox = false;
            this.Controls.Add(this.zaSecondaryExpenseTypes);
            this.Controls.Add(this.zaExpenseTypeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ZaExpenseTypes";
            this.Text = "Reference";
            this.Load += new System.EventHandler(this.ReferenceWindow_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.zaExpenseTypeView, 0);
            this.Controls.SetChildIndex(this.zaSecondaryExpenseTypes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.zaExpenseTypeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaSecondaryExpenseTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.ExtendedObjects.ZaDataGridView zaExpenseTypeView;
        private Core.ExtendedObjects.ZaDataGridView zaSecondaryExpenseTypes;
    }
}