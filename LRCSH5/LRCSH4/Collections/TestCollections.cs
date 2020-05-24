using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH5
{
    class TestCollections
    {
        public List<Person> Persons { get; set; }
        public List<string> Text { get; set; }
        public Dictionary<Person, Student> PersStudDictionary { get; set; }
        public Dictionary<string, Student> stStudDictionary { get; set; }

        public static Student GetStudent(int index)
        {
            Student student = new Student(
                new Person("Name" + index, "Surname" + index, DateTime.Today.AddDays(index)),
                index,
                Education.Master,
                new List<Exam>
                {
                    new Exam( "Object" + index + 1, index, DateTime.Today.AddDays(index+1)),
                    new Exam( "Object" + index + 2, index, DateTime.Today.AddDays(index+2)),
                    new Exam( "Object" + index + 3, index, DateTime.Today.AddDays(index+3))

                },
                new List<Test>
                {
                     new Test("Object" + index +1 , index+1),
                     new Test("Object" + index +2 , index+2),
                     new Test("Object" + index +3 , index+3)

                });

            return student;
        }

        public TestCollections(int count)
        {
            Persons = new List<Person>();
            Text = new List<string>();
            PersStudDictionary = new Dictionary<Person, Student>();
            stStudDictionary = new Dictionary<string, Student>();

            for (int i = 0; i < count; i++)
            {
                Student student = GetStudent(i);
                Person person = student.PersonBase;

                Persons.Add(person);
                Text.Add(person.ToString());
                PersStudDictionary.Add(person, student);
                stStudDictionary.Add(person.ToString(), student);
            }
        }
        public void MeasureTime()
        {
            int length = Persons.Count - 1;
            int[] indexes = { 0, length, length / 2, length + 1 };
            foreach (var index in indexes)
            {
                var searcherStudent = GetStudent(index);
                var searcherPerson = searcherStudent.PersonBase;

                Console.WriteLine("----------------------------");

                var start = Environment.TickCount;
                var answer = Persons.Contains(searcherPerson);
                var end = Environment.TickCount;
                Console.WriteLine("List Person at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = Text.Contains(searcherPerson.ToString());
                end = Environment.TickCount;
                Console.WriteLine("List Person toString at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = PersStudDictionary.ContainsKey(searcherPerson);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Person, Student> key at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = PersStudDictionary.ContainsValue(searcherStudent);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Person, Student> value at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = stStudDictionary.ContainsKey(searcherPerson.ToString());
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, Student> key at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = stStudDictionary.ContainsValue(searcherStudent);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, Student> value at index {0}: " + (end - start) + " {1}", index, answer);
            }

        }

    }
}
