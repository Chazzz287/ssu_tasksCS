using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr22_II_13
{
    public class Graph
    {
        // Вложенный класс, реализующий внутреннюю структуру графа
        private class Node
        {
            private int[,] array;     // Матрица смежности
            private bool[] visited;   // Массив флагов посещения вершин
            private int len;          // Длина массива для матрицы смежности

            // Индексатор для доступа к матрице смежности
            public int this[int i, int j]
            {
                get => array[i, j];
                set => array[i, j] = value;
            }

            // Количество вершин (размер матрицы)
            public int Size => len;

            public Node(int[,] a)
            {
                len = a.GetLength(0);
                array = new int[len * 2, len * 2];
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        array[i, j] = a[i, j];
                    }
                }
                visited = new bool[len];
            }

            private void Resize()
            {
                int[,] newArray = new int[len * 2, len * 2];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        newArray[i, j] = array[i, j];
                    }
                }
                array = newArray;
            }

            // Помечаем все вершины как непосещённые
            public void NovSet()
            {
                for (int i = 0; i < Size; i++)
                    visited[i] = true;
            }

            // Обход в глубину (DFS)
            public void Dfs(int v)
            {
                Console.Write($"{v} ");
                visited[v] = false;

                for (int u = 0; u < Size; u++)
                {
                    if (array[v, u] != 0 && visited[u])
                        Dfs(u);
                }
            }

            // Обход в ширину (BFS)
            public void Bfs(int v)
            {
                var q = new Queue<int>();
                q.Enqueue(v);
                visited[v] = false;

                while (q.Count > 0)
                {
                    v = q.Dequeue();
                    Console.Write($"{v} ");

                    for (int u = 0; u < Size; u++)
                    {
                        if (array[v, u] != 0 && visited[u])
                        {
                            q.Enqueue(u);
                            visited[u] = false;
                        }
                    }
                }
            }

            // Алгоритм Дейкстры
            public long[] Dijkstra(int v, out int[] p)
            {
                visited[v] = false;

                int[,] c = new int[Size, Size];

                // Подготавливаем матрицу стоимости (веса)
                for (int i = 0; i < Size; i++)
                {
                    for (int u = 0; u < Size; u++)
                    {
                        c[i, u] = (array[i, u] == 0 || i == u) ? int.MaxValue : array[i, u];
                    }
                }

                long[] d = new long[Size];
                p = new int[Size];

                for (int u = 0; u < Size; u++)
                {
                    d[u] = c[v, u];
                    p[u] = v;
                }

                d[v] = 0;

                for (int i = 0; i < Size - 1; i++)
                {
                    long min = int.MaxValue;
                    int w = -1;

                    for (int u = 0; u < Size; u++)
                    {
                        if (visited[u] && d[u] < min)
                        {
                            min = d[u];
                            w = u;
                        }
                    }

                    if (w == -1) break;

                    visited[w] = false;

                    for (int u = 0; u < Size; u++)
                    {
                        if (!visited[u]) continue;

                        long dist = d[w] + c[w, u];
                        if (dist < d[u])
                        {
                            d[u] = dist;
                            p[u] = w;
                        }
                    }
                }

                return d;
            }

            // Восстановление пути Дейкстры
            public void WayDijkstra(int a, int b, int[] p, ref Stack<int> path)
            {
                path.Push(b);
                if (a == p[b])
                    path.Push(a);
                else
                    WayDijkstra(a, p[b], p, ref path);
            }

            // Алгоритм Флойда
            public long[,] Floyd(out int[,] p)
            {
                long[,] a = new long[Size, Size];
                p = new int[Size, Size];

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (i == j) a[i, j] = 0;
                        else a[i, j] = (array[i, j] == 0) ? int.MaxValue : array[i, j];
                        p[i, j] = -1;
                    }
                }

                for (int k = 0; k < Size; k++)
                {
                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            if (a[i, k] == int.MaxValue || a[k, j] == int.MaxValue) continue;

                            long dist = a[i, k] + a[k, j];
                            if (dist < a[i, j])
                            {
                                a[i, j] = dist;
                                p[i, j] = k;
                            }
                        }
                    }
                }

                return a;
            }

            // Восстановление пути Флойда
            public void WayFloyd(int a, int b, int[,] p, ref Queue<int> path)
            {
                int k = p[a, b];
                if (k != -1)
                {
                    WayFloyd(a, k, p, ref path);
                    path.Enqueue(k);
                    WayFloyd(k, b, p, ref path);
                }
            }

            public void AddNode(IList<int> connects)
            {
                if (array.GetLength(0) == len)
                {
                    Resize();
                }
                for (int i = 0; i < connects.ToArray().Length; i++)
                {
                    array[len, i] = connects[i];
                    array[i, len] = connects[i];
                }
                len++;

            }
        }

        private Node graph;

        public int Size => graph.Size;

        // Чтение графа из файла
        public Graph(string name)
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());
                int[,] a = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string[] mas = file.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                        a[i, j] = int.Parse(mas[j]);
                }

                graph = new Node(a);
            }
        }

        // Печать матрицы смежности
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                    Console.Write($"{graph[i, j],4}");
                Console.WriteLine();
            }
        }

        // Запуск обхода в глубину
        public void Dfs(int v)
        {
            graph.NovSet();
            graph.Dfs(v);
            Console.WriteLine();
        }

        // Запуск обхода в ширину
        public void Bfs(int v)
        {
            graph.NovSet();
            graph.Bfs(v);
            Console.WriteLine();
        }

        // Запуск Дейкстры и вывод путей
        public void Dijkstra(int v)
        {
            graph.NovSet();
            int[] p;
            long[] d = graph.Dijkstra(v, out p);

            Console.WriteLine($"Кратчайшие пути от вершины {v}:");

            for (int i = 0; i < graph.Size; i++)
            {
                if (i == v) continue;

                Console.Write($"До вершины {i}: длина = {d[i]}, путь = ");
                if (d[i] == int.MaxValue)
                {
                    Console.WriteLine("нет пути");
                }
                else
                {
                    var path = new Stack<int>();
                    graph.WayDijkstra(v, i, p, ref path);
                    Console.WriteLine(string.Join(" -> ", path));
                }
            }
        }

        // Запуск алгоритма Флойда и вывод всех кратчайших путей
        public void Floyd()
        {
            int[,] p;
            long[,] a = graph.Floyd(out p);

            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    if (i == j) continue;

                    if (a[i, j] == int.MaxValue)
                    {
                        Console.WriteLine($"Пути из {i} в {j} не существует.");
                    }
                    else
                    {
                        Console.Write($"Путь из {i} в {j}: длина = {a[i, j]}, путь = ");
                        var path = new Queue<int>();
                        path.Enqueue(i);
                        graph.WayFloyd(i, j, p, ref path);
                        path.Enqueue(j);
                        Console.WriteLine(string.Join(" -> ", path));
                    }
                }
            }
        }

        public void AddVertex(IList<int> connections)
        {
            graph.AddNode(connections);
        }

        // Определяет, существует ли путь длиной не более maxLength между двумя вершинами
        public bool ExistsPath(int start, int end, int maxWeight, out List<int> path)
        {
            path = new List<int>(); // Список для хранения найденного пути (если он будет найден)

            // Проверка на корректность входных данных: номера вершин и максимальный вес не должны выходить за допустимые границы
            if (start < 0 || start >= Size || end < 0 || end >= Size || maxWeight < 0)
                return false;

            // Создаём приоритетную очередь: в ней храним кортежи (текущая вершина, текущий вес пути, сам путь до этой вершины)
            // Второй параметр — приоритет (чем меньше, тем раньше элемент попадёт в очередь) — используем вес пути
            var pq = new PriorityQueue<(int vertex, int weight, List<int> path), int>();

            // Помещаем стартовую вершину в очередь с весом 0 и путём, содержащим только её
            pq.Enqueue((start, 0, new List<int> { start }), 0);

            // Массив посещённых вершин — чтобы не зацикливаться и не обрабатывать одну вершину несколько раз
            var visited = new bool[Size];

            // Пока в очереди есть элементы
            while (pq.Count > 0)
            {
                // Извлекаем вершину с наименьшим весом пути
                var (current, weight, currentPath) = pq.Dequeue();

                // Если текущая вершина — целевая, и суммарный вес пути не превышает maxWeight, значит путь найден
                if (current == end && weight <= maxWeight)
                {
                    path = currentPath; // Сохраняем путь
                    return true;        // Возвращаем успех
                }

                // Если уже посещали эту вершину раньше (по более короткому пути), пропускаем её
                if (visited[current]) continue;

                // Отмечаем текущую вершину как посещённую
                visited[current] = true;

                // Проходим по всем соседям текущей вершины
                for (int neighbor = 0; neighbor < Size; neighbor++)
                {
                    // Получаем вес ребра между current и neighbor
                    int edgeWeight = graph[current, neighbor];

                    // Если ребро существует (вес > 0) и сосед ещё не посещён
                    if (edgeWeight > 0 && !visited[neighbor])
                    {
                        // Вычисляем новый суммарный вес пути до соседа
                        int newWeight = weight + edgeWeight;

                        // Если новый вес не превышает допустимый лимит
                        if (newWeight <= maxWeight)
                        {
                            // Создаём копию текущего пути и добавляем в неё соседа
                            var newPath = new List<int>(currentPath) { neighbor };

                            // Помещаем нового кандидата в очередь с соответствующим приоритетом
                            pq.Enqueue((neighbor, newWeight, newPath), newWeight);
                        }
                    }
                }
            }

            // Если все возможные пути рассмотрены, а нужный путь не найден — возвращаем false
            return false;
        }


    }
}
