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

        void SaveBasePersons()
        {
            using (FileStream file = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(file, persons);
            }
        }
    }
}
