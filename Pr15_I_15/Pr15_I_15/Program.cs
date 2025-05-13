using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 15. Вывести на экран в порядке возрастания все двухзначные числа, увеличив их на 1.
 */
namespace Pr15_I_15
{
    internal class Program
    {
        static int[] Input() {
            using (StreamReader fileIn = new StreamReader(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr15_I_15\Pr15_I_15\input.txt"))
            {
                int cnt = int.Parse(fileIn.ReadLine());
                int[] ints = new int[cnt];
                for (int i = 0; i < cnt; i++) ints[i] = int.Parse(fileIn.ReadLine());
                return ints;    
            }
        }
        static public void Output(System.Collections.Generic.IEnumerable<int> arr)
        {
            using (StreamWriter fileOut = new StreamWriter(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr15_I_15\Pr15_I_15\output.txt"))
            {
                foreach(int i in arr) fileOut.Write($"{i} ");
            }
        }
        static void Main()
        {
            int[] notSortArr = Input();
            var query =
                from val in notSortArr
                where val > 9 & val < 100
                //let valUp = val + 1
                orderby val descending
                select val + 1;

            Output(query);
        }
    }
}
