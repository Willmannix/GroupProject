using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        List<Person> listPerson = new List<Person>();

        
        string _fullName = @"\-\d.*?(\>|(?=\<)|$)";
        string _dateOfBirth = "";
        string _likes = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Person p1 = new Person("Bob", "10/10/1994", "Baseball");
            //Person p2 = new Person("James", "12/05/1995", "Skateboarding");
            //Person p3 = new Person("Bob1", "21/02/2001", "Baseball1");
            //Person p4 = new Person("Bob2", "03/12/2002", "Baseball2");

            //listPerson.Add(p1);
            //listPerson.Add(p2);
            //listPerson.Add(p3);
            //listPerson.Add(p4);

            //foreach (Person P in listPerson)
            //{
            //    ListViewItem Person = new ListViewItem(P.getName());

            //    Person.SubItems.Add(P.getDOB());
            //    Person.SubItems.Add(P.getLikes());

            //    _display.Items.Add(Person);

            //}

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();

            foreach (Person P in listPerson)
            {
                ListViewItem Person = new ListViewItem(P.getName());

                Person.SubItems.Add(P.getDOB());
                Person.SubItems.Add(P.getLikes());

                _display.Items.Add(Person);

            }
        }

        private void _display_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void loadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader("MaCaveFamily.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] name = Regex.Split(line, _fullName);

                        foreach (string list in name)
                        {
                            Person getName = new Person(line, "", "");
                            listPerson.Add(getName);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
