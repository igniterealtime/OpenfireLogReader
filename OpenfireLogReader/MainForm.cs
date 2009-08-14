using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace OpenfireLogReader
{
    public partial class MainForm : Form
    {
        private Dictionary<MyUser, List<MyMessage>> m_Table = new Dictionary<MyUser, List<MyMessage>>();

        public MainForm()
        {
            InitializeComponent();
        }
        #region Events
        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdLog.ShowDialog();

            if (result == DialogResult.Cancel)
                return;
            if (File.Exists(ofdLog.FileName))
            {
                Build(ofdLog.FileName);
            }
        }

        private void lsbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbUsers.SelectedIndex >= 0)
            {
                lsbMessages.Items.Clear();
                lsbMessages.Items.AddRange(m_Table[(MyUser)lsbUsers.SelectedItem].ToArray());
                btnPrintAll.Enabled = true;
            }
            else
            {
                lsbMessages.Items.Clear();
                btnPrintAll.Enabled = false;
            }
        }

        private void lsbMessages_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lsbUsers.SelectedIndex >= 0)
            {
                e.DrawBackground();
                Brush myBrush = Brushes.Black;
                MyMessage theMessage = (MyMessage)lsbMessages.Items[e.Index];
                if (theMessage.To.Name == ((MyUser)lsbUsers.SelectedItem).Name)
                    myBrush = Brushes.Blue;
                else
                    myBrush = Brushes.DarkGreen;

                e.Graphics.DrawString(theMessage.ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        private void lsbMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbMessages.SelectedIndex < 0)
            {
                btnPrintMessage.Enabled = false;
            }
            else
            {
                btnPrintMessage.Enabled = true;
                lblTo.Text = "To : " + ((MyMessage)lsbMessages.SelectedItem).To.Name;
                lblFrom.Text = "From : " + ((MyMessage)lsbMessages.SelectedItem).From.Name;
                lblTimestamp.Text = "Timestamp : " + ((MyMessage)lsbMessages.SelectedItem).TimeStamp.ToString("yyyy-MM-dd hh:mm:ss");
                txbBody.Text = ((MyMessage)lsbMessages.SelectedItem).Body;
            }
        }
        #endregion

        #region Methods
        private void Build(string fileName)
        {
            string file = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                file = new StreamReader(fileName).ReadToEnd();
                if (!file.EndsWith("</jive>"))
                {
                    file += "</jive>";
                }
                doc.LoadXml(file);
            }
            catch (Exception ex) { MessageBox.Show(" - " + ex.Message); }

            DateTime date;
            string to, from;
            MyUser toUser;
            MyUser fromUser;
            MyMessage myMessage;

            XmlNode parentNode = doc.ChildNodes[0];

            foreach (XmlNode packet in parentNode.ChildNodes)
            {
                if (packet.Attributes["timestamp"] == null)
                    continue;

                date = DateTime.ParseExact(packet.Attributes["timestamp"].Value, "MMM dd, yyyy hh:mm:ss:fff tt", CultureInfo.InvariantCulture);

                foreach (XmlNode message in packet.ChildNodes)
                {
                    from = message.Attributes["from"].Value;
                    if (from.IndexOf("@") == -1)
                        continue;

                    to = message.Attributes["to"].Value;
                    if (to.IndexOf("@") == -1)
                        continue;

                    toUser = new MyUser(to.Substring(0, to.IndexOf("@")));
                    fromUser = new MyUser(from.Substring(0, from.IndexOf("@")));

                    foreach (XmlNode body in message.ChildNodes)
                    {
                        if (body.Name == "body")
                        {
                            myMessage = new MyMessage(date, toUser, fromUser, body.InnerText);
                            if (m_Table.ContainsKey(toUser))
                            {
                                if (m_Table[toUser] == null)
                                    m_Table[toUser] = new List<MyMessage>();
                            }
                            else
                            {
                                m_Table.Add(toUser, new List<MyMessage>());
                            }
                            if (m_Table.ContainsKey(fromUser))
                            {
                                if (m_Table[fromUser] == null)
                                    m_Table[fromUser] = new List<MyMessage>();
                            }
                            else
                            {
                                m_Table.Add(fromUser, new List<MyMessage>());
                            }

                            if (!m_Table[toUser].Contains(myMessage))
                                m_Table[toUser].Add(myMessage);
                            if (!m_Table[fromUser].Contains(myMessage))
                                m_Table[fromUser].Add(myMessage);
                        }
                    }
                }
            }

            lsbUsers.Items.Clear();
            foreach (MyUser mu in m_Table.Keys)
            {
                lsbUsers.Items.Add(mu);
            }
        }
        #endregion

        #region Private Classes
        private struct MyUser
        {
            public string Name;

            public MyUser(string name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
            public override bool Equals(object obj)
            {
                return obj is MyUser && Equals((MyUser)obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(MyUser lhs, MyUser rhs)
            {
                return lhs.Equals(rhs);
            }
            public static bool operator !=(MyUser lhs, MyUser rhs)
            {
                return !lhs.Equals(rhs);
            }

            private bool Equals(MyUser other)
            {
                return Name == other.Name;
            }
        }

        private class MyMessage : IComparable
        {
            public DateTime TimeStamp;
            public MyUser To;
            public MyUser From;
            public string Body;

            public MyMessage(string time, MyUser to, MyUser from, string body)
            {
                TimeStamp = DateTime.ParseExact(time, "MMM dd, yyyy hh:mm:ss:fff tt", new CultureInfo("en-US", true));
                To = to;
                From = from;
                Body = body;
            }

            public MyMessage(DateTime timestamp, MyUser to, MyUser from, string body)
            {
                TimeStamp = timestamp;
                To = to;
                From = from;
                Body = body;
            }

            public override bool Equals(object obj)
            {
                return obj is MyMessage && TimeStamp.Equals(((MyMessage)obj).TimeStamp);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public int CompareTo(object obj)
            {
                if (obj is MyMessage)
                {
                    MyMessage other = (MyMessage)obj;
                    return TimeStamp.CompareTo(other.TimeStamp);
                }
                else
                {
                    throw new ArgumentException("Object is not a MyMessage");
                }
            }

            public override string ToString()
            {
                return String.Format("{0} : from {1,-10} :  to {2,-10} : {3}", TimeStamp.ToString("yyyy-MM-dd hh:mm:ss"), From, To, Body);
            }
        }
        #endregion

        #region Printing
        int currentPage = 0;
        int currentRow = 0;

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            prntPreviewDialog.Document = prntAllMessages;
            prntPreviewDialog.ShowDialog();
        }

        private void btnPrintMessage_Click(object sender, EventArgs e)
        {
            prntPreviewDialog.Document = prntMessage;
            prntPreviewDialog.ShowDialog();
        }

        private void prntMessage_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            currentPage = currentRow = 0;
        }

        private void prntMessage_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Inch;

            Single leftMargin = (Single).5;
            Single rightMargin = (Single)8;
            Single topMargin = (Single).5;
            Single bottomMargin = (Single)10;
            Single width = (Single)8;
            Single height = (Single)10;
            StringFormat sf = StringFormat.GenericTypographic;
            Font messageFont = new Font("Calibri", 16, System.Drawing.GraphicsUnit.Point);

            if (lsbMessages.SelectedIndex >= 0)
            {
                currentPage++;

                sf.Alignment = StringAlignment.Far;
                g.DrawString("To        :", messageFont, Brushes.Black, leftMargin, topMargin);
                g.DrawString(((MyMessage)lsbMessages.SelectedItem).To.Name, messageFont, Brushes.Black, rightMargin, topMargin, sf);
                g.DrawString("From      :", messageFont, Brushes.Black, leftMargin, (float)(topMargin + .25));
                g.DrawString(((MyMessage)lsbMessages.SelectedItem).From.Name, messageFont, Brushes.Black, rightMargin, (float)(topMargin + .25), sf);
                g.DrawString("Timestamp :", messageFont, Brushes.Black, leftMargin, (float)(topMargin + .5));
                g.DrawString(((MyMessage)lsbMessages.SelectedItem).TimeStamp.ToString("yyyy-MM-dd hh:mm:ss tt"), messageFont, Brushes.Black, rightMargin, (float)(topMargin + .5), sf);
                sf = new StringFormat(StringFormatFlags.NoClip);
                g.DrawString(txbBody.Text, messageFont, Brushes.Black, new RectangleF(leftMargin, (float)(topMargin + 1), width, height), sf);
            }
        }

        private void prntAllMessages_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            currentPage = currentRow = 0;
        }

        private void prntAllMessages_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Single leftMargin = (Single)25;
            Single rightMargin = (Single)825;
            Single topMargin = (Single)50;
            Single bottomMargin = (Single)1050;
            Single width = (Single)800;
            Single height = (Single)1050;
            DateTime newestTimestamp;
            DateTime oldestTimestamp;
            StringFormat sf = StringFormat.GenericTypographic;
            Font messageFont = new Font("Calibri", 16, System.Drawing.GraphicsUnit.Point);

            if (lsbUsers.SelectedIndex >= 0)
            {
                currentPage++;

                MyUser currentUser = (MyUser)lsbUsers.SelectedItem;
                newestTimestamp = m_Table[currentUser][0].TimeStamp;
                oldestTimestamp = m_Table[currentUser][m_Table[currentUser].Count - 1].TimeStamp;

                string message = String.Format("Messages for : {0} from {1} to {2}", currentUser.Name, oldestTimestamp.ToString("yyyy-MM-dd hh:mm tt"), newestTimestamp.ToString("yyyy-MM-dd hh:mm tt"));
                g.DrawString(message, messageFont, Brushes.Black, leftMargin, topMargin);

                Single currentPosition = 100;
                int rowCounter;
                MyMessage mm;

                for (rowCounter = currentRow; rowCounter < m_Table[currentUser].Count; rowCounter++)
                {
                    mm = m_Table[currentUser][rowCounter];
                    message = String.Format("At: {3,-25}To: {0,-20}From: {1,-20}\n{2}", mm.To, mm.From, mm.Body, mm.TimeStamp);
                    Single currentRowHeight = PrintDetailRow(leftMargin, currentPosition, 25, 1050, 825, message, e, true, rowCounter);
                    if (currentPosition + currentRowHeight < height)
                    {
                        currentPosition += PrintDetailRow(leftMargin, currentPosition, 25, 1050, 825, message, e, false, rowCounter);
                        currentPosition += 10;
                    }
                    else
                    {
                        e.HasMorePages = true;
                        currentRow = rowCounter;
                        break;
                    }
                }
            }
        }

        Single PrintDetailRow(Single x, Single y, Single minHeight, Single maxHeight, Single width, string message, System.Drawing.Printing.PrintPageEventArgs e, bool sizeOnly, int rowCounter)
        {
            Graphics g = e.Graphics;
            String detailText = message;
            RectangleF detailTextLayout = new RectangleF(x, y, width, maxHeight);
            Single detailHeight = 0;
            Font detailRowFont = new Font("Calibri", 16, System.Drawing.GraphicsUnit.Point);
            StringFormat detailStringFormat = new StringFormat(StringFormatFlags.LineLimit);
            detailStringFormat.Trimming = StringTrimming.EllipsisCharacter;

            detailTextLayout.Width = width;

            detailHeight = (Single)Math.Max(g.MeasureString(detailText, detailRowFont, detailTextLayout.Size, detailStringFormat).Height, detailHeight) + (Single).1;

            detailTextLayout.X = x;
            detailTextLayout.Height = Math.Max(Math.Min(detailHeight, maxHeight), minHeight);

            if (!sizeOnly)
            {
                //if (rowCounter % 2 == 1) g.DrawRectangle(Pens.Gray, new Rectangle((int)detailTextLayout.X, (int)detailTextLayout.Y, (int)detailTextLayout.Width, (int)detailTextLayout.Height));

                Rectangle rect = new Rectangle((int)detailTextLayout.X, (int)detailTextLayout.Y, (int)detailTextLayout.Width, (int)detailTextLayout.Height);
                //LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), 0, false);
                //g.FillRectangle(br, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString(detailText, detailRowFont, Brushes.Black, detailTextLayout, detailStringFormat);
                detailTextLayout.X = x;
                detailTextLayout.Y = y;
                detailTextLayout.Height = detailHeight;
                detailTextLayout.Width = width;
            }

            return detailTextLayout.Height;
        }
        #endregion
    }
}