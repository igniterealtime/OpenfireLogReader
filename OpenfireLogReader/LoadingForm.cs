using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenfireLogReader {
	public partial class LoadingForm : Form {
		private int m_size;
		private BackgroundWorker m_worker;

		public LoadingForm(int progressSize, BackgroundWorker worker) {
			m_size = progressSize;
			m_worker = worker;
			InitializeComponent();

			c_progressBar.Maximum = m_size;
			c_progressBar.Step = 1;
		}

		private void c_CancelButton_Click(object sender, EventArgs e) {
			m_worker.CancelAsync();
		}

		public void workerProgressChanged(object sender, ProgressChangedEventArgs e) {
			c_progressBar.Increment(1);
			c_filenameLabel.Text = System.IO.Path.GetFileName((string)e.UserState);
		}

		public void workerRunCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Cancelled) {
				this.DialogResult = DialogResult.Cancel;
			} else {
				this.DialogResult = DialogResult.OK;
			}
			this.Close();
		}
	}
}
