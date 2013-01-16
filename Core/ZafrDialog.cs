using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialLedgerProject.Core
{
    public partial class ZafrDialog : Form
    {
        public object returnValue { get; set; }

        public ZafrDialog()
        {
            InitializeComponent();
        }

        public virtual void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool filled = true;
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is TextBox || ctl is RichTextBox)
                    {
                        if (string.IsNullOrWhiteSpace(((TextBoxBase)ctl).Text))
                        {
                            filled = false;
                        }
                    }
                    // Add more controls as we go
                }
                if (filled)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields before clicking \"OK\".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public virtual void cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ZafrDialog_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c.TabIndex == 0)
                {
                    c.Focus();
                }
            }
        }
    }
}
