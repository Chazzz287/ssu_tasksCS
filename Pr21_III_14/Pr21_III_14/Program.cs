using System;

/*
 * 8 4 12 2 6 10 14 1 3 5 7 9 11 13 => 15
 * 4 2 6 1 3 5 7 => no
 * 4 2 6 1 3 5 => 7
 * 10 20 30 40 50 60 70 80
 В файле input.txt хранится последовательность целых чисел. По входной
последовательности построить АВЛ дерево и:
14. проверить, можно ли добавить один узел в дерево так, чтобы дерево осталось деревом
бинарного поиска и стало идеально сбалансированным (определить допустимое
возможное значение добавляемого узла);
*/

namespace Pr21_III_14
{
    class Program
    {
        static void Main()
        {
            const string path = "C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr21_III_14\\Pr21_III_14\\input.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл input.txt не найден.");
                return;
            }

            var values = Array.ConvertAll(
                File.ReadAllText(path)
                    .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries),
                int.Parse);

            var tree = new AVLTree();
            foreach (var v in values)
                tree.Add(v);

            Console.WriteLine($"Высота дерева: {tree.Height}");
            Console.WriteLine($"Количество узлов: {tree.Count}");
            Console.WriteLine($"Идеально сбалансировано? {tree.IsPerfectlyBalanced()}");

            var possible = tree.FindPossibleInsertValues();
            if (possible.Count == 0)
            {
                Console.WriteLine("Невозможно добиться идеального баланса добавлением одного узла.");
            }
            else
            {
                Console.WriteLine("Допустимые значения для добавления:");
                foreach (var x in possible)
                    Console.WriteLine(x);
            }
        }
    }
}