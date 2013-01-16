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
using FinancialLedgerProject.Accounts;

namespace FinancialLedgerProject.ExpenseType
{
    public partial class ZaSecondaryExpenseTypeDialog : ZafrDialog
    {
        public List<ZaExpenseType> ExpenseTypes { get; set; }

        public ZaSecondaryExpenseTypeDialog()
        {
            InitializeComponent();
        }

        public override void okButton_Click(object sender, EventArgs e)
        {
            ZaSecondaryExpenseType ExpenseType = new ZaSecondaryExpenseType();
            ExpenseType.Name = expenseTypeName.Text;
            ExpenseType.dsExpenseType = (ZaExpenseType)typeComboBox.SelectedValue;
            returnValue = ExpenseType;
            base.okButton_Click(sender, e);
        }

        private void ZaExpenseTypeDialog_Load(object sender, EventArgs e)
        {
            typeComboBox.DataSource = ExpenseTypes;
            typeComboBox.DisplayMember = "Name";
            typeComboBox.ValueMember = "Self";
        }
    }
}
