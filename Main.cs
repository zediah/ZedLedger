using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinancialLedgerProject;

namespace FinancialLedger
{
    static class FinancialLedgerHelper
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ZafrFinancialLedger());
        }
    }
}
