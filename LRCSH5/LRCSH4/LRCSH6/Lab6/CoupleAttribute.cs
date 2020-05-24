using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class CoupleAttribute : System.Attribute
    {
        public string Pair { get; set; }
        public double Probability { get; set; }
        public string ChildType { get; set; }

        public CoupleAttribute()
        {
        }

        public CoupleAttribute(string pair, double probability, string childType)
        {
            this.Pair = pair;
            this.Probability = probability;
            this.ChildType = childType;
        }
    }
}
