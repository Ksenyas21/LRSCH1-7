using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH
{
	class Exam
	{
		public string ObjectName { get; set; }
		public int Score { get; set; }
		public DateTime ExamDate { get; set; }

		public Exam(string objectName, int score, DateTime examDate)
		{
			ObjectName = objectName;
			Score = score;
			ExamDate = examDate;
		}

		public Exam() { }

		public override string ToString()
		{
			return string.Format(" ObjectName: {0} \n Score: {1} \n ExamDate: {2} ", ObjectName, Score, ExamDate);
		}

		
	}
}
