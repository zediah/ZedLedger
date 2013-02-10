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
                    DialogResult = DialogResult.OK;
                    LightBox.Lightbox.Hide();
                    Close();
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
                DialogResult = DialogResult.Cancel;
                LightBox.Lightbox.Hide();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ZafrDialog_Load(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                LightBox.Lightbox.SetBounds(Owner.Left + 8, Owner.Top + 30, Owner.ClientRectangle.Width,
                                   Owner.ClientRectangle.Height);
                LightBox.Lightbox.Owner = Owner;
                LightBox.Lightbox.Show();
                this.BringToFront();
            }
            foreach (Control c in Controls)
            {
                if (c.TabIndex == 0)
                {
                    c.Focus();
                }
            }
        }

        public virtual void InitaliseCustomDialogSettings(params object[] args)
        {
            // Empty, to be overridden
        }
    }
}
