using System;
/*
 * 4
0 1 0 0
1 0 1 1
0 1 0 0
0 1 0 0

0 1 0 1
 * 
 I. В входном файле указывается количество вершин графа и матрица смежности:
13. добавить новую вершину
*/
namespace Pr22_I_13 
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr22_I_13\\Pr22_I_13\\graph.txt");
            Console.WriteLine("Исходная матрица смежности:");
            g.Show();

            // Ввод рёбер для новой вершины
            Console.WriteLine("Введите через пробел 0 или 1 для каждой вершины, с которой будет соединена новая вершина:");
            Console.WriteLine($"Всего вершин: {g.Size}. Введите {g.Size} чисел (0 или 1):");
            var input = Console.ReadLine();
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var connections = new List<int>();
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int val) && (val == 0 || val == 1))
                    connections.Add(val);
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите только 0 или 1.");
                    return;
                }
            }
            if (connections.Count != g.Size)
            {
                Console.WriteLine("Ошибка: количество введённых значений не совпадает с количеством вершин.");
                return;
            }

            Console.WriteLine("Добавляем новую вершину с заданными связями...");
            g.AddVertex(connections);

            Console.WriteLine("Матрица смежности после добавления вершины:");
            g.Show();
        }
    }
}