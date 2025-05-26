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
    internal interface IPersonLogic
    {
        void AddPerson(string name);
        void DeletePerson(string name);
        void DeletePerson(int index);
        IEnumerable GetAllPersons();
        Person GetPerson(int index);
    }
}
