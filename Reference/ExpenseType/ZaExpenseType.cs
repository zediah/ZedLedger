using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.Core;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinancialLedgerProject.ExpenseType
{
    public class ZaExpenseType : PrimaryObject, IComparable
    {
        public const string C_ExpenseType = "ZaExpenseType";

        /// <summary>
        /// Field constant for name of the expense tyep
        /// </summary>
        public const string F_Name = "Name";

        /// <summary>
        /// The name of the expense type
        /// </summary>
        public String Name {get; set;}


        /// <summary>
        /// Field constant for Type
        /// </summary>
        public const string F_Type = "Type";

        /// <summary>
        /// The type of expense for this expense type
        /// </summary>
        public ExpenseTypes Type { get; set; }

        /// <summary>
        /// Different types of expense possible
        /// </summary>
        public enum ExpenseTypes
        {
            None = 0,
            Expense = 1,
            Income = 2,
            Savings = 3
        }

        public override XElement ToXElement()
        {
            XElement xe = base.ToXElement();
            xe.Add(new XElement(F_Name, Name),
                    new XElement(F_Type, (int)Type));
            return xe;
        }

        public ZaExpenseType()
        {

        }

        public ZaExpenseType(string name)
        {
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is ZaExpenseType)
            {
                ZaExpenseType a = (ZaExpenseType)obj;
                return this.Dbseqnum == a.Dbseqnum && this.Name == a.Name && this.Type == a.Type;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Dbseqnum.GetHashCode() + Name.GetHashCode() + Type.GetHashCode();
        }

        public static bool operator ==(ZaExpenseType a, ZaExpenseType b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Dbseqnum == b.Dbseqnum && a.Name == b.Name && a.Type == b.Type;
        }

        public static bool operator !=(ZaExpenseType a, ZaExpenseType b)
        {
            return !(a == b);
        }

        int IComparable.CompareTo(object obj)
        {
            int returnValue = 0;
            try
            {
                if (obj is ZaExpenseType)
                {
                    returnValue = this.Name.CompareTo(((ZaExpenseType)obj).Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }

        public override string NodeLabel()
        {
            string returnValue = "";
            try
            {
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    returnValue = Name;
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
