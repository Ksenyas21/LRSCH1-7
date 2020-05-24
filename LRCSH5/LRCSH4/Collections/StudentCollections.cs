using LRCSH5.ComparerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRCSH5
{
    class StudentCollections
    {
        public delegate void StudentListHandler(object source, StudentListHandlerEventArg args);

        public event StudentListHandler StudentCountChanged;
        public event StudentListHandler StudentReferenceChanged;

        private List<Student> students;
        public string SCOlectionName { get; set; }
        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        public bool Remove(int j) {
            if (Students.Count > j)
            {
                Students.RemoveAt(j);
                if (StudentReferenceChanged != null)
                    StudentReferenceChanged(this, new StudentListHandlerEventArg(SCOlectionName, "Element was Delated by Deleted", j));
                return true;
            }
            return false;
        }
        public void AddDefaults()
        {
            Students = new List<Student>();
            Student fullStudents = new Student(new Person("Xeniia", "Dolhan", DateTime.Now), 302, Education.Master,
                new List<Exam>
                {
                  new Exam("Art",4,DateTime.Now), new Exam("Science",5, DateTime.Now)

                },
                new List<Test>
                {
                    new Test("Gheography", 3), new Test("philosophy", 2)
                });
            Students.Add(fullStudents);
            if (StudentCountChanged != null)
                StudentCountChanged(this, new StudentListHandlerEventArg(SCOlectionName,"Element was added AddDefaults",Students.Count-1));
            Students.Add(new Student());
            if (StudentCountChanged != null)
                StudentCountChanged(this, new StudentListHandlerEventArg(SCOlectionName, "Element was added AddDefaults", Students.Count - 1));
            Students.Add(fullStudents);
            if (StudentCountChanged != null)
                StudentCountChanged(this, new StudentListHandlerEventArg(SCOlectionName, "Element was added AddDefaults", Students.Count - 1));
        }
        public void AddStudents(params Student[] students)
        {
            Students = new List<Student>();
            foreach (var student in students)
            {
                Students.Add(student);
                if (StudentCountChanged != null)
                    StudentCountChanged(this, new StudentListHandlerEventArg(SCOlectionName, "Element was added AddStudents", Students.Count - 1));
            

        }
        }
        public Student this[int index]
        {
            get { return Students[index]; }
            set
            { 
                Students[index] = value;
                if (StudentReferenceChanged != null)
                    StudentReferenceChanged(this, new StudentListHandlerEventArg(SCOlectionName, "Element was Delated by Indexator", index));

            }   
                
        }
        public override string ToString()
        {
            
            return string.Format("Students:\n{0}", string.Join("\n", Students.Select(x => x.ToString()).ToArray()));
        }

        public virtual string ToShortString()
        {
            return string.Format("Students:\n{0}", string.Join("\n", Students.Select(x => x.ToShortString()).ToArray()));
        }

        public void SortByName()
        {
            Students.Sort();
        }
        public void SortByDate()
        {
            Students.Sort(new Person().Compare);
        }
        public void SortByAvarage()
        {
            Students.Sort(new AverageStudentCompare().Compare);
        }
        public double GetMaxMiddleScore()
        {
            return Students.Count != 0 ? Students.Select(x => x.AverageScore).Max() : 0;
        }
        public IEnumerable<Student> GetMasterStudents()
        {
            return Students.Where(x => x.Educations == Education.Master);
        }
        public List<Student> AverageMarkGroup(double value)
        {
            return Students.Where(x => x.AverageScore >= value).ToList();

        }
    }
}
