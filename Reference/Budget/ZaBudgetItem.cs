using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.Core;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Reference.ExpenseType;
using System.Xml.Linq;

namespace FinancialLedgerProject.Reference.Budget
{
    public class ZaBudgetItem : PrimaryObject
    {
        public const string F_Expense = "Expense";
        /// <summary>
        /// The expense this budget item is related to
        /// </summary>
        public ZaExpenseType Expense { get; set; }

        public const string F_SecondaryExpense = "SecondaryExpense";
        /// <summary>
        /// The secondary expense this budget item is related to
        /// </summary>
        public ZaSecondaryExpenseType SecondaryExpense { get; set; }


        public const string F_PercentLimit = "PercentLimit";
        /// <summary>
        /// The maximum percent limit this item should have for the expense
        /// </summary>
        public Decimal PercentLimit { get; set; }

        public const string F_FlatLimit = "FlatLimit";
        /// <summary>
        /// The flat dollar limit this item should have for the expense
        /// </summary>
        public Decimal FlatLimit { get; set; }

        public override XElement ToXElement()
        {
            XElement ex = base.ToXElement();
            ex.Add(new XElement(F_Expense, Expense.Dbseqnum),
                   new XElement(F_SecondaryExpense, SecondaryExpense.Dbseqnum),
                   new XElement(F_PercentLimit, PercentLimit),
                   new XElement(F_FlatLimit, FlatLimit));
            return ex;
        }
    }
}
