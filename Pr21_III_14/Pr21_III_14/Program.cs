using System;

/*
 * 8 4 12 2 6 10 14 1 3 5 7 9 11 13 => 15
 * 4 2 6 1 3 5 7 => no
 * 4 2 6 1 3 5 => 7
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
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr21_III_14\\Pr21_III_14\\input.txt");
            int[] numbers = File.ReadAllText("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr21_III_14\\Pr21_III_14\\input.txt")
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            AVLTree tree = new AVLTree();
            foreach (int num in numbers)
            {
                tree.Add(num);
            }

            Console.WriteLine($"Исходная высота дерева: {tree.Height}");
            Console.WriteLine($"Дерево идеально сбалансировано? {tree.IsPerfectlyBalanced()}");

            var possibleValues = tree.FindPossibleInsertValues();

            if (possibleValues.Count == 0)
            {
                Console.WriteLine("Нельзя добавить один узел, чтобы получить идеально сбалансированное АВЛ-дерево.");
            }
            else
            {
                Console.WriteLine("Допустимые значения для добавления узла, чтобы получить идеально сбалансированное АВЛ-дерево:");
                foreach (var val in possibleValues)
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
}