using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace OpenfireLogReader {
	public partial class MainForm : Form {
		// A list of all the messages by user
		private Dictionary<MyUser, List<MyMessage>> m_userMessages = new Dictionary<MyUser, List<MyMessage>>();

		// TODO: Check and see how much memory is used by keeping a list of messages instead of a count
		private Dictionary<MyUser, Dictionary<MyUser, int>> m_userInteractions = new Dictionary<MyUser, Dictionary<MyUser, int>>();

		// The currently selected user
		private MyUser m_selectedUser = null;
		private List<MyUser> m_userList = null;

		// What user we're filtering on
		private MyUser m_filterUser = null;
		private List<MyUser> m_filterList = null;
		private List<int> filterMap = null;

		// Last printed line for multi page print jobs
		private int m_lastPrintItem;
		private int m_pageNumber;
		private int m_printItemCount;

        // Whether to skip all bad files
        private bool m_skipAll = false;

		public MainForm() {
			InitializeComponent();
            loadFilterToolTip.SetToolTip(c_importFilterCheck, "Only import conversations involving the specified user");
            removeDomainToolTip.SetToolTip(c_removeDomainCheck, "Display and filter by the username only");
		}

		#region Events
		// Open one or more log files
		private void openLogToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult result = ofdLog.ShowDialog();

			if (result == DialogResult.Cancel)
				return;

			loadFiles(ofdLog.FileNames);
		}

		// Open a directory of log files
		private void openLogFolderMenu_Click(object sender, EventArgs e) {
			DialogResult result = folderBrowserDialog.ShowDialog();

			if (result == DialogResult.Cancel)
				return;

			string[] filenames = Directory.GetFiles(folderBrowserDialog.SelectedPath);
			loadFiles(filenames);
		}

		private void c_userList_SelectedIndexChanged(object sender, EventArgs e) {
			m_filterUser = null;

			if (c_userList.SelectedIndex >= 0) {
				m_selectedUser = (MyUser)c_userList.SelectedItem;
				updateMessageList();
				updateFilterList();
			} else {
				m_selectedUser = null;
				c_messageList.VirtualListSize = 0;
				c_filterList.DataSource = null;
			}
		}

		private void c_messageList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			MyMessage message = getVirtualItem(e.ItemIndex);

			if (message != null) {
				e.Item = new ListViewItem(new string[] { message.TimeStamp.ToString(), message.From.Name, message.To.Name, message.Text });
				if (message.From.Name == m_selectedUser.Name) {
					e.Item.ForeColor = System.Drawing.Color.Blue;
				}
				e.Item.Tag = message;
			}
		}

		private void c_messageList_SelectedIndexChanged(object sender, EventArgs e) {
			if (c_messageList.SelectedIndices.Count == 1) {
				String template = "Timestamp: {0}   From: {1}   To: {2}{3}{4}{3}{3}";
				int selectedIndex = c_messageList.SelectedIndices[0];
				
				MyMessage selected = getVirtualItem(selectedIndex);
				c_messageDisplay.Text = String.Format(template, selected.TimeStamp, selected.From,
											 selected.To, Environment.NewLine, selected.Text);
				
				printDialog.AllowSelection = true;
			} else {
				c_messageDisplay.Text = "";
				printDialog.AllowSelection = false;
			}				
		}

        private void c_messageList_VirtualSelectedIndexChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {
            if (c_messageList.SelectedIndices.Count == 0)
            {
                printDialog.AllowSelection = false;
            }
            else
            {
                printDialog.AllowSelection = true;
                c_messageDisplay.SuspendLayout();
                for (int i = 0; i < c_messageList.SelectedIndices.Count; i++)
                {
                    String template = "Timestamp: {0}   From: {1}   To: {2}{3}{4}{3}{3}";
                    int selectedIndex = c_messageList.SelectedIndices[i];

                    MyMessage selected = getVirtualItem(selectedIndex);
                    c_messageDisplay.Text += String.Format(template, selected.TimeStamp, selected.From,
                                             selected.To, Environment.NewLine, selected.Text);
                }
                c_messageDisplay.ResumeLayout();
            }
        }

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void c_filterButton_Click(object sender, EventArgs e) {
			if (sender.Equals(c_filterApplyButton) && (c_filterList.SelectedIndex >= 0)) {
				MyUser selectedUser = (MyUser)c_filterList.SelectedItem;
				if (m_filterUser == selectedUser)
					return;

				m_filterUser = selectedUser;
			} else {
				m_filterUser = null;
				c_filterList.SelectedIndex = -1;
			}
			updateMessageList();
            c_messageList.Focus();
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
			string[] filenames = (string[])e.Argument;
			BackgroundWorker worker = sender as BackgroundWorker;

			foreach (String filename in filenames) {
				if (worker.CancellationPending) {
					return;
				}

				if (File.Exists(filename)) {
					worker.ReportProgress(0, filename);
					parseLogFile(filename);
				}
			}

		}

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void c_loadFilterCheck_CheckedChanged(object sender, EventArgs e)
        {
            c_loadFilterName.Enabled = c_importFilterCheck.Checked;
        }
        #endregion

		#region Methods
		private void parseLogFile(string fileName) {
			string file = "";
			XmlDocument doc = new XmlDocument();
			try {
                Stream st = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                file = new StreamReader(st).ReadToEnd();

				// Logs that are still being written to don't have closing tags
				if (!file.EndsWith("</jive>")) {
					file += "</jive>";
				}
				doc.LoadXml(file);
			}
			catch { /* (Exception ex) */
                if (m_skipAll)
                    return;

                skipFileDialog skip = new skipFileDialog(fileName);
                DialogResult result = skip.ShowDialog();

                if (result == DialogResult.OK) {
                    m_skipAll = true;
				} else if (result == DialogResult.Cancel)  {
                    backgroundWorker.CancelAsync();
				}
                return;
			}

			DateTime date;
			String to, from, id;
			MyUser toUser;
			MyUser fromUser;
			MyMessage myMessage;
            MyUser filterUser = null;
            //String fromResource, toResource;

            if (c_importFilterCheck.Checked == true)
            {
                if (c_loadFilterName.Text.Trim() != "")
                {
                    filterUser = new MyUser(c_loadFilterName.Text.Trim());
                }
            }

            XmlNode parentNode = doc.ChildNodes[0];

			foreach (XmlNode packet in parentNode.ChildNodes) {
				if (packet.Attributes["timestamp"] == null)
					continue;


				if (!DateTime.TryParseExact(packet.Attributes["timestamp"].Value, "MMM dd, yyyy hh:mm:ss:fff tt", new CultureInfo("en-US", true), DateTimeStyles.AllowWhiteSpaces, out date))
				{
					DialogResult ErrorResult = MessageBox.Show(String.Format("Error parsing date ({0}).", packet.Attributes["timestamp"].Value), "Parse Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
					if (ErrorResult == System.Windows.Forms.DialogResult.Cancel)
					{
						backgroundWorker.CancelAsync();
						return;
					}
				} else {
					foreach (XmlNode message in packet.ChildNodes)
					{
						if (message.Attributes["from"] == null)
							continue;

						from = message.Attributes["from"].Value;
						if (from.IndexOf("@") == -1)
							continue;

						if (message.Attributes["to"] == null)
							continue;

						to = message.Attributes["to"].Value;
						if (to == null || to.IndexOf("@") == -1)
							continue;

						if (message.Attributes["id"] == null)
						{
							id = "";
						}
						else
						{
							id = message.Attributes["id"].Value.Trim();
						}

						if (c_removeDomainCheck.Checked)
						{
							/* Only get what's before the  '@' */
							to = to.Substring(0, to.IndexOf("@"));
							from = from.Substring(0, from.IndexOf("@"));
						}
						else
						{
							/* Remove any resource strings at the end of the name */
							if (from.IndexOf("/") > 0)
							{
								from = from.Substring(0, from.IndexOf("/"));
							}
							if (to.IndexOf("/") > 0)
							{
								to = to.Substring(0, to.IndexOf("/"));
							}
						}
						fromUser = new MyUser(from);
						toUser = new MyUser(to);

						if (filterUser != null && filterUser.CompareTo(toUser) != 0 && filterUser.CompareTo(fromUser) != 0)
						{
							continue;
						}

						foreach (XmlNode body in message.ChildNodes)
						{
							if (body.Name == "body")
							{
								myMessage = new MyMessage(date, toUser, fromUser, id, body.InnerText.Trim());
								// Make sure toUser and fromUser exist in the dictionaries
								if (!m_userMessages.ContainsKey(toUser))
								{
									m_userMessages.Add(toUser, new List<MyMessage>());
									m_userInteractions.Add(toUser, new Dictionary<MyUser, int>());
								}
								if (!m_userMessages.ContainsKey(fromUser))
								{
									m_userMessages.Add(fromUser, new List<MyMessage>());
									m_userInteractions.Add(fromUser, new Dictionary<MyUser, int>());
								}

								if (!m_userMessages[toUser].Contains(myMessage))
								{
									m_userMessages[toUser].Add(myMessage);
									if (!m_userInteractions[toUser].ContainsKey(fromUser))
									{
										m_userInteractions[toUser].Add(fromUser, 1);
									}
									else
									{
										m_userInteractions[toUser][fromUser]++;
									}
									if (toUser != fromUser)
									{
										if (!m_userMessages[fromUser].Contains(myMessage))
										{
											m_userMessages[fromUser].Add(myMessage);
										}
										if (!m_userInteractions[fromUser].ContainsKey(toUser))
										{
											m_userInteractions[fromUser].Add(toUser, 1);
										}
										else
										{
											m_userInteractions[fromUser][toUser]++;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void updateFilterList() {
			if (m_selectedUser == null)
				return;

			m_filterList = new List<MyUser>(m_userInteractions[m_selectedUser].Keys);
			m_filterList.Sort();
			c_filterList.DataSource = null;
			c_filterList.DisplayMember = "Name";
			c_filterList.DataSource = m_filterList;
			c_filterList.SelectedIndex = -1;
		}

		private void updateMessageList() {
			c_messageList.VirtualListSize = 0;
			if (m_selectedUser != null) {
				m_userMessages[m_selectedUser].Sort();
				if (m_filterUser == null) {
					filterMap = null;
					c_messageList.VirtualListSize = m_userMessages[m_selectedUser].Count;
				} else {
					filterMap = new List<int>();
					MyMessage[] messages = m_userMessages[m_selectedUser].ToArray();
					for (int i = 0; i < messages.Length; i++) {
						if (messages[i].To == m_filterUser || messages[i].From == m_filterUser) {
							filterMap.Add(i);
						}
					}
					c_messageList.VirtualListSize = m_userInteractions[m_selectedUser][m_filterUser];
				}
			}
            c_messageDisplay.Clear();
		}

		private void loadFiles(string[] filenames) {
			if (filenames.LongLength == 0)
				return;

			if (!backgroundWorker.IsBusy) {
				LoadingForm loadForm = new LoadingForm(filenames.Length, backgroundWorker);
				backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(loadForm.workerProgressChanged);
				backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(loadForm.workerRunCompleted);
				backgroundWorker.RunWorkerAsync((object)filenames);
				loadForm.ShowDialog();

				m_userList = new List<MyUser>(m_userMessages.Keys);
				m_userList.Sort();
				c_userList.DataSource = null;
				c_userList.DisplayMember = "Name";
				c_userList.DataSource = m_userList;

				updateMessageList();
				updateFilterList();
			}
		}

		private MyMessage getVirtualItem(int ItemIndex) {
			int realIndex;
			
			if (m_filterUser == null) {
				realIndex = ItemIndex;
			} else {
				realIndex = filterMap[ItemIndex];
			}
			return m_userMessages[m_selectedUser][realIndex];
		}
		#endregion

		#region Printing Support
		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
			// The current window we are drawing in
			RectangleF current = e.MarginBounds;

			// Measurements of strings
			SizeF measure = new SizeF();
			int mChars;
			int mLines;

			// The name of the currently selected user
			String user = ((MyUser)c_userList.SelectedItem).Name;

			// Font definitions
			System.Drawing.Font regfont = new System.Drawing.Font(FontFamily.GenericSerif, 10, FontStyle.Regular);
			System.Drawing.Font boldfont = new System.Drawing.Font(FontFamily.GenericSerif, 10, FontStyle.Bold);

			// How each string is displayed and placed
			StringFormat format = new StringFormat(StringFormat.GenericTypographic);

			// Increment the page number
			m_pageNumber++;

			// Center the selected user's name on each page
			format.Alignment = StringAlignment.Center;
			measure = e.Graphics.MeasureString(user + " - Page " + m_pageNumber, boldfont, current.Size, format, out mChars, out mLines);
			e.Graphics.DrawString(user + " - Page " + m_pageNumber, boldfont, Brushes.Black, current, format);
			current.Y += measure.Height;
			current.Height -= measure.Height;

			// The rest of the template on the page is left justified
			format.Alignment = StringAlignment.Near;

			String label = "";

			DateTime lastdate = new DateTime(1969, 12, 31, 0, 0, 0);
			DateTime currentdate = new DateTime();
			
			for (; m_lastPrintItem < m_printItemCount; m_lastPrintItem++) {
				RectangleF rectDate;
				RectangleF rectLabel;
				MyMessage message = null;
				String shortDate = null;

				if (e.PageSettings.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.Selection) {
					message = getVirtualItem(c_messageList.SelectedIndices[m_lastPrintItem]);
				} else {
					message = getVirtualItem(m_lastPrintItem);
				}
				currentdate = message.TimeStamp;
				rectDate = current;
				if (lastdate.Date < currentdate.Date) {
					shortDate = currentdate.ToShortDateString();
					measure = e.Graphics.MeasureString(System.Environment.NewLine + shortDate, boldfont, rectDate.Size, format, out mChars, out mLines);
					if (measure.IsEmpty || (mChars < shortDate.Length) || measure.Height > current.Height) {
						e.HasMorePages = true;
						return;
					}
					current.Y += measure.Height;
					current.Height -= measure.Height;
					lastdate = currentdate;
				}

				// The label is 'from -> to (time): '
				label = message.From.Name + " -> " + message.To.Name + " (" + currentdate.ToLongTimeString() + "):";
				rectLabel = current;
				measure = e.Graphics.MeasureString(label, boldfont, rectLabel.Size, format, out mChars, out mLines);
				if (measure.IsEmpty || mChars < label.Length || measure.Height > current.Height) {
					//page done
					e.HasMorePages = true;
					return;
				}

				current.X = (e.MarginBounds.Left * (float)1.05);
				current.Width = e.MarginBounds.Width - e.MarginBounds.X * (float)0.05;
				current.Y += measure.Height;
				current.Height -= measure.Height;


				measure = e.Graphics.MeasureString(message.Text, regfont, current.Size, format, out mChars, out mLines);
				if (measure.IsEmpty || mChars < message.Text.Length || measure.Height > current.Height) {
					//page done
					e.HasMorePages = true;
					return;
				}
				if (shortDate != null) {
					e.Graphics.DrawString(System.Environment.NewLine + shortDate, boldfont, Brushes.Black, rectDate, format);
				}
				e.Graphics.DrawString(label, boldfont, Brushes.Black, rectLabel, format);
				e.Graphics.DrawString(message.Text, regfont, Brushes.Black, current, format);
				current.X = e.MarginBounds.Left;
				current.Width = e.MarginBounds.Width;
				current.Y += measure.Height;
				current.Height -= measure.Height;
			}
		}

		private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e) {
			pageSetupDialog.Document = printDocument;

			pageSetupDialog.ShowDialog();
		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e) {
			printDialog.Document = printDocument;

			DialogResult result = printDialog.ShowDialog();

			if (result == DialogResult.OK) {
				printDocument.Print();
			}
		}

		private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result;
            if (printDialog.AllowSelection)
            {
                result = MessageBox.Show("Preview only selected items?", "Print Preview", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    printDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.Selection;
                }
                else
                {
                    printDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages;
                }
            }

			printPreviewDialog.Document = printDocument;
			result = printPreviewDialog.ShowDialog();
		}

		private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
			m_lastPrintItem = 0;
			m_pageNumber = 0;
			if (printDocument.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages) {
				m_printItemCount = c_messageList.VirtualListSize;
			} else if (printDocument.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.Selection) {
				m_printItemCount = c_messageList.SelectedIndices.Count;
			}		
		}
		#endregion
	}
}
