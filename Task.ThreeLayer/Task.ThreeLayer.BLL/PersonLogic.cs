using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ThreeLayer.DAL;
using Task.ThreeLayer.Entities;

namespace Task.ThreeLayer.BLL
{
    public class PersonLogic : IPersonLogic
    {
        private IBasePersons _peopleRepo;

        public PersonLogic(IBasePersons peopleRepo)
        {
            this._peopleRepo = peopleRepo;
        }

        // Applicant
        public void Add(string lastName, DateTime birthDate, string faculty)
        {
            _peopleRepo.AddPerson(new Applicant(lastName, birthDate, faculty));
        }

        // Student
        public void Add(string lastName, DateTime birthDate, string faculty, int course)
        {
            _peopleRepo.AddPerson(new Student(lastName, birthDate, faculty, course));
        }

        // Teacher
        public void Add(string lastName, DateTime birthDate, string faculty, string position, int experience)
        {
            _peopleRepo.AddPerson(new Teacher(lastName, birthDate, faculty, position, experience));
        }

        public void DeletePerson(string lastName)
        {
            var person = _peopleRepo.GetAllPersons().FirstOrDefault(p => p.LastName == lastName);
            if (person != null)
                _peopleRepo.DeletePerson(person.LastName);
        }

        public void DeletePerson(int index)
        {
                _peopleRepo.DeletePerson(index);
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _peopleRepo.GetAllPersons();
        }

        public Person GetPerson(int index)
        {
            return _peopleRepo.GetPerson(index);
        }
    }

}
