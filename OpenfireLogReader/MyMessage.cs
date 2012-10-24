using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

namespace OpenfireLogReader {
	public class MyMessage : ListViewItem, IComparable, IEquatable<MyMessage> {
		public DateTime TimeStamp;
		public MyUser To;
		public MyUser From;
		public String Id;
		// Inherits 'Text' from ListViewItem

		public MyMessage(string time, MyUser to, MyUser from, string id, string body) {
			TimeStamp = DateTime.ParseExact(time, "MMM dd, yyyy hh:mm:ss:fff tt", new CultureInfo("en-US", true));

			To = to;
			From = from;
			Id = id;
			Text = body;
		}

		public MyMessage(DateTime timestamp, MyUser to, MyUser from, string id, string body) {
			TimeStamp = timestamp;

			To = to;
			From = from;
			Id = id;
			Text = body;
		}

		public override bool Equals(object obj) {
			return obj is MyMessage && TimeStamp.Equals(((MyMessage)obj).TimeStamp);
		}

		public override int GetHashCode() {
			if (Id == "") {
				return (TimeStamp.ToString() + From.Name).GetHashCode();
			} else {
				return (Id + From.Name).GetHashCode();
			}
		}

		public int CompareTo(object obj) {
			if (obj is MyMessage) {
				MyMessage other = (MyMessage)obj;
				return TimeStamp.CompareTo(other.TimeStamp);
			} else {
				throw new ArgumentException("Object is not a MyMessage");
			}
		}

		public bool Equals(MyMessage other) {
			if (other == null)
				return false;

			if (Id == "" || other.Id == "") {
				return TimeStamp.Equals(other.TimeStamp);
			} else {
				return Id == other.Id;
			}
		}

		public override string ToString() {
			return String.Format("{0} : from {1,-10} :  to {2,-10} : {3}", TimeStamp.ToString("yyyy-MM-dd hh:mm:ss"), From, To, Text);
		}
	}

	public class MyMessageListComparer : IComparer {
		private int m_column;

		public MyMessageListComparer() {
			m_column = 0;
		}

		public MyMessageListComparer(int column) {
			m_column = column;
		}

		public int Compare(object x, object y) {
			switch (m_column) {
				case 0:
					DateTime ts1 = ((MyMessage)((ListViewItem)x).Tag).TimeStamp;
					DateTime ts2 = ((MyMessage)((ListViewItem)y).Tag).TimeStamp;
					return DateTime.Compare(ts1, ts2);
				default:
					String s1 = ((ListViewItem)x).SubItems[m_column].Text;
					String s2 = ((ListViewItem)y).SubItems[m_column].Text;
					return String.Compare(s1, s2);
			}
		}
	}
}

