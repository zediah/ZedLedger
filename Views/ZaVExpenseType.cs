using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.ExpenseType;
using System.ComponentModel;
using FinancialLedgerProject.Reference.ExpenseType;
using System.Windows.Forms;
using FinancialLedgerProject.Core;
using System.Drawing;

namespace FinancialLedgerProject.Views
{
    public class ZaVExpenseType : ZaDisplayView
    {
        public override string DisplayName
        {
            get 
            {
                return SecondaryExpenseType != null ? SecondaryExpenseType.Name : ExpenseType.Name;
            }
        }
        
        public const string F_ExpenseType = "ExpenseType";
        /// <summary>
        /// The expense type this view is for
        /// </summary>
        public ZaExpenseType ExpenseType { get; set; }

        public const string F_SecondaryExpenseType = "SecondaryExpenseType";
        /// <summary>
        /// The sub expense type that can appear on this view
        /// </summary>
        public ZaSecondaryExpenseType SecondaryExpenseType { get; set; }

        public const string F_Total = "Total";
        /// <summary>
        /// The total for the expense type for this view
        /// </summary>
        public Decimal Total { get; set; }

        public const string F_Percent = "Percent";
        /// <summary>
        /// The Percent of the Total for this expense type
        /// </summary>
        public Decimal Percent { get; set; }

        public const string F_TotalWithinPeriod = "TotalWithinPeriod";
        /// <summary>
        /// The total within the period given for this expense type
        /// </summary>
        public Decimal TotalWithinPeriod { get; set; }

        public const string F_PercentWithinPeriod = "PercentWithinPeriod";
        /// <summary>
        /// The percent of the expense type within the period
        /// </summary>
        public Decimal PercentWithinPeriod { get; set; }

        


        static public ViewTypes GetViewTypeFromExpenseType(ZaExpenseType.ExpenseTypes type)
        {
            ViewTypes returnValue = ViewTypes.Normal;
            try
            {
                switch(type)
                {
                    case ZaExpenseType.ExpenseTypes.Expense:
                        returnValue = ViewTypes.Normal;
                        break;
                    case ZaExpenseType.ExpenseTypes.Income:
                        returnValue = ViewTypes.Income;
                        break;
                    case ZaExpenseType.ExpenseTypes.Savings:
                        returnValue = ViewTypes.Savings;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }

        public override DataGridViewRow GetRemainCells(DataGridViewRow row)
        {
            var returnValue = row;
            try
            {
                DataGridViewCellStyle NameCellStyle = new DataGridViewCellStyle(row.DefaultCellStyle);
                DataGridViewCellStyle style = new DataGridViewCellStyle(row.DefaultCellStyle);

                // Determine Style
                switch (ViewType)
                {
                    case ZaVExpenseType.ViewTypes.Secondary:
                        style.BackColor = Color.AntiqueWhite;
                        NameCellStyle.BackColor = Color.AntiqueWhite;
                        NameCellStyle.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        break;
                    case ZaVExpenseType.ViewTypes.Blank:
                        row.DefaultCellStyle.BackColor = Color.SlateGray;
                        row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
                        break;
                    case ZaVExpenseType.ViewTypes.Total:
                        NameCellStyle.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        break;
                    default:
                        NameCellStyle.BackColor = Color.LightSkyBlue;
                        NameCellStyle.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        break;
                }
                // Create the rest of the cells
                switch (ViewType)
                {
                    case ZaVExpenseType.ViewTypes.Blank:
                        // Do nothing
                        break;
                    default:
                        var textCell = new DataGridViewTextBoxCell();
                        textCell.Value = DisplayName;
                        textCell.Style = NameCellStyle;
                        returnValue.Cells.Add(textCell);

                        textCell = new DataGridViewTextBoxCell();
                        textCell.Value = Total;
                        textCell.Style = style;
                        returnValue.Cells.Add(textCell);

                        textCell = new DataGridViewTextBoxCell();
                        textCell.Value = Percent;
                        textCell.Style = style;
                        returnValue.Cells.Add(textCell);

                        if (DateRangeSelected)
                        {
                            textCell = new DataGridViewTextBoxCell();
                            textCell.Value = TotalWithinPeriod;
                            textCell.Style = style;
                            returnValue.Cells.Add(textCell);

                            textCell = new DataGridViewTextBoxCell();
                            textCell.Value = PercentWithinPeriod;
                            textCell.Style = style;
                            returnValue.Cells.Add(textCell);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }
    }
}
