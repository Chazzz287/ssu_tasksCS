using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr21_III_14
{
    /// <summary>
    /// AVL-дерево с методами проверки идеального баланса и возможных вставок.
    /// </summary>
    public class AVLTree
    {
        private class Node
        {
            // Значение, хранящееся в узле
            public int Value;

            // Высота поддерева с корнем в этом узле
            public int Height;

            // Количество узлов в поддереве с корнем в этом узле
            public int Count;

            // Левые и правые дочерние узлы
            public Node Left, Right;

            // Конструктор узла, инициализация значением, высотой и количеством
            public Node(int val)
            {
                Value = val;
                Height = 1;
                Count = 1;
            }

            // Обновляет высоту и количество узлов в поддереве
            public void Update()
            {
                int lh = Left?.Height ?? 0;
                int rh = Right?.Height ?? 0;
                Height = Math.Max(lh, rh) + 1;
                Count = 1 + (Left?.Count ?? 0) + (Right?.Count ?? 0);
            }

            // Баланс-фактор: разница высот правого и левого поддеревьев
            public int BalanceFactor => (Right?.Height ?? 0) - (Left?.Height ?? 0);

            // Правый поворот вокруг узла p
            public static Node RotateRight(Node p)
            {
                var q = p.Left;
                p.Left = q.Right;
                q.Right = p;
                p.Update();
                q.Update();
                return q;
            }

            // Левый поворот вокруг узла p
            public static Node RotateLeft(Node p)
            {
                var q = p.Right;
                p.Right = q.Left;
                q.Left = p;
                p.Update();
                q.Update();
                return q;
            }

            // Балансировка узла p
            public static Node Balance(Node p)
            {
                p.Update();
                if (p.BalanceFactor == 2)
                {
                    if (p.Right?.BalanceFactor < 0)
                        p.Right = RotateRight(p.Right);
                    return RotateLeft(p);
                }
                if (p.BalanceFactor == -2)
                {
                    if (p.Left?.BalanceFactor > 0)
                        p.Left = RotateLeft(p.Left);
                    return RotateRight(p);
                }
                return p;
            }

            // Вставка значения в поддерево с корнем p
            public static Node Insert(Node p, int val)
            {
                if (p == null)
                    return new Node(val);
                if (val < p.Value)
                    p.Left = Insert(p.Left, val);
                else if (val > p.Value)
                    p.Right = Insert(p.Right, val);
                // дубликаты не вставляем
                return Balance(p);
            }

            // Симметричный (in-order) обход поддерева
            public static void InOrder(Node p, List<int> list)
            {
                if (p == null) return;
                InOrder(p.Left, list);
                list.Add(p.Value);
                InOrder(p.Right, list);
            }

            // Получить высоту поддерева
            public static int GetHeight(Node p) => p?.Height ?? 0;

            // Получить количество узлов в поддереве
            public static int GetCount(Node p) => p?.Count ?? 0;
        }

        // Корень дерева
        private Node root;

        // Конструктор по умолчанию
        public AVLTree() { }

        // Конструктор, инициализирующий дерево элементами из коллекции
        public AVLTree(IEnumerable<int> items)
        {
            foreach (var v in items)
                Add(v);
        }

        // Вставка значения с балансировкой
        public void Add(int val) => root = Node.Insert(root, val);

        // Высота дерева
        public int Height => Node.GetHeight(root);

        // Количество узлов в дереве
        public int Count => Node.GetCount(root);

        // Проверяет, идеально ли сбалансировано дерево
        public bool IsPerfectlyBalanced()
        {
            // 1. Проверка минимальной высоты: h = ceil(log2(n+1))
            int n = Count;
            double idealH = Math.Ceiling(Math.Log(n + 1, 2));
            if (Height != (int)idealH) return false;
            // 2. Рекурсивная проверка модулей разности
            bool Check(Node p)
            {
                if (p == null) return true;
                int leftCount = Node.GetCount(p.Left);
                int rightCount = Node.GetCount(p.Right);
                if (Math.Abs(leftCount - rightCount) > 1) return false;
                return Check(p.Left) && Check(p.Right);
            }
            return Check(root);
        }

        // Находит все значения, которые можно вставить, чтобы дерево стало идеально сбалансированным
        public List<int> FindPossibleInsertValues()
        {
            var result = new List<int>();
            // Определяем возможную высоту после вставки одного узла
            int n = Count;
            int targetH = (int)Math.Ceiling(Math.Log(n + 2, 2));
            // Если после вставки n+1 элементов минимальная высота не targetH, то нет решений
            if (Height != (int)Math.Ceiling(Math.Log(n + 1, 2)))
                return result;
            // in-order обход
            var inorder = new List<int>();
            Node.InOrder(root, inorder);
            for (int i = 0; i <= inorder.Count; i++)
            {
                int min = (i == 0) ? inorder[0] - 1 : inorder[i - 1] + 1;
                int max = (i == inorder.Count) ? inorder[^1] + 1 : inorder[i] - 1;
                for (int cand = min; cand <= max; cand++)
                {
                    var copy = new AVLTree(inorder);
                    copy.Add(cand);
                    if (copy.IsPerfectlyBalanced())
                    {
                        result.Add(cand);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
