using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

/*
На основе данных входного файла составить список сотрудников учреждения, включив
следующие данные: ФИО, год принятия на работу, должность, зарплата, рабочий стаж.
Вывести в новый файл информацию о сотрудниках, имеющих зарплату ниже
определенного уровня, отсортировав их по рабочему стажу.
 */

namespace Pr14_II_5
{
    struct Employees: IComparable<Employees>
    {
         //поля: ФИО, должность, год принятия на работу, рабочий стаж, зарплата.
        public string nameEmployee, postEmployee; 
        public int yearEmloyment, experience, salary;

        public Employees(string name, string post, int exp, int slr, int year)
        {   
            this.nameEmployee = name;
            this.postEmployee = post;
            this.yearEmloyment = year;
            this.experience = exp;
            this.salary = slr;
        }

        public int CompareTo(Employees other)
        {
            if (this.experience < other.experience) return 1;
            if (this.experience > other.experience) return -1;
            return 0;
        }
        
    }
    internal class Program
    {
        static public int salaryKey;
        static public Employees[] Input()
        {
            using(StreamReader fileIn = new StreamReader(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr14_II_5\Pr14_II_5\input.txt"))
            {
                salaryKey = int.Parse(fileIn.ReadLine());
                int cnt = int.Parse(fileIn.ReadLine());
                Employees[] employees = new Employees[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    string[] text = fileIn.ReadLine().Split(' ');
                    string name = text[0];
                    for (int j = 1; j < text.Length - 4; j++) name = string.Concat(name, ' ', text[j]);
                    employees[i] = new Employees(name, text[text.Length - 4], int.Parse(text[text.Length - 3]), int.Parse(text[text.Length - 2]), int.Parse(text[text.Length - 1]));
                }
                return employees;
            }
        }

        static void Print(List<Employees> array) //выводим данные на экран
        {
            using (StreamWriter fileOut = new StreamWriter(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr14_II_5\Pr14_II_5\output.txt"))
            {
                for (int i = 0;i < array.Count;i++)
                {
                    fileOut.WriteLine($"{array[i].nameEmployee}, {array[i].postEmployee}, {array[i].experience}, {array[i].salary}, " +
                        $"{array[i].yearEmloyment}.\n");
                }
            }
        }
        static void Main(string[] args)
        {
            Employees[] employees = Input();
            List<Employees> needyEmployees = new List<Employees>();
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].salary < salaryKey) needyEmployees.Add(employees[i]);
            }
            needyEmployees.Sort();
            Print(needyEmployees);
        }
    }
}
