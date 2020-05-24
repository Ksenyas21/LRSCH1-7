using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH2
{
    public class Test : IDateAndCopy
    {
        public string _testName { get; set; }
        public bool _ifPass { get; set; }

        public Test(string testName, bool ifPass)
        {
            _testName = testName;
            _ifPass = ifPass;
        }
        public Test():this("Test Info",true)
        { }
        public override string ToString()
        {
            return string.Format(" {0} {1}", _testName,_ifPass);

        }
        public static bool operator ==(Test left, Test right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Test left, Test right)
        {
            return !ReferenceEquals(left, right);
        }

        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual  object DeepCopy()
        {
            return MemberwiseClone();
        }
    }
}
