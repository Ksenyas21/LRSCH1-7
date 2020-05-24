using System;

namespace LRCSH
{
    class Program
    {
		static void Main(string[] args)
		{
			Person xeniaDolgan = new Person("Xenia", "Dolgan", new DateTime(1999, 11, 26));
			Exam exam1 = new Exam("Math", 60, new DateTime(2020, 12, 19));
			Exam exam2 = new Exam("Sciene", 53, new DateTime(2020, 12, 26));
			Student student1 = new Student(xeniaDolgan, 302, new Exam[] { exam1 });

			Console.WriteLine("First task is:\n" + student1.ToShortString() + "\n");
			Console.WriteLine("Second task is: \n" + Education.Bachelor + " " + Education.Master + " " + Education.SecondEducation + "\n ");
			Console.WriteLine("Third task is:\n" + student1 + "\n");
			student1.AddExams(exam1, exam2);
			Console.WriteLine("Fourth task is:\n" + student1.ToString() + "\n");
			Console.WriteLine("Fifth task is (timer in massifs):\n");
			string inputText = Console.ReadLine();

			int nRows = int.Parse(inputText.Split(' ')[0]);
			int mColumns = int.Parse(inputText.Split(' ')[1]);

			int sum = 0;
			int size = 0;
			while (sum < nRows * mColumns)
			{
				sum += ++size;
			}

			Exam[] oneDimension = new Exam[nRows * mColumns];
			Exam[,] twoDimension = new Exam[nRows, mColumns];
			Exam[][] cogged = new Exam[size][];

			var timeStart = Environment.TickCount;
			for (int i = 0; i < nRows * mColumns; i++)
			{
				oneDimension[i] = exam1;
			}
			var timeEnd = Environment.TickCount;
			Console.WriteLine("\nOne dimension is: " + (timeEnd - timeStart));

			timeStart = Environment.TickCount;
			for (int i = 0; i < nRows; i++)
			{
				for (int j = 0; j < mColumns; j++)
				{
					twoDimension[i, j] = exam1;
				}
			}
			timeEnd = Environment.TickCount;
			Console.WriteLine("\nTwo dimension is: " + (timeEnd - timeStart));

			for (int i = 0; i < size; i++)
			{
				if (i == size - 1)
				{
					cogged[i] = new Exam[nRows * mColumns - (sum - size)];
					break;
				}
				cogged[i] = new Exam[i + 1];
			}

			timeStart = Environment.TickCount;
			foreach (var lineArray in cogged)
			{
				for (var j = 0; j < lineArray.Length; j++)
				{
					lineArray[j] = exam1;
				}
			}
			timeEnd = Environment.TickCount;
			Console.WriteLine("\nTwo dimension2 is: " + (timeEnd - timeStart));

		}

	}
}
