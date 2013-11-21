namespace OpenfireLogReader
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ofdLog = new System.Windows.Forms.OpenFileDialog();
            this.mstMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_messageDisplay = new System.Windows.Forms.TextBox();
            this.c_userList = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.c_messageList = new System.Windows.Forms.ListView();
            this.Timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.To = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_filterList = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.c_filterApplyButton = new System.Windows.Forms.Button();
            this.c_filterClearButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.c_importFilterCheck = new System.Windows.Forms.CheckBox();
            this.c_loadFilterName = new System.Windows.Forms.TextBox();
            this.loadFilterToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.c_removeDomainCheck = new System.Windows.Forms.CheckBox();
            this.removeDomainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.c_importOptionsGroup = new System.Windows.Forms.GroupBox();
            this.mstMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.c_importOptionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdLog
            // 
            this.ofdLog.Filter = "Log files|*.log|All Files|*.*";
            this.ofdLog.Multiselect = true;
            // 
            // mstMenu
            // 
            this.mstMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.aboutToolStripMenuItem});
            this.mstMenu.Location = new System.Drawing.Point(0, 0);
            this.mstMenu.Name = "mstMenu";
            this.mstMenu.Size = new System.Drawing.Size(792, 24);
            this.mstMenu.TabIndex = 6;
            this.mstMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogMenuItem,
            this.openLogFolderMenuItem,
            this.toolStripSeparator1,
            this.pageSetupToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // openLogMenuItem
            // 
            this.openLogMenuItem.Name = "openLogMenuItem";
            this.openLogMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openLogMenuItem.Text = "&Import Log...";
            this.openLogMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // openLogFolderMenuItem
            // 
            this.openLogFolderMenuItem.Name = "openLogFolderMenuItem";
            this.openLogFolderMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openLogFolderMenuItem.Text = "Import Log &Folder...";
            this.openLogFolderMenuItem.Click += new System.EventHandler(this.openLogFolderMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // pageSetupToolStripMenuItem
            // 
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.pageSetupToolStripMenuItem.Text = "Page Set&up...";
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.pageSetupToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview...";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // c_messageDisplay
            // 
            this.c_messageDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_messageDisplay.Location = new System.Drawing.Point(16, 352);
            this.c_messageDisplay.Multiline = true;
            this.c_messageDisplay.Name = "c_messageDisplay";
            this.c_messageDisplay.ReadOnly = true;
            this.c_messageDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c_messageDisplay.Size = new System.Drawing.Size(761, 162);
            this.c_messageDisplay.TabIndex = 5;
            // 
            // c_userList
            // 
            this.c_userList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_userList.FormattingEnabled = true;
            this.c_userList.IntegralHeight = false;
            this.c_userList.Location = new System.Drawing.Point(3, 3);
            this.c_userList.Name = "c_userList";
            this.c_userList.Size = new System.Drawing.Size(124, 235);
            this.c_userList.Sorted = true;
            this.c_userList.TabIndex = 0;
            this.c_userList.SelectedIndexChanged += new System.EventHandler(this.c_userList_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(13, 77);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.c_userList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.c_messageList);
            this.splitContainer1.Size = new System.Drawing.Size(767, 243);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 1;
            // 
            // c_messageList
            // 
            this.c_messageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_messageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Timestamp,
            this.From,
            this.To,
            this.Message});
            this.c_messageList.FullRowSelect = true;
            this.c_messageList.GridLines = true;
            this.c_messageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.c_messageList.HideSelection = false;
            this.c_messageList.Location = new System.Drawing.Point(4, 4);
            this.c_messageList.Name = "c_messageList";
            this.c_messageList.Size = new System.Drawing.Size(626, 234);
            this.c_messageList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.c_messageList.TabIndex = 0;
            this.c_messageList.UseCompatibleStateImageBehavior = false;
            this.c_messageList.View = System.Windows.Forms.View.Details;
            this.c_messageList.VirtualMode = true;
            this.c_messageList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.c_messageList_RetrieveVirtualItem);
            this.c_messageList.SelectedIndexChanged += new System.EventHandler(this.c_messageList_SelectedIndexChanged);
            this.c_messageList.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.c_messageList_VirtualSelectedIndexChanged);
            // 
            // Timestamp
            // 
            this.Timestamp.Text = "Timestamp";
            this.Timestamp.Width = 140;
            // 
            // From
            // 
            this.From.Text = "From";
            this.From.Width = 100;
            // 
            // To
            // 
            this.To.Text = "To";
            this.To.Width = 100;
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 360;
            // 
            // c_filterList
            // 
            this.c_filterList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_filterList.FormattingEnabled = true;
            this.c_filterList.Location = new System.Drawing.Point(48, 324);
            this.c_filterList.Name = "c_filterList";
            this.c_filterList.Size = new System.Drawing.Size(160, 21);
            this.c_filterList.TabIndex = 2;
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(13, 327);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "Openfire Reader Logs";
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // c_filterApplyButton
            // 
            this.c_filterApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_filterApplyButton.Location = new System.Drawing.Point(214, 323);
            this.c_filterApplyButton.Name = "c_filterApplyButton";
            this.c_filterApplyButton.Size = new System.Drawing.Size(75, 23);
            this.c_filterApplyButton.TabIndex = 3;
            this.c_filterApplyButton.Text = "Apply Filter";
            this.c_filterApplyButton.UseVisualStyleBackColor = true;
            this.c_filterApplyButton.Click += new System.EventHandler(this.c_filterButton_Click);
            // 
            // c_filterClearButton
            // 
            this.c_filterClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_filterClearButton.Location = new System.Drawing.Point(295, 323);
            this.c_filterClearButton.Name = "c_filterClearButton";
            this.c_filterClearButton.Size = new System.Drawing.Size(75, 23);
            this.c_filterClearButton.TabIndex = 4;
            this.c_filterClearButton.Text = "Clear Filter";
            this.c_filterClearButton.UseVisualStyleBackColor = true;
            this.c_filterClearButton.Click += new System.EventHandler(this.c_filterButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // c_importFilterCheck
            // 
            this.c_importFilterCheck.AutoSize = true;
            this.c_importFilterCheck.Location = new System.Drawing.Point(6, 19);
            this.c_importFilterCheck.Name = "c_importFilterCheck";
            this.c_importFilterCheck.Size = new System.Drawing.Size(80, 17);
            this.c_importFilterCheck.TabIndex = 0;
            this.c_importFilterCheck.Text = "Import Filter";
            this.c_importFilterCheck.UseVisualStyleBackColor = true;
            this.c_importFilterCheck.CheckedChanged += new System.EventHandler(this.c_loadFilterCheck_CheckedChanged);
            // 
            // c_loadFilterName
            // 
            this.c_loadFilterName.Enabled = false;
            this.c_loadFilterName.Location = new System.Drawing.Point(92, 17);
            this.c_loadFilterName.Name = "c_loadFilterName";
            this.c_loadFilterName.Size = new System.Drawing.Size(212, 20);
            this.c_loadFilterName.TabIndex = 1;
            // 
            // c_removeDomainCheck
            // 
            this.c_removeDomainCheck.AutoSize = true;
            this.c_removeDomainCheck.Checked = true;
            this.c_removeDomainCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_removeDomainCheck.Location = new System.Drawing.Point(310, 19);
            this.c_removeDomainCheck.Name = "c_removeDomainCheck";
            this.c_removeDomainCheck.Size = new System.Drawing.Size(136, 17);
            this.c_removeDomainCheck.TabIndex = 2;
            this.c_removeDomainCheck.Text = "Remove Domain Name";
            this.c_removeDomainCheck.UseVisualStyleBackColor = true;
            // 
            // c_importOptionsGroup
            // 
            this.c_importOptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_importOptionsGroup.Controls.Add(this.c_importFilterCheck);
            this.c_importOptionsGroup.Controls.Add(this.c_removeDomainCheck);
            this.c_importOptionsGroup.Controls.Add(this.c_loadFilterName);
            this.c_importOptionsGroup.Location = new System.Drawing.Point(13, 28);
            this.c_importOptionsGroup.Name = "c_importOptionsGroup";
            this.c_importOptionsGroup.Size = new System.Drawing.Size(767, 43);
            this.c_importOptionsGroup.TabIndex = 0;
            this.c_importOptionsGroup.TabStop = false;
            this.c_importOptionsGroup.Text = "Import Options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 526);
            this.Controls.Add(this.c_importOptionsGroup);
            this.Controls.Add(this.c_filterApplyButton);
            this.Controls.Add(this.c_filterClearButton);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.c_filterList);
            this.Controls.Add(this.c_messageDisplay);
            this.Controls.Add(this.mstMenu);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mstMenu;
            this.Name = "MainForm";
            this.Text = "Openfire Log Reader";
            this.mstMenu.ResumeLayout(false);
            this.mstMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.c_importOptionsGroup.ResumeLayout(false);
            this.c_importOptionsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdLog;
        private System.Windows.Forms.MenuStrip mstMenu;
		private System.Windows.Forms.TextBox c_messageDisplay;
		private System.Windows.Forms.ListBox c_userList;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView c_messageList;
		private System.Windows.Forms.ColumnHeader Timestamp;
		private System.Windows.Forms.ColumnHeader From;
		private System.Windows.Forms.ColumnHeader To;
		private System.Windows.Forms.ColumnHeader Message;
		private System.Windows.Forms.ComboBox c_filterList;
		private System.Windows.Forms.Label lblFilter;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openLogMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openLogFolderMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button c_filterApplyButton;
		private System.Windows.Forms.Button c_filterClearButton;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox c_importFilterCheck;
        private System.Windows.Forms.TextBox c_loadFilterName;
        private System.Windows.Forms.ToolTip loadFilterToolTip;
        private System.Windows.Forms.CheckBox c_removeDomainCheck;
        private System.Windows.Forms.ToolTip removeDomainToolTip;
        private System.Windows.Forms.GroupBox c_importOptionsGroup;
    }
}

