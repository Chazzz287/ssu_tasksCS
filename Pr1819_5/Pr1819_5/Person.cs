using Pr1819_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pr1819_5
{
    [Serializable]
    [XmlInclude(typeof(Applicant))]
    [XmlInclude(typeof(Student))]
    [XmlInclude(typeof(Teacher))]
    public abstract class Person : IComparable<Person>
    {
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }

        public Person(string lastName, DateTime birthDate)
        {
            LastName = lastName;
            BirthDate = birthDate;
        }

        // Метод для вычисления возраста
        public int GetAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now < BirthDate.AddYears(age))
                age--;
            return age;
        }

        // Метод сравнения по дате рождения для сортировки
        public int CompareTo(Person other)
        {
            return BirthDate.CompareTo(other.BirthDate);
        }

        public abstract void DisplayInfo(); // Абстрактный метод вывода информации
        public abstract string ToFileFormat(); // Абстрактный метод форматирования данных для файла
    }
}

[Serializable]
public class PersonsData
{
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public List<Person> Persons { get; set; } = new List<Person>();
}