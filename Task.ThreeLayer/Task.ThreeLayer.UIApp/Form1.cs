using System;
using System.Linq;
using System.Windows.Forms;
using Task.ThreeLayer.BLL;
using Task.ThreeLayer.Common;
using Task.ThreeLayer.DAL;
using Task.ThreeLayer.Entities;

namespace Task.ThreeLayer.UIApp
{
    public partial class Form1 : Form
    {
        private readonly IPersonLogic _logic;

        public Form1()
        {
            InitializeComponent();
            _logic = DependencyResolver.PersonLogic;
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            _logic.GetAllPersons();
            UpdateList();
        }
        /*
        private void btnSave_Click(object sender, EventArgs e)
        {
            _logic.SaveToFile("data.json");
            MessageBox.Show("Сохранено");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string role = comboRole.Text;
            string lastName = txtLastName.Text;
            DateTime birth = dateBirth.Value;
            string faculty = txtFaculty.Text;

            if (role == "Applicant")
                _logic.Add(lastName, birth, faculty);
            else if (role == "Student")
                _logic.Add(lastName, birth, faculty, int.Parse(txtCourse.Text));
            else if (role == "Teacher")
                _logic.Add(lastName, birth, faculty, txtPosition.Text, int.Parse(txtExperience.Text));

            UpdateList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _logic.DeleteByLastName(txtLastName.Text);
            UpdateList();
        }*/

        private void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (var p in _logic.GetAllPersons())
                listBox1.Items.Add(p.ToFileFormat());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Для Student
            string lastName = txtLastName.Text;
            DateTime birthDate = BirthDate.Value;
            string faculty = Faculty.Text;
            int course = (int)Course.Value;
            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(faculty))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            _logic.Add(lastName, birthDate, faculty, course);
            UpdateList();
            MessageBox.Show("Запись успешно добавлена.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonStudent_Click(object sender, EventArgs e)
        {
            panelStudent.Visible = true;
            panelTeacher.Visible = false;
            panelApplicant.Visible = false;
        }

        private void panelApplicant_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonTeacher_Click(object sender, EventArgs e)
        {
            panelStudent.Visible = false;
            panelTeacher.Visible = true;
            panelApplicant.Visible = false;
        }

        private void buttonApplicant_Click(object sender, EventArgs e)
        {
            panelStudent.Visible = false;
            panelTeacher.Visible = false;
            panelApplicant.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Для Teacher
            string lastName = textBox2.Text;
            DateTime birthDate = dateTimePicker1.Value;
            string faculty = textBox1.Text;
            string position = textBox5.Text;
            int experience = (int)numericUpDown1.Value;
            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(faculty) || string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            _logic.Add(lastName, birthDate, faculty, position, experience);
            UpdateList();
            MessageBox.Show("Запись успешно добавлена.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Для Applicant
            string lastName = textBox4.Text;
            DateTime birthDate = dateTimePicker2.Value;
            string faculty = textBox3.Text;
            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(faculty))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            _logic.Add(lastName, birthDate, faculty);
            UpdateList();
            MessageBox.Show("Запись успешно добавлена.");
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            string lastName = textBoxForDel.Text;
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Пожалуйста, введите фамилию для удаления.");
                return;
            }
            _logic.DeletePerson(lastName);
            UpdateList();
            MessageBox.Show("Персона успешно удалена.");

        }
    }
}
