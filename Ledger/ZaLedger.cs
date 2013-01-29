using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.Core;
using FinancialLedgerProject.ExpenseType;
using System.IO;
using FinancialLedgerProject.Core.ExtendedObjects;
using FinancialLedgerProject.Reference.ExpenseType;
using System.Collections.ObjectModel;
using FinancialLedgerProject.SystemInfo;
using FinancialLedgerProject.Views;
using System.Xml.Linq;
using FinancialLedgerProject.Reference.Budget;

public class ZaLedger
{
    /// <summary>
    /// Class Name
    /// </summary>
    public const string C_ZaLedger = "ZaLedger";

    /// <summary>
    /// The filename of the current Ledger open
    /// </summary>
    public string LedgerFileName { get; set; }

    /// <summary>
    /// Complete list of Ledger Items for this Ledger
    /// </summary>
    public ZaBindingList<ZaLedgerItem> LedgerItemList { get; set; }

    /// <summary>
    /// Binding source to use for binding to the grids
    /// </summary>
    public BindingSource LedgerItemListSource { get; set; }

    /// <summary>
    /// Complete List of Accounts for this Ledger
    /// </summary>
    public ZaBindingList<ZaAccount> Accounts { get; set; }

    /// <summary>
    /// Accounts keyed by dbseqnum for 
    /// </summary>
    public Dictionary<int, ZaAccount> keyedAccounts;

    /// <summary>
    /// Complete List of Expense Types for this Ledger
    /// </summary>
    public ZaBindingList<ZaExpenseType> ExpenseTypes { get; set; }

    /// <summary>
    /// Expense Types keyed by Dbseqnum for easy reference
    /// </summary>
    public Dictionary<int, ZaExpenseType> keyedExpenseTypes;

    /// <summary>
    /// Complete list of Secondary Expense types for this ledger
    /// </summary>
    public ZaBindingList<ZaSecondaryExpenseType> SecondaryExpenseTypes { get; set; }

    public ZaBudget CurrentBudget { get; set; }

    public ZaBindingList<ZaBudget> Budgets { get; set; }

    private List<ZaVExpenseType> expenseViews;
    /// <summary>
    /// List of expense type views used for generating the by expense grid
    /// </summary>
    public List<ZaVExpenseType> ExpenseViews
    {
        get
        {
            if (expenseViews == null)
            {
                expenseViews = new List<ZaVExpenseType>();
            }
            return expenseViews;
        }
        set
        {
            expenseViews = value;
        }
    }
    private List<ZaVBudgetItem> budgetViews;
    /// <summary>
    /// List of budget item views used for generating the budget grid
    /// </summary>
    public List<ZaVBudgetItem> BudgetViews
    {
        get
        {
            if (budgetViews == null)
            {
                budgetViews = new List<ZaVBudgetItem>();
            }
            return budgetViews;
        }
        set
        {
            budgetViews = value;
        }
    }

    public SortedDictionary<int, ZaVExpenseType.ViewTypes> OrderOfExpenseViews { get; set; }

    public ZaLedger()
    {

    }

    public ZaLedger(string filename)
    {
        PopulateLedger(filename);
    }

    /// <summary>
    /// Save the Ledger to the filename given
    /// </summary>
    /// <param name="filename">The file this ledger will be saved as, defaults to ledger.xml if null</param>
    public void SaveLedger(string filename = null)
    {
        try
        {
            MockDb database = MockDb.Database;
            // Make it pretty
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            // If we've provided a file name - that is now the current file for this ledger.
            if (filename != null)
            {
                LedgerFileName = filename;
            }
            // Open up the filename given, the filename for the ledger or just grab the current direction + "Ledger.xml"
            XmlWriter writer = XmlWriter.Create(LedgerFileName ?? (Directory.GetCurrentDirectory() + "\\ledger.xml"), settings);

            // Create a document will all the information we wish to save.
            XDocument doc = new XDocument(new XElement(ZaLedger.C_ZaLedger, database.Accounts.Select(a => a.ToXElement())
                                                  .Concat(database.ExpenseTypes.Select(e => e.ToXElement()))
                                                  .Concat(database.SecondaryExpenseTypes.Select(se => se.ToXElement()))
                                                  .Concat(database.LedgerItems.Select(i => i.ToXElement()))
                                                  .Concat(database.Budgets.Select(x => x.ToXElement()))
                                                  , database.System.ToXElement()));
            doc.WriteTo(writer);
            writer.Close();
            
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }


    /// <summary>
    /// Populate the Ledger with data from the file given
    /// </summary>
    /// <param name="filename">The file where the ledger data is located</param>
    /// <returns></returns>
    public bool PopulateLedger(string filename)
    {
        bool returnValue = true;
        try
        {
            InitaliseNewLedger();
            LedgerFileName = filename;
            MockDb.Database.LoadDatabaseFromFile(filename);
            LedgerItemList.RaiseListChangedEvents = false;
            UpdateBindableListsWithDb();
            LedgerItemListSource.DataSource = LedgerItemList;
            LedgerItemList.RaiseListChangedEvents = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return returnValue;
    }

    /// <summary>
    /// Creates a blank ledger, to be done on creation of a ledger
    /// </summary>
    public void InitaliseNewLedger()
    {
        try
        {
            MockDb.Database.InitaliseDatabaseForUse();
            LedgerItemList = new ZaBindingList<ZaLedgerItem>();
            ExpenseTypes = new ZaBindingList<ZaExpenseType>();
            SecondaryExpenseTypes = new ZaBindingList<ZaSecondaryExpenseType>();
            Accounts = new ZaBindingList<ZaAccount>();
            Budgets = new ZaBindingList<ZaBudget>();
            LedgerItemListSource = new BindingSource();

            SetupOrderOfExpenseViews();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

    }

    public void UpdateBindableListsWithDb()
    {
        try
        {
            LedgerItemList.AddRange(MockDb.Database.LedgerItems);
            ExpenseTypes.AddRange(MockDb.Database.ExpenseTypes);
            SecondaryExpenseTypes.AddRange(MockDb.Database.SecondaryExpenseTypes);
            Accounts.AddRange(MockDb.Database.Accounts);
            Budgets.AddRange(MockDb.Database.Budgets);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    /// <summary>
    /// Get the total for an account, filtered on the parameters given
    /// </summary>
    /// <param name="e"></param>
    /// <param name="account"></param>
    /// <param name="dateTo"></param>
    /// <param name="dateFrom"></param>
    /// <returns></returns>
    public Decimal GetTotalForAccount(ZaAccount.AccountReportingTypes e, ZaAccount account, DateTime? dateTo = null, DateTime? dateFrom = null)
    {
        Decimal returnValue = 0;
        try
        {
            switch (e)
            {
                case ZaAccount.AccountReportingTypes.Current:
                    returnValue = account.OriginalBalance + (from ZaLedgerItem n in MockDb.Database.LedgerItems
                                                             where n.Account == account
                                                             select n.PurchasePrice).Sum();
                    break;
                case ZaAccount.AccountReportingTypes.Original:
                    returnValue = account.OriginalBalance;
                    break;
                case ZaAccount.AccountReportingTypes.WithinRange:
                    returnValue = (from ZaLedgerItem n in MockDb.Database.LedgerItems
                                   where n.Account == account
                                   && (!dateTo.HasValue || n.PurchaseDate.CompareTo(dateTo) <= 0)
                                   && (!dateFrom.HasValue || n.PurchaseDate.CompareTo(dateFrom) >= 0)
                                   select n.PurchasePrice).Sum();

                    break;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return returnValue;
    }

    /// <summary>
    /// Get the total for an expense type, filtered by the parameters given
    /// </summary>
    /// <param name="expenseType"></param>
    /// <param name="dateTo"></param>
    /// <param name="dateFrom"></param>
    /// <param name="type"></param>
    /// <param name="secExpense"></param>
    /// <returns></returns>
    public Decimal GetTotalForExpenseType(ZaExpenseType expenseType = null, DateTime? dateTo = null, DateTime? dateFrom = null, ZaExpenseType.ExpenseTypes? type = null, ZaSecondaryExpenseType secExpense = null, IEnumerable<ZaLedgerItem> list = null)
    {
        Decimal returnValue = 0;
        try
        {
            // Take all if null is passed through._
            returnValue = (from ZaLedgerItem n in list ?? LedgerItemList
                           where (expenseType != null ? n.ExpenseType != null ?  n.ExpenseType.Equals(expenseType) : false : true)
                               // If a type is given and the item does not have an expense type, exclude it.
                           && (type.HasValue ? n.ExpenseType != null ? n.ExpenseType.Type == type : false : true)
                           && (dateTo.HasValue ? n.PurchaseDate.CompareTo(dateTo) <= 0 : true)
                           && (dateFrom.HasValue ? n.PurchaseDate.CompareTo(dateFrom) >= 0 : true)
                           && (secExpense != null ? n.SecondaryExpenseType == secExpense : true)
                           && (expenseType != null && expenseType.Type == ZaExpenseType.ExpenseTypes.Savings ? 
                             (n.Account != null && n.Account.Type == ZaAccount.AccountTypes.Savings ? true : false) : true)
                           select n.PurchasePrice).Sum();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return returnValue;
    }

    /// <summary>
    /// Get the total of all 'unallocated' expense types
    /// </summary>
    /// <param name="dateTo"></param>
    /// <param name="dateFrom"></param>
    /// <returns></returns>
    public Decimal GetUnallocatedTotal(DateTime? dateTo = null, DateTime? dateFrom = null)
    {
        Decimal returnValue = 0;
        try
        {
            // Take all if null is passed through.
            returnValue = (from ZaLedgerItem n in LedgerItemList
                           where n.ExpenseType == null
                           && (dateTo.HasValue ? n.PurchaseDate.CompareTo(dateTo) <= 0 : true)
                           && (dateFrom.HasValue ? n.PurchaseDate.CompareTo(dateFrom) >= 0 : true)
                           select n.PurchasePrice).Sum();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return returnValue;
    }

    /// <summary>
    /// Will get the relevent view from the list of views based upon the critera given. Will create a new one if one doesn't not exist 
    /// </summary>
    /// <param name="vType">View type parameter</param>
    /// <param name="reference">Reference</param>
    /// <param name="secReference">Secondary Reference</param>
    /// <param name="eType">Expense type</param>
    /// <returns></returns>
    public ZaVExpenseType GetView(ZaVExpenseType.ViewTypes vType, ZaExpenseType reference = null, ZaSecondaryExpenseType secReference = null, ZaExpenseType.ExpenseTypes? eType = null)
    {
        ZaVExpenseType returnValue = null;
        try
        {
            var query = (from ZaVExpenseType n in ExpenseViews
                         where (reference != null ? n.ExpenseType == reference : true) &&
                               (secReference != null ? n.SecondaryExpenseType == secReference : true) &&
                               n.ViewType ==  vType &&
                               (eType != null ? n.ExpenseType.Type == eType : true)
                         select n);

            // If we didn't find the view in the list, it must be new - initalise it
            if (!query.Any())
            {
                returnValue = new ZaVExpenseType();
                if (secReference != null)
                {
                    returnValue.SecondaryExpenseType = secReference;
                }
                else if (reference != null)
                {
                    returnValue.ExpenseType = reference;
                }
                returnValue.ViewType = vType;
                
                // Set up blank row defaults
                switch(vType)
                {
                    case ZaVExpenseType.ViewTypes.Total:
                        returnValue.BlankRowLocation = ZaVExpenseType.BlankRowLocations.AboveAndBelow;
                        break;
                    default:
                        returnValue.BlankRowLocation = ZaVExpenseType.BlankRowLocations.None;
                        break;
                }
                ExpenseViews.Add(returnValue);
            }
            else
            {
                // The view has already been created, use it
                returnValue = query.First();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return returnValue;
    }

    /// <summary>
    /// Function to set up the order in which expense views will be shown.
    /// </summary>
    public void SetupOrderOfExpenseViews()
    {
        try
        {
            OrderOfExpenseViews = new SortedDictionary<int, ZaVExpenseType.ViewTypes>();
            OrderOfExpenseViews.Add(1, ZaVExpenseType.ViewTypes.Normal);
            OrderOfExpenseViews.Add(2, ZaVExpenseType.ViewTypes.Unallocated);
            OrderOfExpenseViews.Add(3, ZaVExpenseType.ViewTypes.Total);
            OrderOfExpenseViews.Add(4, ZaVExpenseType.ViewTypes.Income);
            OrderOfExpenseViews.Add(5, ZaVExpenseType.ViewTypes.Savings);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
}
