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
    public partial class clsFrmRecord : Form
    {
        public ClsConfig Config { get; set; }
        
        public clsFrmRecord()
        {
            InitializeComponent();
        }

        private void DgvRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Key = dgvRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
            string Value = Config.GetRequirement(Key);
        }
    }
}
