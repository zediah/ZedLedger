using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialLedgerProject
{
    public partial class ZaFinancialLedgerMDI : Form
    {
        //private int childFormNumber = 0;
        Dictionary<Form, ZaLedger> WorkingLedgers { get; set; }
        ZaLedger CurrentLedger { get; set; }
        Form CurrentForm { get; set; }

        public ZaFinancialLedgerMDI()
        {
            InitializeComponent();
            WorkingLedgers = new Dictionary<Form, ZaLedger>();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            ZafrFinancialLedger childForm = new ZafrFinancialLedger();
            WorkingLedgers.Add(childForm, new ZaLedger());
            childForm.btnNewButton_Click(sender, e);
            childForm.MdiParent = this;
            childForm.Text = childForm.Name;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            ZafrFinancialLedger childForm = new ZafrFinancialLedger(CurrentLedger);
            childForm.btnOpenItemList_Click(sender, e);
            childForm.MdiParent = this;
            childForm.Text = childForm.Name;
            childForm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void MDILogic()
        {
            saveAsToolStripMenuItem.Enabled = CurrentLedger != null && !string.IsNullOrWhiteSpace(CurrentLedger.LedgerFileName);
            saveAsToolStripMenuItem.Enabled = CurrentLedger != null;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

    }
}
