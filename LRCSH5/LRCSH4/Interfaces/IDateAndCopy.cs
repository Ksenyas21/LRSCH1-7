using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH5
{
    public interface IDateAndCopy
    {
        DateTime Date { get; set; }
        object DeepCopy();
    }
}
