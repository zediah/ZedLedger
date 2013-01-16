using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.Core;
using System.Xml.Linq;
using System.Windows.Forms;

namespace FinancialLedgerProject.ZaSystem
{
    public class ZaSystem : PrimaryObject
    {
        /// <summary>
        /// Constant name for the class
        /// </summary>
        public const string C_ZaSystem = "ZaSystem";

        public const string F_ColumnWidth = "ColumnWidth";
        public const string F_ColumnNameTupleOne = "ColumnTupleOne";
        public const string F_ColumnNameTupleTwo = "ColumnTupleTwo";
        public const string F_ColumnWidthValue = "ColumnWidthValue";
        /// <summary>
        /// Used for Column Width. Key: Grid Name + Grid Column Name Value: Width of Column
        /// </summary>
        public Dictionary<Tuple<string, string>, int> ColumnsWidth { get; set; }

        public const string F_StoredDateFrom = "StoredDateFrom";
        /// <summary>
        /// The Date From on the front page stored from previous session
        /// </summary>
        public DateTime StoredDateFrom { get; set; }
            
        public const string F_StoredDateTo = "StoredDateTo";
        /// <summary>
        /// The Date To on the front page stored from previous session
        /// </summary>
        public DateTime StoredDateTo { get; set; }

        public const string F_RememberGridDimensions = "RememberGridDimensions";
        /// <summary>
        /// Whether the grid dimensions should be remembered for this leldger
        /// </summary>
        public bool RememberGridDimensions { get; set; }

        public const string F_RememberSelectedDates = "RememberSelectedDates";
        /// <summary>
        /// Whether the selected dates should be remembered for this leldger
        /// </summary>
        public bool RememberSelectedDates { get; set; }


        public const string F_UseRedAsIncome = "UseRedAsIncome";
        /// <summary>
        /// Whether to use 'red' values as positive values
        /// </summary>
        public bool UseRedAsIncome { get; set; }

        public const string F_RememberMaximisedState = "RememberMaximisedState";
        /// <summary>
        /// Whether to save the maximised state or not
        /// </summary>
        public bool RememberMaximisedState { get; set; }

        public const string F_Maximised = "Maximised";
        /// <summary>
        /// Whether the window was maximised or not on exit
        /// </summary>
        public bool Maximised { get; set; }


        /// <summary>
        /// Method to create the xml element for this class
        /// </summary>
        /// <returns>XMl element that represents this class</returns>
        public override XElement ToXElement()
        {
            XElement ex =  base.ToXElement();
            ex.Add(new XElement(F_UseRedAsIncome, UseRedAsIncome),
                   new XElement(F_StoredDateTo, StoredDateTo),
                   new XElement(F_StoredDateFrom, StoredDateFrom),
                   new XElement(F_RememberSelectedDates, RememberSelectedDates),
                   new XElement(F_RememberGridDimensions, RememberGridDimensions),
                   new XElement(F_RememberMaximisedState, RememberMaximisedState),
                   new XElement(F_Maximised, Maximised),
                   ColumnsWidth.Select(x => new XElement(F_ColumnWidth, new XElement(F_ColumnNameTupleOne, x.Key.Item1),
                                                                            new XElement(F_ColumnNameTupleTwo, x.Key.Item2),
                                                                            new XElement(F_ColumnWidthValue, x.Value))).TakeWhile(x => RememberGridDimensions));
                return ex;
        }

        public ZaSystem()
        {
            // Only ever be 1, so make it one here.
            Dbseqnum = 1;
            // Assume people don't want to see red as income
            UseRedAsIncome = false;
            RememberMaximisedState = true;
            ColumnsWidth = new Dictionary<Tuple<string, string>, int>();
        }

        /// <summary>
        /// This method will return the width that has been saved on the system record
        /// </summary>
        /// <param name="dgv">The datagridview this column belongs to</param>
        /// <param name="column">The column in question</param>
        /// <returns></returns>
        public int GetColumnWidth(DataGridView dgv, DataGridViewColumn column)
        {
            int returnValue = 1;
            try
            {
                Tuple<string, string> key = new Tuple<string, string>(dgv.Name, column.Name);
                if (ColumnsWidth.ContainsKey(key))
                {
                    returnValue = ColumnsWidth[key];
                }
                else
                {
                    returnValue = column.Width;
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
