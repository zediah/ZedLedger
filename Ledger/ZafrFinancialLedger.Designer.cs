using FinancialLedgerProject.Core.ExtendedObjects;
namespace FinancialLedgerProject
{
    partial class ZafrFinancialLedger
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZafrFinancialLedger));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TabControlPrimary = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.nameFilterTextBox = new System.Windows.Forms.TextBox();
            this.zaLedgerItemsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyData = new System.Windows.Forms.TabPage();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.typeFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.budgetTab = new System.Windows.Forms.TabPage();
            this.btnBudgetPopulate = new System.Windows.Forms.Button();
            this.btnBudgetAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxBudget = new System.Windows.Forms.ComboBox();
            this.importTab = new System.Windows.Forms.TabPage();
            this.groupBoxImport = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnImportFileDialog = new System.Windows.Forms.Button();
            this.btnGenerateImport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.setupTab = new System.Windows.Forms.TabPage();
            this.btnAccountRemove = new System.Windows.Forms.Button();
            this.btnAccountAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExpenseRemove = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExpeseAdd = new System.Windows.Forms.Button();
            this.btnSubExpenseRemove = new System.Windows.Forms.Button();
            this.btnSubExpenseAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripOpenFileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateToLabel = new System.Windows.Forms.Label();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.dateToPicker = new System.Windows.Forms.DateTimePicker();
            this.dateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.splitContainerReference = new System.Windows.Forms.SplitContainer();
            this.btnAccountTransfer = new System.Windows.Forms.Button();
            this.labelAccountSummary = new System.Windows.Forms.Label();
            this.cmsAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.transferFundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxDateRange = new System.Windows.Forms.GroupBox();
            this.labelExpenseSummary = new System.Windows.Forms.Label();
            this.zAccountStatsView = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zExpenseTypeStatsView = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zledgerItemListView = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zBreakdownDataGridView = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zaBudgetGrid = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zaExpenseTypeReferenceDGV = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zaSecondaryExpenseReferenceDGV = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zaAccountsReferenceDGV = new FinancialLedgerProject.Core.ExtendedObjects.ZaDataGridView();
            this.zaAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabControlPrimary.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.zaLedgerItemsContextMenu.SuspendLayout();
            this.monthlyData.SuspendLayout();
            this.budgetTab.SuspendLayout();
            this.importTab.SuspendLayout();
            this.groupBoxImport.SuspendLayout();
            this.setupTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReference)).BeginInit();
            this.splitContainerReference.Panel1.SuspendLayout();
            this.splitContainerReference.Panel2.SuspendLayout();
            this.splitContainerReference.SuspendLayout();
            this.cmsAccount.SuspendLayout();
            this.groupBoxDateRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zAccountStatsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zExpenseTypeStatsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zledgerItemListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zBreakdownDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaBudgetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaExpenseTypeReferenceDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaSecondaryExpenseReferenceDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaAccountsReferenceDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // TabControlPrimary
            // 
            this.TabControlPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TabControlPrimary.Controls.Add(this.mainPage);
            this.TabControlPrimary.Controls.Add(this.monthlyData);
            this.TabControlPrimary.Controls.Add(this.budgetTab);
            this.TabControlPrimary.Controls.Add(this.importTab);
            this.TabControlPrimary.Controls.Add(this.setupTab);
            this.TabControlPrimary.Location = new System.Drawing.Point(3, 27);
            this.TabControlPrimary.Multiline = true;
            this.TabControlPrimary.Name = "TabControlPrimary";
            this.TabControlPrimary.SelectedIndex = 0;
            this.TabControlPrimary.Size = new System.Drawing.Size(484, 519);
            this.TabControlPrimary.TabIndex = 1;
            this.TabControlPrimary.SelectedIndexChanged += new System.EventHandler(this.tabControlDataDisplay_SelectedIndexChanged);
            // 
            // mainPage
            // 
            this.mainPage.BackColor = System.Drawing.Color.Transparent;
            this.mainPage.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.mainPage.Controls.Add(this.label7);
            this.mainPage.Controls.Add(this.nameFilterTextBox);
            this.mainPage.Controls.Add(this.zledgerItemListView);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(476, 493);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Main";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Filter Results By:";
            // 
            // nameFilterTextBox
            // 
            this.nameFilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameFilterTextBox.Location = new System.Drawing.Point(97, 6);
            this.nameFilterTextBox.Name = "nameFilterTextBox";
            this.nameFilterTextBox.Size = new System.Drawing.Size(370, 20);
            this.nameFilterTextBox.TabIndex = 14;
            this.nameFilterTextBox.TextChanged += new System.EventHandler(this.nameFilterTextBox_TextChanged);
            // 
            // zaLedgerItemsContextMenu
            // 
            this.zaLedgerItemsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.splitToolStripMenuItem});
            this.zaLedgerItemsContextMenu.Name = "zaLedgerItemsContextMenu";
            this.zaLedgerItemsContextMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem
            // 
            this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
            this.splitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.splitToolStripMenuItem.Text = "Split";
            this.splitToolStripMenuItem.Click += new System.EventHandler(this.splitToolStripMenuItem_Click);
            // 
            // monthlyData
            // 
            this.monthlyData.BackColor = System.Drawing.Color.LightSteelBlue;
            this.monthlyData.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.monthlyData.Controls.Add(this.zBreakdownDataGridView);
            this.monthlyData.Controls.Add(this.filterComboBox);
            this.monthlyData.Controls.Add(this.typeFilterComboBox);
            this.monthlyData.Controls.Add(this.label2);
            this.monthlyData.Controls.Add(this.label1);
            this.monthlyData.Location = new System.Drawing.Point(4, 22);
            this.monthlyData.Name = "monthlyData";
            this.monthlyData.Padding = new System.Windows.Forms.Padding(3);
            this.monthlyData.Size = new System.Drawing.Size(476, 493);
            this.monthlyData.TabIndex = 1;
            this.monthlyData.Text = "Breakdown";
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(285, 11);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(185, 21);
            this.filterComboBox.TabIndex = 3;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // typeFilterComboBox
            // 
            this.typeFilterComboBox.FormattingEnabled = true;
            this.typeFilterComboBox.Location = new System.Drawing.Point(45, 11);
            this.typeFilterComboBox.Name = "typeFilterComboBox";
            this.typeFilterComboBox.Size = new System.Drawing.Size(170, 21);
            this.typeFilterComboBox.TabIndex = 2;
            this.typeFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.typeFilterComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filter On:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // budgetTab
            // 
            this.budgetTab.BackColor = System.Drawing.Color.LightSteelBlue;
            this.budgetTab.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.budgetTab.Controls.Add(this.zaBudgetGrid);
            this.budgetTab.Controls.Add(this.btnBudgetPopulate);
            this.budgetTab.Controls.Add(this.btnBudgetAdd);
            this.budgetTab.Controls.Add(this.label8);
            this.budgetTab.Controls.Add(this.comboBoxBudget);
            this.budgetTab.Location = new System.Drawing.Point(4, 22);
            this.budgetTab.Name = "budgetTab";
            this.budgetTab.Padding = new System.Windows.Forms.Padding(3);
            this.budgetTab.Size = new System.Drawing.Size(476, 493);
            this.budgetTab.TabIndex = 4;
            this.budgetTab.Text = "Budget";
            // 
            // btnBudgetPopulate
            // 
            this.btnBudgetPopulate.Location = new System.Drawing.Point(274, 10);
            this.btnBudgetPopulate.Name = "btnBudgetPopulate";
            this.btnBudgetPopulate.Size = new System.Drawing.Size(75, 23);
            this.btnBudgetPopulate.TabIndex = 4;
            this.btnBudgetPopulate.Text = "Populate";
            this.btnBudgetPopulate.UseVisualStyleBackColor = true;
            this.btnBudgetPopulate.Click += new System.EventHandler(this.btnBudgetPopulate_Click);
            // 
            // btnBudgetAdd
            // 
            this.btnBudgetAdd.Location = new System.Drawing.Point(242, 9);
            this.btnBudgetAdd.Name = "btnBudgetAdd";
            this.btnBudgetAdd.Size = new System.Drawing.Size(25, 22);
            this.btnBudgetAdd.TabIndex = 3;
            this.btnBudgetAdd.Text = "+";
            this.btnBudgetAdd.UseVisualStyleBackColor = true;
            this.btnBudgetAdd.Click += new System.EventHandler(this.btnBudgetAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(6, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Budget:";
            // 
            // comboBoxBudget
            // 
            this.comboBoxBudget.FormattingEnabled = true;
            this.comboBoxBudget.Location = new System.Drawing.Point(56, 10);
            this.comboBoxBudget.Name = "comboBoxBudget";
            this.comboBoxBudget.Size = new System.Drawing.Size(180, 21);
            this.comboBoxBudget.TabIndex = 1;
            // 
            // importTab
            // 
            this.importTab.BackColor = System.Drawing.Color.LightSteelBlue;
            this.importTab.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.importTab.Controls.Add(this.groupBoxImport);
            this.importTab.Location = new System.Drawing.Point(4, 22);
            this.importTab.Name = "importTab";
            this.importTab.Padding = new System.Windows.Forms.Padding(3);
            this.importTab.Size = new System.Drawing.Size(476, 493);
            this.importTab.TabIndex = 3;
            this.importTab.Text = "Import";
            // 
            // groupBoxImport
            // 
            this.groupBoxImport.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.groupBoxImport.Controls.Add(this.textBox1);
            this.groupBoxImport.Controls.Add(this.btnImportFileDialog);
            this.groupBoxImport.Controls.Add(this.btnGenerateImport);
            this.groupBoxImport.Controls.Add(this.label6);
            this.groupBoxImport.Controls.Add(this.btnImport);
            this.groupBoxImport.Location = new System.Drawing.Point(6, 12);
            this.groupBoxImport.Name = "groupBoxImport";
            this.groupBoxImport.Size = new System.Drawing.Size(247, 135);
            this.groupBoxImport.TabIndex = 3;
            this.groupBoxImport.TabStop = false;
            this.groupBoxImport.Text = "Import";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 4;
            // 
            // btnImportFileDialog
            // 
            this.btnImportFileDialog.Location = new System.Drawing.Point(212, 74);
            this.btnImportFileDialog.Name = "btnImportFileDialog";
            this.btnImportFileDialog.Size = new System.Drawing.Size(28, 23);
            this.btnImportFileDialog.TabIndex = 3;
            this.btnImportFileDialog.Text = "...";
            this.btnImportFileDialog.UseVisualStyleBackColor = true;
            // 
            // btnGenerateImport
            // 
            this.btnGenerateImport.Location = new System.Drawing.Point(6, 105);
            this.btnGenerateImport.Name = "btnGenerateImport";
            this.btnGenerateImport.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateImport.TabIndex = 0;
            this.btnGenerateImport.Text = "Generate";
            this.btnGenerateImport.UseVisualStyleBackColor = true;
            this.btnGenerateImport.Click += new System.EventHandler(this.btnGenerateImport_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 61);
            this.label6.TabIndex = 2;
            this.label6.Text = "To import ledger items to this ledger from an excel document. Please use the Exce" +
    "l Document provided by \"Generate\". Fill this document in, save it and then impor" +
    "t.";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(87, 105);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // setupTab
            // 
            this.setupTab.BackColor = System.Drawing.Color.Transparent;
            this.setupTab.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.setupTab.Controls.Add(this.btnAccountRemove);
            this.setupTab.Controls.Add(this.btnAccountAdd);
            this.setupTab.Controls.Add(this.label3);
            this.setupTab.Controls.Add(this.splitContainer1);
            this.setupTab.Controls.Add(this.zaAccountsReferenceDGV);
            this.setupTab.Location = new System.Drawing.Point(4, 22);
            this.setupTab.Name = "setupTab";
            this.setupTab.Padding = new System.Windows.Forms.Padding(3);
            this.setupTab.Size = new System.Drawing.Size(476, 493);
            this.setupTab.TabIndex = 2;
            this.setupTab.Text = "Setup";
            // 
            // btnAccountRemove
            // 
            this.btnAccountRemove.Location = new System.Drawing.Point(123, 2);
            this.btnAccountRemove.Name = "btnAccountRemove";
            this.btnAccountRemove.Size = new System.Drawing.Size(25, 18);
            this.btnAccountRemove.TabIndex = 5;
            this.btnAccountRemove.Text = "-";
            this.btnAccountRemove.UseVisualStyleBackColor = true;
            // 
            // btnAccountAdd
            // 
            this.btnAccountAdd.Location = new System.Drawing.Point(92, 2);
            this.btnAccountAdd.Name = "btnAccountAdd";
            this.btnAccountAdd.Size = new System.Drawing.Size(25, 18);
            this.btnAccountAdd.TabIndex = 4;
            this.btnAccountAdd.Text = "+";
            this.btnAccountAdd.UseVisualStyleBackColor = true;
            this.btnAccountAdd.Click += new System.EventHandler(this.btnAccountAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Accounts Setup";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 154);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.splitContainer1.Panel1.Controls.Add(this.btnExpenseRemove);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnExpeseAdd);
            this.splitContainer1.Panel1.Controls.Add(this.zaExpenseTypeReferenceDGV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.splitContainer1.Panel2.Controls.Add(this.btnSubExpenseRemove);
            this.splitContainer1.Panel2.Controls.Add(this.btnSubExpenseAdd);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.zaSecondaryExpenseReferenceDGV);
            this.splitContainer1.Size = new System.Drawing.Size(465, 333);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnExpenseRemove
            // 
            this.btnExpenseRemove.Location = new System.Drawing.Point(120, 3);
            this.btnExpenseRemove.Name = "btnExpenseRemove";
            this.btnExpenseRemove.Size = new System.Drawing.Size(25, 18);
            this.btnExpenseRemove.TabIndex = 7;
            this.btnExpenseRemove.Text = "-";
            this.btnExpenseRemove.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Expense Types";
            // 
            // btnExpeseAdd
            // 
            this.btnExpeseAdd.Location = new System.Drawing.Point(89, 3);
            this.btnExpeseAdd.Name = "btnExpeseAdd";
            this.btnExpeseAdd.Size = new System.Drawing.Size(25, 18);
            this.btnExpeseAdd.TabIndex = 6;
            this.btnExpeseAdd.Text = "+";
            this.btnExpeseAdd.UseVisualStyleBackColor = true;
            this.btnExpeseAdd.Click += new System.EventHandler(this.btnExpeseAdd_Click);
            // 
            // btnSubExpenseRemove
            // 
            this.btnSubExpenseRemove.Location = new System.Drawing.Point(135, 2);
            this.btnSubExpenseRemove.Name = "btnSubExpenseRemove";
            this.btnSubExpenseRemove.Size = new System.Drawing.Size(25, 18);
            this.btnSubExpenseRemove.TabIndex = 9;
            this.btnSubExpenseRemove.Text = "-";
            this.btnSubExpenseRemove.UseVisualStyleBackColor = true;
            // 
            // btnSubExpenseAdd
            // 
            this.btnSubExpenseAdd.Location = new System.Drawing.Point(104, 3);
            this.btnSubExpenseAdd.Name = "btnSubExpenseAdd";
            this.btnSubExpenseAdd.Size = new System.Drawing.Size(25, 18);
            this.btnSubExpenseAdd.TabIndex = 8;
            this.btnSubExpenseAdd.Text = "+";
            this.btnSubExpenseAdd.UseVisualStyleBackColor = true;
            this.btnSubExpenseAdd.Click += new System.EventHandler(this.btnSubExpenseAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(1, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sub-Expense Types";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Navy;
            this.menuStrip1.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.debut_dark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(910, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.btnNewButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.btnOpenItemList_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.btnSaveItemList_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.saveAsToolStripMenuItem.Text = "Save As..";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.btnSaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnExitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripSeparator3});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.btnSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(114, 6);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.debut_dark;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripOpenFileLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(910, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripOpenFileLabel
            // 
            this.toolStripOpenFileLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripOpenFileLabel.Name = "toolStripOpenFileLabel";
            this.toolStripOpenFileLabel.Size = new System.Drawing.Size(0, 17);
            this.toolStripOpenFileLabel.Text = "None";
            // 
            // dateToLabel
            // 
            this.dateToLabel.AutoSize = true;
            this.dateToLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateToLabel.Location = new System.Drawing.Point(158, 16);
            this.dateToLabel.Name = "dateToLabel";
            this.dateToLabel.Size = new System.Drawing.Size(49, 13);
            this.dateToLabel.TabIndex = 22;
            this.dateToLabel.Text = "Date To:";
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.AutoSize = true;
            this.dateFromLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateFromLabel.Location = new System.Drawing.Point(6, 16);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(59, 13);
            this.dateFromLabel.TabIndex = 21;
            this.dateFromLabel.Text = "Date From:";
            // 
            // dateToPicker
            // 
            this.dateToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateToPicker.Location = new System.Drawing.Point(213, 13);
            this.dateToPicker.Name = "dateToPicker";
            this.dateToPicker.Size = new System.Drawing.Size(78, 20);
            this.dateToPicker.TabIndex = 18;
            this.dateToPicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // dateFromPicker
            // 
            this.dateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFromPicker.Location = new System.Drawing.Point(71, 13);
            this.dateFromPicker.Name = "dateFromPicker";
            this.dateFromPicker.Size = new System.Drawing.Size(81, 20);
            this.dateFromPicker.TabIndex = 17;
            this.dateFromPicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // splitContainerReference
            // 
            this.splitContainerReference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerReference.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.splitContainerReference.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerReference.Location = new System.Drawing.Point(490, 49);
            this.splitContainerReference.Name = "splitContainerReference";
            this.splitContainerReference.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerReference.Panel1
            // 
            this.splitContainerReference.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerReference.Panel1.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.splitContainerReference.Panel1.Controls.Add(this.btnAccountTransfer);
            this.splitContainerReference.Panel1.Controls.Add(this.labelAccountSummary);
            this.splitContainerReference.Panel1.Controls.Add(this.zAccountStatsView);
            this.splitContainerReference.Panel1.Controls.Add(this.groupBoxDateRange);
            // 
            // splitContainerReference.Panel2
            // 
            this.splitContainerReference.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerReference.Panel2.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.splitContainerReference.Panel2.Controls.Add(this.labelExpenseSummary);
            this.splitContainerReference.Panel2.Controls.Add(this.zExpenseTypeStatsView);
            this.splitContainerReference.Size = new System.Drawing.Size(408, 493);
            this.splitContainerReference.SplitterDistance = 156;
            this.splitContainerReference.TabIndex = 23;
            // 
            // btnAccountTransfer
            // 
            this.btnAccountTransfer.Location = new System.Drawing.Point(312, 13);
            this.btnAccountTransfer.Name = "btnAccountTransfer";
            this.btnAccountTransfer.Size = new System.Drawing.Size(75, 24);
            this.btnAccountTransfer.TabIndex = 25;
            this.btnAccountTransfer.Text = "Transfer";
            this.btnAccountTransfer.UseVisualStyleBackColor = true;
            this.btnAccountTransfer.Click += new System.EventHandler(this.btnAccountTransfer_Click);
            // 
            // labelAccountSummary
            // 
            this.labelAccountSummary.AutoSize = true;
            this.labelAccountSummary.BackColor = System.Drawing.Color.Transparent;
            this.labelAccountSummary.Location = new System.Drawing.Point(4, 44);
            this.labelAccountSummary.Name = "labelAccountSummary";
            this.labelAccountSummary.Size = new System.Drawing.Size(104, 13);
            this.labelAccountSummary.TabIndex = 20;
            this.labelAccountSummary.Text = "Account(s) Summary";
            // 
            // cmsAccount
            // 
            this.cmsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferFundsToolStripMenuItem});
            this.cmsAccount.Name = "cmsAccount";
            this.cmsAccount.Size = new System.Drawing.Size(153, 26);
            // 
            // transferFundsToolStripMenuItem
            // 
            this.transferFundsToolStripMenuItem.Name = "transferFundsToolStripMenuItem";
            this.transferFundsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.transferFundsToolStripMenuItem.Text = "Transfer Funds";
            this.transferFundsToolStripMenuItem.Click += new System.EventHandler(this.transferFundsToolStripMenuItem_Click);
            // 
            // groupBoxDateRange
            // 
            this.groupBoxDateRange.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.groupBoxDateRange.Controls.Add(this.dateFromLabel);
            this.groupBoxDateRange.Controls.Add(this.dateFromPicker);
            this.groupBoxDateRange.Controls.Add(this.dateToLabel);
            this.groupBoxDateRange.Controls.Add(this.dateToPicker);
            this.groupBoxDateRange.Location = new System.Drawing.Point(3, 0);
            this.groupBoxDateRange.Name = "groupBoxDateRange";
            this.groupBoxDateRange.Size = new System.Drawing.Size(303, 41);
            this.groupBoxDateRange.TabIndex = 24;
            this.groupBoxDateRange.TabStop = false;
            this.groupBoxDateRange.Text = "Specified Date Range";
            // 
            // labelExpenseSummary
            // 
            this.labelExpenseSummary.AutoSize = true;
            this.labelExpenseSummary.BackColor = System.Drawing.Color.Transparent;
            this.labelExpenseSummary.Location = new System.Drawing.Point(3, 4);
            this.labelExpenseSummary.Name = "labelExpenseSummary";
            this.labelExpenseSummary.Size = new System.Drawing.Size(105, 13);
            this.labelExpenseSummary.TabIndex = 21;
            this.labelExpenseSummary.Text = "Expense(s) Summary";
            // 
            // zAccountStatsView
            // 
            this.zAccountStatsView.AllowUserToAddRows = false;
            this.zAccountStatsView.AllowUserToDeleteRows = false;
            this.zAccountStatsView.AllowUserToOrderColumns = true;
            this.zAccountStatsView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.zAccountStatsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.zAccountStatsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zAccountStatsView.ContextMenuStrip = this.cmsAccount;
            this.zAccountStatsView.Location = new System.Drawing.Point(3, 60);
            this.zAccountStatsView.Name = "zAccountStatsView";
            this.zAccountStatsView.ReadOnly = true;
            this.zAccountStatsView.reloadMethod = null;
            this.zAccountStatsView.RowHeadersVisible = false;
            this.zAccountStatsView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.zAccountStatsView.Size = new System.Drawing.Size(402, 89);
            this.zAccountStatsView.TabIndex = 19;
            this.zAccountStatsView.UseRedAsIncome = false;
            this.zAccountStatsView.UseStandardStyle = true;
            this.zAccountStatsView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.zAccountStatsView_ColumnWidthChanged);
            this.zAccountStatsView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zAccountStatsView_MouseDown);
            // 
            // zExpenseTypeStatsView
            // 
            this.zExpenseTypeStatsView.AllowUserToAddRows = false;
            this.zExpenseTypeStatsView.AllowUserToDeleteRows = false;
            this.zExpenseTypeStatsView.AllowUserToResizeRows = false;
            this.zExpenseTypeStatsView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.zExpenseTypeStatsView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zExpenseTypeStatsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.zExpenseTypeStatsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.zExpenseTypeStatsView.Location = new System.Drawing.Point(3, 20);
            this.zExpenseTypeStatsView.Name = "zExpenseTypeStatsView";
            this.zExpenseTypeStatsView.ReadOnly = true;
            this.zExpenseTypeStatsView.reloadMethod = null;
            this.zExpenseTypeStatsView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.zExpenseTypeStatsView.RowHeadersVisible = false;
            this.zExpenseTypeStatsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.zExpenseTypeStatsView.Size = new System.Drawing.Size(402, 310);
            this.zExpenseTypeStatsView.TabIndex = 20;
            this.zExpenseTypeStatsView.UseRedAsIncome = false;
            this.zExpenseTypeStatsView.UseStandardStyle = false;
            this.zExpenseTypeStatsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.zExpenseTypeStatsView_CellContentClick);
            this.zExpenseTypeStatsView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.zExpenseTypeStatsView_ColumnWidthChanged);
            // 
            // zledgerItemListView
            // 
            this.zledgerItemListView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.zledgerItemListView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.zledgerItemListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.zledgerItemListView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.zledgerItemListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zledgerItemListView.ContextMenuStrip = this.zaLedgerItemsContextMenu;
            this.zledgerItemListView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.zledgerItemListView.Location = new System.Drawing.Point(6, 32);
            this.zledgerItemListView.Name = "zledgerItemListView";
            this.zledgerItemListView.reloadMethod = null;
            this.zledgerItemListView.RowHeadersVisible = false;
            this.zledgerItemListView.Size = new System.Drawing.Size(461, 455);
            this.zledgerItemListView.TabIndex = 2;
            this.zledgerItemListView.UseRedAsIncome = false;
            this.zledgerItemListView.UseStandardStyle = true;
            this.zledgerItemListView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.zledgerItemListView_ColumnWidthChanged);
            this.zledgerItemListView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.zledgerItemListView_DataError);
            this.zledgerItemListView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.zledgerItemListView_EditingControlShowing);
            this.zledgerItemListView.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.zledgerItemListView_RowLeave);
            // 
            // zBreakdownDataGridView
            // 
            this.zBreakdownDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zBreakdownDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.zBreakdownDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zBreakdownDataGridView.Location = new System.Drawing.Point(5, 38);
            this.zBreakdownDataGridView.Name = "zBreakdownDataGridView";
            this.zBreakdownDataGridView.ReadOnly = true;
            this.zBreakdownDataGridView.reloadMethod = null;
            this.zBreakdownDataGridView.RowHeadersVisible = false;
            this.zBreakdownDataGridView.Size = new System.Drawing.Size(465, 449);
            this.zBreakdownDataGridView.TabIndex = 4;
            this.zBreakdownDataGridView.UseRedAsIncome = false;
            this.zBreakdownDataGridView.UseStandardStyle = true;
            // 
            // zaBudgetGrid
            // 
            this.zaBudgetGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zaBudgetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaBudgetGrid.Location = new System.Drawing.Point(5, 34);
            this.zaBudgetGrid.Name = "zaBudgetGrid";
            this.zaBudgetGrid.reloadMethod = null;
            this.zaBudgetGrid.Size = new System.Drawing.Size(467, 453);
            this.zaBudgetGrid.TabIndex = 0;
            this.zaBudgetGrid.UseRedAsIncome = false;
            this.zaBudgetGrid.UseStandardStyle = false;
            this.zaBudgetGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.zExpenseTypeStatsView_CellContentClick);
            // 
            // zaExpenseTypeReferenceDGV
            // 
            this.zaExpenseTypeReferenceDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zaExpenseTypeReferenceDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaExpenseTypeReferenceDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.zaExpenseTypeReferenceDGV.Location = new System.Drawing.Point(3, 24);
            this.zaExpenseTypeReferenceDGV.Name = "zaExpenseTypeReferenceDGV";
            this.zaExpenseTypeReferenceDGV.reloadMethod = null;
            this.zaExpenseTypeReferenceDGV.RowHeadersVisible = false;
            this.zaExpenseTypeReferenceDGV.Size = new System.Drawing.Size(221, 306);
            this.zaExpenseTypeReferenceDGV.TabIndex = 0;
            this.zaExpenseTypeReferenceDGV.UseRedAsIncome = false;
            this.zaExpenseTypeReferenceDGV.UseStandardStyle = true;
            this.zaExpenseTypeReferenceDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.zaExpenseTypeReferenceDGV_DataError);
            // 
            // zaSecondaryExpenseReferenceDGV
            // 
            this.zaSecondaryExpenseReferenceDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zaSecondaryExpenseReferenceDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaSecondaryExpenseReferenceDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.zaSecondaryExpenseReferenceDGV.Location = new System.Drawing.Point(4, 24);
            this.zaSecondaryExpenseReferenceDGV.Name = "zaSecondaryExpenseReferenceDGV";
            this.zaSecondaryExpenseReferenceDGV.reloadMethod = null;
            this.zaSecondaryExpenseReferenceDGV.RowHeadersVisible = false;
            this.zaSecondaryExpenseReferenceDGV.Size = new System.Drawing.Size(226, 306);
            this.zaSecondaryExpenseReferenceDGV.TabIndex = 0;
            this.zaSecondaryExpenseReferenceDGV.UseRedAsIncome = false;
            this.zaSecondaryExpenseReferenceDGV.UseStandardStyle = true;
            this.zaSecondaryExpenseReferenceDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.zaSecondaryExpenseReferenceDGV_DataError);
            // 
            // zaAccountsReferenceDGV
            // 
            this.zaAccountsReferenceDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zaAccountsReferenceDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaAccountsReferenceDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.zaAccountsReferenceDGV.Location = new System.Drawing.Point(6, 20);
            this.zaAccountsReferenceDGV.Name = "zaAccountsReferenceDGV";
            this.zaAccountsReferenceDGV.reloadMethod = null;
            this.zaAccountsReferenceDGV.RowHeadersVisible = false;
            this.zaAccountsReferenceDGV.Size = new System.Drawing.Size(461, 128);
            this.zaAccountsReferenceDGV.TabIndex = 1;
            this.zaAccountsReferenceDGV.UseRedAsIncome = false;
            this.zaAccountsReferenceDGV.UseStandardStyle = true;
            // 
            // zaAccountBindingSource
            // 
            this.zaAccountBindingSource.DataSource = typeof(FinancialLedgerProject.Accounts.ZaAccount);
            // 
            // ZafrFinancialLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::FinancialLedgerProject.Properties.Resources.subtle_grunge;
            this.ClientSize = new System.Drawing.Size(910, 571);
            this.Controls.Add(this.splitContainerReference);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TabControlPrimary);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZafrFinancialLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zedworks Ledger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZafrFinancialLedger_FormClosing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.TabControlPrimary.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.zaLedgerItemsContextMenu.ResumeLayout(false);
            this.monthlyData.ResumeLayout(false);
            this.monthlyData.PerformLayout();
            this.budgetTab.ResumeLayout(false);
            this.budgetTab.PerformLayout();
            this.importTab.ResumeLayout(false);
            this.groupBoxImport.ResumeLayout(false);
            this.groupBoxImport.PerformLayout();
            this.setupTab.ResumeLayout(false);
            this.setupTab.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainerReference.Panel1.ResumeLayout(false);
            this.splitContainerReference.Panel1.PerformLayout();
            this.splitContainerReference.Panel2.ResumeLayout(false);
            this.splitContainerReference.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReference)).EndInit();
            this.splitContainerReference.ResumeLayout(false);
            this.cmsAccount.ResumeLayout(false);
            this.groupBoxDateRange.ResumeLayout(false);
            this.groupBoxDateRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zAccountStatsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zExpenseTypeStatsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zledgerItemListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zBreakdownDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaBudgetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaExpenseTypeReferenceDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaSecondaryExpenseReferenceDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaAccountsReferenceDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaAccountBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ZaDataGridView zledgerItemListView;
        private System.Windows.Forms.TabControl TabControlPrimary;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage monthlyData;
        private ZaDataGridView zBreakdownDataGridView;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.ComboBox typeFilterComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ContextMenuStrip zaLedgerItemsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripOpenFileLabel;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox nameFilterTextBox;
        private System.Windows.Forms.Label dateToLabel;
        private ZaDataGridView zAccountStatsView;
        private System.Windows.Forms.Label dateFromLabel;
        private ZaDataGridView zExpenseTypeStatsView;
        private System.Windows.Forms.DateTimePicker dateToPicker;
        private System.Windows.Forms.DateTimePicker dateFromPicker;
        private System.Windows.Forms.TabPage setupTab;
        private ZaDataGridView zaAccountsReferenceDGV;
        private System.Windows.Forms.BindingSource zaAccountBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZaDataGridView zaExpenseTypeReferenceDGV;
        private ZaDataGridView zaSecondaryExpenseReferenceDGV;
        private System.Windows.Forms.SplitContainer splitContainerReference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAccountSummary;
        private System.Windows.Forms.Label labelExpenseSummary;
        private System.Windows.Forms.Button btnAccountRemove;
        private System.Windows.Forms.Button btnAccountAdd;
        private System.Windows.Forms.Button btnExpenseRemove;
        private System.Windows.Forms.Button btnExpeseAdd;
        private System.Windows.Forms.Button btnSubExpenseRemove;
        private System.Windows.Forms.Button btnSubExpenseAdd;
        private System.Windows.Forms.TabPage importTab;
        private System.Windows.Forms.GroupBox groupBoxImport;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnImportFileDialog;
        private System.Windows.Forms.Button btnGenerateImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxDateRange;
        private System.Windows.Forms.TabPage budgetTab;
        private ZaDataGridView zaBudgetGrid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxBudget;
        private System.Windows.Forms.Button btnBudgetAdd;
        private System.Windows.Forms.Button btnBudgetPopulate;
        private System.Windows.Forms.ToolStripMenuItem splitToolStripMenuItem;
        private System.Windows.Forms.Button btnAccountTransfer;
        private System.Windows.Forms.ContextMenuStrip cmsAccount;
        private System.Windows.Forms.ToolStripMenuItem transferFundsToolStripMenuItem;
    }
}