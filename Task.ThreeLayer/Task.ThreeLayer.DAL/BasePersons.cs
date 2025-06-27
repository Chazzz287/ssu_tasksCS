using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ThreeLayer.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;


namespace Task.ThreeLayer.DAL
{
    public class BasePersons : IBasePersons
    {
        int index;
        Dictionary<int, Person> persons;

        private readonly JsonSerializerOptions options = new()
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers =
                {
                    ti =>
                    {
                        if (ti.Type == typeof(Person))
                        {
                            ti.PolymorphismOptions = new JsonPolymorphismOptions
                            {
                                TypeDiscriminatorPropertyName = "$type",
                                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
                                DerivedTypes =
                                {
                                    new JsonDerivedType(typeof(Applicant), "Applicant"),
                                    new JsonDerivedType(typeof(Student), "Student"),
                                    new JsonDerivedType(typeof(Teacher), "Teacher")
                                }
                            };
                        }
                    }
                }
            },
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };


        public BasePersons()
        {
            using (FileStream file = new FileStream("..\\..\\..\\..\\data.json", FileMode.OpenOrCreate))
            {
                if (file.Length == 0) // файл пуст, создаю новую базу
                {
                    persons = new Dictionary<int, Person>();
                    index = 0;
                }
                else
                {
                    persons = JsonSerializer.Deserialize<Dictionary<int, Person>>(file, options);
                    if (persons.Count > 0)
                        index = persons.Keys.Max() + 1;
                    else
                        index = 0;

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
            SaveBasePersons();
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
            SaveBasePersons();
        }

        public void DeletePerson(int index)
        {
            if (persons.ContainsKey(index))
            {
                persons.Remove(index);
            }
            SaveBasePersons();
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
            using (FileStream file = new FileStream("..\\..\\..\\..\\data.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(file, persons, options);
            }
        }
    }


}
