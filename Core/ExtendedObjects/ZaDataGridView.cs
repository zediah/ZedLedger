using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace FinancialLedgerProject.Core.ExtendedObjects
{
    class ZaDataGridView : DataGridView
    {
        public bool UseRedAsIncome { get; set; }
        public event EventHandler VerticalScrollbarVisibleChanged;
        public event EventHandler HorizontalScrollbarVisibleChanged;

        public Action reloadMethod { get; set;}

        /// <summary>
        /// Whether this grid will use the standard style for the whole form
        /// </summary>-
        public bool UseStandardStyle { get; set; }

        public ZaDataGridView()
        {
            this.VerticalScrollBar.VisibleChanged += new EventHandler(VerticalScrollBar_VisibleChanged);
            this.HorizontalScrollBar.VisibleChanged += new EventHandler(HorizontalScrollBar_VisibleChanged);
            this.CellFormatting += new DataGridViewCellFormattingEventHandler(currencyCells_CellFormatting);
            this.UserAddedRow += new DataGridViewRowEventHandler(zaDataGridView_UserAddedRow);
        }

        public bool VerticalScrollbarVisible
        {
            get { return VerticalScrollBar.Visible; }
        }

        public bool HorizontalScrollbarVisible
        {
            get { return HorizontalScrollBar.Visible; }
        }

        private void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            EventHandler handler = VerticalScrollbarVisibleChanged;
            if (handler != null) 
                handler(this, e);
        }

        private void HorizontalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            EventHandler handler = HorizontalScrollbarVisibleChanged;
            if (handler != null) 
                handler(this, e);
        } 


        public ScrollBar GetScrollBar(ScrollBars barType)
        {
            ScrollBar returnValue = null;
            try
            {
                switch (barType)
                {
                    case System.Windows.Forms.ScrollBars.Horizontal:
                        returnValue = HorizontalScrollBar;
                        break;
                    case System.Windows.Forms.ScrollBars.Vertical:
                        returnValue = VerticalScrollBar;
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }

        public void AddEmptyRow()
        {
            try
            {
                this.Rows.Add(new DataGridViewRow());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void currencyCells_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.CellStyle.Format == "c" && e.Value != null)
                {
                    if ((((Decimal)e.Value < 0 && UseRedAsIncome) || ((Decimal)e.Value >= 0 && !UseRedAsIncome)))
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    e.Value = Math.Abs((Decimal)e.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void zaDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.DataBoundItem is PrimaryObject)
                {
                    PrimaryObject item = (PrimaryObject)e.Row.DataBoundItem;
                    if (item != null)
                    {
                        // Set the dbseqnum when a new row is added
                        if (DataSource is IEnumerable)
                        {
                            item.SetDbseqnum<PrimaryObject>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ZaDataGridView
            // 
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }


       
    }
}
