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
    public partial class AddChild : Form
    {
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string Likes { get; set; }

        public AddChild()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            FullName = name.Text;
            DateOfBirth = DOB.Text;
            Likes = comment.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
