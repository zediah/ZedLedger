using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Reference.ExpenseType;
using FinancialLedgerProject.Reference.Budget;
using FinancialLedgerProject.Core;
using System.Windows.Forms;
using System.Drawing;

namespace FinancialLedgerProject.Views
{
    public class ZaVBudgetItem : ZaDisplayView
    {
        /// <summary>
        /// The name that will be displayed for the name column
        /// </summary>
        public override string DisplayName
        {
            get
            {
                if (Item != null)
                {
                    return Item.SecondaryExpense != null ? Item.SecondaryExpense.Name : Item.Expense.Name;
                }
                return "No Name";
            }
        }

        /// <summary>
        /// The item that will be displayed for this view
        /// </summary>
        public ZaBudgetItem Item { get; set; }

        public override DataGridViewRow GetRemainCells(DataGridViewRow row)
        {
            DataGridViewRow returnValue = row;
            try
            {
                DataGridViewCellStyle NameCellStyle = new DataGridViewCellStyle(row.DefaultCellStyle);
                DataGridViewCellStyle style = new DataGridViewCellStyle(row.DefaultCellStyle);

                // Determine Style
                switch (ViewType)
                {
                    case ViewTypes.Secondary:
                        style.BackColor = Color.AntiqueWhite;
                        NameCellStyle.BackColor = Color.AntiqueWhite;
                        NameCellStyle.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        break;
                    case ViewTypes.Blank:
                        row.DefaultCellStyle.BackColor = Color.SlateGray;
                        row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
                        break;
                    case ViewTypes.Total:
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
                    case ViewTypes.Blank:
                        // Do nothing
                        break;
                    default:
                        var textCell = new DataGridViewTextBoxCell();
                        textCell.Value = DisplayName;
                        textCell.Style = NameCellStyle;
                        returnValue.Cells.Add(textCell);
                        
                        textCell = new DataGridViewTextBoxCell();
                        textCell.Value = Item.FlatLimit;
                        textCell.Style = style;
                        returnValue.Cells.Add(textCell);

                        textCell = new DataGridViewTextBoxCell();
                        textCell.Value = Item.PercentLimit;
                        textCell.Style = style;
                        returnValue.Cells.Add(textCell);
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
