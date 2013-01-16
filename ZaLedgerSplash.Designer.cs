namespace FinancialLedgerProject
{
    partial class ZaLedgerSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZaLedgerSplash));
            this.newButton = new System.Windows.Forms.Button();
            this.openExistingButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.useLastButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(137, 104);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(171, 37);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "Create New Ledger";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openExistingButton
            // 
            this.openExistingButton.Location = new System.Drawing.Point(137, 147);
            this.openExistingButton.Name = "openExistingButton";
            this.openExistingButton.Size = new System.Drawing.Size(171, 38);
            this.openExistingButton.TabIndex = 1;
            this.openExistingButton.Text = "Open Existing Ledger";
            this.openExistingButton.UseVisualStyleBackColor = true;
            this.openExistingButton.Click += new System.EventHandler(this.openExistingButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(137, 231);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(171, 34);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // useLastButton
            // 
            this.useLastButton.Location = new System.Drawing.Point(137, 191);
            this.useLastButton.Name = "useLastButton";
            this.useLastButton.Size = new System.Drawing.Size(171, 34);
            this.useLastButton.TabIndex = 3;
            this.useLastButton.Text = "Open Last Used Ledger";
            this.useLastButton.UseVisualStyleBackColor = true;
            this.useLastButton.Click += new System.EventHandler(this.useLastButton_Click);
            // 
            // ZaLedgerSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.LedgerSplashBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(455, 336);
            this.Controls.Add(this.useLastButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.openExistingButton);
            this.Controls.Add(this.newButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZaLedgerSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.ZaLedgerSplash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button openExistingButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button useLastButton;
    }
}