using System;
using System.Linq;

namespace LRCSH3
{
   internal  class Program
    {
        static void Main(string[] args)
        {
            StudentCollections studentCollection = new StudentCollections();
            studentCollection.AddStudents(
                    TestCollections.GetStudent(5),
                    TestCollections.GetStudent(2),
                    TestCollections.GetStudent(1),
                    TestCollections.GetStudent(3),
                    TestCollections.GetStudent(4)
                );

           Console.WriteLine("studentCollection default: \n {0}\n", string.Join(" ; ", studentCollection.Students.Select(x => x._Name).ToArray()));

            studentCollection.SortByName();
            Console.WriteLine("Sorted by Name: \n {0}\n", string.Join(" ; ", studentCollection.Students.Select(x => x._Name).ToArray()));
            studentCollection.SortByDate();
            Console.WriteLine("Sorted by Date: \n {0}\n", string.Join(" ; ", studentCollection.Students.Select(x => x._Name).ToArray()));
            studentCollection.GetMaxMiddleScore();
            Console.WriteLine("Sorted by miiddle : \n {0}\n", string.Join(" ; ", studentCollection.Students.Select(x => x._Name).ToArray()));
            Console.WriteLine("Maximum middle Score: {0}\n", studentCollection.GetMaxMiddleScore());
             Console.WriteLine("Person with Education = Master :\n {0}\n",string.Join(" ; ", studentCollection.GetMasterStudents().Select(x => x._Name).ToArray()));

            int value = 3;
            Console.WriteLine("Students with middle Score more then {0}:\n {1}\n", value,
                string.Join(" ; ", studentCollection.AverageMarkGroup(value).Select(x => x._Name).ToArray()));

            TestCollections test = new TestCollections(3);
            Console.WriteLine("Searching time:");
            test.MeasureTime();
            Console.ReadKey();

        }
    }
}
