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

        string _fullName = @"-\d+/\d+/\d+\D+";
        string _dateOfBirth = @"(\d+)/(\d+)/(\d+)";
        string _comments = @"(?<=\d+\w+)";

        string line = "";
        string insertComments = "";
        string tempDOB = "";

        public string[] Dates;
        DateTime currentdate = DateTime.Now;

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

        private void Form1_Load(object sender, EventArgs e)                  /*====*/
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _display_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void uploadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader("MaCaveFamily.txt"))
                {
                    string name = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] FullName = Regex.Split(line, _fullName);
                        foreach (string match in FullName)
                        {
                            if (match != "")
                            {

                                name = match;
                                name = name.Replace("-", " ");
                                //Person getName = new Person(line, "", "");
                                //listPerson.Add(getName);
                            }
                        }

                        string[] substringDob = Regex.Split(line, _dateOfBirth);
                        Match matchDob = Regex.Match(line, _dateOfBirth);
                        if (matchDob.Success)
                        {
                            tempDOB = matchDob.Value;
                        }

                        string[] Comments = Regex.Split(line, _comments);
                        foreach (string item in Comments)
                        {
                            insertComments = item;
                        }

                        insertComments = insertComments.Replace("-", "");

                        DateTime insertDOB = DateTime.ParseExact(tempDOB, "dd/MM/yyyy", null);

                        Person newPerson = new Person(name, insertDOB, insertComments);
                        listPerson.Add(newPerson);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }
            button1.Enabled = false;
        }

        public void birthdays()
        {

            _display.Items.Clear();

            DateTime tempDate = new DateTime();


            foreach (Person p in listPerson)
            {
                tempDate = p.getDOB();

                int day = Convert.ToInt32(tempDate.Day);
                int month = Convert.ToInt32(tempDate.Month);

                if (month == currentdate.Month || month == currentdate.Month + 1)
                {
                    if (month == currentdate.Month)
                    {
                        int currentDay = currentdate.Day;
                        if (day - currentDay > 0 && day - currentDay < 8)
                        {
                            ListViewItem lvi = new ListViewItem(p.getName());
                            lvi.SubItems.Add(p.getDOB().ToString());
                            _display.Items.Add(lvi);
                        }
                    }
                    if (month == currentdate.Month + 1)
                    {
                        int currentDay = currentdate.Day;
                        if (day - currentDay == 7)
                        {
                            ListViewItem lvi = new ListViewItem(p.getName());
                            lvi.SubItems.Add(p.getDOB().ToString());
                            _display.Items.Add(lvi);
                        }
                    }
                }
            }
            if (_display.Items.Count < 1) //Checks if the list contains zero(0) items if so then simply output the following message
            {

                _display.Columns[0].Text = "";
                _display.Columns[1].Text = "";
                _display.Columns[2].Text = "";


                ListViewItem lvi = new ListViewItem("No Birthdays coming up in the next 7 days!");
                _display.Items.Add(lvi);
            }
        }

        public void listByAge()
        {
            listPerson.Sort(new ListByAge());
       
            foreach (Person p in listPerson)
            {
                ListViewItem lvi = new ListViewItem(p.getName());
                lvi.SubItems.Add(CalculateAge(p.getDOB()).ToString());
                lvi.SubItems.Add(p.getComments());
                _display.Items.Add(lvi);
            }
        }

        public void listByABC()
        {
            listPerson.Sort(new ListBylphaOrder());
   
            foreach (Person p in listPerson)
            {
                ListViewItem lvi = new ListViewItem(p.getName());
                lvi.SubItems.Add(p.getDOB().ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(p.getComments());
                _display.Items.Add(lvi);
            }
        }

        public void multipleBirths()
        {
            //List any / all multiple births: nicknames of children who are 
            //part of a multiple birth. The program should state if they 
            //are twins, triplets quads etc.  
            listPerson.Sort(new ListByAge());
            for (int i = 0; i < listPerson.Count; i++)
            {
                int numFam = FindMultipleBirths(listPerson[i]);
                if (numFam == 2)
                {
                    ListViewItem lvi = new ListViewItem(listPerson[i + 1].getName());
                    lvi.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);
                    lvi.SubItems.Add("Twin");
                    _display.Items.Add(lvi);

                    ListViewItem lvi1 = new ListViewItem(listPerson[i].getName());
                    lvi1.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);
                    lvi1.SubItems.Add("Twin");
                    _display.Items.Add(lvi1);
                    i++;
                }
                else if (numFam == 3)
                {
                    ListViewItem lvi = new ListViewItem(listPerson[i].getName());
                    lvi.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);
                    lvi.SubItems.Add("Triplet");
                    _display.Items.Add(lvi);
                }
                else if (numFam == 4)
                {
                    ListViewItem lvi = new ListViewItem(listPerson[i].getName());
                    lvi.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);
                    lvi.SubItems.Add("Quadruplet");
                    _display.Items.Add(lvi);
                }
            }
        }

        private int FindMultipleBirths(Person person)
        {
            int count = 1;
            listPerson.Sort(new ListByAge());
            for (int i = 0; i < listPerson.Count; i++)
            {
                if (listPerson[i].DOB == person.DOB)
                {
                    if (listPerson[i].Equals(person))
                    {
                        ;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            return count;
        }

            public void addNewChild()
        {
            //Add new child - nickname, date of birth and
            //comment should be saved for the new child.The new details 
            //should be save in the file and program data refreshed.

        }

        public void nameNextBaby()
        {
                //Name the next baby - An exciting algorithm that you 
                //come up with for Mrs.McCave’s next baby name.
        }

        public void allowanceMonth()
        {
                //Calculate Mrs.McCave’s children’s allowance for the current month.
                //http://www.citizensinformation.ie/en/social_welfare/social_welfare_payments/social_welfare_payments_to_families_and_children/child_benefit.html 
        }

        public void allowanceYear()
        {
                //Calculate Mrs.McCave’s children’s allowance for the current Year.
                //http://www.citizensinformation.ie/en/social_welfare/social_welfare_payments/social_welfare_payments_to_families_and_children/child_benefit.html 
        }

        public void schoolTimes()
        {

        }

        public void infoGraphic()
        {

        }

        public void headingRePop()
        {
            _display.Columns[0].Text = "Name";
            _display.Columns[1].Text = "Date of birth";
            _display.Columns[2].Text = "Likes";
        }

        public static int CalculateAge(DateTime dob)
        {
            DateTime currentDate = DateTime.Today;
            int currentYear = currentDate.Year;
            int DOBYear = dob.Year;
            return currentYear - DOBYear;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            uploadData();

            foreach (Person P in listPerson)
            {
                ListViewItem Person = new ListViewItem(P.getName());
                Person.SubItems.Add(P.getDOB().ToString("dd/MM/yyyy"));
                Person.SubItems.Add(P.getComments());

                _display.Items.Add(Person);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            headingRePop();
            birthdays();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            headingRePop();
            _display.Columns[1].Text = "Age";

            _display.Items.Clear();

            listByAge();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _display.Items.Clear();

            listByABC();

            headingRePop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            headingRePop();
            _display.Columns[2].Text = "Multi births";

            _display.Items.Clear();

            multipleBirths();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
