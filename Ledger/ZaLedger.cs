using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.ExpenseType;
using System.IO;
using FinancialLedgerProject.Core.ExtendedObjects;
using FinancialLedgerProject.ZaSystem;
using FinancialLedgerProject.Reference.ExpenseType;
using System.Collections.ObjectModel;
using FinancialLedgerProject.Views;
using System.Xml.Linq;
using FinancialLedgerProject.Reference.Budget;

public class ZaLedger
{
    /// <summary>
    /// System Record for the ledger
    /// </summary>
    public ZaSystem System { get; set; }

    public BackgroundWorker Worker;

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

    ~ZaLedger()
    {
        if (System != null)
        {

        }
    }

    /// <summary>
    /// Save the Ledger to the filename given
    /// </summary>
    /// <param name="filename">The file this ledger will be saved as, defaults to ledger.xml if null</param>
    public void SaveLedger(string filename = null)
    {
        try
        {
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
            XDocument doc = new XDocument(new XElement(ZaLedger.C_ZaLedger, Accounts.Select(a => a.ToXElement())
                                                  .Concat(ExpenseTypes.Select(e => e.ToXElement()))
                                                  .Concat(SecondaryExpenseTypes.Select(se => se.ToXElement()))
                                                  .Concat(LedgerItemList.GetFullList().Select(i => i.ToXElement()))
                                                  .Concat(Budgets.Select(x => x.ToXElement()))
                                                  ,System.ToXElement()));
            doc.WriteTo(writer);
            writer.Close();
            
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    /// <summary>
    /// Populate the accounts list
    /// </summary>
    public void PopulateAccounts()
    {
        Accounts = new ZaBindingList<ZaAccount>();
        keyedAccounts = new Dictionary<int, ZaAccount>();
        try
        {
            XDocument document = XDocument.Load(LedgerFileName);
            var allAccounts = from c in document.Descendants(ZaAccount.C_ZaAccount)
                    select new ZaAccount
                    {

                        //Dbseqnum = int.Parse((string)c.Element(ZaAccount.C_ZaAccount + ZaAccount.F_Dbseqnum)),
                        //Type = (ZaAccount.AccountTypes)(int)c.Element(ZaAccount.C_ZaAccount + ZaAccount.F_Type),
                        //Name = (string)c.Element(ZaAccount.C_ZaAccount + ZaAccount.F_Name),
                        //OriginalBalance = (decimal)c.Element(ZaAccount.C_ZaAccount + ZaAccount.F_OriginalBalance)
                        Dbseqnum = int.Parse((string)c.Element(ZaAccount.F_Dbseqnum)),
                        Type = (ZaAccount.AccountTypes)(int)c.Element(ZaAccount.F_Type),
                        Name = (string)c.Element(ZaAccount.F_Name),
                        OriginalBalance = (decimal)c.Element(ZaAccount.F_OriginalBalance)
                    };
            Accounts.AddRange(allAccounts);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    /// <summary>
    /// Populate expense types list
    /// </summary>
    public void PopulateExpenseTypes()
    {
        try
        {
            ExpenseTypes = new ZaBindingList<ZaExpenseType>();
            SecondaryExpenseTypes = new ZaBindingList<ZaSecondaryExpenseType>();
            XDocument document = XDocument.Load(LedgerFileName);
            var e = from c in document.Descendants(typeof(ZaExpenseType).Name)
                    select new ZaExpenseType
                    {
                        //Dbseqnum = int.Parse((string)c.Element(ZaExpenseType.C_ExpenseType + ZaExpenseType.F_Dbseqnum)),
                        //Type = (ZaExpenseType.ExpenseTypes)(int)c.Element(ZaExpenseType.C_ExpenseType + ZaExpenseType.F_Type),
                        //Name = (string)c.Element(ZaExpenseType.C_ExpenseType + ZaExpenseType.F_Name)
                        Dbseqnum = (int)c.Element(ZaExpenseType.F_Dbseqnum),
                        Type = (ZaExpenseType.ExpenseTypes)(int)c.Element(ZaExpenseType.F_Type),
                        Name = (string)c.Element(ZaExpenseType.F_Name)
                    };
            ExpenseTypes.AddRange(e);
            var se = from c in document.Descendants(typeof(ZaSecondaryExpenseType).Name)
                     select new ZaSecondaryExpenseType
                     {
                         //Dbseqnum = (int)c.Element(ZaSecondaryExpenseType.C_SecondaryExpenseType + ZaSecondaryExpenseType.F_Dbseqnum),
                         //Name = (string)c.Element(ZaSecondaryExpenseType.C_SecondaryExpenseType + ZaSecondaryExpenseType.F_Name),
                         //dsExpenseType = ExpenseTypes.SingleOrDefault(x => x.Dbseqnum == (int)c.Element(ZaSecondaryExpenseType.C_SecondaryExpenseType + ZaSecondaryExpenseType.F_DsExpenseType))

                         Dbseqnum = (int)c.Element(ZaSecondaryExpenseType.F_Dbseqnum),
                         Name = (string)c.Element(ZaSecondaryExpenseType.F_Name),
                         dsExpenseType = ExpenseTypes.SingleOrDefault(x => x.Dbseqnum == (int)c.Element(ZaSecondaryExpenseType.F_DsExpenseType))
                     };
            SecondaryExpenseTypes.AddRange(se);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    public void PopulateBudgets()
    {
        Budgets = new ZaBindingList<ZaBudget>();
        try
        {
            XDocument loadDocument = XDocument.Load(LedgerFileName);
            var b = from c in loadDocument.Descendants(typeof(ZaBudget).Name)
                    select new ZaBudget
                    {
                        Dbseqnum = (int)c.Element(ZaBudget.F_Dbseqnum),
                        Name = (string)c.Element(ZaBudget.F_Name),
                        BudgetItems = c.Descendants(typeof(ZaBudgetItem).Name)
                                       .Select(x => new ZaBudgetItem
                                       {
                                           Dbseqnum = (int)x.Element(ZaBudgetItem.F_Dbseqnum),
                                           Expense = ExpenseTypes.FirstOrDefault(y => y.Dbseqnum == (int)x.Element(ZaBudgetItem.F_Expense)),
                                           SecondaryExpense = SecondaryExpenseTypes.FirstOrDefault(y => y.Dbseqnum == (int)x.Element(ZaBudgetItem.F_SecondaryExpense)),
                                           FlatLimit = (Decimal)x.Element(ZaBudgetItem.F_FlatLimit),
                                           PercentLimit = (Decimal)x.Element(ZaBudgetItem.F_PercentLimit)
                                       }).ToList()
                    };
            Budgets.AddRange(b);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    /// <summary>
    /// Populate ledger item list
    /// </summary>
    public void PopulateItemList()
    {
        try
        {
            XDocument loadDocument = XDocument.Load(LedgerFileName);
            var b = from c in loadDocument.Descendants(typeof(ZaLedgerItem).Name)
                    //let dbseqnum = (string)c.Element(ZaLedgerItem.C_ZaLedgerItem + ZaLedgerItem.F_Dbseqnum)
                    //let description = (string)c.Element(ZaLedgerItem.C_ZaLedgerItem + ZaLedgerItem.F_Description)
                    //let purchaseDate = (string)c.Element(ZaLedgerItem.C_ZaLedgerItem + ZaLedgerItem.F_PurchaseDate)
                    //let purchasePrice = (string)c.Element(ZaLedgerItem.C_ZaLedgerItem + ZaLedgerItem.F_PurchasePrice)
                    //let account = (string)c.Element(ZaLedgerItem.C_ZaLedgerItem + ZaLedgerItem.F_Account)
                    //let expenseType = (string)c.Element(ZaLedgerItem.C_ZaLedgerItem + ZaLedgerItem.F_ExpenseType)
                    //let secondaryExpenseType = (string)c.Element(ZaLedgerItem.C_ZaLedgerItem + ZaLedgerItem.F_SecondaryExpenseType)
                    let dbseqnum = (string)c.Element(ZaLedgerItem.F_Dbseqnum)
                    let description = (string)c.Element(ZaLedgerItem.F_Description)
                    let purchaseDate = (string)c.Element(ZaLedgerItem.F_PurchaseDate)
                    let purchasePrice = (string)c.Element(ZaLedgerItem.F_PurchasePrice)
                    let account = (string)c.Element(ZaLedgerItem.F_Account)
                    let expenseType = (string)c.Element(ZaLedgerItem.F_ExpenseType)
                    let secondaryExpenseType = (string)c.Element(ZaLedgerItem.F_SecondaryExpenseType)
                    select new ZaLedgerItem
                    {
                        Dbseqnum = int.Parse(dbseqnum),
                        Description = description,
                        PurchaseDate = DateTime.Parse(purchaseDate),
                        PurchasePrice = Decimal.Parse(purchasePrice),
                        Account = Accounts.SingleOrDefault(a => a.Dbseqnum.ToString() == account),
                        ExpenseType = ExpenseTypes.SingleOrDefault(a => a.Dbseqnum.ToString() == expenseType),
                        SecondaryExpenseType = SecondaryExpenseTypes.SingleOrDefault(x => x.Dbseqnum.ToString() == secondaryExpenseType)
                    };
            LedgerItemList.AddRange(b);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    /// <summary>
    /// Populate the System Record for this ledger
    /// </summary>
    public void PopulateSystem()
    {
        try
        {
            // Always initialise the system and columnwidth dictionary
            System = new ZaSystem();
            XDocument loadDocument = XDocument.Load(LedgerFileName);
            var b = from c in loadDocument.Descendants(typeof(ZaSystem).Name)
                    select new ZaSystem
                    {
                        Dbseqnum = (int)c.Element(ZaLedgerItem.F_Dbseqnum),
                        RememberGridDimensions = (bool)c.Element(ZaSystem.F_RememberGridDimensions),
                        RememberSelectedDates = (bool)c.Element(ZaSystem.F_RememberSelectedDates),
                        StoredDateFrom = (DateTime)c.Element(ZaSystem.F_StoredDateFrom),
                        StoredDateTo = (DateTime)c.Element(ZaSystem.F_StoredDateTo),
                        UseRedAsIncome = (bool)c.Element(ZaSystem.F_UseRedAsIncome),
                        Maximised = (bool)c.Element(ZaSystem.F_Maximised),
                        RememberMaximisedState = (bool)c.Element(ZaSystem.F_RememberMaximisedState),
                        ColumnsWidth = (from a in c.Descendants(ZaSystem.F_ColumnWidth)
                                        select new
                                        {
                                            key = new Tuple<string, string>((string)a.Element(ZaSystem.F_ColumnNameTupleOne),
                                                                 (string)a.Element(ZaSystem.F_ColumnNameTupleTwo)),
                                            value = (int)a.Element(ZaSystem.F_ColumnWidthValue)
                                        }).ToDictionary(p => p.key, p => p.value)
                        //Dbseqnum = (int)c.Element(ZaSystem.C_ZaSystem + ZaLedgerItem.F_Dbseqnum),
                        //RememberGridDimensions = (bool)c.Element(ZaSystem.C_ZaSystem + ZaSystem.F_RememberGridDimensions),
                        //RememberSelectedDates = (bool)c.Element(ZaSystem.C_ZaSystem + ZaSystem.F_RememberSelectedDates),
                        //StoredDateFrom = DateTime.Parse(c.Element(ZaSystem.C_ZaSystem + ZaSystem.F_StoredDateFrom).Value),
                        //StoredDateTo = DateTime.Parse(c.Element(ZaSystem.C_ZaSystem + ZaSystem.F_StoredDateTo).Value),
                        //UseRedAsIncome = (bool)c.Element(ZaSystem.C_ZaSystem + ZaSystem.F_UseRedAsIncome),
                        //ColumnsWidth = (from a in c.Descendants(ZaSystem.C_ZaSystem + ZaSystem.F_ColumnWidth)
                        //                select new
                        //                {
                        //                    key = new Tuple<string, string>((string)a.Element(ZaSystem.C_ZaSystem + ZaSystem.F_ColumnNameTupleOne),
                        //                                         (string)a.Element(ZaSystem.C_ZaSystem + ZaSystem.F_ColumnNameTupleTwo)),
                        //                    value = (int)a.Element(ZaSystem.C_ZaSystem + ZaSystem.F_ColumnWidthValue)
                        //                }).ToDictionary(p => p.key, p => p.value)

                    };
            System = b.SingleOrDefault();
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
            LedgerFileName = filename;
            LedgerItemList = new ZaBindingList<ZaLedgerItem>();
            LedgerItemListSource = new BindingSource();
            LedgerItemList.RaiseListChangedEvents = false;
            PopulateAccounts();
            PopulateExpenseTypes();
            SetupOrderOfExpenseViews();
            PopulateItemList();
            PopulateBudgets();
            PopulateSystem();
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
                    returnValue = account.OriginalBalance + (from ZaLedgerItem n in LedgerItemList.GetFullList()
                                                             where n.Account == account
                                                             select n.PurchasePrice).Sum();
                    break;
                case ZaAccount.AccountReportingTypes.Original:
                    returnValue = account.OriginalBalance;
                    break;
                case ZaAccount.AccountReportingTypes.WithinRange:
                    returnValue = (from ZaLedgerItem n in LedgerItemList.GetFullList()
                                   where n.Account == account
                                   && (dateTo.HasValue ? n.PurchaseDate.CompareTo(dateTo) <= 0 : true)
                                   && (dateFrom.HasValue ? n.PurchaseDate.CompareTo(dateFrom) >= 0 : true)
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
