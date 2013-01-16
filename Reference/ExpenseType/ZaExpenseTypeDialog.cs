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
    public partial class ZaExpenseTypeDialog : ZafrDialog
    {
        public ZaExpenseTypeDialog()
        {
            InitializeComponent();
        }

        public override void okButton_Click(object sender, EventArgs e)
        {
            ZaSecondaryExpenseType subExpenseType = new ZaSecondaryExpenseType();
            subExpenseType.Name = expenseTypeName.Text;
            subExpenseType.dsExpenseType = (ZaExpenseType)typeComboBox.SelectedValue;
            returnValue = subExpenseType;
            base.okButton_Click(sender, e);
        }

        private void ZaExpenseTypeDialog_Load(object sender, EventArgs e)
        {
            typeComboBox.DataSource = Enum.GetValues(typeof(ZaExpenseType.ExpenseTypes));
        }
    }
}
