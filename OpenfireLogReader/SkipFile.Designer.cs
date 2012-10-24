namespace OpenfireLogReader
{
    partial class skipFileDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(skipFileDialog));
            this.noButton = new System.Windows.Forms.Button();
            this.yesButton = new System.Windows.Forms.Button();
            this.skipText = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.yesToAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // noButton
            // 
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.noButton.Location = new System.Drawing.Point(291, 73);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "&Cancel";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.Close);
            // 
            // yesButton
            // 
            this.yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yesButton.Location = new System.Drawing.Point(129, 73);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "&Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.Close);
            // 
            // skipText
            // 
            this.skipText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skipText.Location = new System.Drawing.Point(65, 12);
            this.skipText.Multiline = true;
            this.skipText.Name = "skipText";
            this.skipText.ReadOnly = true;
            this.skipText.Size = new System.Drawing.Size(417, 55);
            this.skipText.TabIndex = 1;
            this.skipText.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // yesToAllButton
            // 
            this.yesToAllButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.yesToAllButton.Location = new System.Drawing.Point(210, 73);
            this.yesToAllButton.Name = "yesToAllButton";
            this.yesToAllButton.Size = new System.Drawing.Size(75, 23);
            this.yesToAllButton.TabIndex = 1;
            this.yesToAllButton.Text = "Yes To &All";
            this.yesToAllButton.UseVisualStyleBackColor = true;
            this.yesToAllButton.Click += new System.EventHandler(this.Close);
            // 
            // skipFileDialog
            // 
            this.AcceptButton = this.yesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.noButton;
            this.ClientSize = new System.Drawing.Size(494, 108);
            this.ControlBox = false;
            this.Controls.Add(this.yesToAllButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.skipText);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.noButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "skipFileDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Open Error";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.TextBox skipText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button yesToAllButton;
    }
}