using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Tools
{
    public partial class FrmPattern : Form
    {
        public FrmPattern()
        {
            InitializeComponent();
        }

        private void CbxAll_CheckedChanged(object sender, EventArgs e)
        {
            chklbxPattern.Enabled = !cbxAll.Checked;
        }
    }
}
