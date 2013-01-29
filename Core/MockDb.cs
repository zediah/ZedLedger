using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.Core.ExtendedObjects;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Reference;
using FinancialLedgerProject.Reference.Budget;
using FinancialLedgerProject.Reference.ExpenseType;
using FinancialLedgerProject.SystemInfo;

namespace FinancialLedgerProject.Core
{
    public sealed class MockDb
    {
        private static readonly Lazy<MockDb> database =
            new Lazy<MockDb>(() => new MockDb());

        public static MockDb Database { get { return database.Value; } }

        public List<ZaExpenseType> ExpenseTypes { get; set; }

        public List<ZaAccount> Accounts { get; set; }

        public List<ZaSecondaryExpenseType> SecondaryExpenseTypes { get; set; }

        public List<ZaLedgerItem> LedgerItems { get; set; }

        public List<ZaBudget> Budgets { get; set; }

        public List<ZaBudgetItem> BudgetItems { get; set; }

        public ZaSystem System { get; set; }

        private Dictionary<Type, IList> CachedTypes { get; set; }
             
        /// <summary>
        /// Use a private constructor so others can't create one
        /// </summary>
        private MockDb()
        {
            
        }

        public IList<T> GetRelatedTable<T>()  where T : PrimaryObject
        {
            try
            {
                return GetRelatedTable(typeof (T)).Cast<T>().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public IList GetRelatedTable(Type t)
        {
            try
            {
                if (CachedTypes.ContainsKey(t))
                {
                    return CachedTypes[t];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public void Add<T>(T newObj) where T: PrimaryObject
        {
            try
            {
                if (CachedTypes.ContainsKey(typeof(T)))
                {
                    newObj.SetDbseqnum<T>();
                    CachedTypes[typeof(T)].Add(newObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Remove(PrimaryObject removeObj)
        {
            try
            {
                if (CachedTypes.ContainsKey(removeObj.GetType()) && 
                    CachedTypes[removeObj.GetType()].Contains(removeObj))
                {
                    CachedTypes[removeObj.GetType()].Remove(removeObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LoadDatabaseFromFile(string filename)
        {
            try
            {
                XDocument document = XDocument.Load(filename);
                PopulateSystem(document);
                PopulateAccounts(document);
                PopulateExpenseTypes(document);
                PopulateItemList(document);
                PopulateBudgets(document);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void InitaliseDatabaseForUse()
        {
            try
            {
                Accounts = new List<ZaAccount>();
                ExpenseTypes = new List<ZaExpenseType>();
                SecondaryExpenseTypes = new List<ZaSecondaryExpenseType>();
                Budgets = new List<ZaBudget>();
                LedgerItems = new List<ZaLedgerItem>();
                System = new ZaSystem();

                CachedTypes = new Dictionary<Type, IList>();
                CachedTypes.Add(typeof(ZaAccount), Accounts);
                CachedTypes.Add(typeof(ZaExpenseType), ExpenseTypes);
                CachedTypes.Add(typeof(ZaSecondaryExpenseType), SecondaryExpenseTypes);
                CachedTypes.Add(typeof(ZaLedgerItem), LedgerItems);
                CachedTypes.Add(typeof(ZaBudget), Budgets);
                CachedTypes.Add(typeof(ZaBudgetItem), BudgetItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Populate the accounts list
        /// </summary>
        private void PopulateAccounts(XDocument xmlFile)
        {
            try
            {
                var allAccounts = from c in xmlFile.Descendants(ZaAccount.C_ZaAccount)
                                  select new ZaAccount
                                  {
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
        private void PopulateExpenseTypes(XDocument xmlFile)
        {
            try
            {
                var e = from c in xmlFile.Descendants(typeof(ZaExpenseType).Name)
                        select new ZaExpenseType
                        {
                            Dbseqnum = (int)c.Element(ZaExpenseType.F_Dbseqnum),
                            Type = (ZaExpenseType.ExpenseTypes)(int)c.Element(ZaExpenseType.F_Type),
                            Name = (string)c.Element(ZaExpenseType.F_Name)
                        };
                ExpenseTypes.AddRange(e);
                var se = from c in xmlFile.Descendants(typeof(ZaSecondaryExpenseType).Name)
                         select new ZaSecondaryExpenseType
                         {
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

        private void PopulateBudgets(XDocument xmlFile)
        {
            try
            {
                var b = from c in xmlFile.Descendants(typeof(ZaBudget).Name)
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
        private void PopulateItemList(XDocument xmlFile)
        {
            try
            {
                var b = from c in xmlFile.Descendants(typeof(ZaLedgerItem).Name)
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
                LedgerItems.AddRange(b);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Populate the System Record for this ledger
        /// </summary>
        private void PopulateSystem(XDocument xmlFile)
        {
            try
            {
                // Always initialise the system and columnwidth dictionary
                var b = from c in xmlFile.Descendants(typeof(ZaSystem).Name)
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
                        };
                System = b.SingleOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
