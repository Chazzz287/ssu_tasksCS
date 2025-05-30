

/*
 * II. В входном файле указывается количество вершин графа/орграфа и матрица смежности: 
13. определить, существует ли путь длиной не более L между двумя данными вершинами;
*/

namespace Pr22_II_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph("..\\..\\..\\graph.txt");
            Console.WriteLine("Graph:\n");
            graph.Show();

            Console.WriteLine("Введите первую вершину:\n");
            int startVertex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вторую вершину:\n");
            int endVertex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите максимальную длину пути L:\n");
            int maxLength = Convert.ToInt32(Console.ReadLine());


            List<int> path;
            bool pathExists = graph.ExistsPath(startVertex, endVertex, maxLength, out path);
            if (pathExists)
            {
                Console.WriteLine($"Путь длиной не более {maxLength} между вершинами {startVertex} и {endVertex} существует.");
                Console.WriteLine("Путь: " + string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine($"Путь длиной не более {maxLength} между вершинами {startVertex} и {endVertex} не существует.");
            }
        }
    }
}