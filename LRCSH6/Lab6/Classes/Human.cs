using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    abstract class Human : IHasName
    {
        public string Name { get; }

        public Human (string name)
        {
            this.Name = name;
        }

        public string getName()
        {
            return this.Name;
        }

        public IEnumerator GetEnumerator()
        {
            Type t = this.GetType();
            object[] attrs = t.GetCustomAttributes(false);
            foreach (CoupleAttribute coupleAttr in attrs)
            {
                yield return coupleAttr;
            }           
        }

    }
}
