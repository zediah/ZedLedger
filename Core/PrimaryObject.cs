using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FinancialLedgerProject.Core
{
    public class PrimaryObject
    {
        public const string F_Dbseqnum = "dbseqnum";

        private int? dbseqnum;

        /// <summary>
        /// Primary Key of the object
        /// </summary>
        public int Dbseqnum
        {
            get
            {
                return dbseqnum.GetValueOrDefault(-1);
            }
            set
            {
                dbseqnum = value;
            }
        }

        public virtual XElement ToXElement()
        {
            return new XElement(this.GetType().Name, new XElement(F_Dbseqnum, Dbseqnum));
        }

        /// <summary>
        /// Label - allows nodelabel to be used for databinding
        /// </summary>
        public string Label
        {
            get
            {
                return NodeLabel();
            }
        }

        /// <summary>
        /// Reference to self, used for databinding
        /// </summary>
        public PrimaryObject Self
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Set the primary key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public void SetDbseqnum<T>(IEnumerable<T> array)
        {
            var list = from PrimaryObject n in array
                         select n.Dbseqnum;
            if (list.Count() > 0)
            {
                // Only set the dbseqnum if it is not already set.
                if (Dbseqnum < 1)
                {
                    // Talk about an extended, complicated value.
                    // Take a range of 1 (lowest value) to the biggest number + 1 in the list. 
                    // Then, ignore everything already in the list
                    // Next, order it by ascending - that way the smallest number available will be first, then take the first
                    // This should be the next dbseqnum filling in the gaps!...maybe we shouldn't fill the gaps, sigh.
                    this.Dbseqnum = Enumerable.Range(1, list.Max() + 1).Except(list).OrderBy(num => num).First();
                }
            }
            else
            {
                this.Dbseqnum = 1;
            }
        }

        public override string ToString()
        {
            return NodeLabel();
        }

        public virtual string NodeLabel()
        {
            string returnValue = "";
            try
            {
                    returnValue = this.Dbseqnum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return returnValue;
        }

        static public bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}
