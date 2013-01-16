using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.Core;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinancialLedgerProject.Reference.Budget
{
    public class ZaBudget : PrimaryObject, IComparable
    {
        public const string F_BudgetItems = "BudgetItems";
        public List<ZaBudgetItem> BudgetItems { get; set; }

        public const string F_Name = "Name";
        public string Name { get; set; }

        public override XElement ToXElement()
        {
            XElement ex = base.ToXElement();
            ex.Add(new XElement(F_Name, Name),
                   new XElement(F_BudgetItems, BudgetItems.Select(x => x.ToXElement())));
            return ex;
        }

        /// <summary>
        /// Compare to allows to compare two budgets to work out which should come first
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            int returnValue = 0;
            try
            {
                if (obj is ZaBudget)
                {
                    returnValue = this.Name.CompareTo(((ZaBudget)obj).Name);
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
