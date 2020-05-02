using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Tools
{
    public partial class clsFrmFolder : Form
    {
        string lastDraggedOjectName;
        string hash;
        DateTime LastClick = DateTime.Now;

        public delegate void OpenRecViewer(string fileName);
        OpenRecViewer callback;
        public delegate void DisplayStatus(string fileName);
        DisplayStatus callbackStatus;
        bool listView_md = false;
        string strFileList;

        public clsFrmFolder()
        {
            InitializeComponent();
            PopulateFolderNames();
        }

        public void Init(int panelnum, OpenRecViewer voidRecViewer, DisplayStatus voidStatus)
        {
            callback = voidRecViewer;
            callbackStatus = voidStatus;
            Name = "Folder" + panelnum.ToString();
            listView.Name = "listView" + panelnum.ToString();

            string fname = ClsConfig.GetKey(Name, "");
            if (fname!="")
            {
                InsertUniquePath(fname);
                cmbbxFolder.Text = fname;
            }
            ListView_Populate();
            cmbbxFolder.SelectedIndexChanged += CmbbxFolder_SelectedIndexChanged;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!Directory.Exists(cmbbxFolder.Text)) return;

            timer1.Enabled = false;
            try
            {
                string newhash = GetHashString();
                if (hash != newhash)
                {
                    hash = newhash;
                    ListView_Populate();
                }
            }
            finally
            {
                timer1.Enabled = true;
            }
        }

        private void PopulateFolderNames()
        {
            string[] RTFileList = Directory.GetFiles(Directory.GetCurrentDirectory(), "??RT.ENV");
            if (RTFileList.Count() >= 1)
            {
                string[] lines = File.ReadAllLines(RTFileList[0]);
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        string fn = line.Split(':')[0];
                        if(fn !="")
                        {
                            PopulateUNCFile(fn);
                        }
                        break;
                    }
                }
            }
        }

        private void PopulateUNCFile(string fn)
        {
            if (!File.Exists(fn)) return;

            string[] dirList = File.ReadAllLines(fn);
            foreach (string dir in dirList)
                if (Directory.Exists(dir))
                    InsertUniquePath(dir);
        }

        private void PasteFile()
        {
            if (!Directory.Exists(cmbbxFolder.Text)) return;

            IDataObject data_object = Clipboard.GetDataObject();

            // Look for a file drop.
            if (data_object.GetDataPresent(DataFormats.FileDrop))
            {
                bool need_refresh = false;
                string[] files = (string[])data_object.GetData(DataFormats.FileDrop);
                foreach (string fn1 in files)
                {
                    string fname = Path.GetFileName(fn1);
                    string fn2 = ClsCommon.IncludeTrailingBackslash(cmbbxFolder.Text) + fname;

                    if (fn1 == fn2) continue;

                    if (File.Exists(fn1))
                        if (File.Exists(fn2))
                        {
                            if (MessageBox.Show(fname, "Do you want to overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                CopyFile(fn1, fn2);
                                need_refresh = true;
                            }
                        }
                        else
                        {
                            CopyFile(fn1, fn2);
                            need_refresh = true;
                        }
                }

                if (need_refresh)
                    ListView_Populate();
            }
        }

        /*private void TbFolder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ListView_Populate();
        }*/

        /* Menu */
        private void MnuContext_Opening(object sender, CancelEventArgs e)
        {
            if (listView.SelectedItems.Count == 0) return;

            string ext = Path.GetExtension(listView.SelectedItems[0].Text).ToUpper();
            if (ext == ".EXE")
            {
                mnuExecute.Visible = true;
                mnuRecordViewer.Visible = false;
                mnuNoteplus.Visible = false;
                mnuNotepad.Visible = false;
            }
            else if (ext == ".DLL")
            {
                mnuExecute.Visible = false;
                mnuRecordViewer.Visible = false;
                mnuNoteplus.Visible = false;
                mnuNotepad.Visible = false;
            }
            else
            {
                mnuExecute.Visible = false;
                mnuRecordViewer.Visible = true;
                mnuNoteplus.Visible = true;
                mnuNotepad.Visible = true;
            }
        }

        private void MnuExecute_Click(object sender, EventArgs e)
        {
            string fileName = listView.SelectedItems[0].Text;
            if (fileName == "") return;

            string curdir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(curdir);
            System.Diagnostics.Process.Start(fileName);
            Directory.SetCurrentDirectory(curdir);
        }

        private void MnuRecordViewer_Click(object sender, EventArgs e)
        {
            string fn = listView.SelectedItems[0].Tag.ToString();
            if (File.Exists(fn))
                callback(fn);
        }

        private void MnuNoteplus_Click(object sender, EventArgs e)
        {
            string fname = listView.SelectedItems[0].Tag.ToString();
            if (fname == "") return;

            string notepad = ClsCommon.GetNoteplus();
            if (notepad != "")
                Process.Start(notepad, "\"" + fname + "\"");
        }

        private void MnuNotepad_Click(object sender, EventArgs e)
        {
            string fname = listView.SelectedItems[0].Tag.ToString();
            if (fname == "") return;

            string fileName = GetFileFullName();
            System.Diagnostics.Process.Start("notepad", fname);
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            ListView_Delete();
        }

        private void MnuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void MnuExplore_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(cmbbxFolder.Text))
                System.Diagnostics.Process.Start(cmbbxFolder.Text);
        }

        private void ListView_Populate()
        {
            listView.Clear();
            ListView_CreateHeaders();
            ListView_Fill(@cmbbxFolder.Text);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ListView_CreateHeaders()
        {
            ColumnHeader colHead;

            colHead = new ColumnHeader();
            colHead.Text = "Filename";
            listView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Size";
            listView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Last accessed";
            listView.Columns.Add(colHead);
        }

        private void ListView_Fill(string root)
        {
            try
            {
                ListViewItem lvi;
                ListViewItem.ListViewSubItem lvsi;

                if (root.CompareTo("") == 0) return;

                DirectoryInfo dir = new DirectoryInfo(root);
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                listView.Items.Clear();
                listView.BeginUpdate();

                lvi = new ListViewItem();
                lvi.Text = "..";
                listView.Items.Add(lvi);
                foreach (DirectoryInfo di in dirs)
                {
                    lvi = new ListViewItem();
                    lvi.Text = di.Name;
                    lvi.Tag = di.FullName;

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = "Dir";
                    lvi.SubItems.Add(lvsi);

                    listView.Items.Add(lvi);
                }

                foreach (FileInfo fi in files)
                {
                    string ext = fi.Extension.ToLower();
                    if (!VerifyExtension(ext)) continue;

                    lvi = new ListViewItem();
                    lvi.Text = fi.Name;
                    lvi.Tag = fi.FullName;
                    if (ext == ".exe" || ext == ".dll")
                        lvi.ImageIndex = 1;
                    else
                        lvi.ImageIndex = 0;

                    lvsi = new ListViewItem.ListViewSubItem();
                    if (fi.Length < 1024)
                        lvsi.Text = (fi.Length).ToString() + " B";
                    else
                        lvsi.Text = (fi.Length / 1024).ToString() + " KB";
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = fi.LastAccessTime.ToString();
                    lvi.SubItems.Add(lvsi);
                    listView.Items.Add(lvi);
                }
                listView.EndUpdate();
            }
            catch (System.Exception err)
            {
                //MessageBox.Show("Error: " + err.Message);
            }
        }

        private void ListView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Add)
                listView.Font = new Font(listView.Font.FontFamily, listView.Font.Size + 1);
            else if (e.Control && e.KeyCode == Keys.Subtract)
                listView.Font = new Font(listView.Font.FontFamily, listView.Font.Size - 1);
            else if (e.Control && e.KeyCode == Keys.A)
                foreach (ListViewItem lv in listView.Items)
                    lv.Selected = true;

            if (e.KeyCode == Keys.Delete)
                ListView_Delete();

            if (e.Control && (e.KeyCode == Keys.Insert) || (e.KeyCode == Keys.C))
            {
                /*string path = ClsCommon.IncludeTrailingBackslash(cmbbxFolder.Text);
                StringCollection paths = new StringCollection();
                for (int i = 0; i < listView.SelectedItems.Count; i++)
                {
                    paths.Add(path + listView.SelectedItems[i].Text);
                }
                Clipboard.SetFileDropList(paths);*/
                CopyToClipboard();
            }

            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
                PasteFile();
        }

        private void ListView_Delete()
        {
            foreach (ListViewItem Item in listView.SelectedItems)
                FileSystem.DeleteFile(@Item.Tag.ToString(), UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            ListView_Populate();
        }

        private void ListView_MouseDown(object sender, MouseEventArgs e)
        {
            listView_md = true;
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (!listView_md) return;
            if (e.Button == MouseButtons.Right) return;

            string S = "";
            foreach (ListViewItem lv in listView.SelectedItems)
            {
                if (lv.SubItems[0].Text == ".." || lv.SubItems[1].Text == "Dir") continue;
                S += lv.Tag.ToString() + ",";
            }

            if (S == "") return;
            listView.DoDragDrop(S, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void ListView_MouseUp(object sender, MouseEventArgs e)
        {
            listView_md = false;
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ListView_DragDrop(object sender, DragEventArgs e)
        {
            if (cmbbxFolder.Text == "") return;

            bool need_refresh = false;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] items = (string[])e.Data.GetData(DataFormats.FileDrop);
                string path = ClsCommon.IncludeTrailingBackslash(cmbbxFolder.Text);
                for(int i=0; i < items.Count(); i++)
                {
                    if (items[i] == "") continue;

                    string fn1 = items[i];
                    string fn2 = path + Path.GetFileName(fn1);
                    if (fn1 != fn2)
                    {
                        File.Copy(fn1, fn2, true);
                        need_refresh = true;
                    }
                }
            }
            else
            {
                string fileList = e.Data.GetData(DataFormats.Text).ToString();
                string[] items = fileList.Split(',');
                string path = ClsCommon.IncludeTrailingBackslash(cmbbxFolder.Text);
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == "") continue;
                    string fn1 = items[i];
                    string fn2 = path + Path.GetFileName(items[i]);
                    if (fn1 != fn2)
                    {
                        File.Copy(fn1, fn2, true);
                        need_refresh = true;
                    }
                }
            }
            if (need_refresh)
                ListView_Populate();
            listView_md = false;
        }

        private string GetItemText(ListView LVIEW)
        {
            string fileNames = "";
            string path = ClsCommon.IncludeTrailingBackslash(cmbbxFolder.Text);
            for (int i = 0; i < LVIEW.SelectedItems.Count; i++)
                fileNames += path + LVIEW.SelectedItems[i].Text + ",";
            return fileNames;
        }

        private bool VerifyExtension(string ext)
        {
            ext = ext.ToUpper();
            string patterns = ClsConfig.GetKey("Patterns", "-1");

            if (patterns.Contains("-1")) return true;

            if (patterns.Contains("0")) //TPG files
                if (float.TryParse(ext, out float value))
                    return true;

            string extensions = ClsConfig.GetKey("TPGExtensions", "*.ACK;*.IRS;*.PST;*.TRN;*.FUL");

            if (patterns.Contains("1")) //Config files
                extensions += "*.EN*;*.CFG;*.XML;*.UNC";

            if (patterns.Contains("2")) //TXT file
                extensions += "*.TXT;*.BAT";

            if (patterns.Contains("3")) //EXE files
                extensions += "*.EXE;*.DLL";

            if (extensions.Contains(ext))
                return true;
            return false;
        }

        /* Drag and Drop */

        private void CopyFile(string fromFileName, string toFileName)
        {
            File.Copy(fromFileName, toFileName, true);
        }

        private void CopyToClipboard()
        {
            string path = ClsCommon.IncludeTrailingBackslash(cmbbxFolder.Text);
            StringCollection paths = new StringCollection();
            for (int i = 0; i < listView.SelectedItems.Count; i++)
            {
                paths.Add(path + listView.SelectedItems[i].Text);
            }
            Clipboard.SetFileDropList(paths);
        }

        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private string GetHashString()
        {
            if (cmbbxFolder.Text == "") return "";
            if (!Directory.Exists(cmbbxFolder.Text)) return "";

            string inputString = "";
            foreach (string fn in Directory.GetFiles(cmbbxFolder.Text))
                inputString += fn;

            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private void CmbbxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView_Populate();
        }

        private void CmbbxFolder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListView_Populate();
                if (Directory.Exists(cmbbxFolder.Text))
                    ClsConfig.SetKey(Name, cmbbxFolder.Text);
            }
        }

        private void CmbbxFolder_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TimeSpan Current = DateTime.Now - LastClick;
                TimeSpan DblClickSpan =
                TimeSpan.FromMilliseconds(Current.TotalMilliseconds);

                if (Current.TotalMilliseconds <= 500)
                {
                    if (Directory.Exists(cmbbxFolder.Text))
                        folderBrowserDialog.SelectedPath = cmbbxFolder.Text;

                    SendKeys.Send("{TAB}{TAB}{RIGHT}");
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        cmbbxFolder.Text = folderBrowserDialog.SelectedPath;
                }
                LastClick = DateTime.Now;
            }
        }

        private void InsertUniquePath(string path)
        {
            if (cmbbxFolder.Items.IndexOf(path) == -1)
                cmbbxFolder.Items.Add(path);
        }

        private string GetFileFullName()
        {
            string path = ClsCommon.IncludeTrailingBackslash(cmbbxFolder.Text);
            string S = "";
            for (int i=0;i< listView.SelectedItems.Count; i++)
            {
                S += path + listView.SelectedItems[i].Text + ",";
            }
            return S;
        }

        private void MnuPaste_Click(object sender, EventArgs e)
        {
            PasteFile();
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems[0].SubItems[0].Text == "..")
            {
                string path = @cmbbxFolder.Text;
                string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
                cmbbxFolder.Text = newPath;
            }
            else
            if (listView.SelectedItems[0].SubItems[1].Text == "Dir")
            {
                string path = ClsCommon.IncludeTrailingBackslash(@cmbbxFolder.Text) + listView.SelectedItems[0].SubItems[0].Text;
                cmbbxFolder.Text = path;
            }
        }
    }
}
