namespace QA_Tools
{
    partial class clsFrmFolder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clsFrmFolder));
            this.panelFolder = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.mnuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecordViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNoteplus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbbxFolder = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelFolder.SuspendLayout();
            this.mnuContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFolder
            // 
            this.panelFolder.Controls.Add(this.listView);
            this.panelFolder.Controls.Add(this.cmbbxFolder);
            this.panelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFolder.Location = new System.Drawing.Point(0, 0);
            this.panelFolder.Name = "panelFolder";
            this.panelFolder.Size = new System.Drawing.Size(304, 396);
            this.panelFolder.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.ContextMenuStrip = this.mnuContext;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 21);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(304, 375);
            this.listView.SmallImageList = this.imageList1;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
            this.listView.DoubleClick += new System.EventHandler(this.ListView_DoubleClick);
            this.listView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListView1_KeyUp);
            this.listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseDown);
            this.listView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseMove);
            this.listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseUp);
            // 
            // mnuContext
            // 
            this.mnuContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExecute,
            this.mnuRecordViewer,
            this.mnuNoteplus,
            this.mnuNotepad,
            this.toolStripSeparator1,
            this.mnuDelete,
            this.mnuCopy,
            this.mnuPaste,
            this.toolStripSeparator2,
            this.mnuExplore});
            this.mnuContext.Name = "mnuContext";
            this.mnuContext.Size = new System.Drawing.Size(195, 214);
            this.mnuContext.Text = "Execute";
            this.mnuContext.Opening += new System.ComponentModel.CancelEventHandler(this.MnuContext_Opening);
            // 
            // mnuExecute
            // 
            this.mnuExecute.Name = "mnuExecute";
            this.mnuExecute.Size = new System.Drawing.Size(194, 22);
            this.mnuExecute.Text = "Execute";
            this.mnuExecute.Click += new System.EventHandler(this.MnuExecute_Click);
            // 
            // mnuRecordViewer
            // 
            this.mnuRecordViewer.Name = "mnuRecordViewer";
            this.mnuRecordViewer.Size = new System.Drawing.Size(194, 22);
            this.mnuRecordViewer.Text = "Open with &QA_Edit";
            this.mnuRecordViewer.Click += new System.EventHandler(this.MnuRecordViewer_Click);
            // 
            // mnuNoteplus
            // 
            this.mnuNoteplus.Name = "mnuNoteplus";
            this.mnuNoteplus.Size = new System.Drawing.Size(194, 22);
            this.mnuNoteplus.Text = "Open with &Notepad++";
            this.mnuNoteplus.Click += new System.EventHandler(this.MnuNoteplus_Click);
            // 
            // mnuNotepad
            // 
            this.mnuNotepad.Name = "mnuNotepad";
            this.mnuNotepad.Size = new System.Drawing.Size(194, 22);
            this.mnuNotepad.Text = "Open with Note&pad";
            this.mnuNotepad.Click += new System.EventHandler(this.MnuNotepad_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(194, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.MnuDelete_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(194, 22);
            this.mnuCopy.Text = "Copy";
            this.mnuCopy.Click += new System.EventHandler(this.MnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(194, 22);
            this.mnuPaste.Text = "Paste";
            this.mnuPaste.Click += new System.EventHandler(this.MnuPaste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // mnuExplore
            // 
            this.mnuExplore.Name = "mnuExplore";
            this.mnuExplore.Size = new System.Drawing.Size(194, 22);
            this.mnuExplore.Text = "Explore here";
            this.mnuExplore.Click += new System.EventHandler(this.MnuExplore_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file.png");
            this.imageList1.Images.SetKeyName(1, "exe.png");
            // 
            // cmbbxFolder
            // 
            this.cmbbxFolder.BackColor = System.Drawing.SystemColors.Info;
            this.cmbbxFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbbxFolder.FormattingEnabled = true;
            this.cmbbxFolder.Location = new System.Drawing.Point(0, 0);
            this.cmbbxFolder.Name = "cmbbxFolder";
            this.cmbbxFolder.Size = new System.Drawing.Size(304, 21);
            this.cmbbxFolder.TabIndex = 0;
            this.cmbbxFolder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CmbbxFolder_KeyUp);
            this.cmbbxFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CmbbxFolder_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // clsFrmFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 396);
            this.Controls.Add(this.panelFolder);
            this.Name = "clsFrmFolder";
            this.Text = "clsFrmFolder";
            this.panelFolder.ResumeLayout(false);
            this.mnuContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ContextMenuStrip mnuContext;
        private System.Windows.Forms.ToolStripMenuItem mnuExecute;
        private System.Windows.Forms.ToolStripMenuItem mnuRecordViewer;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuNoteplus;
        private System.Windows.Forms.ToolStripMenuItem mnuNotepad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.Panel panelFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuExplore;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ComboBox cmbbxFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
    }
}