using System;
using System.Collections;

namespace LRCSH2
{   // Edition = Test
    // Exam = Article
    // Student = student


    class Program
    {
        static void Main(string[] args)
        {
           
               Person person1 = new Person("Xenia", "Dolgan", new DateTime(1999, 11, 26));
               Person person2 = new Person("Xenia", "Dolgan", new DateTime(1999, 11, 26));

               Console.WriteLine("First task equals : ");
               Console.WriteLine(" == : " + (person1 == person2));
               Console.WriteLine(" Equals : " + person1.Equals(person2));
               Console.WriteLine(" Hash : " + person1.GetHashCode() + " " + person2.GetHashCode());

               Console.WriteLine("Second task:");
               Student student = new Student();
               student.AddExam(new Exam(), new Exam());
               student.AddTest(new Test(), new Test());
               Console.WriteLine(student);


               Console.WriteLine("Third task:");
               Console.WriteLine(student.PersonBase);

               Console.WriteLine("Fourth task DeepCopy:");
               Student StudentCopy = (Student)student.DeepCopy();
               student.Name = "Original";
               Console.WriteLine(student.Name + " != " + StudentCopy.Name);
               Student student1 = new Student();

                  Console.WriteLine("\nFifth task exception : ");
                   try
                   {
                       student1.GroupNumber = 800;
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine(e.Message);

                   }
            double value = 3;
            Console.WriteLine("\nSixth task: ");
            foreach(var exams in student.GetExamMoreThan(value))
            {
                Console.WriteLine(exams);
            }

            Test test = new Test("Science", false);
            Test test1 = new Test("Geography", true);
            Exam exam = new Exam("Art", 3, new DateTime(2020, 05, 05));
            student.AddExam(exam);
            student.AddTest(test, test1);
            Console.WriteLine("\nSeventh task: ");
            foreach (var pass in student.IfExamAndTestPass())
            {
                Console.WriteLine(pass);
            }

        }
    }
}
