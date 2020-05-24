using LRCSH5.ComparerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRCSH5.DelegateClasses
{
    class Journal
    {
       public List<JournalEntry> JournalEntries { get; set; }

        public Journal()
        {
            JournalEntries = new List<JournalEntry>();
        }

        public void AddEvent(object source, StudentListHandlerEventArg args)
        {
            JournalEntry entry = new JournalEntry(args.CollectionName, args.CollectionChangeType, args.ElementNumber);
            JournalEntries.Add(entry);

        }
        public override string ToString()
        {
            return string.Format("{0}", string.Join("\n", JournalEntries.Select(x => x.ToString()).ToArray()));
        }
    }
}
