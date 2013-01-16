using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialLedgerProject.Core.ExtendedObjects
{
    public class ZaDataGridViewCalendarColumn : DataGridViewColumn
    {
        public ZaDataGridViewCalendarColumn()
            : base(new ZaDataGridViewCalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(ZaDataGridViewCalendarCell)))
                {
                    throw new InvalidCastException("Must be a Calendar Cell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
