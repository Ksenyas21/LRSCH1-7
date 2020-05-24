using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH
{
	class Person
	{

		private string _Name;
		private string _Surname;
		private DateTime _Birth;

		public Person(string name, string surname, DateTime Birth)
		{
			_Name = name;
			_Surname = surname;
			_Birth = Birth;
		}
		public Person() { }


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
		public override string ToString()
		{

			return string.Format("Name: {0} \n Surname: {1} \n  Birth: {2}", Name, Surname, Birth);

		}
		public string ToShortString()
		{
			return string.Format("Name: {0} \n  Surname: {1}", Name, Surname);

		}
	
	}
}
