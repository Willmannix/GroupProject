using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Person
    {
        //private string Name;
        //private DateTime insertDOB;
        //private string insertComments;

        public string name { get; set; }
        public DateTime DOB { get; set; }
        public string comments { get; set; }

        public Person()
        {
            this.name = "";
            this.DOB = new DateTime();
            this.comments = "";
        }

        public Person(string Name, DateTime DOB, string Likes)
        {
            this.name = Name;
            this.DOB = DOB;
            this.comments = Likes;
        }


        public string getName()
        {
            return this.name;
        }
        public DateTime getDOB()
        {
            return this.DOB;
        }
        public string getComments()
        {
            return this.comments;
        }
    }
}
