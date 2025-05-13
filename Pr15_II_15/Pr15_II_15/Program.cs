using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

/*
 * Задание 15. На основе данных входного файла составить список вкладчиков банка,
включив следующие данные: ФИО, номер счета, сумма, год открытия счета. Вывести в новый
файл информацию о тех вкладчиках, которые открыли вклад в текущем году, отсортировав
их по сумме вклада. 
*/

namespace Pr15_II_15
{
    struct Contributor
    {
        public string nameContributor;
        public int yearOpen;
        public uint id;
        public decimal summ;

        public Contributor(string name, uint num, decimal summm, int year)
        {
            this.nameContributor = name;
            this.id = num;
            this.summ = summm;
            this.yearOpen = year;
        }
    }
    internal class Program
    {
        static public Contributor[] Input()
        {
             
            using(StreamReader fileIn = new StreamReader(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr15_II_15\Pr15_II_15\Input.txt"))
            {
                int cnt = int.Parse(fileIn.ReadLine());
                Contributor[] result = new Contributor[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    string[] line = fileIn.ReadLine().Split(' ');
                    string name = line[0];
                    for (int j = 1; j < line.Length - 3; j++) name = string.Concat(name, ' ', line[j]);
                    result[i] = new Contributor(name, uint.Parse(line[line.Length - 3]), 
                        decimal.Parse(line[line.Length - 2]), 
                        int.Parse(line[line.Length - 1])
                        );
                }
                return result;
            }
        }
        static public void Output(IOrderedEnumerable<Contributor> arr)
        {
            using(StreamWriter fileOut = new StreamWriter(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr15_II_15\Pr15_II_15\Output.txt"))
            {
                foreach(Contributor contr in arr)
                {
                    fileOut.WriteLine($"{contr.nameContributor} №{contr.id} {contr.summ} year open: {contr.yearOpen}");
                }
            }
        }
        static void Main(string[] args)
        {
            Contributor[] arr = Input();
            var query = from contr in arr
                        where contr.yearOpen == DateTime.Now.Year
                        orderby contr.summ
                        select contr;
            Output(query);
        }
    }
}
