using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Person
    {
        public string name { get; set; }
        public string DOB { get; set; }
        public string likes { get; set; }

        public Person()
        {
            this.name = "";
            this.DOB = "";
            this.likes = "";
        }

        public Person(string Name, string DOB, string Likes)
        {
            this.name = Name;
            this.DOB = DOB;
            this.likes = Likes;
        }

        public string getName()
        {
            return this.name;
        }
        public string getDOB()
        {
            return this.DOB;
        }
        public string getLikes()
        {
            return this.likes;
        }
    }
}
