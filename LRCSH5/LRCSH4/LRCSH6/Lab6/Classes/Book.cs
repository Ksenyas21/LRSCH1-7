using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Book : IHasName
    {
        public string Name { get; }

        public Book(string name)
        {
            this.Name = name;
        }
    }
}
