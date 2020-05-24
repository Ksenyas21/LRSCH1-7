
using LRCSH5.DelegateClasses;
using System;
using System.IO;

namespace LRCSH5
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "NewFile";
            Student stud1 = new Student();
            Student stud2 = (Student)stud1.DeepCopy();

            Console.WriteLine("Original is \n{0} \nCopy is \n {1}", stud1, stud2);

            Console.WriteLine("Please enter file name:");
            fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not exist. Creating new file...");
                File.Create(fileName);
            }
            else
            {
                stud1.Load(fileName);
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine(stud1);

            stud1.AddFromConsole();
            stud1.Save(fileName);

            Console.WriteLine("-------------------------------");
            Console.WriteLine(stud1);

            Student.Load(fileName, stud1);
            stud1.AddFromConsole();
           Student.Save(fileName, stud1);

            Console.WriteLine("-------------------------------");
            Console.WriteLine(stud1);
        }
    }
}
