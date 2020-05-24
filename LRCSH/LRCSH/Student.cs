using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH
{
	class Student
	{
		private Person _student;
		private int _groupNumber;
		private Exam[] _examsPass;
		private Education _education;

		public Student(Person student, int groupNumber, Exam[] examsPass)
		{
			_student = student;
			_groupNumber = groupNumber;
			_examsPass = examsPass;
		}

		public Student()
		{
		}

		public int GroupNumber
		{
			get { return _groupNumber; }
			set { _groupNumber = value; }
		}

		public Person Students
		{
			get { return _student; }
			set { _student = value; }
		}

		public Education Educations
		{
			get { return _education; }
			set { _education = value; }
		}
		public Exam[] Exam
		{
			get { return _examsPass; }
			set { _examsPass = value; }
		}

		public double AverageScore
		{
			get
			{
				double allScore = 0;
				foreach (var examsPass in Exam)
				{
					allScore += examsPass.Score;
				}
				return allScore / Exam.Length;
			}
		}

		public bool this[Education education]
		{
			get { return _education == education; }
		}

		public void AddExams(params Exam[] exams)
		{
			Array.Resize(ref _examsPass, Exam.Length + exams.Length);
			Array.Copy(exams, 0, Exam, Exam.Length - exams.Length, exams.Length);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var examPass in Exam)
			{
				stringBuilder.AppendLine(examPass.ToString());
			}
			return string.Format(" Students: {0} \n Educations: {1} \n GroupNumber: {2} \n Exams: {3}", Students, Educations, GroupNumber, stringBuilder);
		}


		public virtual string ToShortString()
		{
			return string.Format(" Students: {0} \n Educations: {1} \n  Group Number: {2} \n  Average score: {3}", Students, Educations, GroupNumber, AverageScore);
		}

		

	}


}
