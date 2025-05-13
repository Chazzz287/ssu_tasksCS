using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.ThreeLayer.Entities
{
    public class Student : Person
    {
        public string Faculty { get; set; }
        public int Course { get; set; }

        public Student() { }

        public Student(string lastName, DateTime birthDate, string faculty, int course)
            : base(lastName, birthDate)
        {
            Faculty = faculty;
            Course = course;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Студент: {LastName}, Возраст: {GetAge()}, Факультет: {Faculty}, Курс: {Course}");
        }

        public override string ToFileFormat()
        {
            return $"Student,{LastName},{BirthDate.ToString("d")},{Faculty},{Course}";
        }
    }
}
