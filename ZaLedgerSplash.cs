using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using FinancialLedgerProject.Properties;

namespace FinancialLedgerProject
{
    public partial class ZaLedgerSplash : Form
    {
        public ZafrFinancialLedger ledgerForm { get; set; }

        public ZaLedgerSplash()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ledgerForm.btnNewButton_Click(sender, e);
            ledgerForm.Show();
            ledgerForm.Focus();
            this.Close();
        }

        private void openExistingButton_Click(object sender, EventArgs e)
        {
            if (ledgerForm.OpenLedger())
            {
                ledgerForm.Show();
                ledgerForm.Focus();
                this.Close();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ledgerForm.Close();
        }

        private void useLastButton_Click(object sender, EventArgs e)
        {
            // if the setting is not empty AND the file exists - go and load it.
            if (!string.IsNullOrEmpty(Settings.Default.LastUsedLedger) && File.Exists(Settings.Default.LastUsedLedger))
            {
                if (ledgerForm.OpenLedger(Settings.Default.LastUsedLedger))
                {
                    ledgerForm.Show();
                    ledgerForm.Focus();
                    this.Close();
                }
            }
            else
            {
                throw new Exception("Last Ledger no longer exists or setting is empty!");
            }
        }

        private void ZaLedgerSplash_Load(object sender, EventArgs e)
        {
            useLastButton.Enabled = !string.IsNullOrEmpty(Settings.Default.LastUsedLedger);
            if (!string.IsNullOrEmpty(Settings.Default.LastUsedLedger))
            {
                useLastButton.Text = useLastButton.Text + ": " + Settings.Default.LastUsedLedger.Split('\\').Last().Split('.')[0];
            }

        }
    }
}
