using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        List<Person> listPerson = new List<Person>();    //initialize the datat into a list

        string _fullName = @"-\d+/\d+/\d+\D+";        // Extract the Full name from the list using Regex
        string _dateOfBirth = @"(\d+)/(\d+)/(\d+)";  // \d is a digit from 0 - 9, etc.
        string _comments = @"(?<=\d+\w+)";

        string line = "";
        string insertComments = "";
        string tempDOB = "";

        double pre, prim, sec, college, finished;  //global variables used in the Graph

        public string[] Dates;
        DateTime currentdate = DateTime.Now;      //set up the current Time and Date

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
            //button10.Enabled = false; // Disable for the time being
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

        public void uploadData()      //Uploaded data from the file and initialize it
        {
            try
            {
                using (StreamReader sr = new StreamReader("MaCaveFamily.txt"))
                {
                    string name = "";

                    while ((line = sr.ReadLine()) != null)                              // Exclude expression used for the name
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

                        string[] substringDob = Regex.Split(line, _dateOfBirth);           //Include expression used to find the Date
                        Match matchDob = Regex.Match(line, _dateOfBirth);
                        if (matchDob.Success)
                        {
                            tempDOB = matchDob.Value;
                        }

                        string[] Comments = Regex.Split(line, _comments);                  //Include expression used to find the Comments
                        foreach (string item in Comments)
                        {
                            insertComments = item;
                        }

                        insertComments = insertComments.Replace("-", "");

                        DateTime insertDOB = DateTime.ParseExact(tempDOB, "dd/MM/yyyy", null);  //sets the default format for the date

                        Person newPerson = new Person(name, insertDOB, insertComments);
                        listPerson.Add(newPerson);                                               //Add a new Person to the list
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
            _display.Items.Clear();                                //Clear the items in the Display box

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
                            ListViewItem lvi = new ListViewItem(p.getName());                   //Adds a user to the list into the names column
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
                _display.Items.Add(lvi);                           //dislay list into List view
            }
        }

        public void multipleBirths()
        {
            listPerson.Sort(new ListByAge());
            for (int i = 0; i < listPerson.Count; i++)
            {
                int temp = DuplicateBirth(listPerson[i]);
                if (temp == 2)
                {
                    ListViewItem list = new ListViewItem(listPerson[i + 1].getName());
                    ListViewItem list1 = new ListViewItem(listPerson[i].getName());                          //Used a duplicate here to temporarily fix one set of twins displaying

                    list.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);
                    list1.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);

                    list.SubItems.Add("Twin");
                    list1.SubItems.Add("Twin");

                    _display.Items.Add(list);
                    _display.Items.Add(list1);

                    i++;
                }
                else if (temp == 3)
                {
                    ListViewItem lvi = new ListViewItem(listPerson[i].getName());
                    lvi.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);          //Re Format for the Date of birth just in case
                    lvi.SubItems.Add("Triplet");
                    _display.Items.Add(lvi);

                }
                else if (temp == 4)
                {
                    ListViewItem lvi = new ListViewItem(listPerson[i].getName());
                    lvi.SubItems.Add(listPerson[i].DOB.Day + "/" + listPerson[i].DOB.Month + "/" + listPerson[i].DOB.Year);
                    lvi.SubItems.Add("Quadruplet");
                    _display.Items.Add(lvi);
                }
            }
        }

        private int DuplicateBirth(Person person)       //Check for exact same birthdays
        {
            int count = 1;
            listPerson.Sort(new ListByAge());
            for (int i = 0; i < listPerson.Count; i++)
            {
                if (listPerson[i].DOB == person.DOB)
                {
                    if (listPerson[i].Equals(person))
                    {
                        //* -- *//
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void addChild()
        {
            //Add new child - nickname, date of birth and
            //comment should be saved for the new child.The new details 
            //should be save in the file and program data refreshed.

            string name = "";
            DateTime DOB = new DateTime();
            string likes = "";

            bool present = false;

            using (AddChild AddChildToList = new AddChild())
            {
                if (AddChildToList.ShowDialog() == DialogResult.OK)             //indicates the return value of the dialog box
                {
                    name = AddChildToList.FullName;
                    DOB = DateTime.Parse(AddChildToList.DateOfBirth);
                    likes = AddChildToList.Likes;

                    foreach (Person p in listPerson)
                    {
                        if (p.name == name && p.DOB == DOB)
                        {
                            present = true;
                            MessageBox.Show(name + " Is already a part of the list, please try again!");
                        }
                    }

                    if (!present)
                    {
                        Person temp = new Person(name, DOB, likes);
                        listPerson.Add(temp);

                        string newChild = Environment.NewLine + name + "-" + DOB.ToString("dd/MM/yyyy") + "-" + likes;          //Writes into the text file.

                        File.AppendAllText("MaCaveFamily.txt", newChild);          

                        MessageBox.Show("You have successfully added " + name + " to the list!"); 
                    }
                }
            }
        }

        public void nameNextBaby()
        {
            //Name the next baby - An exciting algorithm that you 
            //come up with for Mrs.McCave’s next baby name.

            string[] FistName = { "Baldy","Chubby","Clean","Dazzling","Drab","Fancy",
                "Flabby","Gorgeous","Long",
                "Plain","Scruffy","Skinny"};

            Random rand = new Random();

            string lastname = "";
            int indexFirstName = rand.Next(FistName.Length);

            if (FistName[indexFirstName] == "Baldy")
            {
                lastname = "Mcaldy";
            }
            if (FistName[indexFirstName] == "Chubby")
            {
                lastname = "O'ruddy";
            }
            if (FistName[indexFirstName] == "Clean")
            {
                lastname = "Arlene";
            }
            if (FistName[indexFirstName] == "Dazzling")
            {
                lastname = "Darragh";
            }
            if (FistName[indexFirstName] == "Drab")
            {
                lastname = "McRab";
            }
            if (FistName[indexFirstName] == "Fancy")
            {
                lastname = "Pancy";
            }
            if (FistName[indexFirstName] == "Flabby")
            {
                lastname = "O'Toole";
            }
            if (FistName[indexFirstName] == "Gorgeous")
            {
                lastname = "George";
            }
            if (FistName[indexFirstName] == "Plain")
            {
                lastname = "Jane";
            }
            if (FistName[indexFirstName] == "Scruffy")
            {
                lastname = "McGuffy";
            }
            if (FistName[indexFirstName] == "Skinny")
            {
                lastname = "Mini";
            }
            if (FistName[indexFirstName] == "Long")
            {
                lastname = "John";
            }

            MessageBox.Show(FistName[indexFirstName] + " " + lastname);       //Random name generator based off the random first name selected from the list which
                                                                              //is matched with a rhyming surname
        }

        public void allowanceMonth()
        {
            int final = 0;
            
            listPerson.Sort(new ListByAge());
            for (int i = 0; i < listPerson.Count; i++)
            {
                if (CalculateAge(listPerson[i].DOB) < 18)
                {
                    int multi = DuplicateBirth(listPerson[i]);
                    if (multi == 1)
                    {
                        final += 140;
                    }
                    else if (multi == 2)
                    {
                        final += 210;

                        final += 210;
                        i++;
                    }
                    else
                    {
                        final += 280;
                    }
                }
            }
            ListViewItem monthlyAllowence = new ListViewItem("Monthly allowance total");
            monthlyAllowence.SubItems.Add(final.ToString());
            _display.Items.Add(monthlyAllowence);
        }
        
        public void allowanceYear()
        {
            int final = 0;
           
            listPerson.Sort(new ListByAge());
            for (int i = 0; i < listPerson.Count; i++)
            {
                if (CalculateAge(listPerson[i].DOB) < 18)
                {
                    int multi = DuplicateBirth(listPerson[i]);
                    if (multi == 1)
                    {
                        DateTime tempP = new DateTime(listPerson[i].DOB.Year, listPerson[i].DOB.Month, listPerson[i].DOB.Day);
                        int tempFinal = 0;
                        for (int y = 0; y < 12; y++)
                        {
                            if (CalculateAge(tempP.AddMonths(DateTime.Today.Month)) < 18)
                            {
                                tempFinal += 140;
                                tempP = tempP.AddMonths(-1);
                            }
                        }
                        final += tempFinal;
                    }
                    else if (multi == 2)
                    {
                        Person tempPerson1 = new Person();   
                        tempPerson1 = listPerson[i + 1];
                        int tempFinal1 = 0;
                        for (int y = 0; y < 12; y++)
                        {
                            if (CalculateAge(tempPerson1.DOB) < 18)
                            {
                                tempFinal1 += 210;
                                tempPerson1.DOB.AddMonths(1);
                            }
                        }
                        final += tempFinal1;

                        Person tempPerson = new Person();
                        tempPerson = listPerson[i];
                        int tempFinal = 0;
                        for (int y = 0; y < 12; y++)
                        {
                            if (CalculateAge(tempPerson.DOB) < 18)
                            {
                                tempFinal += 210;
                                tempPerson.DOB.AddMonths(1);
                            }
                        }
                        final += tempFinal;

                        i++;
                    }
                    else
                    {
                        Person tempP = new Person();
                        tempP = listPerson[i];
                        int tempFinal = 0;
                        for (int y = 0; y < 12; y++)
                        {
                            if (CalculateAge(tempP.DOB) < 18)
                            {
                                tempFinal += 280;
                                tempP.DOB.AddMonths(1);
                            }
                        }
                        final += tempFinal;
                    }
                }
            }
            ListViewItem yearlyAllowence = new ListViewItem("Yearly allowence total");
            yearlyAllowence.SubItems.Add(final.ToString());
            _display.Items.Add(yearlyAllowence);
        }

        public void schoolTimes()
        {
            int year = 0;

            bool result = false;

            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    if (form2.Year == null)
                    {
                        year = DateTime.Today.Year;
                    }
                    else
                    {
                        year = Convert.ToInt32(form2.Year);
                    }

                    result = true;

                }
            }

            if (result)
            {
                DateTime temp = new DateTime(year, 1, 1);
                foreach (Person p in listPerson)
                {
                    DateTime tempDate = new DateTime();
                    if (temp == DateTime.Today)
                    {
                        tempDate = (p.DOB.AddDays(temp.Day));
                        tempDate = (p.DOB.AddMonths(temp.Month));
                        tempDate = (p.DOB.AddYears(temp.Year));
                    }
                    tempDate = (p.DOB.AddYears(DateTime.Today.Year - temp.Year));
                    ListViewItem lvi = new ListViewItem(p.getName());
                    lvi.SubItems.Add(CalculateAge(tempDate).ToString());

                    if (CalculateAge(tempDate) >= 1 && CalculateAge(tempDate) < 5)
                    {
                        lvi.SubItems.Add("Pre school");
                    }
                    else if (CalculateAge(tempDate) >= 5 && CalculateAge(tempDate) <= 11)
                    {
                        lvi.SubItems.Add("Primary School");
                    }
                    else if (CalculateAge(tempDate) >= 12 && CalculateAge(tempDate) <= 18)
                    {
                        lvi.SubItems.Add("Secondary School");
                    }
                    else if (CalculateAge(tempDate) >= 19 && CalculateAge(tempDate) <= 23)
                    {
                        lvi.SubItems.Add("College");
                    }
                    else
                    {
                        lvi.SubItems.Add("Finished");
                    }
                    _display.Items.Add(lvi);
                }
            }
            if(!result)
            {
                MessageBox.Show("Nothing entered, no Info updated!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
       
        public void infoGraphic()
        {

        }

        public void headingRePop()                         // Use to re populate the titles of the List box after each reset
        {
            _display.Columns[0].Text = "Name";
            _display.Columns[1].Text = "Date of birth";
            _display.Columns[2].Text = "Likes";
        }

        public static int CalculateAge(DateTime dob)      // Calculate the age compared to todays date
        {
            DateTime currentDate = DateTime.Today;
            int currentYear = currentDate.Year;
            int DOBYear = dob.Year;
            return currentYear - DOBYear;
        }
        private void button1_Click(object sender, EventArgs e)       // Upload and initialize data
        {
            uploadData();

            foreach (Person P in listPerson)
            {
                ListViewItem Person = new ListViewItem(P.getName());   
                Person.SubItems.Add(P.getDOB().ToString("dd/MM/yyyy")); 
                Person.SubItems.Add(P.getComments());

                _display.Items.Add(Person);            // populate list accordingly.

            }
        }

        private void button2_Click(object sender, EventArgs e)         // Birthdays in the next 7 days
        {
            headingRePop();
            birthdays();
        }

        private void button3_Click(object sender, EventArgs e) // list names sorted started from the oldest
        {
            headingRePop();
            _display.Columns[1].Text = "Age";

            _display.Items.Clear();

            listByAge();
        }

        private void button4_Click(object sender, EventArgs e)  // List names by alphabetical order
        {
            _display.Items.Clear();

            listByABC();

            headingRePop();
        }

        private void button5_Click(object sender, EventArgs e)  // List multi births
        {
            headingRePop();
            _display.Columns[2].Text = "Multi births";

            _display.Items.Clear();

            multipleBirths();
        }

        private void button6_Click(object sender, EventArgs e)  // Add a new child
        {
            addChild();
        }

        private void button7_Click(object sender, EventArgs e)  // Random baby name
        {
            nameNextBaby();
        }

        private void button8_Click(object sender, EventArgs e)  // Allowence for the children per month and year
        {
            _display.Items.Clear();

            headingRePop();
            _display.Columns[1].Text = "Total";
            _display.Columns[2].Text = "";

            allowanceMonth();
            allowanceYear();
        }

        private void button9_Click(object sender, EventArgs e)         //School times
        {
            _display.Items.Clear();
            schoolTimes();

            headingRePop();
            _display.Columns[2].Text = "Education";

        }

        private void button10_Click(object sender, EventArgs e)           //re used code from the School times planner for the graph
        {
            Form3 form3 = new Form3();

            int year = 0;

            bool result = false;

            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    if (form2.Year == null)
                    {
                        year = DateTime.Today.Year;
                    }
                    else
                    {
                        year = Convert.ToInt32(form2.Year);
                    }

                    result = true;

                }
            }

            if (result)
            {
                DateTime temp = new DateTime(year, 1, 1);
                foreach (Person p in listPerson)
                {
                    DateTime tempDate = new DateTime();
                    if (temp == DateTime.Today)
                    {
                        tempDate = (p.DOB.AddDays(temp.Day));
                        tempDate = (p.DOB.AddMonths(temp.Month));
                        tempDate = (p.DOB.AddYears(temp.Year));
                    }
                    tempDate = (p.DOB.AddYears(DateTime.Today.Year - temp.Year));
                    ListViewItem lvi = new ListViewItem(p.getName());

                    if (CalculateAge(tempDate) >= 1 && CalculateAge(tempDate) < 5)
                    {
                        pre++;
                    }
                    else if (CalculateAge(tempDate) >= 5 && CalculateAge(tempDate) <= 11)
                    {
                        prim++;
                    }
                    else if (CalculateAge(tempDate) >= 12 && CalculateAge(tempDate) <= 18)
                    {
                        sec++;
                    }
                    else if (CalculateAge(tempDate) >= 19 && CalculateAge(tempDate) <= 23)
                    {
                        college++;
                    }
                    else
                    {
                        finished++;
                    }
                }
            }

            form3.pre = pre;            // Populate the Form 3 chart.
            form3.prim = prim;
            form3.sec = sec;
            form3.college = college;
            form3.finished = finished;

            form3.ShowDialog();
        }

        private void quit_Click(object sender, EventArgs e)        // Quits the program 
        {
            this.Close();              // Close ?
        }
    }
}
