using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH5.ComparerClasses
{
   internal class StudentListHandlerEventArg : System.EventArgs
    {
        public string CollectionName { get; set; }
        public string CollectionChangeType { get; set; }

        public int ElementNumber { get; set; }

        public StudentListHandlerEventArg(string collectionName, string collectionChangeType, int elementNumber)
        {
            CollectionName = collectionName;
            CollectionChangeType = collectionChangeType;
            ElementNumber = elementNumber;
        }

        public StudentListHandlerEventArg():this(null,null,0)
        {
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", CollectionName, CollectionChangeType, ElementNumber);
        }
    }
}
