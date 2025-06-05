using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ThreeLayer.Entities;
/*
 addPerson
    deletePerson
    deletePerson by index
    getAllPersons
    getPerson

 */
namespace Task.ThreeLayer.BLL
{
    public interface IPersonLogic
    {
        void Add(string lastName, DateTime birthDate, string faculty); // Applicant
        void Add(string lastName, DateTime birthDate, string faculty, int course); // Student
        void Add(string lastName, DateTime birthDate, string faculty, string position, int experience); // Teacher
        void DeletePerson(string lastName);
        void DeletePerson(int index);
        IEnumerable<Person> GetAllPersons();
        Person GetPerson(int index);
    }
}
