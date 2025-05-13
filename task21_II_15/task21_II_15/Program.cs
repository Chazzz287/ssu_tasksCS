/*
 II. В файле input.txt хранится последовательность целых чисел. По входной
последовательности построить дерево бинарного поиска и:
    15. найти сумму узлов, расположенных не выше k-го уровня;
 */

namespace Pr21_II_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int k;
            // Чтение данных из файла
            string[] lines = File.ReadAllLines("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\task21_II_15\\task21_II_15\\input.txt");
            int[] numbers = Array.ConvertAll(lines, int.Parse);
            k = numbers[0];
            // Создание дерева бинарного поиска
            BinaryTree bst = new BinaryTree();
            foreach (int number in numbers[1..])
            {
                bst.Add(number);
            }
            bst.Preorder();
            int sum = bst.SumUpToLevel(k);
            Console.WriteLine($"Сумма узлов не выше уровня {k}: {sum}");


        }
    }
}