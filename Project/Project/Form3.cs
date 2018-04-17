using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form3 : Form
    {
        public string Year { get; set; }

        
        public double pre, prim, sec, college, finished;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points[0].SetValueY(pre);
            chart1.Series[0].Points[1].SetValueY(prim);
            chart1.Series[0].Points[2].SetValueY(sec);
            chart1.Series[0].Points[3].SetValueY(college);
            chart1.Series[0].Points[4].SetValueY(finished);
        }
    }
}
