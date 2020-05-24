using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH2
{
    public interface IDateAndCopy
    {
        DateTime Date { get; set; }
        object DeepCopy();
    }
}
