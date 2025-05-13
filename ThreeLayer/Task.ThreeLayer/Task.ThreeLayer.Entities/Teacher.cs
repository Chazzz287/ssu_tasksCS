using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.ThreeLayer.Entities
{
    [Serializable]
    public class Teacher : Person
    {
        public string Faculty { get; set; } // Факультет
        public string Position { get; set; } // Должность
        public int Experience { get; set; } // Стаж работы

        public Teacher() { }

        public Teacher(string lastName, DateTime birthDate, string faculty, string position, int experience)
            : base(lastName, birthDate)
        {
            Faculty = faculty;
            Position = position;
            Experience = experience;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Преподаватель: {LastName}, Возраст: {GetAge()}, Факультет: {Faculty}, Должность: {Position}, Стаж: {Experience} лет");
        }

        public override string ToFileFormat()
        {
            return $"Teacher,{LastName},{BirthDate.ToString("d")},{Faculty},{Position},{Experience}";
        }
    }
}
