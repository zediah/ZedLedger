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
    public partial class LightBox : Form
    {

        private static readonly Lazy<LightBox> lightbox =
                                new Lazy<LightBox>(() => new LightBox());

        public static LightBox Lightbox { get { return lightbox.Value; } }

        public LightBox()
        {
            InitializeComponent();
        }
    }
}
