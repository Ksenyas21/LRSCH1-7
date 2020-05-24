using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LRCSH5
{
	[Serializable]
	class Student : Person
	{
		
		private int _groupNumber;
		private Education _education;
		private List<Exam> _examList;
		private List<Test> _testList;

		public Student(Person student, int groupNumber, Education education, List<Exam> examList, List<Test> testList)
			: base(student._Name, student._Surname, student._Birth)
		{
			_groupNumber = groupNumber;
			_education = education;
			_examList = examList;
			_testList = testList;
		}

		public Student() : this(new Person(), 302, Education.Master, new List<Exam> { new Exam() }, new List<Test> { new Test() })
		{ }
		public List<Test> TestList
		{
			get { return _testList; }
			set { _testList = value; }
		}
		public List<Exam> ExamList
		{
			get { return _examList; }
			set { _examList = value; }
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public int GroupNumber
		{
			get { return _groupNumber; }
			set
			{
				if (value <= 100 || value > 699)
				{

					throw new Exception("Group number must be between 100 and 699");

				}
			}
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public Education Educations
		{
			get { return _education; }
			set { _education = value; }
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public double AverageScore
		{
			get
			{
				double allScore = 0;
				foreach (Exam examsPass in ExamList)
				{
					allScore += examsPass._Score;
				}
				return allScore / ExamList.Count;
			}
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public bool this[Education education]
		{
			get { return _education == education; }
		}


		//-------------------------------------------------------------------------------------------------------------------------
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var examPass in ExamList)
			{
				stringBuilder.AppendLine(examPass.ToString());
			}
			foreach (var test in TestList)
			{
				stringBuilder.AppendLine(test.ToString());
			}

			return string.Format("  {0}, {1}, \n {2}  ", Educations, GroupNumber, stringBuilder);
		}

		//-------------------------------------------------------------------------------------------------------------------------
		public virtual string ToShortString()
		{
			return string.Format(" Students: {0} \n Educations: {1} \n  Group Number: {2} \n  Average score: {3}",/* Students,*/ Educations, GroupNumber, AverageScore);
		}

		
	
		//-------------------------------------------------------------------------------------------------------------------------
		protected bool Equals(Student other)
		{
			return _education == other._education &&
				_groupNumber == other._groupNumber &&
				Equals(_examList, other._examList) &&
				Equals(_testList, other._testList);
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Student)obj);
		}

		//-------------------------------------------------------------------------------------------------------------------------
		public static bool operator ==(Student left, Student right)
		{
			return ReferenceEquals(left, right);
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public static bool operator !=(Student left, Student right)
		{
			return !ReferenceEquals(left, right);
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public void AddExam(params Exam[] exam)
		{
			if (exam != null)
			{
				ExamList.AddRange(exam);
			}

		}
		//-------------------------------------------------------------------------------------------------------------------------
		public void AddTest(params Test[] test)
		{
			if (test != null)
			{
				TestList.AddRange(test);
			}

		}
		//-------------------------------------------------------------------------------------------------------------------------
		public IEnumerable GetExamMoreThan(double value)
		{

			foreach (Exam ex in ExamList)
			{
				if (ex._Score > value)
				{
					yield return ex;
				}
			}
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public IEnumerable IfExamAndTestPass()
		{

			foreach (Exam ex in ExamList)
			{
				if (ex._Score > 2)
				{
					yield return ex;
				}
			}
			foreach (Test test in TestList)
			{
				if (test._ifPass > 2)
				{
					yield return test;
				}
			}
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public IEnumerable GetTestAndExam()
		{
			foreach (Exam exam in ExamList)
			{
				yield return exam;
			}
			foreach (Test test in TestList)
			{
				yield return test;
			}
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public Person PersonBase
		{
			get { return new Person(_Name, _Surname, _Birth); }
			set
			{
				_Name = value._Name;
				_Surname = value._Surname;
				_Birth = value._Birth;
			}
		}

//-------------------------------------------------------------------------------------------------------------------------
		public bool AddFromConsole()
		{
			try
			{
				Console.WriteLine("Hello, you can enter here Exam in format:\n" +
								  "ObjactName Score ExamDate(dd.mm.yyyy) , " +
								  "use space as text split");
				string[] input = Console.ReadLine().Split(' ');
				int i = 0;
				while (i < input.Length)
				{
					string ObjectName = input[i++];
					int  Score = Int32.Parse(input[i++]);
					DateTime ExamDate = DateTime.ParseExact(input[i++], "dd.MM.yyyy", null);

					AddExam(new Exam(ObjectName, Score, ExamDate));
				}
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
		}
		//-------------------------------------------------------------------------------------------------------------------------

		public bool Save(string filename)
		{
			try
			{
				using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(stream, this);
				}

				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
		}

		public bool Load(string filename)
		{

			using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
			{
				try
				{
					BinaryFormatter formatter = new BinaryFormatter();
					Student student = (Student)formatter.Deserialize(stream);

					this.PersonBase = student.PersonBase;
					this.GroupNumber = student.GroupNumber;
					this.Educations = student.Educations;
					this.ExamList = student.ExamList;
					this.TestList = student.TestList;
					
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					return false;
				}

			}
		}
		//-------------------------------------------------------------------------------------------------------------------------
		public static bool Save(string filename, Student obj)
		{
			return obj.Save(filename);
		}

		public static bool Load(string filename, Student obj)
		{
			return obj.Load(filename);
		}

		public override object DeepCopy()
		{
			using (MemoryStream stream = new MemoryStream())
			{
				if (this.GetType().IsSerializable)
				{
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(stream, this);
					stream.Position = 0;
					return formatter.Deserialize(stream);
				}

				return null;
			}
		}
	}
}
