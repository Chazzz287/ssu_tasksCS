using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 15. Найти такую точку на плоскости, сумма расстояний от которой до остальных точек плоскости минимальна

4
0 0
2 1
1 2
3 3

(2, 1)
(1, 2)

 */

namespace Pr_14_I_15
{
    struct SPoint //описание структуры
    {
        public int x, y; //поля структуры
        public SPoint(int x, int y) //конструктор структуры
        {
            this.x = x;
            this.y = y;
        }
        //метод структуры
        public double Distance(SPoint obj)
        {
            return Math.Sqrt((x - obj.x) * (x - obj.x) + (y - obj.y) * (x - obj.x));
        }
    }

    internal class Program
    {
        static public SPoint[] Input() //читаем данные из файла
        {
            using (StreamReader fileIn = new StreamReader(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr_14_I_15\Pr_14_I_15\input.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                SPoint[] ar = new SPoint[n]; //описание массива структур
                for (int i = 0; i < n; i++)
                {
                    string[] text = fileIn.ReadLine().Split(' ');
                    ar[i] = new SPoint(int.Parse(text[0]), int.Parse(text[1])); //вызов конструктора структуры
                }
                return ar; //в качестве результата метод возвращает ссылку на массив структур
            }
        }
        static void Print(IEnumerable<SPoint> objPoint) //выводим данные на экран
        {
            using (StreamWriter fileOut = new StreamWriter(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr_14_I_15\Pr_14_I_15\output.txt"))
            {
                foreach (SPoint obj in objPoint)
                {
                    fileOut.WriteLine($"({obj.x}, {obj.y})");
                }
            }
        }

        static void Main(string[] args)
        {
            SPoint[] array = Input();
            double dist, minDist = int.MaxValue;
            SPoint minPoint = new SPoint(array[0].x, array[0].y);
            List<SPoint> ansPoints = new List<SPoint>();

            for(int i = 0; i < array.Length; i++) 
            {
                dist = 0;
                for(int j = 0; j < array.Length; j++)
                {
                    dist += array[i].Distance(array[j]);
                }
                if (dist == minDist)
                {
                    ansPoints.Add(array[i]);
                }
                if (dist < minDist)
                {
                    minDist = dist;
                    minPoint = array[i];
                    ansPoints.Clear();
                    ansPoints.Add(minPoint);
                }
            }
            Print(ansPoints);
        }
    }
}
