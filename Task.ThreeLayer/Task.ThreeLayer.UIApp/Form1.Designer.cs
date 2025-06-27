namespace Task.ThreeLayer.UIApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            panelStudent = new Panel();
            labelCourse = new Label();
            labelFaculty = new Label();
            labelBirthDate = new Label();
            labelName = new Label();
            Add = new Button();
            Course = new NumericUpDown();
            Faculty = new TextBox();
            BirthDate = new DateTimePicker();
            txtLastName = new TextBox();
            buttonStudent = new Button();
            buttonTeacher = new Button();
            buttonApplicant = new Button();
            panelTeacher = new Panel();
            label1 = new Label();
            textBox5 = new TextBox();
            labelExp = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            textBox2 = new TextBox();
            panelApplicant = new Panel();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button2 = new Button();
            textBox3 = new TextBox();
            dateTimePicker2 = new DateTimePicker();
            textBox4 = new TextBox();
            buttonLoad = new Button();
            buttonDel = new Button();
            textBoxForDel = new TextBox();
            panelStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Course).BeginInit();
            panelTeacher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panelApplicant.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 103);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(479, 224);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // panelStudent
            // 
            panelStudent.Controls.Add(labelCourse);
            panelStudent.Controls.Add(labelFaculty);
            panelStudent.Controls.Add(labelBirthDate);
            panelStudent.Controls.Add(labelName);
            panelStudent.Controls.Add(Add);
            panelStudent.Controls.Add(Course);
            panelStudent.Controls.Add(Faculty);
            panelStudent.Controls.Add(BirthDate);
            panelStudent.Controls.Add(txtLastName);
            panelStudent.Location = new Point(497, 103);
            panelStudent.Name = "panelStudent";
            panelStudent.Size = new Size(357, 224);
            panelStudent.TabIndex = 2;
            // 
            // labelCourse
            // 
            labelCourse.AutoSize = true;
            labelCourse.Location = new Point(15, 122);
            labelCourse.Name = "labelCourse";
            labelCourse.Size = new Size(54, 20);
            labelCourse.TabIndex = 6;
            labelCourse.Text = "Course";
            // 
            // labelFaculty
            // 
            labelFaculty.AutoSize = true;
            labelFaculty.Location = new Point(15, 90);
            labelFaculty.Name = "labelFaculty";
            labelFaculty.Size = new Size(54, 20);
            labelFaculty.TabIndex = 5;
            labelFaculty.Text = "Faculty";
            labelFaculty.Click += label1_Click_1;
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.Location = new Point(15, 59);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(72, 20);
            labelBirthDate.TabIndex = 4;
            labelBirthDate.Text = "BirthDate";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(15, 24);
            labelName.Name = "labelName";
            labelName.Size = new Size(49, 20);
            labelName.TabIndex = 3;
            labelName.Text = "Name";
            labelName.Click += label1_Click;
            // 
            // Add
            // 
            Add.Location = new Point(15, 166);
            Add.Name = "Add";
            Add.Size = new Size(94, 29);
            Add.TabIndex = 3;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += button1_Click;
            // 
            // Course
            // 
            Course.Location = new Point(93, 120);
            Course.Name = "Course";
            Course.Size = new Size(150, 27);
            Course.TabIndex = 3;
            Course.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Faculty
            // 
            Faculty.Location = new Point(93, 87);
            Faculty.Name = "Faculty";
            Faculty.Size = new Size(163, 27);
            Faculty.TabIndex = 2;
            // 
            // BirthDate
            // 
            BirthDate.Location = new Point(93, 54);
            BirthDate.Name = "BirthDate";
            BirthDate.Size = new Size(250, 27);
            BirthDate.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(93, 21);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(163, 27);
            txtLastName.TabIndex = 0;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // buttonStudent
            // 
            buttonStudent.Location = new Point(497, 68);
            buttonStudent.Name = "buttonStudent";
            buttonStudent.Size = new Size(120, 29);
            buttonStudent.TabIndex = 7;
            buttonStudent.Text = "Add Student";
            buttonStudent.UseVisualStyleBackColor = true;
            buttonStudent.Click += buttonStudent_Click;
            // 
            // buttonTeacher
            // 
            buttonTeacher.Location = new Point(623, 68);
            buttonTeacher.Name = "buttonTeacher";
            buttonTeacher.Size = new Size(120, 29);
            buttonTeacher.TabIndex = 8;
            buttonTeacher.Text = "Add Teacher";
            buttonTeacher.UseVisualStyleBackColor = true;
            buttonTeacher.Click += buttonTeacher_Click;
            // 
            // buttonApplicant
            // 
            buttonApplicant.Location = new Point(746, 68);
            buttonApplicant.Name = "buttonApplicant";
            buttonApplicant.Size = new Size(120, 29);
            buttonApplicant.TabIndex = 9;
            buttonApplicant.Text = "Add Applicant";
            buttonApplicant.UseVisualStyleBackColor = true;
            buttonApplicant.Click += buttonApplicant_Click;
            // 
            // panelTeacher
            // 
            panelTeacher.Controls.Add(label1);
            panelTeacher.Controls.Add(textBox5);
            panelTeacher.Controls.Add(labelExp);
            panelTeacher.Controls.Add(label2);
            panelTeacher.Controls.Add(label3);
            panelTeacher.Controls.Add(label4);
            panelTeacher.Controls.Add(button1);
            panelTeacher.Controls.Add(numericUpDown1);
            panelTeacher.Controls.Add(textBox1);
            panelTeacher.Controls.Add(dateTimePicker1);
            panelTeacher.Controls.Add(textBox2);
            panelTeacher.Location = new Point(497, 103);
            panelTeacher.Name = "panelTeacher";
            panelTeacher.Size = new Size(357, 264);
            panelTeacher.TabIndex = 7;
            panelTeacher.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 122);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 8;
            label1.Text = "Position";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(104, 119);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(163, 27);
            textBox5.TabIndex = 7;
            // 
            // labelExp
            // 
            labelExp.AutoSize = true;
            labelExp.Location = new Point(15, 154);
            labelExp.Name = "labelExp";
            labelExp.Size = new Size(81, 20);
            labelExp.TabIndex = 6;
            labelExp.Text = "Experience";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 90);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 5;
            label2.Text = "Faculty";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 59);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 4;
            label3.Text = "BirthDate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 24);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Name";
            // 
            // button1
            // 
            button1.Location = new Point(15, 195);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(104, 152);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(104, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(163, 27);
            textBox1.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(104, 54);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(104, 21);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(163, 27);
            textBox2.TabIndex = 0;
            // 
            // panelApplicant
            // 
            panelApplicant.Controls.Add(label6);
            panelApplicant.Controls.Add(label7);
            panelApplicant.Controls.Add(label8);
            panelApplicant.Controls.Add(button2);
            panelApplicant.Controls.Add(textBox3);
            panelApplicant.Controls.Add(dateTimePicker2);
            panelApplicant.Controls.Add(textBox4);
            panelApplicant.Location = new Point(497, 103);
            panelApplicant.Name = "panelApplicant";
            panelApplicant.Size = new Size(357, 160);
            panelApplicant.TabIndex = 8;
            panelApplicant.Visible = false;
            panelApplicant.Paint += panelApplicant_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 90);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 5;
            label6.Text = "Faculty";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 59);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 4;
            label7.Text = "BirthDate";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 24);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 3;
            label8.Text = "Name";
            // 
            // button2
            // 
            button2.Location = new Point(15, 122);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(93, 87);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(163, 27);
            textBox3.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(93, 54);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(93, 21);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(163, 27);
            textBox4.TabIndex = 0;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 68);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(94, 29);
            buttonLoad.TabIndex = 10;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += btnLoad_Click;
            // 
            // buttonDel
            // 
            buttonDel.Location = new Point(112, 68);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(94, 29);
            buttonDel.TabIndex = 11;
            buttonDel.Text = "Delete";
            buttonDel.UseVisualStyleBackColor = true;
            buttonDel.Click += buttonDel_Click;
            // 
            // textBoxForDel
            // 
            textBoxForDel.Location = new Point(212, 68);
            textBoxForDel.Name = "textBoxForDel";
            textBoxForDel.Size = new Size(250, 27);
            textBoxForDel.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 480);
            Controls.Add(textBoxForDel);
            Controls.Add(buttonDel);
            Controls.Add(buttonLoad);
            Controls.Add(buttonApplicant);
            Controls.Add(buttonTeacher);
            Controls.Add(buttonStudent);
            Controls.Add(listBox1);
            Controls.Add(panelStudent);
            Controls.Add(panelApplicant);
            Controls.Add(panelTeacher);
            Name = "Form1";
            Text = "Form1";
            panelStudent.ResumeLayout(false);
            panelStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Course).EndInit();
            panelTeacher.ResumeLayout(false);
            panelTeacher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panelApplicant.ResumeLayout(false);
            panelApplicant.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Panel panelStudent;
        private DateTimePicker BirthDate;
        private TextBox txtLastName;
        private NumericUpDown Course;
        private TextBox Faculty;
        private Button Add;
        private Label labelName;
        private Label labelFaculty;
        private Label labelBirthDate;
        private Label labelCourse;
        private Button buttonStudent;
        private Button buttonTeacher;
        private Button buttonApplicant;
        private Panel panelTeacher;
        private Label labelExp;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox2;
        private Panel panelApplicant;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker2;
        private TextBox textBox4;
        private Label label1;
        private TextBox textBox5;
        private Button buttonLoad;
        private Button buttonDel;
        private TextBox textBoxForDel;
    }
}
