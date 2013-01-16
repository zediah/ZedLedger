using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialLedgerProject.Core;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinancialLedgerProject.Accounts
{
    public class ZaAccount : PrimaryObject, IComparable
    {
        /// <summary>
        /// Types of reporting available on accounts
        /// </summary>
        public enum AccountReportingTypes
        {
            Original = 1,
            Current = 2,
            WithinRange = 3
        }

        /// <summary>
        /// Types of accounts
        /// </summary>
        public enum AccountTypes
        {
            None=0,
            Standard=1,
            Savings=2,
            CreditCard=3,
            Mortage=4,
            Trade=5
        }

        /// <summary>
        /// Class name constant
        /// </summary>
        public const string C_ZaAccount = "ZaAccount";

        /// <summary>
        /// Field "Name" constant
        /// </summary>
        public const string F_Name = "Name";
        public String Name {get; set;}

        /// <summary>
        /// Original Balance field constant
        /// </summary>
        public const string F_OriginalBalance = "OriginalBalance";

        /// <summary>
        /// The original balance of the account
        /// </summary>
        public Decimal OriginalBalance {get; set;}

        /// <summary>
        /// Field string for 'type'
        /// </summary>
        public const string F_Type = "Type";

        /// <summary>
        /// The type of account this is
        /// </summary>
        public AccountTypes Type { get; set; }

        public override XElement ToXElement()
        {
            XElement xe = base.ToXElement();
            xe.Add(new XElement(F_Name, Name),
                    new XElement(F_OriginalBalance, OriginalBalance),
                    new XElement(F_Type, (int)Type));
            return xe;
        }

        /// <summary>
        /// Compare to allows to compare two accounts to work out which should come first
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            int returnValue = 0;
            try
            {
                if (obj is ZaAccount)
                {
                    returnValue = this.Name.CompareTo(((ZaAccount)obj).Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return returnValue;
        }

        /// <summary>
        /// What will be shown for the 'tostring' method
        /// </summary>
        /// <returns></returns>
        public override string NodeLabel()
        {
            string returnValue = "";
            try
            {
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    returnValue = Name;
                }

                if ((int)Type > 0)
                {
                    returnValue += (!string.IsNullOrWhiteSpace(returnValue) ? " - " : "") + Type.ToString(); 
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
