using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ThreeLayer.Entities;
using System.Text.Json;


namespace Task.ThreeLayer.DAL
{
    internal class BasePersons : IBasePersons
    {
        int index;
        Dictionary<int, Person> persons;

        public BasePersons()
        {
            using (FileStream file = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                if (file.Length == 0) // файл пуст, создаю новую базу
                {
                    persons = new Dictionary<int, Person>();
                    index = 0;
                }
                else
                {
                    persons = JsonSerializer.Deserialize<Dictionary<int, Person>>(file);
                }
            }
        }
        ~BasePersons()
        {
            SaveBasePersons();
        }

        public void AddPerson(Person person)
        {
            persons.Add(index, person);
            index++;
        }

        public void DeletePerson(string name)
        {
            foreach (var item in persons)
            {
                if (item.Value.LastName == name)
                {
                    persons.Remove(item.Key);
                    break;
                }
            }
        }

        public void DeletePerson(int index)
        {
            if (persons.ContainsKey(index))
            {
                persons.Remove(index);
            }
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return persons.Values;
        }

        public Person GetPerson(int index)
        {
            if (persons.ContainsKey(index))
            {
                return persons[index];
            }
            else
            {
                throw new KeyNotFoundException("Person not found");
            }
        }

        public void SaveBasePersons()
        {
            using (FileStream file = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(file, persons);
            }
        }
    }
}
