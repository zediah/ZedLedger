using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinancialLedgerProject.Core;

namespace FinancialLedgerProject.Accounts
{
    public partial class ZaAccountDialog : ZafrDialog
    {
        public ZaAccountDialog()
        {
            InitializeComponent();
        }

        public override void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                ZaAccount Account = new ZaAccount();
                Account.Name = accountName.Text;
                Account.OriginalBalance = Decimal.Parse(originalBalanceTextBox.Text);
                returnValue = Account;
                base.okButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
