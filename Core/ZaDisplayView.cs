using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Reference.ExpenseType;
using System.Windows.Forms;
using System.Drawing;

namespace FinancialLedgerProject.Core
{
    public class ZaDisplayView
    {
        /// <summary>
        /// The parent of this display view
        /// </summary>
        public ZaDisplayView Parent { get; set; }

        /// <summary>
        /// The name that will be displayed in a grid
        /// </summary>
        public virtual string DisplayName {get; set;}
        
        /// <summary>
        /// Sets whether the view should be displayed or not
        /// </summary>
        public bool Display = true;

        /// <summary>
        /// Whether this view has been expanded
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// The type of view this is
        /// </summary>
        public ViewTypes ViewType { get; set; }

        /// <summary>
        /// Where blank rows should be on this view
        /// </summary>
        public BlankRowLocations BlankRowLocation { get; set; }

        public bool DateRangeSelected { get; set; }

        /// <summary>
        /// List of types of views possible
        /// </summary>
        public enum ViewTypes
        {
            Normal = 1,
            Unallocated = 2,
            Total = 3,
            Blank = 4,
            Secondary = 5,
            Savings = 6,
            Income = 7
        }
        
        /// <summary>
        /// Locations blank rows could appear for views
        /// </summary>
        public enum BlankRowLocations
        {
            None = 0,
            Above = 1,
            Below = 2,
            AboveAndBelow = 3
        }

        /// <summary>
        /// Return the remaining cells required to be shown
        /// </summary>
        /// <returns></returns>
        public virtual DataGridViewRow GetRemainCells(DataGridViewRow row)
        {
            DataGridViewRow returnValue = row;
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }
    }
}
