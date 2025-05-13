using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1819_5
{
    [Serializable]
    public class Applicant : Person
    {
        public string Faculty { get; set; }

        public Applicant() { }

        public Applicant(string lastName, DateTime birthDate, string faculty)
            : base(lastName, birthDate)
        {
            Faculty = faculty;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Абитуриент: {LastName}, Возраст: {GetAge()}, Факультет: {Faculty}");
        }

        public override string ToFileFormat()
        {
            return $"Applicant,{LastName},{BirthDate.ToString("d")},{Faculty}";
        }
    }
}
