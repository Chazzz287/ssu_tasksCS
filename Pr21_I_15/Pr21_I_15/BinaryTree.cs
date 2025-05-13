using System;
using System.Data;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Pr21_I_15 {
public class BinaryTree
{
        // вложенный класс, ответственный за узлы и операции допустимые для дерева бинарного поиска
        private class Node 
        {
            public object inf;  // информация, хранящаяся в узле
            public Node left;  // указатель на левое поддерево
            public Node right;  // указатель на правое поддерево
            // конструктор вложенного класса 
            public Node(object inf)
            {
                this.inf = inf;
                left = null;
                right = null;
            }

            // метод для добавления узла в дерево
            public static void Add(ref Node root, object inf) 
            { 
                if (root == null)
                    root = new Node(inf);
                else
                {
                    if (((IComparable)(root.inf)).CompareTo(inf) > 0)
                        Add(ref root.left, inf);
                    else
                        Add(ref root.right, inf);
                }
            }
            public static void Preorder(Node root) // обход в прямом порядке
            {
                if (root != null)
                {
                    Console.Write("{0} ", root.inf);
                    Preorder(root.left);
                    Preorder(root.right);
                }
            }

            public static void Inorder(Node root)  // симметричный обход
            {
                if (root != null)
                {
                    Inorder(root.left);
                    Console.Write("{0} ", root.inf);
                    Inorder(root.right);
                }
            }

            public static void Postorder(Node root) // обратный обход
            {
                if (root != null)
                {
                    Postorder(root.left);
                    Postorder(root.right);
                    Console.Write("{0} ", root.inf);
                }
            }

            public static int Order(Node root) // подсчет количества узлов со степенью 1
            {
                if (root == null)
                    return 0;
                if (root.left != null && root.right == null)
                    return 1 + Order(root.left) + Order(root.right);
                else if (root.left == null && root.right != null)
                    return 1 + Order(root.left) + Order(root.right);
                else
                    return Order(root.left) + Order(root.right);
            }

            public static void PrintNodesWithDegreeOne(Node root, ref int cnt) // вывод всех узлов со степенью 1
            {
                if (root == null)
                    return;
                bool isDegreeOne = (root.left != null && root.right == null) || (root.left == null && root.right != null);
                if (isDegreeOne)
                {
                    cnt += 1;
                    Console.Write("{0} ", root.inf);
                }
                PrintNodesWithDegreeOne(root.left, ref cnt);
                PrintNodesWithDegreeOne(root.right, ref cnt);
            }

            // метод для поиска ключевого узла в дереве
            public static void Search(Node root, object key, out Node item)
            {
                if (root == null)
                {
                    item = null;
                }
                else
                {
                    if (((IComparable)(root.inf)).CompareTo(key) == 0)
                        item = root;
                    else
                    {
                        if (((IComparable)(root.inf)).CompareTo(key) > 0)
                            Search(root.left, key, out item);
                        else
                            Search(root.right, key, out item);
                    }
                }
            }

            // методы Del и Delete позволяют удалить узел в дереве так, чтобы дерево при этом
            // оставалось деревом бинарного поиска
            public static void Del(Node t, ref Node tr)
            {
                if(tr.right != null)
                {
                    Del(t, ref tr.right);
                }
                else
                {
                    t.inf = tr.inf;
                    tr = tr.left;
                }
            }

            public static void Delete(ref Node t, object key)
            {
                if (t == null)
                    throw new Exception("Элемент не найден");
                if (((IComparable)(t.inf)).CompareTo(key) > 0)
                    Delete(ref t.left, key);
                else if (((IComparable)(t.inf)).CompareTo(key) < 0)
                    Delete(ref t.right, key);
                else
                {
                    if (t.left == null)
                        t = t.right;
                    else if (t.right == null)
                        t = t.left;
                    else
                        Del(t, ref t.left);
                }
            }
        }

        Node tree; // ссылка на корень дерева

        // свойство для доступа к значению корня дерева
        public object Inf
        {
            set {tree.inf = value;}
            get { return tree.inf;}
        }

        // открытый конструктор класса
        public BinaryTree()
        {
            tree = null;
        }

        // закрытый конструктор класса
        private BinaryTree(Node t)
        {
            tree = t;
        }

        // метод для добавления узла в дерево
        public void Add(object inf)
        {
            Node.Add(ref tree, inf);
        }
        // организация различных способов обхода дерева
        public void Preorder()
        {
            Node.Preorder(tree);
        }
        public void Inorder()
        {
            Node.Inorder(tree);
        }
        public void Postorder()
        {
            Node.Postorder(tree);
        }

        // метод для поиска узла в дереве
        public BinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            return new BinaryTree(r);
        }

        // метод для удаления узла из дерева
        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }

        public int Order()
        {
            return Node.Order(tree);
        }
        public void PrintNodesWithDegreeOne() // вывод всех узлов со степенью 1
        {
            int cnt = 0;
            Node.PrintNodesWithDegreeOne(tree, ref cnt);
            Console.WriteLine($"\nИтоговое количество узлов: {cnt}");
        }
    }
}