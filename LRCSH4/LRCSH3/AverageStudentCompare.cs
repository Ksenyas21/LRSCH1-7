using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH3
{
   internal class AverageStudentCompare: IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if(x.AverageScore.CompareTo(y.AverageScore)!= 0)
            { 
            return x.AverageScore.CompareTo(y.AverageScore);
              }
            return 0;
        }

    }
}
