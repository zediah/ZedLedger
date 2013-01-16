using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialLedgerProject.Core.ExtendedObjects
{
    public class ZaDataGridViewCalendarCell : DataGridViewTextBoxCell
    {
        public ZaDataGridViewCalendarCell()
            : base()
        {
            // Use the short date format.
            this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            ZaCalendarCellControl ctl =
                DataGridView.EditingControl as ZaCalendarCellControl;
            // Use the default row value when Value property is null.
            if (this.RowIndex > -1)
            {
                if (this.Value == null || (DateTime)this.Value == DateTime.MinValue)
                {
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                }
                else
                {
                    ctl.Value = (DateTime)this.Value;
                }
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses.
                return typeof(ZaCalendarCellControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return DateTime.Now;
            }
        }
    }
}
