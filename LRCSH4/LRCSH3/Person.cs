using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH3
{
	class Person : IDateAndCopy, IComparable, IComparer<Person>
	{

		public string _Name;
		public string _Surname;
		public DateTime _Birth;

		public Person(string name, string surname, DateTime Birth)
		{
			_Name = name;
			_Surname = surname;
			_Birth = Birth;
		}
		public Person() : this("Ksenia", "Dolhan", DateTime.Today)
		{ }


		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public string Surname
		{
			get { return _Surname; }
			set { _Surname = value; }
		}

		public int Birthday
		{
			get { return _Birth.Year; }
			set { _Birth = new DateTime(value, _Birth.Month, _Birth.Day); }

		}
		public DateTime Birth
		{
			get { return _Birth; }
			set { _Birth = value; }
		}

		public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override string ToString()
		{

			return string.Format(" {0}  {1} , {2}", Name, Surname, Birth);

		}
		public string ToShortString()
		{
			return string.Format("Name: {0} \n  Surname: {1}", Name, Surname);

		}

	
		
		public int CompareTo(object obj)
		{
			if (obj == null) return 1;
			Person otherPerson = obj as Person;
			if (otherPerson != null)
				return String.Compare(Name, otherPerson.Name, StringComparison.Ordinal);
			throw new ArgumentException("Object is not a Person");
		}

		
		public int Compare(Person x, Person y)
		{
			if (x._Birth.CompareTo(y._Birth) != 0) 
			{
				return x._Birth.CompareTo(y._Birth);
			}
			return 0;
		}
		protected bool Equals(Person other)
		{
			return string.Equals(_Name, other._Name) && string.Equals(_Surname, other._Surname) && _Birth.Equals(other._Birth);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Person)obj);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (_Name != null ? _Name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (_Surname != null ? _Surname.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ _Birth.GetHashCode();
				return hashCode;
			}
		}
		public static bool operator ==(Person left, Person right)
		{
			return ReferenceEquals(left, right);
		}

		public static bool operator !=(Person left, Person right)
		{
			return !ReferenceEquals(left, right);
		}


		public virtual object DeepCopy()
		{
			return MemberwiseClone();
		}
	}
}
