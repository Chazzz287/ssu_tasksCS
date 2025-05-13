using System;
using System.Collections;
using Task.ThreeLayer.Entities;

namespace Task.ThreeLayer.BLL
{
    public interface IPersonLogic
    {
        void AddPerson(string name);
        void DeletePerson(string name);
        void DeletePerson(int index);
        IEnumerable GetAllPerson();
        Person GetPerson(int index);
    }
}
