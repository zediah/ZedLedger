using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinancialLedgerProject.Core;

namespace FinancialLedgerProject.Reference.Budget
{
    public partial class ZaBudgetDialog : ZafrDialog
    {
        public ZaBudgetDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            ZaBudget budget = new ZaBudget();
            budget.Name = textBoxName.Text;
            budget.BudgetItems = new List<ZaBudgetItem>();
            returnValue = budget;
        }
    }
}
