using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH2
{
 public	class Exam : IDateAndCopy
	{
		public string _ObjectName { get; set; }
		public int _Score { get; set; }
		public DateTime _ExamDate { get; set; }

		public Exam(string objectName, int score, DateTime examDate)
		{
			_ObjectName = objectName;
			_Score = score;
			_ExamDate = examDate;
		}

		public Exam():this("Exam Math",4,DateTime.Today)
		{ }

		public override string ToString()
		{
			return string.Format("  {0}  {1}   {2} ", _ObjectName, _Score, _ExamDate);
		}

		protected bool Equals(Exam other)
		{
			return string.Equals( _ObjectName, other._ObjectName) &&_Score == other._Score && _ExamDate.Equals(other._ExamDate);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Exam)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (_ObjectName != null ? _ObjectName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^  _Score.GetHashCode();
				hashCode = (hashCode * 397) ^ _ExamDate.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(Exam left, Exam right)
		{
			return ReferenceEquals(left, right);
		}

		public static bool operator !=(Exam left, Exam right)
		{
			return !ReferenceEquals(left, right);
		}

		//public double Raiting { get; private set; }
		public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public virtual object DeepCopy()
		{
			return MemberwiseClone();
		}
	}
}
