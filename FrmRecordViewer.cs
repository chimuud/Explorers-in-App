using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Tools
{
    public partial class FrmRecordViewer : Form
    {
        string tpgFile;
        public FrmRecordViewer()
        {
            InitializeComponent();
        }
        public void Init(string fileName)
        {
            if (!File.Exists(@fileName)) return;

            int l = 512;
            string alltext = System.IO.File.ReadAllText(@fileName);
            alltext = alltext.Replace("\r\n", string.Empty);
            string[] lines = Enumerable.Range(0, alltext.Length / l)
                .Select(i => alltext.Substring(i * l, l)).ToArray();

            if (lines.Count() > 0)
                PopulateRecords(lines);
        }
        private void PopulateRecords(string[] lines)
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                //lines[i]
                //AddTab
            }
        }
    }
}
