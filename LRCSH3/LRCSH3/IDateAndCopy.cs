using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH3
{
    public interface IDateAndCopy
    {
        DateTime Date { get; set; }
        object DeepCopy();
    }
}
