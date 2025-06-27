using Task.ThreeLayer.Common;
using Task.ThreeLayer.Entities;
using Task.ThreeLayer.BLL;

namespace Task.ThreeLayer.ConsolePL
{

    class Program
    {
        static void Show(IPersonLogic personLogic)
        {
            foreach (var person in personLogic.GetAllPersons())
            {
                person.DisplayInfo();
            }
        }
        static void Main(string[] args)
        {
            IPersonLogic personLogic = DependencyResolver.PersonLogic;
            
            Console.WriteLine("Исходная выгрузка");
            Show(personLogic);

            // Абитуриент
            personLogic.Add("Ivanov", new DateTime(2000, 1, 1), "Mathematics");
            // Студент
            personLogic.Add("Petrov", new DateTime(1999, 2, 2), "Physics", 2);
            // Преподаватель
            personLogic.Add("Sidorov", new DateTime(1998, 3, 3), "Chemistry", "Professor", 10);

            Console.WriteLine("\nПосле добавления новых записей:");
            Show(personLogic);
            //// Удаление по фамилии
            //personLogic.DeletePerson("Ivanov");
            //personLogic.DeletePerson(1); // Удаление по индексу
            //Console.WriteLine("\nПосле удаления записей:");
            //Show(personLogic);
        }
    }
}