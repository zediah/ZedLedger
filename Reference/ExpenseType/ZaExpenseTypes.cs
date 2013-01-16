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
using FinancialLedgerProject.Reference.ExpenseType;

namespace FinancialLedgerProject.Reference
{
    public partial class ZaExpenseTypes : ZafrDialog
    {
        public List<ZaExpenseType> removedExpenseTypes { get; set; }
        public ZaBindingList<ZaExpenseType> bindingExpenseTypes { get; set; }

        public List<ZaSecondaryExpenseType> removedSecondaryExpenseTypes { get; set; }
        public ZaBindingList<ZaSecondaryExpenseType> bindingSecondaryExpenseTypes { get; set; }

        public ZaBindingList<ZaExpenseType> bindingExpenseTypes2 { get; set; }

        public ZaExpenseTypes()
        {
            InitializeComponent();
        }

        public void LoadReferenceList()
        {
            try
            {
                //primary expense types grid
                zaExpenseTypeView.AutoGenerateColumns = false;
                zaExpenseTypeView.Columns.Clear();
                zaExpenseTypeView.DataSource = bindingExpenseTypes;

                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Name";
                textColumn.DataPropertyName = ZaExpenseType.F_Name;

                zaExpenseTypeView.Columns.Add(textColumn);

                DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Type";
                comboColumn.DataSource = Enum.GetValues(typeof(ZaExpenseType.ExpenseTypes));
                comboColumn.DataPropertyName = ZaExpenseType.F_Type;

                zaExpenseTypeView.Columns.Add(comboColumn);


                //Secondary expense types grid
                zaSecondaryExpenseTypes.AutoGenerateColumns = false;
                zaSecondaryExpenseTypes.Columns.Clear();
                zaSecondaryExpenseTypes.DataSource = bindingSecondaryExpenseTypes;

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Name";
                textColumn.DataPropertyName = ZaSecondaryExpenseType.F_Name;

                zaSecondaryExpenseTypes.Columns.Add(textColumn);

                comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Expense Type";
                comboColumn.DataSource = bindingExpenseTypes2;
                comboColumn.DisplayMember = "Label";
                comboColumn.ValueMember = "Self";
                comboColumn.DataPropertyName = "dsExpenseType";

                zaSecondaryExpenseTypes.Columns.Add(comboColumn);

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
                bindingExpenseTypes2 = bindingExpenseTypes;
                LoadReferenceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zaExpenseTypeView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void SetDimensions()
        {
            try
            {

                int expenseViewWidth = (from DataGridViewColumn n in zaExpenseTypeView.Columns
                                           select n.Width).Sum() + 3;
                if (zaExpenseTypeView.VerticalScrollbarVisible)
                {
                    expenseViewWidth += SystemInformation.VerticalScrollBarWidth;
                }
                int secondaryExpenseViewWidth = (from DataGridViewColumn n in zaSecondaryExpenseTypes.Columns
                                                 select n.Width).Sum() + 3;
                if (zaSecondaryExpenseTypes.VerticalScrollbarVisible)
                {
                    secondaryExpenseViewWidth += SystemInformation.VerticalScrollBarWidth;
                }

                zaSecondaryExpenseTypes.Width = secondaryExpenseViewWidth;
                zaExpenseTypeView.Width = expenseViewWidth;
                zaSecondaryExpenseTypes.Location = new Point(zaExpenseTypeView.Location.X + expenseViewWidth + 5, zaSecondaryExpenseTypes.Location.Y);
                this.Width = expenseViewWidth + secondaryExpenseViewWidth + 50;
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zaSecondaryExpenseTypes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Such a dodgy way to stop the error...
        }

        private void zaGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SetDimensions();
        }
    }
}
