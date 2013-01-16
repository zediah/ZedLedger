using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Core;

namespace FinancialLedgerProject.Reference.ExpenseType
{
    class ZaMetaExpenseType : PrimaryObject
    {
        /// <summary>
        /// List of controls contained in this meta expense type
        /// </summary>
        public List<ZaMetaExpenseTypeControl> ControlList { get; set; }

        /// <summary>
        /// Reference to the expense type this meta data is to
        /// </summary>
        public ZaExpenseType ExpenseReference { get; set; }
    }
}
