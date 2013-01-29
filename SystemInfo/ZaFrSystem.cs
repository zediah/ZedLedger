using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinancialLedgerProject.Core;

namespace FinancialLedgerProject.SystemInfo
{
    public partial class ZaFrSystem : ZafrDialog
    {
        public ZaSystem SystemReference { get; set; }

        public ZaFrSystem()
        {
            InitializeComponent();
        }

        private void ZaFrSystem_Load(object sender, EventArgs e)
        {
            checkboxRememberDates.DataBindings.Add("Checked", SystemReference, ZaSystem.F_RememberSelectedDates);
            checkBoxRemeberGrid.DataBindings.Add("Checked", SystemReference, ZaSystem.F_RememberGridDimensions);
            checkBoxRedAsPositive.DataBindings.Add("Checked", SystemReference, ZaSystem.F_UseRedAsIncome);
            checkBoxSaveMaxState.DataBindings.Add("Checked", SystemReference, ZaSystem.F_RememberMaximisedState);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

    }
}
