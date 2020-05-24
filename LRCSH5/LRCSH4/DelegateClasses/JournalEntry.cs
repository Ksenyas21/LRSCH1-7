using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH5.DelegateClasses
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public string CollectionChangeType { get; set; }
         public int ElementNumber { get; set; }

        public JournalEntry(string collectionName, string collectionChangeType, int elementNumber)
        {
            CollectionName = collectionName;
            CollectionChangeType = collectionChangeType;
            ElementNumber = elementNumber;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", CollectionName, CollectionChangeType,ElementNumber);
        }
    }
}
