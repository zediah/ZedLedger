using System;
using FinancialLedgerProject.Core;
using System.Collections.Generic;
using System.Windows.Forms;
using FinancialLedgerProject.ExpenseType;
using FinancialLedgerProject.Accounts;
using FinancialLedgerProject.Reference.ExpenseType;
using System.Xml.Linq;

public class ZaLedgerItem : PrimaryObject
{
    /// <summary>
    /// Table name constant
    /// </summary>
    public const string C_ZaLedgerItem = "ZaLedgerItem";

    /// <summary>
    /// Field constant for purchase price
    /// </summary>
    public const string F_PurchasePrice = "PurchasePrice";

    /// <summary>
    /// Price this item was purchased for
    /// </summary>
    public Decimal PurchasePrice {get; set;}

    /// <summary>
    /// Field constant for description
    /// </summary>
    public const string F_Description = "Description";
    
    /// <summary>
    /// Description of the purchase
    /// </summary>
    public String Description {get; set;}

    /// <summary>
    /// Field constant for expense type
    /// </summary>
    public const string F_ExpenseType = "ExpenseType";

    /// <summary>
    /// Type of expense this purchase was
    /// </summary>
    public ZaExpenseType ExpenseType {get; set;}

    /// <summary>
    /// Field constant for secondary expense type
    /// </summary>
    public const string F_SecondaryExpenseType = "SecondaryExpenseType";

    /// <summary>
    /// The secondary expense type applicable to this purchase
    /// </summary>
    public ZaSecondaryExpenseType SecondaryExpenseType { get; set; }

    /// <summary>
    /// Field constant for purchase date
    /// </summary>
    public const string F_PurchaseDate = "PurchaseDate";

    /// <summary>
    /// When this was purchased
    /// </summary>
    public DateTime PurchaseDate { get; set; }

    /// <summary>
    /// Field constant for account
    /// </summary>
    public const string F_Account = "Account";

    /// <summary>
    /// Account this was debted/credited to
    /// </summary>
    public ZaAccount Account { get; set; }

    public override XElement ToXElement()
    {
        XElement xe = base.ToXElement();
        xe.Add(new XElement(F_PurchaseDate, PurchaseDate),
            new XElement(F_Description, Description),
            new XElement(F_ExpenseType, ExpenseType != null ? ExpenseType.Dbseqnum.ToString() : ""),
            new XElement(F_PurchasePrice, PurchasePrice),
            new XElement(F_SecondaryExpenseType, SecondaryExpenseType != null ? SecondaryExpenseType.Dbseqnum.ToString() : ""),
            new XElement(F_Account, Account != null ? Account.Dbseqnum.ToString() : ""));
        return xe;
    }

    /// <summary>
    /// The types of attributes that can be filtered on
    /// </summary>
    public enum ConfigurableAttributes
    {
        Accounts=1,
        ExpenseTypes=2,
        SecondaryExpenseType=3
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public ZaLedgerItem()
	{
        // Always default a new purchase date to today
        PurchaseDate = DateTime.Today;
	}

    public ZaLedgerItem(DateTime date, String desc, ZaExpenseType expT, ZaSecondaryExpenseType secExpT, ZaAccount acc, Decimal price = 0)
    {
        PurchaseDate = date;
        Description = desc;
        ExpenseType = expT;
        SecondaryExpenseType = secExpT;
        Account = acc;
        PurchasePrice = price;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public ZaLedgerItem(ZaLedgerItem toClone)
        : this(toClone.PurchaseDate, toClone.Description, toClone.ExpenseType, toClone.SecondaryExpenseType, toClone.Account, toClone.PurchasePrice)
    {

    }

    /// <summary>
    /// Method to override the 'to string'
    /// </summary>
    /// <returns></returns>
    public override string NodeLabel()
    {
        string returnValue = "";
        try
        {
             returnValue += "$" + PurchasePrice.ToString();
            if (ExpenseType != null)
            {
                returnValue += " - " + ExpenseType.Name;
            }
            if (PurchaseDate != null)
            {
                returnValue += " - " + PurchaseDate.ToShortDateString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return returnValue;
    }
}
