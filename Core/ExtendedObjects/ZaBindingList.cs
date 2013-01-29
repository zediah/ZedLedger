using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Linq.Expressions;

namespace FinancialLedgerProject.Core.ExtendedObjects
{
    public class ZaBindingList<T> : BindingList<T>, IBindingListView where T: PrimaryObject
    {
        /// <summary>
        /// Whether the control is filtered or not
        /// </summary>
        private bool isFiltered { get; set; }

        /// <summary>
        /// The current filter
        /// </summary>
        private string FilterString;

        private List<T> modifiedList;
        /// <summary>
        /// The list that should be shown based upon the sorting/filtering
        /// </summary>
        List<T> ModifiedList
        {
            get { return modifiedList ?? (modifiedList = new List<T>()); }
            set
            {
                modifiedList = value;
            }
        }

        /// <summary>
        /// Whether the list is currently sorted or not
        /// </summary>
        bool isSortedValue;

        /// <summary>
        /// The way the current list is sorted, ascending/descending
        /// </summary>
        ListSortDescriptionCollection IBindingListView.SortDescriptions
        {
            get
            {
                return new ListSortDescriptionCollection();
            }
        }

        
        /// <summary>
        /// Yes this list support advanced sorting? No
        /// </summary>
        bool IBindingListView.SupportsAdvancedSorting
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Does the this list support filtering? Yes
        /// </summary>
        bool IBindingListView.SupportsFiltering
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// The current filter applied to this list
        /// </summary>
        string IBindingListView.Filter
        {
            get
            {
                return FilterString;
            }
            set
            {
                FilterString = value;
                UpdateFilter();
            }
        }

        /// <summary>
        /// This method will filter the list based upon the filter string 
        /// </summary>
        protected virtual void UpdateFilter()
        {
            RaiseListChangedEvents = false;
            if (string.IsNullOrWhiteSpace(FilterString))
            {
                ((IBindingListView)this).RemoveFilter();
            }
            else
            {
                var UnModifiedList = MockDb.Database.GetRelatedTable<T>();
                string propertyName, value, sign;
                char[] acceptableExpressionSigns = { '>', '<', '=' };
                List<string> filterExpressions = new List<string>();
                foreach (string s in FilterString.Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    filterExpressions.AddRange(s.Split(new string[] { "AND" }, StringSplitOptions.RemoveEmptyEntries));
                }

                foreach (string s in filterExpressions)
                {

                    int index = s.IndexOfAny(acceptableExpressionSigns);
                    if (index == -1)
                    {
                        propertyName = s.Split(new string[] { "LIKE" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                        value = s.Split(new string[] { "LIKE" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                        sign = "LIKE";
                    }
                    else
                    {
                        propertyName = s.Substring(0, index - 1).Trim();
                        value = s.Substring(index + 1, s.Length - (index + 1)).Trim().ToLower();
                        sign = s[index].ToString();
                    }

                    IEnumerable<T> tempList = Enumerable.Empty<T>();
                    ClearItems();
                    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(T)))
                    {
                        // Building up the query with union should be faster than .ToList()ing it each time
                        // THIS IS USED DUE TO LAZY EVALULATION OF LINQ QUERIES
                        PropertyDescriptor tempProp = prop;
                        switch (sign)
                        {
                            case "LIKE":
                                Decimal dValue;
                                if (Decimal.TryParse(value, out dValue) && prop.PropertyType.FullName == typeof(Decimal).FullName)
                                {
                                    tempList = tempList.Union(UnModifiedList.Where(n => ((decimal)tempProp.GetValue(n)) == dValue));
                                }
                                else
                                {
                                    tempList = tempList.Union(UnModifiedList.Where(n => tempProp.GetValue(n) != null ? (tempProp.GetValue(n).ToString().ToLower()).Contains(value.ToString().ToLower()) : false));
                                }
                                break;
                            case "<":
                                DateTime dateValue; 
                                if (decimal.TryParse(value, out dValue))
                                {
                                    tempList = UnModifiedList.Where(n => ((decimal)prop.GetValue(n)) > dValue);
                                }   
                                else if (DateTime.TryParse(value, out dateValue))
                                {
                                    tempList = UnModifiedList.Where(n => ((DateTime)prop.GetValue(n)) > dateValue);
                                }
                                break;
                            case ">":
                                if (decimal.TryParse(value, out dValue))
                                {
                                    tempList = UnModifiedList.Where(n => ((decimal)prop.GetValue(n)) < dValue);
                                }
                                else if (DateTime.TryParse(value, out dateValue))
                                {
                                    tempList = UnModifiedList.Where(n => ((DateTime)prop.GetValue(n)) < dateValue);
                                }
                                break;
                            case "=":
                                if (decimal.TryParse(value, out dValue))
                                {
                                    tempList = UnModifiedList.Where(n => ((decimal)prop.GetValue(n)) == dValue);
                                }
                                else if (DateTime.TryParse(value, out dateValue))
                                {
                                    tempList = UnModifiedList.Where(n => ((DateTime)prop.GetValue(n)) == dateValue);
                                }
                                else
                                {
                                    tempList = UnModifiedList.Where(n => ((string)prop.GetValue(n)).Equals(value));
                                }
                                break;
                        }
                    }
                    this.AddRange(tempList.Distinct());
                    isFiltered = true;
                }
                RaiseListChangedEvents = true;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        protected override bool SupportsSearchingCore
        {
            get
            {
                return false;
            }
        }

        protected override bool IsSortedCore
        {
            get
            {
                return isSortedValue;
            }
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        ListSortDirection sortDirectionCore;

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return sortDirectionCore;
            }
        }

        PropertyDescriptor sortPropertyCore;

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return sortPropertyCore;
            }
        }

        void IBindingListView.RemoveFilter()
        {
            try
            {
                RaiseListChangedEvents = false;
                isFiltered = false;
                ClearItems();
                AddRange(MockDb.Database.GetRelatedTable<T>());
                FilterString = "";
                RaiseListChangedEvents = true;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void IBindingListView.ApplySort(ListSortDescriptionCollection sorts)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            try
            {
                if (prop.PropertyType.GetInterface("IComparable") != null)
                {
                    RaiseListChangedEvents = false;
                    sortPropertyCore = prop;
                    sortDirectionCore = direction;
                    ModifiedList.Clear();
                    // Prepare the modified list and preserve old list
                    ModifiedList.AddRange(Items);
                    // Call Sort on the ArrayList.
                    if (direction == ListSortDirection.Ascending)
                    {
                        ModifiedList = ModifiedList.OrderBy(prop.GetValue).ToList();
                    }
                    else
                    {
                        ModifiedList = ModifiedList.OrderByDescending(prop.GetValue).ToList();
                    }

                    for (int i = 0; i < this.Count; i++)
                    {
                        this[i] = ModifiedList[i];
                    }
                    isSortedValue = true;
                    RaiseListChangedEvents = true;
                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                }
                else
                    // If the property type does not implement IComparable, let the user
                    // know.
                    throw new NotSupportedException("Cannot sort by " + prop.Name +
                        ". This" + prop.PropertyType.ToString() +
                    " does not implement IComparable");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void RemoveSortCore()
        {
            try
            {
                isSortedValue = false;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public override void EndNew(int itemIndex)
        {
            try
            {
                if (itemIndex == this.Count - 1)
                {
                    if (SortPropertyCore != null)
                    {
                        ApplySortCore(sortPropertyCore, sortDirectionCore);
                    }
                }
                base.EndNew(itemIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Adds a range of values to the binding list
        /// </summary>
        /// <param name="list"></param>
        public void AddRange(IEnumerable<T> list)
        {
            try
            {
                if (list != null)
                {
                    foreach (T t in list)
                    {
                        Add(t);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        new public void Add(T item)
        {
            try
            {
                // Set the dbseqnum if this object can have one
                if (typeof(T).IsSubclassOf(typeof(PrimaryObject)))
                {
                    item.SetDbseqnum<T>();
                }
                base.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            try
            {
                if (typeof(T).IsSubclassOf(typeof(PrimaryObject)))
                {
                    object o = Activator.CreateInstance(typeof(T));
                    e.NewObject = o;
                    MockDb.Database.Add(((T)o));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void RemoveItem(int index)
        {
            try
            {
                MockDb.Database.Remove(this[index]);
                base.RemoveItem(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
}
