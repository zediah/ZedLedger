using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Reference.ExpenseType;

namespace FinancialLedgerProject.Core
{
    public class DbConnection : DbContext
    {
        public DbSet<ZaLedgerItem> LedgerItems {get; set;}
        public DbSet<ZaAccount> Accounts { get; set; }
        public DbSet<ZaExpenseType> ExpenseTypes { get; set; }
        public DbSet<ZaSecondaryExpenseType> SecondaryExpenseTypes { get; set; }
    }
}
