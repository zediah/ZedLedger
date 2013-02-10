using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.Core.ExtendedObjects;
using FinancialLedgerProject.Reference;
using FinancialLedgerProject.Core;
using FinancialLedgerProject.Reference.Accounts;
using FinancialLedgerProject.Reference.ExpenseType;
using FinancialLedgerProject.SystemInfo;
using FinancialLedgerProject.Views;
using System.Collections.ObjectModel;
using System.Threading;
using FinancialLedgerProject.Properties;
using Excel = Microsoft.Office.Interop.Excel;
using FinancialLedgerProject.Reference.Budget;
using FinancialLedgerProject.Ledger_Item;

namespace FinancialLedgerProject
{
    public partial class ZafrFinancialLedger : Form
    {
        public ZaLedger CurrentLedger { get; set; }

        public DateTime selectedDateFrom;
        /// <summary>
        /// Transient Selected From Date
        /// </summary>
        public DateTime SelectedDateFrom { get; set; }

        /// <summary>
        /// Transient Selected To Date
        /// </summary>
        public DateTime SelectedDateTo { get; set; }

        /// <summary>
        /// A list of all the datagridviews for this form
        /// </summary>
        List<ZaDataGridView> DGVs = new List<ZaDataGridView>();

        public ZafrFinancialLedger()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
        }

        public ZafrFinancialLedger(ZaLedger ledger)
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            CurrentLedger = ledger;
        }

        public void SetCurrentLedger(ZaLedger ledger)
        {
            CurrentLedger = ledger;
        }

        /// <summary>
        /// Set up all grids
        /// </summary>
        private void SetupGrid()
        {
            try
            {
                if (CurrentLedger != null)
                {
                    zExpenseTypeStatsView.reloadMethod = LoadExpenseTypeStatsGrids;
                    LoadLedgerItemGrids();
                    LoadExpenseTypeStatsGrids();
                    LoadAccountsStatsGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Set up the ledger item grid
        /// </summary>
        public void LoadLedgerItemGrids()
        {
            try
            {
                if (CurrentLedger != null)
                {
                    #region Item Data Grid View
                    DataGridViewTextBoxColumn textColumn;
                    zledgerItemListView.DataSource = CurrentLedger.LedgerItemListSource;
                    zledgerItemListView.AutoGenerateColumns = false;

                    zledgerItemListView.Columns.Clear();
                    ZaDataGridViewCalendarColumn dateColumn = new ZaDataGridViewCalendarColumn();
                    dateColumn.DataPropertyName = "PurchaseDate";
                    dateColumn.DefaultCellStyle.Format = "d";
                    dateColumn.HeaderText = "Date";
                    dateColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                    dateColumn.Name = ZaLedgerItem.F_PurchaseDate;
                    dateColumn.Width = MockDb.Database.System.GetColumnWidth(zledgerItemListView, dateColumn);

                    zledgerItemListView.Columns.Add(dateColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.DataPropertyName = "Description";
                    textColumn.HeaderText = "Description";
                    textColumn.Name = ZaLedgerItem.F_Description;
                    textColumn.Width = MockDb.Database.System.GetColumnWidth(zledgerItemListView, textColumn);


                    zledgerItemListView.Columns.Add(textColumn);

                    DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
                    comboColumn.DataSource = CurrentLedger.Accounts;
                    comboColumn.DataPropertyName = "Account";
                    comboColumn.DisplayMember = "Label";
                    comboColumn.ValueMember = "Self";
                    comboColumn.HeaderText = "Account";
                    comboColumn.MaxDropDownItems = 20;
                    comboColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                    comboColumn.Name = ZaLedgerItem.F_Account;
                    comboColumn.Width = MockDb.Database.System.GetColumnWidth(zledgerItemListView, comboColumn);


                    zledgerItemListView.Columns.Add(comboColumn);

                    comboColumn = new DataGridViewComboBoxColumn();
                    comboColumn.DataSource = CurrentLedger.ExpenseTypes;
                    comboColumn.DataPropertyName = "ExpenseType";
                    comboColumn.DisplayMember = "Label";
                    comboColumn.ValueMember = "Self";
                    comboColumn.HeaderText = "Expense Type";
                    comboColumn.MaxDropDownItems = 20;
                    comboColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                    comboColumn.Name = ZaLedgerItem.F_ExpenseType;
                    comboColumn.Width = MockDb.Database.System.GetColumnWidth(zledgerItemListView, comboColumn);


                    zledgerItemListView.Columns.Add(comboColumn);

                    comboColumn = new DataGridViewComboBoxColumn();
                    comboColumn.DataSource = CurrentLedger.SecondaryExpenseTypes;
                    comboColumn.DataPropertyName = "SecondaryExpenseType";
                    comboColumn.DisplayMember = "Label";
                    comboColumn.ValueMember = "Self";
                    comboColumn.HeaderText = "Sub Type";
                    comboColumn.MaxDropDownItems = 20;
                    comboColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                    comboColumn.Name = ZaLedgerItem.F_SecondaryExpenseType;
                    comboColumn.Width = MockDb.Database.System.GetColumnWidth(zledgerItemListView, comboColumn);

                    zledgerItemListView.Columns.Add(comboColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.DataPropertyName = "PurchasePrice";
                    textColumn.DefaultCellStyle.Format = "c";
                    textColumn.HeaderText = "Price";
                    textColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                    textColumn.Name = ZaLedgerItem.F_PurchasePrice;
                    textColumn.Width = MockDb.Database.System.GetColumnWidth(zledgerItemListView, textColumn);


                    zledgerItemListView.Columns.Add(textColumn);

                    zledgerItemListView.Invalidate();
                    AdjustLedgerItemViewWidth();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// clear and then Load both the expense and account stats grids
        /// </summary>
        public void LoadExpenseTypeStatsGrids()
        {
            try
            {
                bool showDateColumns = IsDateRangeSelected();
                #region Stats Data Grid View             
                DataGridViewTextBoxColumn textColumn;

                #region Column Setup
                zExpenseTypeStatsView.AutoGenerateColumns = false;
                zExpenseTypeStatsView.Columns.Clear();

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "+";
                buttonColumn.Frozen = true;
                buttonColumn.Width = 25;
                buttonColumn.DefaultCellStyle.SelectionBackColor = Color.Transparent;
                buttonColumn.Name = "Expand";
                buttonColumn.Width = MockDb.Database.System.GetColumnWidth(zExpenseTypeStatsView, buttonColumn);

                zExpenseTypeStatsView.Columns.Add(buttonColumn);

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Type";
                textColumn.Frozen = true;
                textColumn.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                textColumn.DefaultCellStyle.Font = new System.Drawing.Font(zExpenseTypeStatsView.Font, FontStyle.Bold);
                textColumn.Name = ZaVExpenseType.F_ExpenseType;
                textColumn.Width = MockDb.Database.System.GetColumnWidth(zExpenseTypeStatsView, textColumn);

                zExpenseTypeStatsView.Columns.Add(textColumn);

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.DefaultCellStyle.Format = "c";
                textColumn.HeaderText = "Total";
                textColumn.Name = ZaVExpenseType.F_Total;
                textColumn.Width = MockDb.Database.System.GetColumnWidth(zExpenseTypeStatsView, textColumn);

                zExpenseTypeStatsView.Columns.Add(textColumn);

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.DefaultCellStyle.Format = "p2";
                textColumn.HeaderText = "Percent";
                textColumn.Name = ZaVExpenseType.F_Percent;
                textColumn.Width = MockDb.Database.System.GetColumnWidth(zExpenseTypeStatsView, textColumn);

                zExpenseTypeStatsView.Columns.Add(textColumn);

                if (showDateColumns)
                {
                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.DefaultCellStyle.Format = "c";
                    textColumn.HeaderText = "Total (In Range)";
                    textColumn.Name = ZaVExpenseType.F_TotalWithinPeriod;
                    textColumn.Width = MockDb.Database.System.GetColumnWidth(zExpenseTypeStatsView, textColumn);

                    zExpenseTypeStatsView.Columns.Add(textColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.DefaultCellStyle.Format = "p2";
                    textColumn.HeaderText = "% (In Range)";
                    textColumn.Name = ZaVExpenseType.F_PercentWithinPeriod;
                    textColumn.Width = MockDb.Database.System.GetColumnWidth(zExpenseTypeStatsView, textColumn);

                    zExpenseTypeStatsView.Columns.Add(textColumn);
                }
                #endregion
                

                RecalculateExpenseTypeViews();

                #region Cell Setup

                // This should be in order...
                foreach(ZaVExpenseType.ViewTypes e in CurrentLedger.OrderOfExpenseViews.Values)
                {
                    foreach (ZaVExpenseType view in CurrentLedger.ExpenseViews.Where(x => x.ViewType == e && x.Display))
                    {
                        AddDisplayViewRowToDataGrid(view, zExpenseTypeStatsView);
                        if (view.Expanded)
                        {
                            ZaVExpenseType view1 = view;
                            foreach (ZaVExpenseType secView in CurrentLedger.ExpenseViews.Where(x => x.Parent == view1))
                            {
                                AddDisplayViewRowToDataGrid(secView, zExpenseTypeStatsView);
                            }
                        }
                    }
                }
                #endregion
                #endregion
                AdjustExpenseStatsViewDimensions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Given a view, add a row to the expense type grid based upon the view
        /// </summary>
        /// <param name="view">The view the row will be generated from</param>
        public void AddDisplayViewRowToDataGrid(ZaDisplayView view, DataGridView grid)
        {
            try
            {
                if (view.BlankRowLocation == ZaVExpenseType.BlankRowLocations.AboveAndBelow ||
                    view.BlankRowLocation == ZaVExpenseType.BlankRowLocations.Above)
                {
                    grid.Rows.Add(CreateDisplayViewRow(CurrentLedger.GetView(ZaVExpenseType.ViewTypes.Blank)));
                }

                grid.Rows.Add(CreateDisplayViewRow(view));

                if(view.BlankRowLocation == ZaVExpenseType.BlankRowLocations.AboveAndBelow ||
                    view.BlankRowLocation == ZaVExpenseType.BlankRowLocations.Below)
                {
                    grid.Rows.Add(CreateDisplayViewRow(CurrentLedger.GetView(ZaVExpenseType.ViewTypes.Blank)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            };
        }

        /// <summary>
        /// Create a row based upon a given expense view
        /// </summary>
        /// <param name="view">The view to create a row for</param>
        /// <returns>The populated row</returns>
        public DataGridViewRow CreateDisplayViewRow(ZaDisplayView view)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell textCell;
            DataGridViewButtonCell buttonCell;
            try
            {
                row.Tag = view;
                row.DefaultCellStyle.Font = DefaultFont;
                // Create the first cell
                switch (view.ViewType)
                {
                    case ZaVExpenseType.ViewTypes.Secondary:
                        textCell = new DataGridViewTextBoxCell();
                        textCell.Value = "9";
                        textCell.Style.Font = new Font("Wingdings 3", 8);
                        textCell.Style.ForeColor = Color.LightGray;
                        textCell.Style.SelectionForeColor = Color.LightGray;
                        textCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        row.Cells.Add(textCell);
                        break;
                    case ZaVExpenseType.ViewTypes.Total:
                    case ZaVExpenseType.ViewTypes.Unallocated:
                    case ZaVExpenseType.ViewTypes.Blank:
                        textCell = new DataGridViewTextBoxCell();
                        row.Cells.Add(textCell);
                        break;
                    default:
                        if (CurrentLedger.ExpenseViews.Any(x => x.Parent == view))
                        {
                            buttonCell = new DataGridViewButtonCell();
                            buttonCell.Value = "+";
                            row.Cells.Add(buttonCell);
                        }
                        else
                        {
                            textCell = new DataGridViewTextBoxCell();
                            row.Cells.Add(textCell);
                        }
                        break;
                }
                view.DateRangeSelected = IsDateRangeSelected();
                view.GetRemainCells(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return row;
        }

        /// <summary>
        /// Run through each possible view, populate the list and recalculate them
        /// </summary>
        public void RecalculateExpenseTypeViews()
        {
            try
            {
                // Total = Total of all 'expense' types and all that have been unallocated (assume expense)
                Decimal total = CurrentLedger.GetTotalForExpenseType(type: ZaExpenseType.ExpenseTypes.Expense) + CurrentLedger.GetUnallocatedTotal();
                Decimal totalWithDate = CurrentLedger.GetTotalForExpenseType(null, SelectedDateTo, SelectedDateFrom, ZaExpenseType.ExpenseTypes.Expense) +
                    CurrentLedger.GetUnallocatedTotal(SelectedDateTo, SelectedDateFrom);
                ZaVExpenseType view;
                ZaVExpenseType secondaryView;
                #region Expense type rows
                foreach (ZaExpenseType.ExpenseTypes e in Enum.GetValues(typeof(ZaExpenseType.ExpenseTypes)))
                {

                    foreach (ZaExpenseType reference in (from ZaExpenseType n in CurrentLedger.ExpenseTypes
                                                         where n.Type == e
                                                         select n))
                    {
                        view = CurrentLedger.GetView(ZaVExpenseType.GetViewTypeFromExpenseType(e), reference);

                            foreach (ZaSecondaryExpenseType secondaryReference in (from ZaSecondaryExpenseType n in CurrentLedger.SecondaryExpenseTypes
                                                                                   where n.dsExpenseType == reference
                                                                                   select n))
                            {
                                secondaryView = CurrentLedger.GetView(ZaVExpenseType.ViewTypes.Secondary, secReference: secondaryReference);
                                secondaryView.Parent = view;
                                secondaryView.Total = CurrentLedger.GetTotalForExpenseType(secExpense: secondaryReference);
                                secondaryView.Percent = total > 0 ? secondaryView.Total / total : 0 ;
                                secondaryView.TotalWithinPeriod = CurrentLedger.GetTotalForExpenseType(secExpense: secondaryReference, dateTo: SelectedDateTo, dateFrom: SelectedDateFrom);
                                secondaryView.PercentWithinPeriod = totalWithDate > 0 ? secondaryView.TotalWithinPeriod / totalWithDate : 0;

                            }

                        
                        view.Total = CurrentLedger.GetTotalForExpenseType(reference);
                        view.Percent = total > 0 ? view.Total / total : 0;
                        view.TotalWithinPeriod = CurrentLedger.GetTotalForExpenseType(reference, SelectedDateTo, SelectedDateFrom);
                        view.PercentWithinPeriod = totalWithDate > 0 ? view.TotalWithinPeriod / totalWithDate : 0;
                    }
                }
                #endregion
                #region blank view
                // This will insert a blank view, this needs to be done at least once to initalise it
                CurrentLedger.GetView(ZaVExpenseType.ViewTypes.Blank);
                #endregion
                #region Total row
                view = CurrentLedger.GetView(ZaVExpenseType.ViewTypes.Total, new ZaExpenseType("Total"));
                view.Total = total;
                view.TotalWithinPeriod = totalWithDate;
                #endregion
                #region Unallocated row
                view = CurrentLedger.GetView(ZaVExpenseType.ViewTypes.Unallocated, new ZaExpenseType("Unallocated"));
                view.Total = CurrentLedger.GetUnallocatedTotal();
                view.TotalWithinPeriod = CurrentLedger.GetUnallocatedTotal(SelectedDateTo, SelectedDateFrom);
                view.Display = view.Total > 0;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// clear and then Load both the expense and account stats grids
        /// </summary>
        public void LoadAccountsStatsGrids()
        {
            try
            {
                #region Accounts Grid View
                zAccountStatsView.Columns.Clear();
                DataGridViewTextBoxColumn textColumn;
                DataGridViewRow row;
                DataGridViewCell cell;

                #region Create the columns
                textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Account";
                textColumn.Frozen = true;
                textColumn.Name = ZaAccount.F_Name;
                textColumn.Width = MockDb.Database.System.GetColumnWidth(zAccountStatsView, textColumn);

                zAccountStatsView.Columns.Add(textColumn);

                foreach (ZaAccount.AccountReportingTypes n in Enum.GetValues(typeof(ZaAccount.AccountReportingTypes)))
                {
                    if (!(n == ZaAccount.AccountReportingTypes.WithinRange && !IsDateRangeSelected()))
                    {
                        textColumn = new DataGridViewTextBoxColumn();
                        textColumn.HeaderText = n.ToString();
                        textColumn.Name = n.ToString();
                        textColumn.Width = MockDb.Database.System.GetColumnWidth(zAccountStatsView, textColumn);
                        

                        zAccountStatsView.Columns.Add(textColumn);
                    }
                }
                #endregion
                #region Create the details per account
                foreach (ZaAccount account in CurrentLedger.Accounts)
                {
                    row = new DataGridViewRow();

                    row.Tag = account;

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = account.ToString();
                    cell.Style.Font = new System.Drawing.Font(zExpenseTypeStatsView.Font, FontStyle.Bold);
                    cell.Style.BackColor = Color.LightSkyBlue;

                    row.Cells.Add(cell);

                    foreach (ZaAccount.AccountReportingTypes e in Enum.GetValues(typeof(ZaAccount.AccountReportingTypes)))
                    {
                        if (!(e == ZaAccount.AccountReportingTypes.WithinRange && !IsDateRangeSelected()))
                        {
                            cell = new DataGridViewTextBoxCell();
                            cell.Value = CurrentLedger.GetTotalForAccount(e, account, SelectedDateTo, SelectedDateFrom);
                            cell.Style.Format = "c";

                            row.Cells.Add(cell);
                        }
                    }

                    zAccountStatsView.Rows.Add(row);
                }
                #endregion
                AdjustAccountStatsViewDimensions();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// clear then Load the breakdown grid and all it's information
        /// </summary>
        public void LoadBreakdownGrid()
        {
            try
            {
                zBreakdownDataGridView.Columns.Clear();
                DataGridViewTextBoxColumn textColumn;
                DataGridViewRow row;
                DataGridViewCell cell;
                Decimal totalMonthlyOnCategory = 0;

                if (typeFilterComboBox.SelectedItem != null && filterComboBox.SelectedItem != null)
                {
                    #region Create the columns
                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.HeaderText = "Month/Year";
                    textColumn.Frozen = true;
                    zBreakdownDataGridView.Columns.Add(textColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.HeaderText = "Amount";
                    zBreakdownDataGridView.Columns.Add(textColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.HeaderText = "% Month";
                    zBreakdownDataGridView.Columns.Add(textColumn);
                    
                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.HeaderText = "Count";
                    zBreakdownDataGridView.Columns.Add(textColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.HeaderText = "Month Total";
                    zBreakdownDataGridView.Columns.Add(textColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.HeaderText = "% All";
                    zBreakdownDataGridView.Columns.Add(textColumn);

                    textColumn = new DataGridViewTextBoxColumn();
                    textColumn.HeaderText = "Count";
                    zBreakdownDataGridView.Columns.Add(textColumn);

                    #endregion
                    #region Create Rows
                    Decimal total = (from ZaLedgerItem n in CurrentLedger.LedgerItemList
                                    where (n.ExpenseType != null && n.ExpenseType.Type != ZaExpenseType.ExpenseTypes.Income) || n.ExpenseType == null
                                    select n.PurchasePrice).Sum();

                    List<ZaLedgerItem> FilteredLedgerItemList = new List<ZaLedgerItem>();
                    switch ((ZaLedgerItem.ConfigurableAttributes)typeFilterComboBox.SelectedItem)
                    {
                        case ZaLedgerItem.ConfigurableAttributes.Accounts:
                            FilteredLedgerItemList = (from ZaLedgerItem li in CurrentLedger.LedgerItemList
                                                      where li.Account == (ZaAccount)filterComboBox.SelectedItem
                                                      select li).ToList();
                            break;
                        case ZaLedgerItem.ConfigurableAttributes.ExpenseTypes:
                            FilteredLedgerItemList = (from ZaLedgerItem li in CurrentLedger.LedgerItemList
                                                      where li.ExpenseType == (ZaExpenseType)filterComboBox.SelectedItem
                                                      select li).ToList();
                            break;
                        case ZaLedgerItem.ConfigurableAttributes.SecondaryExpenseType:
                            FilteredLedgerItemList = (from ZaLedgerItem li in CurrentLedger.LedgerItemList
                                                      where li.SecondaryExpenseType == (ZaSecondaryExpenseType)filterComboBox.SelectedItem
                                                      select li).ToList();
                            break;
                    }

                    foreach (var n in (from ZaLedgerItem item in FilteredLedgerItemList
                                       select new { item.PurchaseDate.Month, item.PurchaseDate.Year }).Distinct())
                    {
                        //Decimal monthQuery = CurrentLedger.GetTotalForExpenseType(dateTo: new DateTime(n.Year, n.Month, 1),
                        //dateFrom: new DateTime(n.Year, n.Month, DateTime.DaysInMonth(n.Year, n.Month)));
                        var monthQuery = (from ZaLedgerItem a in CurrentLedger.LedgerItemList
                         where a.PurchaseDate.Year == n.Year
                         && a.PurchaseDate.Month == n.Month
                         && a.ExpenseType != null ? a.ExpenseType.Type == ZaExpenseType.ExpenseTypes.Expense : false
                         select a.PurchasePrice);
                        Decimal monthTotal = monthQuery.Sum();

                        var totalMonthQuery = (from ZaLedgerItem a in FilteredLedgerItemList
                                               where a.PurchaseDate.Year == n.Year
                                               && a.PurchaseDate.Month == n.Month
                                               && (a.ExpenseType == null || a.ExpenseType.Type != ZaExpenseType.ExpenseTypes.Savings 
                                               || (a.Account != null && a.Account.Type == ZaAccount.AccountTypes.Savings))
                                               select a.PurchasePrice);
                        Decimal monthTotalPaid = totalMonthQuery.Sum();

                        totalMonthlyOnCategory += monthTotalPaid;

                        row = new DataGridViewRow();

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = n.Month + "/" + n.Year;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = monthTotalPaid;
                        cell.Style.Format = "c";
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = monthTotal > 0 ? monthTotalPaid / monthTotal : 0;
                        cell.Style.Format = "p2";
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = totalMonthQuery.Count();
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = monthTotal;
                        cell.Style.Format = "c";
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = monthTotalPaid > 0 ? monthTotalPaid / total : 0;
                        cell.Style.Format = "p2";
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = monthQuery.Count();
                        row.Cells.Add(cell);

                        zBreakdownDataGridView.Rows.Add(row);
                    }
                    #endregion
                    #region Totals Rows
                    zBreakdownDataGridView.AddEmptyRow();

                    row = new DataGridViewRow();

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = "Total";
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = totalMonthlyOnCategory;
                    cell.Style.Format = "c";
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = totalMonthlyOnCategory > 0 ? totalMonthlyOnCategory / total : 0;
                    cell.Style.Format = "p2";
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = FilteredLedgerItemList.Count();
                    row.Cells.Add(cell);


                    cell = new DataGridViewTextBoxCell();
                    cell.Value = total;
                    cell.Style.Format = "c";
                    row.Cells.Add(cell);

                    // Add empty
                    row.Cells.Add(new DataGridViewTextBoxCell());

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = CurrentLedger.LedgerItemList.Count();
                    row.Cells.Add(cell);

                    zBreakdownDataGridView.Rows.Add(row);

                    zBreakdownDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Open button event - for opening an existing ledger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnOpenItemList_Click(object sender, EventArgs e)
        {
            try
            {
                OpenLedger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Open a ledger from a file
        /// </summary>
        /// <param name="filename">The filename to open</param>
        /// <returns>Whether the open was succesful or not</returns>
        public bool OpenLedger(string filename = null)
        {
            bool returnValue = false;
            try
            {
                // If we already have a ledger, make sure they want to open/create a new one.
                if (CurrentLedger == null || MessageBox.Show("Are you sure you wish to open another ledger?", "Open New Ledger?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    OpenFileDialog ledger = new OpenFileDialog();
                    ledger.DefaultExt = ".Led";
                    ledger.Filter = "Ledgers|*.Led|XML Files|*.xml|All Files|*.*";
                    if (!String.IsNullOrEmpty(filename) || ledger.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        returnValue = true;
                        CurrentLedger = new ZaLedger();
                        CurrentLedger.PopulateLedger(filename ?? ledger.FileName);
                        InitaliseLedgerFrame();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }
        /// <summary>
        /// Clear all databindings to controls
        /// </summary>
        public void ClearBindings()
        {
            try
            {
                dateFromPicker.DataBindings.Clear();
                dateToPicker.DataBindings.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         }

        /// <summary>
        /// Bind the Controls on the form
        /// </summary>
        public void BindControls()
        {
            try
            {
                if (CurrentLedger != null)
                {
                    comboBoxBudget.DataBindings.Add(new Binding("SelectedItem", CurrentLedger, "CurrentBudget"));
                    //dateFromPicker.DataBindings.Add("Value", this, "SelectedDateFrom");
                    //dateToPicker.DataBindings.Add("Value", this, "SelectedDateTo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Set the Defaults from the System Record on load of ledger
        /// </summary>
        public void SetDefaultsFromSystem()
        {
            try
            {
                if (CurrentLedger != null)
                {

                    if (MockDb.Database.System.RememberSelectedDates)
                    {
                        this.SelectedDateFrom = MockDb.Database.System.StoredDateFrom;
                        this.SelectedDateTo = MockDb.Database.System.StoredDateTo;
                        this.dateFromPicker.Value = MockDb.Database.System.StoredDateFrom;
                        this.dateToPicker.Value = MockDb.Database.System.StoredDateTo;
                    }
                    else
                    {
                        this.SelectedDateFrom = DateTime.Today;
                        this.SelectedDateTo = DateTime.Today;
                    }
                    if (MockDb.Database.System.RememberMaximisedState)
                    {
                        this.WindowState = MockDb.Database.System.Maximised ? FormWindowState.Maximized : FormWindowState.Normal;
                    }
                }
                SetupListOfDataGridView();
                SetupDataGridViewFromSystem();
                SetupDataGridViews();
                SetColumnDefaultsFromSystem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Through recursion, will find all datagridviews...this may be changed to include more later
        /// </summary>
        /// <param name="ctl">For recursion. Null if this is the first time</param>
        public void SetupListOfDataGridView(Control ctl = null)
        {
            try
            {
                // If this is the first time, assume it's for everything
                if (ctl == null)
                    ctl = this;
                foreach (Control con in ctl.Controls)
                {
                    if (ctl is ZaDataGridView)
                    {
                        DGVs.Add((ZaDataGridView) ctl);
                    }
                    else
                    {
                        SetupListOfDataGridView(con);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Will set up each datagridview with the appropriate settings. This should only be called once
        /// </summary>
        public void SetupDataGridViews()
        {
            try
            {
                // If the list hasn't been set up - set it up!
                if (!DGVs.Any())
                {
                    SetupListOfDataGridView();
                }
                // Now set the datagridviews to their appropriate values
                foreach (ZaDataGridView dgv in DGVs)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle(dgv.DefaultCellStyle);
                    style.BackColor = Color.LightCyan;
                    // Only set the styles for a DGV that uses the standard style
                    if (dgv.UseStandardStyle)
                    {
                        dgv.AlternatingRowsDefaultCellStyle = style;
                    }
                    if (dgv.DataSource != null)
                    {
                        dgv.CellMouseDown += new DataGridViewCellMouseEventHandler(datagridview_CellMouseDown);
                        dgv.ContextMenuStrip = zaLedgerItemsContextMenu;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Set up the datagridview from the System file
        /// </summary>
        public void SetupDataGridViewFromSystem()
        {
            try
            {
                foreach (ZaDataGridView dgv in DGVs)
                {
                    dgv.UseRedAsIncome = MockDb.Database.System.UseRedAsIncome;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Set the column defaults from the system record.
        /// </summary>
        public void SetColumnDefaultsFromSystem()
        {
            try
            {
                if (MockDb.Database.System != null && MockDb.Database.System.ColumnsWidth != null)
                {
                    foreach (DataGridViewColumn col in zledgerItemListView.Columns)
                    {
                        Tuple<string, string> key = new Tuple<string, string>(zledgerItemListView.Name, col.Name);
                        if (MockDb.Database.System.ColumnsWidth.ContainsKey(key))
                        {
                            col.Width = MockDb.Database.System.ColumnsWidth[key];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Save button event - for saving the current ledger with current filename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSaveItemList_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentLedger != null)
                {
                    // If the ledger filename is empty, then this hasnt' been saved before
                    // Make the user use the 'save as' prompt instead
                    if (string.IsNullOrEmpty(CurrentLedger.LedgerFileName))
                    {
                        btnSaveAsToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        SaveLedger();
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Common method that will save the ledger.
        /// </summary>
        public void SaveLedger(string filename = null)
        {
            try
            {
                if (CurrentLedger != null)
                {
                    SaveSettings();
                    CurrentLedger.SaveLedger(filename);
                    FormLogic();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Save the size of the columns to the system record so they can be remembered
        /// </summary>
        public void SaveColumnWidthsToSystem(IEnumerable<DataGridView> dgvs)
        {
            try
            {
                if (CurrentLedger != null)
                {
                    foreach (var dgv in dgvs)
                    {
                        SaveColumnWidthsToSystem(dgv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Save the size of the columns to the system record so they can be remembered
        /// </summary>
        public void SaveColumnWidthsToSystem(DataGridView dgv)
        {
            try
            {
                if (CurrentLedger != null)
                {
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            Tuple<string, string> key = new Tuple<string, string>(dgv.Name, column.Name);
                            if (!MockDb.Database.System.ColumnsWidth.ContainsKey(key))
                            {
                                MockDb.Database.System.ColumnsWidth.Add(key, column.Width);
                            }
                            else
                            {
                                MockDb.Database.System.ColumnsWidth[key] = column.Width;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Save the settings to the system record.
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                if (CurrentLedger != null)
                {
                    SaveColumnWidthsToSystem(DGVs);

                    if (MockDb.Database.System.RememberSelectedDates)
                    {
                        MockDb.Database.System.StoredDateFrom = dateFromPicker.Value;
                        MockDb.Database.System.StoredDateTo = dateToPicker.Value;
                    }
                    MockDb.Database.System.Maximised = this.WindowState == FormWindowState.Maximized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Form logic to disable/enable controls
        /// </summary>
        public void FormLogic()
        {
            try
            {
                filterComboBox.Enabled = typeFilterComboBox.SelectedItem != null;
                saveAsToolStripMenuItem.Enabled = CurrentLedger != null;
                saveToolStripMenuItem.Enabled = CurrentLedger != null;
                optionsToolStripMenuItem.Enabled = CurrentLedger != null;
                if (CurrentLedger != null)
                {
                    toolStripOpenFileLabel.Text = string.IsNullOrWhiteSpace(CurrentLedger.LedgerFileName) ? "None" : CurrentLedger.LedgerFileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Formload - shows the splashscreen and calls formlogic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FormLoad(object sender, EventArgs e)
        {
            try
            {
                FormLogic();
                this.Hide();
                ZaLedgerSplash splash = new ZaLedgerSplash();
                splash.ledgerForm = this;
                splash.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Open the form to manage the accounts avaialble
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentLedger != null)
                {
                    if (CurrentLedger.Accounts == null)
                    {
                        CurrentLedger.Accounts = new ZaBindingList<ZaAccount>();
                    }
                    ZaAccounts diag = new ZaAccounts();
                    diag.bindingAccounts = new ZaBindingList<ZaAccount>();
                    diag.bindingAccounts = CurrentLedger.Accounts;
                    diag.FormClosing += new FormClosingEventHandler(diag_FormClosing);
                    diag.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Open the form to manage the expense types avaialble
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnExpenseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentLedger != null)
                {
                    if (CurrentLedger.ExpenseTypes == null)
                    {
                        CurrentLedger.ExpenseTypes = new ZaBindingList<ZaExpenseType>();
                    }
                    ZaExpenseTypes diag = new ZaExpenseTypes();
                    diag.bindingExpenseTypes = new ZaBindingList<ZaExpenseType>();
                    diag.bindingExpenseTypes = CurrentLedger.ExpenseTypes;
                    diag.bindingSecondaryExpenseTypes = new ZaBindingList<Reference.ExpenseType.ZaSecondaryExpenseType>();
                    diag.bindingSecondaryExpenseTypes = CurrentLedger.SecondaryExpenseTypes;
                    diag.FormClosing += diag_FormClosing;
                    diag.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Form Closing event - assures that grids are updated after tinking with account/expense management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void diag_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Only if the user has pressed "OK" do we want this run.
                if (sender is ZafrDialog &&
              ((ZafrDialog)sender).DialogResult == DialogResult.OK && e.CloseReason == CloseReason.UserClosing)
                {

                    // Add to DB, this lets the type flow through properly
                    dynamic returnValue = ((ZafrDialog)sender).returnValue;

                    // If we were given a list, process the list instead of a single item
                    if (returnValue is IEnumerable)
                    {
                        foreach (dynamic value in (IEnumerable)returnValue)
                        {
                            MockDb.Database.Add(value);
                        }
                    }
                    else
                    {
                        if (returnValue != null)
                        {
                            MockDb.Database.Add(returnValue);
                        }

                    }

                    // Then add to visible list
                    var typeSwitch = new Dictionary<Type, Action>{
                    {typeof(ZaAccounts), () => CurrentLedger.Accounts = ((ZaAccounts)sender).bindingAccounts},
                    {typeof(ZaExpenseTypes), () => {CurrentLedger.ExpenseTypes = ((ZaExpenseTypes)sender).bindingExpenseTypes;
                                                   CurrentLedger.SecondaryExpenseTypes = ((ZaExpenseTypes)sender).bindingSecondaryExpenseTypes;}},
                    {typeof(ZaFrSystem), SetupDataGridViewFromSystem},
                    {typeof(ZaAccountDialog), () => CurrentLedger.Accounts.Add((ZaAccount)((ZafrDialog)sender).returnValue)},
                    {typeof(ZaExpenseTypeDialog), () => CurrentLedger.ExpenseTypes.Add((ZaExpenseType)((ZafrDialog)sender).returnValue)},
                    {typeof(ZaSecondaryExpenseTypeDialog), () => CurrentLedger.SecondaryExpenseTypes.Add((ZaSecondaryExpenseType)((ZafrDialog)sender).returnValue)},
                    {typeof(ZaAccountTransfer), () => CurrentLedger.LedgerItemList.AddRange((List<ZaLedgerItem>)((ZafrDialog)sender).returnValue)}
                };

                    if (typeSwitch.ContainsKey(sender.GetType()))
                    {
                        typeSwitch[sender.GetType()]();
                    }
                    SetupGrid();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Create a new, blank ledger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnNewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentLedger == null
                    || MessageBox.Show("Are you sure you wish to create a new Ledger?\nThis will unload the current one", "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    CurrentLedger = new ZaLedger();
                    CurrentLedger.InitaliseNewLedger();
                    InitaliseLedgerFrame();
                }
                FormLogic();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InitaliseLedgerFrame()
        {
            try
            {
                ClearBindings();
                SetupGrid();
                LoadReferenceGrids();
                SetDefaultsFromSystem();
                BindControls();
                SetFilterTypeComboBox();
                FormLogic();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zledgerItemListView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Do nothing with these at the moment (maybe i'll get around to making it never happen one day...)
            // Seems to have something to do with combobox cells
        }


        /// <summary>
        /// Event for when the ledger item grids width is changed to update others based on this change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zledgerItemListView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                AdjustLedgerItemViewWidth();
                SaveColumnWidthsToSystem(zledgerItemListView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Adjust the ledger item grid such that it will always be wide enough to see every column
        /// </summary>
        public void AdjustLedgerItemViewWidth()
        {
            try
            {
                bool addVScrollWidth = (zledgerItemListView.Rows.GetRowsHeight(DataGridViewElementStates.Visible) > zledgerItemListView.Height) ||
                                       zledgerItemListView.GetScrollBar(ScrollBars.Vertical).Visible;

                int newWidth = zledgerItemListView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 3
                            + (addVScrollWidth ? zledgerItemListView.GetScrollBar(ScrollBars.Vertical).Width : 0);
                int difference = zledgerItemListView.Width - newWidth;
                zledgerItemListView.Width = newWidth;
                TabControlPrimary.Width = newWidth + SystemInformation.VerticalScrollBarWidth;

                splitContainerReference.Location = new Point(splitContainerReference.Location.X - difference, splitContainerReference.Location.Y);
                splitContainerReference.Width += difference;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Adjust the accounting stats grid such that it is always tall enough including a horizontal
        /// scrollbar
        /// </summary>
        public void AdjustAccountStatsViewDimensions()
        {
            try
            {
                int totalHeight = zAccountStatsView.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + zAccountStatsView.ColumnHeadersHeight + SystemInformation.HorizontalScrollBarHeight;
                int totalWidth = zAccountStatsView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 2;

                zAccountStatsView.Height = totalHeight;
                zAccountStatsView.Width = totalWidth;
                splitContainerReference.SplitterDistance = totalHeight + 22 + groupBoxDateRange.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Adjust the Expense Stats datagridview dimensions
        /// </summary>
        public void AdjustExpenseStatsViewDimensions()
        {
            try
            {
                int width = zExpenseTypeStatsView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + SystemInformation.VerticalScrollBarWidth + 2;
                int height = zExpenseTypeStatsView.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + zExpenseTypeStatsView.ColumnHeadersHeight + 2;

                if (height > splitContainerReference.Panel2.Height)
                    height = splitContainerReference.Panel2.Height;

                this.zExpenseTypeStatsView.Height = height;
                this.zExpenseTypeStatsView.Width = width;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        /// <summary>
        /// Method for when the either date pickers values are changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedDateFrom = dateFromPicker.Value;
                SelectedDateTo = dateToPicker.Value;
                LoadAccountsStatsGrids();
                LoadExpenseTypeStatsGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Sets the filter type on the breakdown type box
        /// </summary>
        public void SetFilterTypeComboBox()
        {
            try
            {
                comboBoxBudget.DataSource = CurrentLedger.Budgets;
                comboBoxBudget.DisplayMember = "Name";
                typeFilterComboBox.DataSource = Enum.GetValues(typeof(ZaLedgerItem.ConfigurableAttributes));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Event for when scrollbar visibility is changed on the accounts grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountHorizontalScrollbarVisibilityChanged(object sender, EventArgs e)
        {
            try
            {
                AdjustAccountStatsViewDimensions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Method for when the type of filter for the breakdown grid is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typeFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((ZaLedgerItem.ConfigurableAttributes)typeFilterComboBox.SelectedItem)
                {
                    case ZaLedgerItem.ConfigurableAttributes.Accounts:
                        filterComboBox.DataSource = CurrentLedger.Accounts;
                        break;
                    case ZaLedgerItem.ConfigurableAttributes.ExpenseTypes:
                        filterComboBox.DataSource = CurrentLedger.ExpenseTypes;
                        break;
                    case ZaLedgerItem.ConfigurableAttributes.SecondaryExpenseType:
                        filterComboBox.DataSource = CurrentLedger.SecondaryExpenseTypes;
                        break;
                }
                filterComboBox.ValueMember = "Self";
                filterComboBox.DisplayMember = "Name";
                LoadBreakdownGrid();
                FormLogic();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Method for when the filter is changed on the breakdown grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBreakdownGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// "Save As..." button method to save the ledger to a new location/name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (CurrentLedger != null)
                {
                    SaveFileDialog fd = new SaveFileDialog();
                    fd.AddExtension = true;
                    fd.AutoUpgradeEnabled = true;
                    fd.DefaultExt = ".Led";
                    fd.Title = "Save Ledger As...";
                    fd.Filter = "Ledgers|*.Led|XML Files|*.xml|All Files|*.*"; 
                    if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        SaveLedger(fd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// "Remove" context menu method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var menu = (ToolStripDropDownItem)sender;
                var strip = (ContextMenuStrip)menu.Owner;
                var dgv = (DataGridView)strip.SourceControl;
                if (dgv.SelectedRows.Count > 0)
                {
                    dgv.Rows.RemoveAt(dgv.Rows.GetFirstRow(DataGridViewElementStates.Selected));
                    dgv.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// When finished editing a row, update the grids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zledgerItemListView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Don't reload/commit the edit if there's nothing changed!
                if (zledgerItemListView.IsCurrentRowDirty)
                {
                    zledgerItemListView.CommitEdit(0);
                    // Update the grids with the new value entered...yes, it's not the most effecient way
                    LoadAccountsStatsGrids();
                    LoadExpenseTypeStatsGrids();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Settings menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentLedger != null)
                {
                    ZaFrSystem diag = new ZaFrSystem();
                    diag.SystemReference = MockDb.Database.System;
                    diag.FormClosing += new FormClosingEventHandler(diag_FormClosing);
                    diag.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zledgerItemListView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (zledgerItemListView.CurrentCell.OwningColumn.Name == ZaLedgerItem.F_SecondaryExpenseType)
                {
                    DataGridViewComboBoxColumn comboColumn =  (DataGridViewComboBoxColumn)zledgerItemListView.CurrentCell.OwningColumn;
                    ZaExpenseType Expense = (ZaExpenseType)zledgerItemListView.CurrentRow.Cells[3].Value;
                    DataGridViewComboBoxEditingControl c = (DataGridViewComboBoxEditingControl)e.Control;
                    if (c.DataSource != null)
                    {
                        c.DataSource = ((ZaBindingList<ZaSecondaryExpenseType>)comboColumn.DataSource).Where(x => x.dsExpenseType == Expense).ToList();
                        c.SelectedItem = (ZaSecondaryExpenseType)zledgerItemListView.CurrentRow.Cells[4].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zExpenseTypeStatsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    DataGridViewRow row = (DataGridViewRow)zExpenseTypeStatsView.Rows[e.RowIndex];
                    // Only act as if 'clicked' if this is actually a button cell!
                    if (row.Cells[e.ColumnIndex] is DataGridViewButtonCell)
                    {
                        ZaDisplayView item = (ZaDisplayView)row.Tag;
                        // Swap whatever it currently is.
                        item.Expanded = !item.Expanded;
                        // Call a reload on the grid
                        if (((ZaDataGridView)sender).reloadMethod != null)
                            Invoke(((ZaDataGridView)sender).reloadMethod);
                        //LoadExpenseTypeStatsGrids();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void nameFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(nameFilterTextBox.Text))
                {
                    CurrentLedger.LedgerItemListSource.Filter = "Description LIKE " + nameFilterTextBox.Text;
                }
                else
                {
                    CurrentLedger.LedgerItemListSource.Filter = "";
                    LoadExpenseTypeStatsGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ZafrFinancialLedger_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CurrentLedger != null)
                {
                    Settings.Default.LastUsedLedger = CurrentLedger.LedgerFileName;
                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Load the budget grid
        /// </summary>
        private void LoadBudgetGrid()
        {
            try
            {
                zaBudgetGrid.AutoGenerateColumns = false;
                zaBudgetGrid.Columns.Clear();

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "+";
                buttonColumn.Frozen = true;
                buttonColumn.Width = 25;
                buttonColumn.DefaultCellStyle.SelectionBackColor = Color.Transparent;

                zaBudgetGrid.Columns.Add(buttonColumn);

                DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Expense Type";

                zaBudgetGrid.Columns.Add(comboColumn);

                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.DefaultCellStyle.Format = "c";
                textColumn.HeaderText = "Flat";

                zaBudgetGrid.Columns.Add(textColumn);

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.DefaultCellStyle.Format = "p2";
                textColumn.HeaderText = "Percent";

                zaBudgetGrid.Columns.Add(textColumn);

                
                CreateBudgetViews();
                AddBudgetViewsToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Create all budget views from the current budget item list for the current budget
        /// </summary>
        private void CreateBudgetViews()
        {
            try
            {
                if (CurrentLedger.CurrentBudget != null)
                {
                    foreach (ZaBudgetItem bi in CurrentLedger.CurrentBudget.BudgetItems.Where(x => x.SecondaryExpense == null))
                    {
                        var budgetItemView = CurrentLedger.BudgetViews.FirstOrDefault(x => x.Item == bi);
                        if (budgetItemView == null)
                        {
                            budgetItemView = new ZaVBudgetItem();
                            budgetItemView.Item = bi;
                            budgetItemView.ViewType = ZaDisplayView.ViewTypes.Normal;
                            CurrentLedger.BudgetViews.Add(budgetItemView);
                        }
                        foreach (ZaBudgetItem sbi in CurrentLedger.CurrentBudget.BudgetItems.Where(x => x.Expense == bi.Expense && x.SecondaryExpense != null))
                        {
                            var secBudgetItemView = new ZaVBudgetItem();
                            secBudgetItemView.Item = sbi;
                            secBudgetItemView.Parent = budgetItemView;
                            secBudgetItemView.ViewType = ZaDisplayView.ViewTypes.Secondary;
                            CurrentLedger.BudgetViews.Add(secBudgetItemView);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Add all the budget views too the grid
        /// </summary>
        private void AddBudgetViewsToGrid()
        {
            try
            {
                foreach (ZaVBudgetItem item in CurrentLedger.BudgetViews.Where(x => x.Item.SecondaryExpense == null && x.Display) )
                {
                    AddDisplayViewRowToDataGrid(item, zaBudgetGrid);
                    if (item.Expanded)
                    {
                        foreach (ZaVBudgetItem secItem in CurrentLedger.BudgetViews.Where(x => x.Parent == item && x.Display))
                        {
                            AddDisplayViewRowToDataGrid(secItem, zaBudgetGrid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Method to create a budget item for every expense/secondary expense type
        /// </summary>
        private void AddDefaultBudgetItems(ZaExpenseType expenseType = null)
        {
            try
            {
                // We need this to exist before doing this...
                if (CurrentLedger.CurrentBudget != null)
                {
                    // If we haven't given an expense type, we want to create all the expense types
                    if (expenseType == null)
                    {
                        CurrentLedger.CurrentBudget.BudgetItems.AddRange(CurrentLedger.ExpenseTypes.Except(CurrentLedger.CurrentBudget.BudgetItems.Select(x => x.Expense)).Select(x => new ZaBudgetItem() { Expense = x }));
                    }
                    else
                    {
                        // If we've been given an expense type, create items for all the secondary types of this expense type
                        CurrentLedger.CurrentBudget.BudgetItems.AddRange(CurrentLedger.SecondaryExpenseTypes.Except(CurrentLedger.CurrentBudget.BudgetItems.Select(x => x.SecondaryExpense)).Select(x => new ZaBudgetItem() { SecondaryExpense = x, Expense = expenseType }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadReferenceGrids()
        {
            try
            {
                #region Expense type grid
                // Expense type grid
                zaExpenseTypeReferenceDGV.AutoGenerateColumns = false;
                zaExpenseTypeReferenceDGV.Columns.Clear();
                zaExpenseTypeReferenceDGV.DataSource = CurrentLedger.ExpenseTypes;

                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Name";
                textColumn.DataPropertyName = ZaExpenseType.F_Name;

                zaExpenseTypeReferenceDGV.Columns.Add(textColumn);

                DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Type";
                comboColumn.DataSource = Enum.GetValues(typeof(ZaExpenseType.ExpenseTypes));
                comboColumn.DataPropertyName = ZaExpenseType.F_Type;

                zaExpenseTypeReferenceDGV.Columns.Add(comboColumn);


                //Secondary expense types grid
                zaSecondaryExpenseReferenceDGV.AutoGenerateColumns = false;
                zaSecondaryExpenseReferenceDGV.Columns.Clear();
                zaSecondaryExpenseReferenceDGV.DataSource = CurrentLedger.SecondaryExpenseTypes;

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Name";
                textColumn.DataPropertyName = ZaSecondaryExpenseType.F_Name;

                zaSecondaryExpenseReferenceDGV.Columns.Add(textColumn);

                comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Expense Type";
                comboColumn.DataSource = CurrentLedger.ExpenseTypes;
                comboColumn.DisplayMember = "Label";
                comboColumn.ValueMember = "Self";
                comboColumn.DataPropertyName = "dsExpenseType";

                zaSecondaryExpenseReferenceDGV.Columns.Add(comboColumn);
                #endregion
                #region Accounts grid
                // Accounts grid
                zaAccountsReferenceDGV.AutoGenerateColumns = false;
                zaAccountsReferenceDGV.Columns.Clear();
                zaAccountsReferenceDGV.DataSource = CurrentLedger.Accounts;

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Name";
                textColumn.DataPropertyName = ZaAccount.F_Name;

                zaAccountsReferenceDGV.Columns.Add(textColumn);

                textColumn = new DataGridViewTextBoxColumn();
                textColumn.HeaderText = "Original Balance";
                textColumn.DataPropertyName = ZaAccount.F_OriginalBalance;
                textColumn.DefaultCellStyle.Format = "c";

                zaAccountsReferenceDGV.Columns.Add(textColumn);

                comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Type";
                comboColumn.DataPropertyName = ZaAccount.F_Type;
                comboColumn.DataSource = Enum.GetValues(typeof(ZaAccount.AccountTypes));
                comboColumn.ValueType = typeof(ZaAccount.AccountTypes);

                zaAccountsReferenceDGV.Columns.Add(comboColumn);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Will control what happens when the tab is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlDataDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (TabControlPrimary.SelectedIndex)
                {
                    case 0:
                        SetupGrid();
                        break;
                    case 1:
                        LoadBreakdownGrid();
                        break;
                    case 2:
                        LoadBudgetGrid();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zaSecondaryExpenseReferenceDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void zaExpenseTypeReferenceDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        /// <summary>
        /// + button for account reference grid click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            try
            {
               ShowCustomDialog<ZaAccountDialog>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// + button for expense grid click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExpeseAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCustomDialog<ZaExpenseTypeDialog>();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// + button for sub expense grid click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubExpenseAdd_Click(object sender, EventArgs e)
        {
            ShowCustomDialog<ZaSecondaryExpenseTypeDialog>();
        }

        /// <summary>
        /// Cell Mouse Down event to select a row on right click or middle click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagridview_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
                {
                    if (e.RowIndex >= 0)
                    {
                        ((ZaDataGridView)sender).ClearSelection();
                        ((ZaDataGridView)sender).Rows[e.RowIndex].Selected = true;
                        // Disable all current menu strip items if this is a new row
                        foreach (ToolStripMenuItem i in ((ZaDataGridView)sender).ContextMenuStrip.Items)
                        {
                            i.Enabled = !((ZaDataGridView)sender).Rows[e.RowIndex].IsNewRow;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGenerateImport_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application app = new Excel.Application();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Determine if a positive date range has been selected
        /// </summary>
        /// <returns></returns>
        public bool IsDateRangeSelected()
        {
            bool returnValue = false;
            try
            {
                returnValue = SelectedDateFrom.CalculateDaysBetween(SelectedDateTo) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }

        /// <summary>
        /// Button to bring up the dialog to add a budget
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBudgetAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCustomDialog<ZaBudgetDialog>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Button call to automatically populate expense types for the selected budget
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBudgetPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentLedger.CurrentBudget != null)
                {
                    AddDefaultBudgetItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Tool strip menu item to split the currently selected item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var menu = (ToolStripDropDownItem)sender;
                var strip = (ContextMenuStrip)menu.Owner;
                var dgv = (DataGridView)strip.SourceControl;
                if (dgv.SelectedRows.Count > 0)
                {
                    ZaLedgerItem ledgerItem = dgv.Rows[dgv.Rows.GetFirstRow(DataGridViewElementStates.Selected)].DataBoundItem as ZaLedgerItem;
                    if (ledgerItem != null)
                    {
                        ZaLedgerItem newItem = new ZaLedgerItem(ledgerItem);

                        newItem = ShowCustomDialog<ZaLedgerItemDialog>(newItem) as ZaLedgerItem;

                        if (newItem != null)
                        {
                            CurrentLedger.LedgerItemList.Add(newItem);
                            // We have our item, reduce the purchase price by the value chosen 
                            ledgerItem.PurchasePrice -= newItem.PurchasePrice;
                            // Have the list sort again if it's sorted
                            CurrentLedger.LedgerItemList.EndNew(CurrentLedger.LedgerItemList.IndexOf(newItem));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zAccountStatsView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                AdjustAccountStatsViewDimensions();
                SaveColumnWidthsToSystem(zAccountStatsView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void zExpenseTypeStatsView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                AdjustAccountStatsViewDimensions();
                SaveColumnWidthsToSystem(zExpenseTypeStatsView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAccountTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCustomDialog<ZaAccountTransfer>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void transferFundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = zAccountStatsView.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (row != null)
                {
                    ZaAccount account = row.Tag as ZaAccount;
                    if (account != null)
                    {
                        ShowCustomDialog<ZaAccountTransfer>(account);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private object ShowCustomDialog<T>(params object[] args) where T : ZafrDialog, new() 
        {
            object returnValue = null;
            try
            {
                var dialog = new T();
                dialog.InitaliseCustomDialogSettings(args);
                dialog.FormClosing += new FormClosingEventHandler(diag_FormClosing);
                dialog.Owner = this;
                dialog.ShowDialog();

                returnValue = dialog.returnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }

        /// <summary>
        /// Method to select the row and enable context items for that row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zAccountStatsView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = ((DataGridView) sender).HitTest(e.X, e.Y);
                    ((DataGridView) sender).ClearSelection();
                    if (hti.RowIndex >= 0)
                    {
                        ((DataGridView) sender).Rows[hti.RowIndex].Selected = true;
                    }
                    transferFundsToolStripMenuItem.Enabled = hti.RowIndex >= 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    internal static class HelperMethods
    {
            /// <summary>
        /// Calculate the days between this date and the date given
        /// </summary>
        public static int CalculateDaysBetween(this DateTime date, DateTime date2)
        {
            int returnValue = 0;
            try
            {
                returnValue = (date2 - date).Days;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }
}
}
