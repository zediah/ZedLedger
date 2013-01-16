using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.Core;

namespace FinancialLedgerProject.Reference.ExpenseType
{
    class ZaMetaExpenseTypeControl : PrimaryObject
    {
        /// <summary>
        /// Enumeration of all the types of controls possible to display
        /// </summary>
        public enum ControlType
        {
            Text = 1,
            Date = 2,
            Money = 3,
            ComboBox = 4
        }

        /// <summary>
        /// The type of control this meta control is
        /// </summary>
        public ControlType type { get; set; }

        /// <summary>
        /// The position this meta control will appear in the row
        /// </summary>
        public int Position { get; set; }


        /// <summary>
        /// The value stored for this control
        /// </summary>
        public object Value { get; set; }
    }
}
