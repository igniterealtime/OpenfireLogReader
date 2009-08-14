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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ofdLog = new System.Windows.Forms.OpenFileDialog();
            this.mstMenu = new System.Windows.Forms.MenuStrip();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbBody = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lsbUsers = new System.Windows.Forms.ListBox();
            this.lsbMessages = new System.Windows.Forms.ListBox();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.btnPrintMessage = new System.Windows.Forms.Button();
            this.prntMessage = new System.Drawing.Printing.PrintDocument();
            this.prntPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.prntAllMessages = new System.Drawing.Printing.PrintDocument();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.mstMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdLog
            // 
            this.ofdLog.Filter = "Log files|*.log|All Files|*.*";
            // 
            // mstMenu
            // 
            this.mstMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogToolStripMenuItem});
            this.mstMenu.Location = new System.Drawing.Point(0, 0);
            this.mstMenu.Name = "mstMenu";
            this.mstMenu.Size = new System.Drawing.Size(806, 24);
            this.mstMenu.TabIndex = 6;
            this.mstMenu.Text = "menuStrip1";
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.openLogToolStripMenuItem.Text = "Open Log";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // txbBody
            // 
            this.txbBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBody.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBody.Location = new System.Drawing.Point(15, 478);
            this.txbBody.Multiline = true;
            this.txbBody.Name = "txbBody";
            this.txbBody.Size = new System.Drawing.Size(779, 159);
            this.txbBody.TabIndex = 7;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(12, 435);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 18);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To :";
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(12, 457);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(47, 18);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "From :";
            // 
            // lsbUsers
            // 
            this.lsbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbUsers.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbUsers.FormattingEnabled = true;
            this.lsbUsers.ItemHeight = 17;
            this.lsbUsers.Location = new System.Drawing.Point(12, 27);
            this.lsbUsers.Name = "lsbUsers";
            this.lsbUsers.Size = new System.Drawing.Size(104, 395);
            this.lsbUsers.TabIndex = 10;
            this.lsbUsers.SelectedIndexChanged += new System.EventHandler(this.lsbUsers_SelectedIndexChanged);
            // 
            // lsbMessages
            // 
            this.lsbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbMessages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lsbMessages.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbMessages.FormattingEnabled = true;
            this.lsbMessages.ItemHeight = 17;
            this.lsbMessages.Location = new System.Drawing.Point(122, 27);
            this.lsbMessages.Name = "lsbMessages";
            this.lsbMessages.Size = new System.Drawing.Size(672, 395);
            this.lsbMessages.TabIndex = 11;
            this.lsbMessages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lsbMessages_DrawItem);
            this.lsbMessages.SelectedIndexChanged += new System.EventHandler(this.lsbMessages_SelectedIndexChanged);
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimestamp.AutoSize = true;
            this.lblTimestamp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimestamp.Location = new System.Drawing.Point(287, 435);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(87, 18);
            this.lblTimestamp.TabIndex = 12;
            this.lblTimestamp.Text = "Timestamp : ";
            // 
            // btnPrintMessage
            // 
            this.btnPrintMessage.Enabled = false;
            this.btnPrintMessage.Location = new System.Drawing.Point(698, 455);
            this.btnPrintMessage.Name = "btnPrintMessage";
            this.btnPrintMessage.Size = new System.Drawing.Size(96, 23);
            this.btnPrintMessage.TabIndex = 13;
            this.btnPrintMessage.Text = "Print Message";
            this.btnPrintMessage.UseVisualStyleBackColor = true;
            this.btnPrintMessage.Click += new System.EventHandler(this.btnPrintMessage_Click);
            // 
            // prntMessage
            // 
            this.prntMessage.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prntMessage_PrintPage);
            this.prntMessage.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prntMessage_BeginPrint);
            // 
            // prntPreviewDialog
            // 
            this.prntPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prntPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prntPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.prntPreviewDialog.Document = this.prntMessage;
            this.prntPreviewDialog.Enabled = true;
            this.prntPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("prntPreviewDialog.Icon")));
            this.prntPreviewDialog.Name = "prntPreviewDialog";
            this.prntPreviewDialog.Visible = false;
            // 
            // prntAllMessages
            // 
            this.prntAllMessages.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prntAllMessages_PrintPage);
            this.prntAllMessages.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prntAllMessages_BeginPrint);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Enabled = false;
            this.btnPrintAll.Location = new System.Drawing.Point(698, 426);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(96, 23);
            this.btnPrintAll.TabIndex = 14;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 649);
            this.Controls.Add(this.btnPrintAll);
            this.Controls.Add(this.btnPrintMessage);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.lsbMessages);
            this.Controls.Add(this.lsbUsers);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txbBody);
            this.Controls.Add(this.mstMenu);
            this.MainMenuStrip = this.mstMenu;
            this.Name = "MainForm";
            this.Text = "Reader";
            this.mstMenu.ResumeLayout(false);
            this.mstMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdLog;
        private System.Windows.Forms.MenuStrip mstMenu;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.TextBox txbBody;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ListBox lsbUsers;
        private System.Windows.Forms.ListBox lsbMessages;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.Button btnPrintMessage;
        private System.Drawing.Printing.PrintDocument prntMessage;
        private System.Windows.Forms.PrintPreviewDialog prntPreviewDialog;
        private System.Drawing.Printing.PrintDocument prntAllMessages;
        private System.Windows.Forms.Button btnPrintAll;
    }
}

