using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ListBylphaOrder : IComparer<Person>
    {
        public int Compare(Person person1, Person person2)
        {
            return string.Compare(person1.name, person2.name);
        }
    }
}
