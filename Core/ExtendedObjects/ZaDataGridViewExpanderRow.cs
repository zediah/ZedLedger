using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialLedgerProject.Core.ExtendedObjects
{
    class ZaDataGridViewExpanderRow : DataGridViewRow
    {
        /// <summary>
        /// Whether the row is expanded or not
        /// </summary>
        public bool Expanded { get; set; }
    }
}
