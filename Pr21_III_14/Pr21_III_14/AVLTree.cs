using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr21_III_14
{
    /// <summary>
    /// АВЛ‑дерево с «весовым» критерием идеального баланса:
    /// |L − R| ≤ 1 только для корневого узла (количество элементов
    /// в левом и правом поддеревьях отличается не более чем на 1).
    /// </summary>
    public class AVLTree
    {
        private class Node
        {
            public int Value;
            public int Height = 1;   // высота поддерева (лист = 1)
            public int Count = 1;   // количество узлов в поддереве
            public Node Left, Right;

            public Node(int value) => Value = value;

            public void Update()
            {
                Height = Math.Max(Left?.Height ?? 0, Right?.Height ?? 0) + 1;
                Count = 1 + (Left?.Count ?? 0) + (Right?.Count ?? 0);
            }

            #region АВЛ‑ротации
            public static int BalanceFactor(Node p) => (p.Right?.Height ?? 0) - (p.Left?.Height ?? 0);
            public static Node RotateRight(Node p)
            {
                var q = p.Left;
                p.Left = q.Right;
                q.Right = p;
                p.Update();
                q.Update();
                return q;
            }
            public static Node RotateLeft(Node p)
            {
                var q = p.Right;
                p.Right = q.Left;
                q.Left = p;
                p.Update();
                q.Update();
                return q;
            }
            public static Node Balance(Node p)
            {
                p.Update();
                if (BalanceFactor(p) == 2)
                {
                    if (BalanceFactor(p.Right) < 0)
                        p.Right = RotateRight(p.Right);
                    return RotateLeft(p);
                }
                if (BalanceFactor(p) == -2)
                {
                    if (BalanceFactor(p.Left) > 0)
                        p.Left = RotateLeft(p.Left);
                    return RotateRight(p);
                }
                return p;
            }
            #endregion

            #region Вставка/удаление
            public static Node Insert(Node p, int value)
            {
                if (p == null) return new Node(value);
                if (value < p.Value)
                    p.Left = Insert(p.Left, value);
                else if (value > p.Value)
                    p.Right = Insert(p.Right, value); // дубликаты игнорируем
                return Balance(p);
            }
            public static Node Delete(Node p, int value)
            {
                if (p == null) return null;
                if (value < p.Value) p.Left = Delete(p.Left, value);
                else if (value > p.Value) p.Right = Delete(p.Right, value);
                else
                {
                    if (p.Left == null) return p.Right;
                    if (p.Right == null) return p.Left;
                    // Минимум правого поддерева
                    Node min = p.Right;
                    while (min.Left != null) min = min.Left;
                    p.Value = min.Value;
                    p.Right = Delete(p.Right, min.Value);
                }
                return Balance(p);
            }
            #endregion

            public static void InOrder(Node p, List<int> list)
            {
                if (p == null) return;
                InOrder(p.Left, list);
                list.Add(p.Value);
                InOrder(p.Right, list);
            }
        }

        private Node _root;

        public AVLTree() { }
        public AVLTree(IEnumerable<int> items)
        {
            foreach (var v in items) Add(v);
        }

        public int Height => _root?.Height ?? 0;
        public int Count => _root?.Count ?? 0;

        public void Add(int value) => _root = Node.Insert(_root, value);
        public void Delete(int value) => _root = Node.Delete(_root, value);

        /// <summary>
        /// Весовой идеальный баланс (только корень):
        /// |L − R| ≤ 1, где L/R — количество узлов в левом/правом поддеревьях.
        /// </summary>
        public bool IsPerfectlyBalanced()
        {
            if (_root == null) return true; // пустое дерево считаем идеальным
            int left = _root.Left?.Count ?? 0;
            int right = _root.Right?.Count ?? 0;
            return Math.Abs(left - right) <= 1;
        }

        /// <summary>
        /// Подбор значений, чья одиночная вставка приведёт дерево
        /// в состояние идеального (весового) баланса.
        /// </summary>
        public List<int> FindPossibleInsertValues()
        {
            var result = new List<int>();
            if (IsPerfectlyBalanced()) return result; // уже сбалансировано

            // Собираем отсортированный список элементов
            var inorder = new List<int>();
            Node.InOrder(_root, inorder);

            bool Exists(int x) => inorder.BinarySearch(x) >= 0;

            void Try(int cand)
            {
                if (Exists(cand)) return;
                var clone = new AVLTree(inorder);
                clone.Add(cand);
                if (clone.IsPerfectlyBalanced()) result.Add(cand);
            }

            if (inorder.Count == 0) return result;

            // Кандидаты: по краям диапазона и середины “дыр”
            Try(inorder[0] - 1);
            Try(inorder[^1] + 1);
            for (int i = 1; i < inorder.Count; i++)
            {
                int a = inorder[i - 1];
                int b = inorder[i];
                // если пропущено ровно одно значение
                if (b - a == 2) Try(a + 1);
                // если интервал шире, пробуем середину
                else if (b - a > 2) Try(a + (b - a) / 2);
            }

            result.Sort();
            return result;
        }
    }
}
