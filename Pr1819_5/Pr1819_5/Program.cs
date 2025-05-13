using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
/*
Pr18 Создать абстрактный класс Персона с методами, позволяющим вывести на экран
информацию о персоне, а также определить ее возраст (на момент текущей даты).
2) Создать производные классы: Абитуриент (фамилия, дата рождения, факультет), Студент
(фамилия, дата рождения, факультет, курс), Преподаватель (фамилия, дата рождения,
факультет, должность, стаж), со своими методами вывода информации на экран, и
определения возраста.
3) Создать базу (массив) из n персон, вывести полную информацию из базы на экран, а
также организовать поиск персон, чей возраст попадает в заданный диапазон. 

Pr19 В абстрактном классе Персона реализовать метод CompareTo так, чтобы
можно было базу данных о персонах по дате рождения. 
 */

namespace Pr1819_5
{
    class Program
    {
        static void Main()
        {
            string inputTxtPath = "C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr1819_5\\Pr1819_5\\input.txt";
            string inputXmlPath = "C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr1819_5\\Pr1819_5\\data.xml";
            string outputXmlPath = "C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr1819_5\\Pr1819_5\\result.xml";
            string outputTxtPath = "C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr1819_5\\Pr1819_5\\output.txt";

            PersonsData persons;
            int minAge = -1, maxAge = -1;

            // Проверка существования XML-файла
            if (File.Exists(inputXmlPath) && new FileInfo(inputXmlPath).Length > 0)
            {
                persons = LoadFromXml(inputXmlPath);
            }
            else
            {
                // Загрузка из TXT и создание XML
                persons = LoadPersons(inputTxtPath, ref minAge, ref maxAge);
                SaveToXml(persons, inputXmlPath);
            }

            // Выполнение основной логики (фильтрация по возрасту)
            PersonsData outputData = new PersonsData();
            outputData.MinAge = persons.MinAge;
            outputData.MaxAge = persons.MaxAge;
            if (persons.MinAge > 0 && persons.MaxAge > 0)
            {
                foreach (var person in persons.Persons.Where(p => p.GetAge() >= persons.MinAge && p.GetAge() <= persons.MaxAge))
                {
                    outputData.Persons.Add(person);
                    
                }
            }

            // Сохранение результатов
            SaveToXml(outputData, outputXmlPath);

            Console.WriteLine("Готово! Результаты в result.xml");
        }

        // Метод загрузки данных из файла
        static PersonsData LoadPersons(string filePath, ref int minAge, ref int maxAge)
        {
            PersonsData persons = new PersonsData();
            using (StreamReader fileIn = new StreamReader(filePath))
            {
                minAge = int.Parse(fileIn.ReadLine());
                maxAge = int.Parse(fileIn.ReadLine());
                while (!fileIn.EndOfStream)
                {
                    var line = fileIn.ReadLine();
                    var parts = line.Split(',');
                    // Обработка даты в формате "yyyy-MM-dd"
                    DateTime birthDate = DateTime.ParseExact(parts[2], "yyyy-MM-dd", null);
                    // Остальная логика без изменений
                }
            }
            return persons;
        }

        static void SaveToXml(PersonsData data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PersonsData),
                new[] { typeof(Applicant), typeof(Student), typeof(Teacher) });

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }
        }

        static PersonsData LoadFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PersonsData),
                new[] { typeof(Applicant), typeof(Student), typeof(Teacher) });

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (PersonsData)serializer.Deserialize(fs);
            }
        }
    }
}
