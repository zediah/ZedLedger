using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.Core;

namespace FinancialLedgerProject.Reference.Accounts
{
    public partial class ZaAccountTransfer : ZafrDialog
    {
        private List<ZaAccount> UsedAccounts = new List<ZaAccount>();

        private ZaAccount originAccount;

        public ZaAccountTransfer()
        {
            InitializeComponent();
        }

        public void SetOriginAccount(ZaAccount account)
        {
            originAccount = account;
        }

        private void updateAvailableAccounts(ComboBox box)
        {
            var availableList = MockDb.Database.Accounts.Except(UsedAccounts).ToList();
            var selectedItem = box.SelectedItem as ZaAccount;
            if (selectedItem != null)
            {
                availableList.Add(selectedItem);
            }
            box.DataSource = availableList.OrderBy(x => x.NodeLabel()).ToList();
            // With a new list, the old selected index might be a different item.
            // So reselect the item!
            box.SelectedItem = selectedItem;
        }

        private void comboDestinationAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UsedAccounts = Controls.OfType<ComboBox>().Select(x => x.SelectedItem).Cast<ZaAccount>().ToList();
            foreach (ComboBox box in Controls.OfType<ComboBox>().Where(x => x != sender))
            {
                updateAvailableAccounts(box);
            }
        }

        private void ZaAccountTransfer_Load(object sender, EventArgs e)
        {
            UsedAccounts.Clear();
            foreach (ComboBox box in Controls.OfType<ComboBox>())
            {
                updateAvailableAccounts(box);
            }
            comboDestinationAccount.SelectedItem = null;
            // Origin account is set when coming from context item
            comboOriginalAccount.SelectedItem = originAccount;
            comboThroughAccount.SelectedItem = null;

            // Force the origin account if coming from context item
            comboOriginalAccount.Enabled = originAccount == null;
        }

        public override void okButton_Click(object sender, EventArgs e)
        {
            var fullItemList = new List<ZaLedgerItem>();
            var originAccount = (ZaAccount) comboOriginalAccount.SelectedItem;
            var throughAccount = (ZaAccount) comboThroughAccount.SelectedItem;
            var destinationAccount = (ZaAccount) comboDestinationAccount.SelectedItem;
            var amount = Decimal.Parse(textBox1.Text);
            var dateOfTransfer = dateTimeDateOfTransfer.Value;

            if (originAccount != null && destinationAccount != null && amount > 0)
            {
                var originItem = new ZaLedgerItem();
                originItem.PurchaseDate = DateTime.Today;
                originItem.Account = originAccount;
                originItem.Description = "Transfer from [" + originAccount + "] to [" +
                                         (throughAccount ?? destinationAccount) + "]";
                originItem.PurchasePrice = amount;
                originItem.PurchaseDate = dateOfTransfer;
                fullItemList.Add(originItem);

                if (throughAccount != null)
                {
                    var throughItemRecieved = new ZaLedgerItem();
                    throughItemRecieved.PurchaseDate = DateTime.Today;
                    throughItemRecieved.Account = throughAccount;
                    throughItemRecieved.Description = "Transfer Recieved from [" + originAccount + "]";
                    throughItemRecieved.PurchasePrice = -amount;
                    throughItemRecieved.PurchaseDate = dateOfTransfer;
                    fullItemList.Add(throughItemRecieved);

                    var throughItemForwarded = new ZaLedgerItem();
                    throughItemForwarded.PurchaseDate = DateTime.Today;
                    throughItemForwarded.Account = throughAccount;
                    throughItemForwarded.Description = "Forwarding Transfer to [" + destinationAccount + "]";
                    throughItemForwarded.PurchasePrice = amount;
                    throughItemForwarded.PurchaseDate = dateOfTransfer;
                    fullItemList.Add(throughItemForwarded);
                }

                var destinationItem = new ZaLedgerItem();
                destinationItem.PurchaseDate = DateTime.Today;
                destinationItem.Account = destinationAccount;
                destinationItem.Description = "Transfer Recieved from [" + (throughAccount ?? destinationAccount) + "]";
                destinationItem.PurchasePrice = -amount;
                destinationItem.PurchaseDate = dateOfTransfer;
                fullItemList.Add(destinationItem);

                returnValue = fullItemList;
                base.okButton_Click(sender, e);
                // clear all the values on the form
                originAccount = null;
            }
            else
            {
                MessageBox.Show("An origin account, destination account and amount are required as a minimum.",
                                "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override void InitaliseCustomDialogSettings(params object[] args)
        {
            try
            {
                ZaAccount acc = args.ElementAtOrDefault(0) as ZaAccount;
                if (acc != null)
                {
                    SetOriginAccount(acc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
