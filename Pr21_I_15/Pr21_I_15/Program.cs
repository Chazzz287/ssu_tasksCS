/*
 В файле input.txt хранится последовательность целых чисел. По входной
последовательности построить дерево бинарного поиска и найти для него:
1.15. количество узлов со степенью 1;
 */

namespace Pr21_I_15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Чтение данных из файла
            string[] lines = File.ReadAllLines("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr21_I_15\\Pr21_I_15\\input.txt");
            int[] numbers = Array.ConvertAll(lines, int.Parse);
            // Создание дерева бинарного поиска
            BinaryTree bst = new BinaryTree();
            foreach (int number in numbers)
            {
                bst.Add(number);
            }
            // Подсчет количества узлов со степенью 1
            bst.PrintNodesWithDegreeOne();

        }
    }
}