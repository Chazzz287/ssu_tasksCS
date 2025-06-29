using System;
using System.IO;
using System.Collections.Generic;

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
        static void Main(string[] args)
        {
            // Путь к входному файлу: первый аргумент, иначе "input.txt" в каталоге запуска
            string path = args.Length > 0 ? args[0] : "../../../input.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл \"{path}\" не найден.");
                return;
            }

            // Читаем все целые числа из файла
            var values = Array.ConvertAll(
                File.ReadAllText(path)
                    .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries),
                int.Parse);

            // Строим дерево
            var tree = new AVLTree(values);

            Console.WriteLine($"Высота дерева: {tree.Height}");
            Console.WriteLine($"Количество узлов: {tree.Count}");

            bool balanced = tree.IsPerfectlyBalanced();
            Console.WriteLine($"Идеально сбалансировано? {balanced}");

            var candidates = tree.FindPossibleInsertValues();
            if (candidates.Count == 0)
            {
                Console.WriteLine("Невозможно добиться идеального баланса добавлением одного узла.");
            }
            else
            {
                Console.WriteLine("Значения, которые сделают дерево идеальным (весовой баланс на корне):");
                foreach (var v in candidates)
                    Console.WriteLine(v);
            }
        }
    }
}