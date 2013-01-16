using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinancialLedgerProject.Core.ExtendedObjects;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Core;

namespace FinancialLedgerProject.Reference
{
    public partial class ZaAccounts : ZafrDialog
    {
        public List<ZaAccount> removedAccounts { get; set; }
        public ZaBindingList<ZaAccount> bindingAccounts { get; set; }

        public ZaAccounts()
        {
            InitializeComponent();
        }

        public void LoadReferenceList()
        {
            try
            {
                zaAccountsReference.AutoGenerateColumns = false;
                zaAccountsReference.Columns.Clear();
                zaAccountsReference.DataSource = bindingAccounts;

                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Name";
                textColumn.DataPropertyName = ZaAccount.F_Name;

                zaAccountsReference.Columns.Add(textColumn);

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Original Balance";
                textColumn.DataPropertyName = ZaAccount.F_OriginalBalance;
                textColumn.DefaultCellStyle.Format = "c";

                zaAccountsReference.Columns.Add(textColumn);

                DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Type";
                comboColumn.DataPropertyName = ZaAccount.F_Type;
                comboColumn.DataSource = Enum.GetValues(typeof(ZaAccount.AccountTypes));
                comboColumn.ValueType = typeof(ZaAccount.AccountTypes);

                zaAccountsReference.Columns.Add(comboColumn);

                SetDimensions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReferenceWindow_Load(object sender, EventArgs e)
        {
            try
            {
                LoadReferenceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zaAccountsReference_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // DO nothing, just make it stop MAKE IT STOP...
        }

        private void SetDimensions()
        {
            try
            {
                int accountsViewWidth = (from DataGridViewColumn n in zaAccountsReference.Columns
                                                 select n.Width).Sum() + 3;
                if (zaAccountsReference.VerticalScrollbarVisible)
                {
                    accountsViewWidth += SystemInformation.VerticalScrollBarWidth;
                }

                zaAccountsReference.Width = accountsViewWidth;
                this.Width = accountsViewWidth + 45;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zaAccountsReference_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SetDimensions();
        }

    }
}
