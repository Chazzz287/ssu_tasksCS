using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 16. Вывести на экран в порядке убывания все трехзначные числа, уменьшив их на 1
*/

namespace Pr16_I_16
{
    internal class Program
    {
        static int[] Input()
        {
            using (StreamReader fileIn = new StreamReader(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr16_I_16\Pr16_I_16\input.txt"))
            {
                int cnt = int.Parse(fileIn.ReadLine());
                int[] ints = new int[cnt];
                for (int i = 0; i < cnt; i++) ints[i] = int.Parse(fileIn.ReadLine());
                return ints;
            }
        }
        static public void Output(IEnumerable<int> arr)
        {
            using (StreamWriter fileOut = new StreamWriter(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr16_I_16\Pr16_I_16\output.txt"))
            {
                foreach (int i in arr) fileOut.Write($"{i} ");
            }
        }
        static void Main()
        {
            int[] notSortArr = Input();
            var query = notSortArr.Where(x => x > 99 & x < 1000).Select(x => --x).OrderByDescending(x => x);
            Output(query);
        }
    }
}
