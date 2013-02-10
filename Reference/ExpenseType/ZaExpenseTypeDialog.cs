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
            try
            {
                ZaExpenseType expenseType = new ZaExpenseType();
                expenseType.Name = expenseTypeName.Text;
                expenseType.Type = (ZaExpenseType.ExpenseTypes)typeComboBox.SelectedValue;
                returnValue = expenseType;
                base.okButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ZaExpenseTypeDialog_Load(object sender, EventArgs e)
        {
            typeComboBox.DataSource = Enum.GetValues(typeof(ZaExpenseType.ExpenseTypes));
        }
    }
}
