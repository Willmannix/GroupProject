namespace Project
{
    partial class AddChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fullName = new System.Windows.Forms.Label();
            this.dateOfBirth = new System.Windows.Forms.Label();
            this.DOB = new System.Windows.Forms.DateTimePicker();
            this.comment = new System.Windows.Forms.TextBox();
            this.comments = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(69, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(254, 20);
            this.name.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comments);
            this.panel1.Controls.Add(this.comment);
            this.panel1.Controls.Add(this.DOB);
            this.panel1.Controls.Add(this.dateOfBirth);
            this.panel1.Controls.Add(this.fullName);
            this.panel1.Controls.Add(this.name);
            this.panel1.Location = new System.Drawing.Point(6, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 131);
            this.panel1.TabIndex = 2;
            // 
            // fullName
            // 
            this.fullName.AutoSize = true;
            this.fullName.Location = new System.Drawing.Point(3, 12);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(60, 13);
            this.fullName.TabIndex = 3;
            this.fullName.Text = "Full Name :";
            // 
            // dateOfBirth
            // 
            this.dateOfBirth.AutoSize = true;
            this.dateOfBirth.Location = new System.Drawing.Point(3, 42);
            this.dateOfBirth.Name = "dateOfBirth";
            this.dateOfBirth.Size = new System.Drawing.Size(71, 13);
            this.dateOfBirth.TabIndex = 4;
            this.dateOfBirth.Text = "Date of birth :";
            // 
            // DOB
            // 
            this.DOB.Location = new System.Drawing.Point(123, 36);
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(200, 20);
            this.DOB.TabIndex = 5;
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(97, 62);
            this.comment.Multiline = true;
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(226, 57);
            this.comment.TabIndex = 6;
            // 
            // comments
            // 
            this.comments.AutoSize = true;
            this.comments.Location = new System.Drawing.Point(3, 65);
            this.comments.Name = "comments";
            this.comments.Size = new System.Drawing.Size(62, 13);
            this.comments.TabIndex = 7;
            this.comments.Text = "Comments :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter the required details below.";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(6, 178);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(331, 32);
            this.submitBtn.TabIndex = 4;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // AddChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 238);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "AddChild";
            this.Text = "Add a new child";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker DOB;
        private System.Windows.Forms.Label dateOfBirth;
        private System.Windows.Forms.Label fullName;
        private System.Windows.Forms.Label comments;
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitBtn;
    }
}