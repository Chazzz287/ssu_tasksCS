using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            Program x = new Program();
            string a = "";
            while (a == "")
            {
                // 15)  все ли цифры трехзначного числа одинаковые.
                x.task5_3_1();
                a = Console.ReadLine();
            }

            Console.ReadLine();
        }

        void task5_4_1()
        {
            // Разработать рекурсивный метод, который по заданному натуральному числу N (N >= 1000) выведет на
            // экран все натуральные числа, не превышающие N, в порядке возрастания.
            int x = 1;
            void rec(int n)
            {
                if (x <= n)
                {
                    Console.WriteLine($"{x++}");
                    rec(n);
                }

            }

            int a = int.Parse(Console.ReadLine());
            rec(a);
        }

        void task7_4_15()
        {
            /* Для каждого столбца найти произведение элементов с номерами от k1 до k2 и записать
               данные в новый массив.
            */

            int k1, k2;
            k1 = int.Parse(Console.ReadLine());
        }
        void task5_3_1()
        {
            // task: для вычисления n-го члена следующей последовательности 𝑏1 = −10, 𝑏2 = 2, 𝑏𝑛+2 = |𝑏𝑛| − 6𝑏𝑛+1
            // сама рекурсия:
            int rec(int n)
            {
                if (n == 1) return -10;
                if (n == 2) return 2;
                return Math.Abs(rec(n - 2)) - 6 * rec(n - 1);
            }

            int x = int.Parse(Console.ReadLine());
            Console.WriteLine($"b{x} = {rec(x)}");
        }

        

        void task2_5_A()
        {
            // task: для каждого целого числа на отрезке [a, b] вывести на экран количество делителей;
            int a, b;
            Console.WriteLine("Enter num a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num b: ");
            b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++) {
                Console.WriteLine($"{i} = {amount_div(i)}");
            }
        }

        void task2_5_B()
        {
            // task: вывести на экран только те целые числа отрезка [a, b], у которых
            // количество делителей равно заданному числу;
            int a, b, n;
            ushort div;
            Console.WriteLine("Enter num a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num b: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num n: ");
            n = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++)
            {
                div = amount_div(i);
                if (div == n) Console.WriteLine($"{i} = {div}");
            }

        }

        void task2_5_C()
        {
            // task: вывести на экран только те целые числа отрезка [a, b], у которых количество делителей максимально;
            int a, b;
            Console.WriteLine("Enter num a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num b: ");
            b = int.Parse(Console.ReadLine());
            ushort[] div = new ushort[b - a + 1];
            ushort maxDiv = 0;
            for (int i = 0; i < b - a + 1; i++)
            {
                div[i] = amount_div(i + a);
                if (div[i] > maxDiv) maxDiv = div[i];
            }
            Console.WriteLine($"maxDix: {maxDiv}");
            for (int i = 0; i < b - a +1; i++)
            {
                if (div[i] == maxDiv)Console.WriteLine($"{i + a}");
            }
            }

        void task2_5_D()
        {
            // для заданного числа А вывести на экран ближайшее следующее по отношению к нему число,
            // имеющее столько же делителей, сколько и число А;
            int a, i;
            Console.WriteLine("Enter num A: ");
            a = int.Parse(Console.ReadLine());
            ushort aDiv = amount_div(a);
            for (i = a + 1; amount_div(i) != aDiv; i++);
            Console.WriteLine($"next num: {i}");
        }

        // количество делителей числа
        protected ushort amount_div(int n)
        {
            ushort cnt = 2;
            for (int i = 2; i * i <= n; i++) {
                if (n % i == 0) { 
                    cnt++;
                    if (i * i != n) cnt++; 
                }
            }
            return cnt;
        }

        void task15_3()
        {

            // все двухзначные числа, произведение цифр которых нечетное;
            for (int i = 11; i < 100; i += 2)
            {
                if ((i >= 20 && i < 30) || (i >= 40 && i < 50) || (i >= 60 && i < 70) || (i >= 80 && i < 90))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

        }
        void task15_2()
        {
            
                Console.WriteLine("Введите трехзначное число: ");
                string str = Console.ReadLine();
                if (str.Length == 3)
                {
                    string ans = (str[0] == str[1] && str[1] == str[2]) ? "Цифры одинаковы" : "Цифры не одинаковы";
                    Console.WriteLine(ans);
                }
                else
                {
                    Console.WriteLine("Число не трехзначное");
                }
        }
    }
}
