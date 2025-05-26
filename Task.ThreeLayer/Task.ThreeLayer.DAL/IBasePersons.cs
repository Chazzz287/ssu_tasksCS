using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ThreeLayer.Entities;

namespace Task.ThreeLayer.DAL
{
    public interface IBasePersons
    {

        void AddPerson(Person person);
        void DeletePerson(string name);
        void DeletePerson(int index);
        IEnumerable<Person> GetAllPersons();
        Person GetPerson(int index);
    }
}
