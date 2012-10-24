namespace OpenfireLogReader {
	partial class LoadingForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.c_progressBar = new System.Windows.Forms.ProgressBar();
            this.c_CancelButton = new System.Windows.Forms.Button();
            this.c_filenameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // c_progressBar
            // 
            this.c_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_progressBar.Location = new System.Drawing.Point(13, 12);
            this.c_progressBar.Name = "c_progressBar";
            this.c_progressBar.Size = new System.Drawing.Size(367, 23);
            this.c_progressBar.TabIndex = 0;
            // 
            // c_CancelButton
            // 
            this.c_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.c_CancelButton.Location = new System.Drawing.Point(305, 42);
            this.c_CancelButton.Name = "c_CancelButton";
            this.c_CancelButton.Size = new System.Drawing.Size(75, 23);
            this.c_CancelButton.TabIndex = 1;
            this.c_CancelButton.Text = "&Cancel";
            this.c_CancelButton.UseVisualStyleBackColor = true;
            this.c_CancelButton.Click += new System.EventHandler(this.c_CancelButton_Click);
            // 
            // c_filenameLabel
            // 
            this.c_filenameLabel.AutoEllipsis = true;
            this.c_filenameLabel.AutoSize = true;
            this.c_filenameLabel.Location = new System.Drawing.Point(12, 47);
            this.c_filenameLabel.MaximumSize = new System.Drawing.Size(290, 13);
            this.c_filenameLabel.Name = "c_filenameLabel";
            this.c_filenameLabel.Size = new System.Drawing.Size(0, 13);
            this.c_filenameLabel.TabIndex = 2;
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c_CancelButton;
            this.ClientSize = new System.Drawing.Size(392, 73);
            this.Controls.Add(this.c_filenameLabel);
            this.Controls.Add(this.c_CancelButton);
            this.Controls.Add(this.c_progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading...";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar c_progressBar;
		private System.Windows.Forms.Button c_CancelButton;
		private System.Windows.Forms.Label c_filenameLabel;
	}
}