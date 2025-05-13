using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ThreeLayer.Entities;

namespace Task.ThreeLayer.DAL
{
    internal interface IBasePersons
    {

        void AddPerson(Person person);
        void DeletePerson(string name);
        void DeletePerson(int index);
        IEnumerable GetAllPersons();
        Person GetPerson(int index);
    }
}
