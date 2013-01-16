namespace FinancialLedgerProject.ZaSystem
{
    partial class ZaFrSystem
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
            this.checkBoxRemeberGrid = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxSaveMaxState = new System.Windows.Forms.CheckBox();
            this.checkBoxRedAsPositive = new System.Windows.Forms.CheckBox();
            this.checkboxRememberDates = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(13, 144);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(119, 144);
            // 
            // checkBoxRemeberGrid
            // 
            this.checkBoxRemeberGrid.AutoSize = true;
            this.checkBoxRemeberGrid.Location = new System.Drawing.Point(6, 19);
            this.checkBoxRemeberGrid.Name = "checkBoxRemeberGrid";
            this.checkBoxRemeberGrid.Size = new System.Drawing.Size(156, 17);
            this.checkBoxRemeberGrid.TabIndex = 0;
            this.checkBoxRemeberGrid.Text = "Remember Grid Dimensions";
            this.checkBoxRemeberGrid.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxSaveMaxState);
            this.groupBox1.Controls.Add(this.checkBoxRedAsPositive);
            this.groupBox1.Controls.Add(this.checkboxRememberDates);
            this.groupBox1.Controls.Add(this.checkBoxRemeberGrid);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 118);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visual Settings";
            // 
            // checkBoxSaveMaxState
            // 
            this.checkBoxSaveMaxState.AutoSize = true;
            this.checkBoxSaveMaxState.Location = new System.Drawing.Point(6, 91);
            this.checkBoxSaveMaxState.Name = "checkBoxSaveMaxState";
            this.checkBoxSaveMaxState.Size = new System.Drawing.Size(131, 17);
            this.checkBoxSaveMaxState.TabIndex = 3;
            this.checkBoxSaveMaxState.Text = "Save Maximised State";
            this.checkBoxSaveMaxState.UseVisualStyleBackColor = true;
            // 
            // checkBoxRedAsPositive
            // 
            this.checkBoxRedAsPositive.AutoSize = true;
            this.checkBoxRedAsPositive.Location = new System.Drawing.Point(6, 67);
            this.checkBoxRedAsPositive.Name = "checkBoxRedAsPositive";
            this.checkBoxRedAsPositive.Size = new System.Drawing.Size(145, 17);
            this.checkBoxRedAsPositive.TabIndex = 2;
            this.checkBoxRedAsPositive.Text = "Use Red Text As Income";
            this.checkBoxRedAsPositive.UseVisualStyleBackColor = true;
            // 
            // checkboxRememberDates
            // 
            this.checkboxRememberDates.AutoSize = true;
            this.checkboxRememberDates.Location = new System.Drawing.Point(6, 43);
            this.checkboxRememberDates.Name = "checkboxRememberDates";
            this.checkboxRememberDates.Size = new System.Drawing.Size(153, 17);
            this.checkboxRememberDates.TabIndex = 1;
            this.checkboxRememberDates.Text = "Remember Dates Selected";
            this.checkboxRememberDates.UseVisualStyleBackColor = true;
            // 
            // ZaFrSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(201, 177);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ZaFrSystem";
            this.Text = "System";
            this.Load += new System.EventHandler(this.ZaFrSystem_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxRemeberGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkboxRememberDates;
        private System.Windows.Forms.CheckBox checkBoxRedAsPositive;
        private System.Windows.Forms.CheckBox checkBoxSaveMaxState;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}