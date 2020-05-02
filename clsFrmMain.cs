using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QA_Tools
{
    public partial class FrmMain : Form
    {
        private ClsConfig oConfig = new ClsConfig();
        private int visibleCol = 1;
        List<clsFrmFolder> FrmFolderList = new List<clsFrmFolder>();
        private DataModule dataModule = new DataModule();

        public Color ControlDark { get; private set; }

        public FrmMain()
        {
            InitializeComponent();
            if (File.Exists("..\\config.xml"))
                Directory.SetCurrentDirectory("..");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            PopulateToolbar();
            GetSettings();
            PopulatePanels();
            //PopulateConnections();
            tabControl1.TabPages.Remove(tabSql);
            FrmMain_Resize(sender, e);
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            double colwidth = pnlMain.Width / visibleCol;
            int w = (int)Math.Round(colwidth);
            pnlCol1.Width = w;
            pnlCol2.Width = w;
            pnlCol3.Width = w;
            if (this.WindowState == FormWindowState.Minimized)
            {
                //Hide();
                //notifyIcon.Visible = true;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetAppSettings();
            SaveDefaultFolders();
        }

        private void SaveDefaultFolders()
        {
            for (int I = 1; I <= 12; I++)
            {
                Panel panel = (Panel)pnlMain.Controls.Find("pnl" + I.ToString(), true)[0];
                ComboBox cbx = (ComboBox)panel.Controls.Find("cmbbxFolder", true)[0];
                if (cbx.Text != "")
                    ClsConfig.SetKey("Folder" + I.ToString(), cbx.Text);
            }
        }
        private void PopulateToolbar()
        {
            ClsConfig.Log("PopulateToolbar >");
            string str3 = "";
            int count = 0;
            string[] apis = ClsConfig.GetApis();
            foreach (string api in apis)
            {
                count++;
                ToolStripButton btn = new ToolStripButton(api, null, null, "Api"+count.ToString());
                btn.Click += ApiButton_Click;
                toolBtnAPI.DropDownItems.Add(btn);
            }

            toolbtnQE.Enabled = File.Exists("QA_EDIT.EXE");

            string[] exeList = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.EXE");
            foreach(string exe in exeList)
            {
                string fn = Path.GetFileName(exe).ToUpper();
                if (fn.Contains(Application.ProductName.ToUpper()) || fn.Contains("QA-EDIT.EXE")) continue;

                str3 = fn;
                if (fn.Length >= 3)
                    str3 = fn.Substring(0, 3);
                ToolStripButton btn = new ToolStripButton(str3);
                btn.Click += ToolStripButton_Click;
                btn.ToolTipText = exe;
                btn.BackColor = ControlDark;
                btn.Checked = true;
                toolStrip.Items.Add(btn);
            }
            ClsConfig.Log("< PopulateToolbar");
        }

        private void ApiButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            System.Diagnostics.Process.Start(btn.Text);
        }

        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            System.Diagnostics.Process.Start((string)btn.ToolTipText);
        }

        private void PrepareVisiblePanels()
        {
            pnlCol1.Visible = false;
            pnlCol2.Visible = false;
            pnlCol3.Visible = false;
            pnlCol4.Visible = false;

            for (int col = 1; col <= visibleCol; col++)
            {
                Panel panel = (Panel)pnlMain.Controls.Find("pnlCol" + col.ToString(), true)[0];
                panel.Visible = true;
                panel.Width = Convert.ToInt32(ClsConfig.GetKey(panel.Name, panel.Width.ToString()));

                if (col == visibleCol)
                    panel.Dock = DockStyle.Fill;
                else
                    panel.Dock = DockStyle.Left;
                panel.BringToFront();
            }
        }

        private void PopulateConnections()
        {
            string[] connList = ClsConfig.GetConnections();
            foreach (string S in connList)
                cmbConnections.Items.Add(S);
            cmbConnections.SelectedIndex = 0;
            btnConnect.BackColor = Color.Red;
        }

        private void CbxAll_CheckStateChanged(object sender, EventArgs e)
        {
            chklbxPattern.Enabled = !cbxAll.Checked;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                pnlMain.Visible = false;
                SaveSettings();
                PopulatePanels();
                tabControl1.SelectedTab = tpFolderViewer;
                FrmMain_Resize(sender, e);
            }
            finally { pnlMain.Visible = true; }
        }

        private void ParseFileInfo(object sender)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
                tb.Text = @"C:\";
            string[] fileList = Directory.GetFiles(@tb.Text);
            string ColRow = tb.Name.Substring(8, 2);
            List<string> list = new List<string>();

            foreach (string S in fileList)
            {
                string fn = Path.GetFileNameWithoutExtension(@S);
                string ext = Path.GetExtension(S);
                if (IsFYFile(fn, ext))
                    list.Add(S);
            }

            DataGridView dgv = (DataGridView)pnlMain.Controls.Find("gridFiles" + ColRow, true)[0];
            /*if (dgv.CurrentCell != null)
            {
                tmptop = dgv.FirstDisplayedScrollingRowIndex;
                tmprow = dgv.CurrentCell.RowIndex;
            }*/

            dgv.Rows.Clear();

            foreach (string fullName in list)
            {
                string updateTime = File.GetLastWriteTime(fullName).ToString("yy.MM.dd HH:mm:ss");
                string fileName = Path.GetFileName(fullName);
                ParseGrid(ColRow, fileName, updateTime);
            }
            /*if (dgv.CurrentCell != null)
            {
                try
                {
                    //dgv.Rows[tmprow].Selected = true;
                    //dgv.FirstDisplayedScrollingRowIndex = tmptop;
                }
                catch
                {
                    dgv.Rows[dgv.Rows.Count - 1].Selected = true;
                }
            }*/
        }

        bool IsFYFile(string fileName, string ext)
        {
            string pattern = ClsConfig.GetKey("Patterns", "-1");
            string[] patternList = pattern.Split(',');

            fileName = fileName.ToUpper();
            ext = ext.Remove(0, 1);
            ext = ext.ToUpper();

            if (patternList[0] == "-1")
                return true;

            if (pattern.Contains("0") && IsTPGFile(ext))
                return true;

            if (pattern.Contains("1") && IsConfigFile(fileName, ext))
                return true;

            if (pattern.Contains("2") && ext == "TXT")
                return true;

            if (pattern.Contains("3") && ext == "EXE")
                return true;

            return false;
        }

        private bool IsTPGFile(string ext)
        {
            if (ext == "ACK") return true;
            if (int.TryParse(ext, out int n)) return true;
            return false;
        }

        private bool IsConfigFile(string fileName, string ext)
        {
            if ((fileName == "CONFIG" && ext == "XML") ||
                (fileName == "RAL" ||
                    (fileName.Length >= 2 && fileName.Substring(fileName.Length - 2, 2) == "RT") ||
                    (fileName.Length >= 4 && fileName.Substring(fileName.Length - 4, 4) == "TEST")) && ext.Substring(0, 2) == "EN" ||
                    ext == "UNC")
                return true;
            else
                return false;
        }

        private void ParseGrid(string ColRow, string fileName, string updateTime)
        {
            DataGridView dgv = (DataGridView)pnlMain.Controls.Find("gridFiles" + ColRow, true)[0];
            dgv.Rows.Add(fileName, updateTime);
        }

        private void SetAppSettings()
        {
            ClsConfig.SetKey("Height1", pnl1.Height.ToString());
            ClsConfig.SetKey("Height2", pnl2.Height.ToString());
            ClsConfig.SetKey("Height4", pnl4.Height.ToString());
            ClsConfig.SetKey("Height5", pnl5.Height.ToString());
            ClsConfig.SetKey("Height7", pnl7.Height.ToString());
            ClsConfig.SetKey("Height8", pnl8.Height.ToString());
            ClsConfig.SetKey("Height10", pnl10.Height.ToString());
            ClsConfig.SetKey("Height11", pnl11.Height.ToString());

        }

        private void SaveSettings()
        {
            string pattern = "";
            if (cbxAll.Checked)
                pattern = "-1";
            else
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (chklbxPattern.GetItemCheckState(i) == CheckState.Checked)
                        pattern += i.ToString() + ',';
                }
            }
            visibleCol = (int)udColumns.Value;
            ClsConfig.SetKey("VisibleCols", visibleCol.ToString());
            ClsConfig.SetKey("Patterns", pattern);
        }

        private void PopulatePanels()
        {
            try
            {
                pnlMain.Visible = false;
                ClsConfig.Log("PopulatePanels >");
                PrepareVisiblePanels();
                FreePanels();

                for (int I = 1; I <= 3 * visibleCol; I++)
                {
                    Panel panel = (Panel)pnlMain.Controls.Find("pnl" + I.ToString(), true)[0];
                    clsFrmFolder frmFolder = new clsFrmFolder();
                    frmFolder.Init(I, OpenRecViewer, DisplayStatus);
                    panel.Controls.Add(frmFolder.panelFolder);
                    FrmFolderList.Add(frmFolder);
                }
                ClsConfig.Log("< PopulatePanels");
            }
            finally { pnlMain.Visible = true; }
        }

        private void FreePanels()
        {
            foreach (clsFrmFolder frm in FrmFolderList)
                if (frm != null)
                    frm.Dispose();
            FrmFolderList.Clear();

            for (int I = 1; I <= 12; I++)
            {
                Panel panel = (Panel)pnlMain.Controls.Find("pnl" + I.ToString(), true)[0];
                panel.Controls.Clear();
            }
        }

        private void GetSettings()
        {
            ClsConfig.Log("GetSettings >");
            string pattern = ClsConfig.GetKey("Patterns", "-1"); //config.AppSettings.Settings["Patterns"].Value;
            visibleCol = Convert.ToInt32(ClsConfig.GetKey("VisibleCols", "1"));   //config.AppSettings.Settings["VisibleCols"].Value);
            udColumns.Value = visibleCol;

            //set File Pattern
            if (pattern.Contains("-1"))
            {
                cbxAll.Checked = true;
            }
            else
            {
                string[] arrPatterns = pattern.Split(',');
                foreach (string S in arrPatterns)
                {
                    if (S != "")
                        chklbxPattern.SetItemCheckState(Convert.ToInt32(S), CheckState.Checked);
                }
            }
            pnl1.Height = Convert.ToInt32(ClsConfig.GetKey("Height1", pnl1.Height.ToString()));
            pnl2.Height = Convert.ToInt32(ClsConfig.GetKey("Height2", pnl2.Height.ToString()));
            pnl4.Height = Convert.ToInt32(ClsConfig.GetKey("Height4", pnl4.Height.ToString()));
            pnl5.Height = Convert.ToInt32(ClsConfig.GetKey("Height5", pnl5.Height.ToString()));
            pnl7.Height = Convert.ToInt32(ClsConfig.GetKey("Height7", pnl7.Height.ToString()));
            pnl8.Height = Convert.ToInt32(ClsConfig.GetKey("Height8", pnl8.Height.ToString()));
            pnl10.Height = Convert.ToInt32(ClsConfig.GetKey("Height10", pnl10.Height.ToString()));
            pnl11.Height = Convert.ToInt32(ClsConfig.GetKey("Height11", pnl11.Height.ToString()));
            ClsConfig.Log("< GetSettings");

            //Read SQL history
            string sqlFileName = Path.ChangeExtension(Application.ExecutablePath, ".sql");
            if (File.Exists(sqlFileName))
                textHistory.Text = File.ReadAllText(sqlFileName);
        }

        private void OpenRecViewer(string fileName)
        {
            if (File.Exists("QA_Edit.exe"))
            {
                System.Diagnostics.Process.Start("QA_Edit.exe", fileName);
            }
        }

        private void DisplayStatus(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            toolFileDate.Text = "Date Modified: " + fileInfo.LastWriteTime.ToString();
            toolFileSize.Text = " File Size: " + fileInfo.Length.ToString() + 
                "("+ (fileInfo.Length/1024).ToString()+"K)";
            toolFileVersion.Text = " File Version: " + FileVersionInfo.GetVersionInfo(fileName).FileVersion;
        }

        private void SaveConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);

            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Properties.Settings.Default.Reload();
        }

        private void ToolbtnNoteplus_Click(object sender, EventArgs e)
        {
            string noteplus = ClsCommon.GetNoteplus();
            if (noteplus != "")
                Process.Start(noteplus);
        }

        private void ToolbtnNotepad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void ToolbtnExplorer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe");
        }

        private void ToolbtnSSMS_Click(object sender, EventArgs e)
        {
            string fn = "~temp.sql";
            File.Create(fn);
            System.Diagnostics.Process.Start("sqlwb.exe");
        }

        private void ToolbtnQE_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\\QA_Edit.exe");
        }

        private void BtnTokenize_Click(object sender, EventArgs e)
        {
            ClsTools tools = new ClsTools();
            textToken.Text = tools.Tokenize(textPlain.Text).Replace("[\"", "").Replace("\"]", "");
            tools.Dispose();
        }

        private void BtnDetokenize_Click(object sender, EventArgs e)
        {
            ClsTools tools = new ClsTools();
            textPlain.Text = tools.Detokenize(textToken.Text).Replace("[\"", "").Replace("\"]", "");
            tools.Dispose();
        }

        private void BtnCCGPost_Click(object sender, EventArgs e)
        {
            ClsTools tools = new ClsTools();
            textResult.Text = tools.CCGPost(textCCGYear.Text, updownCCGCore.Value.ToString(), 
                textCCGKey.Text, cmbCCGOperator.Text, textCCGTable.Text, textCCGKeyValue.Text);
            tools.Dispose();
        }

        private void TextSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter || e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                dataGridView.DataSource = null;
                string status = dataModule.Execute(textSQL.Text, dataGridView);
                statusStrip2.Items[0].Text = status;
                if (status.Contains("row(s)"))
                    InsertHistory(textSQL.Text);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (dataModule.ConnectDatabase(cmbConnections.Text))
            {
                btnConnect.BackColor = Color.Green;
                toolStripStatusLabel1.Text = cmbConnections.Text;
            }
            else
            {
                btnConnect.BackColor = Color.Red;
                toolStripStatusLabel1.Text = "Closed";
            }
        }

        private void CmbConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.PerformClick();
        }

        private void InsertHistory(string textSQL)
        {
            string content = textHistory.Text.Replace("\n\r", "").ToUpper();
            string subtext = textSQL.Replace("\n\r", "").ToUpper();
            if (!content.Contains(subtext))
            {
                if (textHistory.Text != "" && !textHistory.Text.EndsWith(";"))
                    textHistory.Text += ";";
                textHistory.AppendText("");
                textHistory.AppendText("");
                textHistory.AppendText(textSQL + ";");
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void ToolstripMenu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
