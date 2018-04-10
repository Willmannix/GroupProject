using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ListByAge : IComparer<Person>
    {
        public int Compare(Person person1, Person person2)
        {
            return DateTime.Compare(person1.DOB, person2.DOB);
        }
    }
}
