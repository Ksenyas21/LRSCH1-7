using System;
using System.Collections.Generic;
using System.Text;

namespace LRCSH5
{
    [Serializable]
    public class Test : IDateAndCopy
    {
        public string _testName { get; set; }
        public int _ifPass { get; set; }

        public Test(string testName, int ifPass)
        {
            _testName = testName;
            _ifPass = ifPass;
        }
        public Test() : this("Test Info", 4)
        { }
        public override string ToString()
        {
            return string.Format(" {0} {1}", _testName, _ifPass);

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
        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }
    }
}
