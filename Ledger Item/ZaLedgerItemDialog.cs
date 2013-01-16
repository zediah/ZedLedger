using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinancialLedgerProject.Core;
using FinancialLedgerProject.Reference.ExpenseType;
using FinancialLedgerProject.ExpenseType;

namespace FinancialLedgerProject.Ledger_Item
{
    public partial class ZaLedgerItemDialog : ZafrDialog
    {
        /// <summary>
        /// The ledger item we are working on/planning to return
        /// </summary>
        public ZaLedgerItem LedgerItem { get; set; }

        /// <summary>
        /// The ledger, kind of the database in this instance
        /// </summary>
        public ZaLedger Ledger { get; set; }

        /// <summary>
        /// The maximum value the ledger item may be 
        /// </summary>
        public decimal MaxItemValue { get; set; }

        public ZaLedgerItemDialog()
        {
            InitializeComponent();
        }

        private void ZaLedgerItemDialog_Load(object sender, EventArgs e)
        {
            if (LedgerItem == null)
            {
                LedgerItem = new ZaLedgerItem();
            }
            else
            {
                MaxItemValue = LedgerItem.PurchasePrice;
            }
            accountCombo.DataSource = Ledger.Accounts;
            accountCombo.DisplayMember = "Label";
            accountCombo.ValueMember = "Self";
            accountCombo.SelectedItem = LedgerItem.Account;

            expenseTypeCombo.DataSource = Ledger.ExpenseTypes;
            expenseTypeCombo.DisplayMember = "Label";
            expenseTypeCombo.ValueMember = "Self";
            expenseTypeCombo.SelectedItem = LedgerItem.ExpenseType;

            UpdateSecondaryCombo();
            secondaryExpenseTypeCombo.DisplayMember = "Label";
            secondaryExpenseTypeCombo.ValueMember = "Self";
            secondaryExpenseTypeCombo.SelectedItem = LedgerItem.SecondaryExpenseType;

            descriptionText.Text = LedgerItem.Description;

            purchaseDatePicker.Value = LedgerItem.PurchaseDate != DateTime.MinValue ? LedgerItem.PurchaseDate :  DateTime.Today;

            purchasePriceNumeric.Text = LedgerItem.PurchasePrice.ToString();
        }

        public override void okButton_Click(object sender, EventArgs e)
        {
            if (MaxItemValue > 0 && decimal.Parse(purchasePriceNumeric.Text) > MaxItemValue)
            {
                MessageBox.Show("Purchase price of this item is greater than than item being split.\nPlease enter a purchase price less than $" + MaxItemValue);
            }
            else
            {
                LedgerItem.PurchaseDate = purchaseDatePicker.Value;
                LedgerItem.PurchasePrice = decimal.Parse(purchasePriceNumeric.Text);
                LedgerItem.SecondaryExpenseType = (ZaSecondaryExpenseType)secondaryExpenseTypeCombo.SelectedItem;
                LedgerItem.ExpenseType = (ZaExpenseType)expenseTypeCombo.SelectedItem;
                LedgerItem.Description = descriptionText.Text;
                returnValue = LedgerItem;
                base.okButton_Click(sender, e);
            }

        }

        private void expenseTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSecondaryCombo();
        }

        public void UpdateSecondaryCombo()
        {
            ZaExpenseType expense = expenseTypeCombo.SelectedItem as ZaExpenseType;

            // Clear the selected item
            secondaryExpenseTypeCombo.SelectedItem = null;
            // Now set up the data source
            secondaryExpenseTypeCombo.DataSource = Ledger.SecondaryExpenseTypes.Where(x => x.dsExpenseType == expense).ToList();
        }

    }
}
