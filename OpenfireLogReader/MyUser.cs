using System;

namespace OpenfireLogReader
{
	public class MyUser : IComparable
	{
		public string Name;

		public MyUser (string name)
		{
			Name = name;
		}

		public override string ToString ()
		{
			return Name;
		}

		public override int GetHashCode ()
		{
			return Name.GetHashCode ();
		}

		public static bool operator == (MyUser lhs, MyUser rhs)
		{
			if (System.Object.ReferenceEquals(lhs, rhs))
				return true;

			if (((object)lhs == null) || ((object)rhs == null))
				return false;

			return lhs.Name == rhs.Name;
		}

		public static bool operator != (MyUser lhs, MyUser rhs)
		{

			return !(lhs == rhs);
		}

		public override bool Equals(System.Object obj){ 
			if (obj == null)
				return false;

			MyUser mu = obj as MyUser;
			if ((System.Object)mu == null)
				return false;

			return Name == mu.Name;
		}
			
		public bool Equals (MyUser other)
		{
			if (other == null)
				return false;

			return Name == other.Name;
		}

		public int CompareTo(System.Object obj) {
			if (obj == null)
				return 1;

			MyUser otherUser = obj as MyUser;
			if (otherUser != null)
				return this.Name.CompareTo(otherUser.Name);
			else
				throw new ArgumentException("Object is no a MyUser");
			
		}
	}
}