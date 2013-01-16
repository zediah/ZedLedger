using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Core;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinancialLedgerProject.Reference.ExpenseType
{
    public class ZaSecondaryExpenseType : PrimaryObject, IComparable
    {
        /// <summary>
        /// Table constant name
        /// </summary>
        public const string C_SecondaryExpenseType = "SecondaryExpenseType";

        /// <summary>
        /// Field constant for Name
        /// </summary>
        public const string F_Name = "Name";
        /// <summary>
        /// Name of the secondary expense type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Field constant for foreign key
        /// </summary>
        public const string F_DsExpenseType = "dsExpenseType";
        /// <summary>
        /// Foreign key to an expense type applicable to this secondary expense type
        /// </summary>
        public ZaExpenseType dsExpenseType { get; set; }

        public override XElement ToXElement()
        {
            XElement xe = base.ToXElement();
            xe.Add(new XElement(F_Name, Name),
                new XElement(F_DsExpenseType, dsExpenseType != null ? dsExpenseType.Dbseqnum.ToString() : ""));
            return xe;
        }

        public override bool Equals(object obj)
        {
            if (obj is ZaSecondaryExpenseType)
            {
                ZaSecondaryExpenseType a = (ZaSecondaryExpenseType)obj;
                return this.Dbseqnum == a.Dbseqnum && this.Name == a.Name && this.dsExpenseType == a.dsExpenseType;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Dbseqnum.GetHashCode() + Name.GetHashCode() + dsExpenseType.GetHashCode();
        }

        public static bool operator ==(ZaSecondaryExpenseType a, ZaSecondaryExpenseType b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Dbseqnum == b.Dbseqnum && a.Name == b.Name && a.dsExpenseType == b.dsExpenseType;
        }

        public static bool operator !=(ZaSecondaryExpenseType a, ZaSecondaryExpenseType b)
        {
            return !(a == b);
        }

        int IComparable.CompareTo(object obj)
        {
            int returnValue = 0;
            try
            {
                if (obj is ZaSecondaryExpenseType)
                {
                    returnValue = this.Name.CompareTo(((ZaSecondaryExpenseType)obj).Name);
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
                MessageBox.Show(ex.Message);
            }
            return returnValue;
        }

    }
}
