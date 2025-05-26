using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr21_III_14
{
    public class AVLTree
    {
        private class Node
        {
            public int inf;
            public int height;
            public Node left, rigth;

            public Node(int val)
            {
                inf = val;
                height = 1;
                left = rigth = null;
            }

            public int Height => this == null ? 0 : height;

            public int BalanceFactor
            {
                get
                {
                    int rh = rigth?.Height ?? 0;
                    int lh = left?.Height ?? 0;
                    return rh - lh;
                }
            }

            public void NewHeight()
            {
                int rh = rigth?.Height ?? 0;
                int lh = left?.Height ?? 0;
                height = (rh > lh ? rh : lh) + 1;
            }

            public static void RotationRigth(ref Node t)
            {
                Node x = t.left;
                t.left = x.rigth;
                x.rigth = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }

            public static void RotationLeft(ref Node t)
            {
                Node x = t.rigth;
                t.rigth = x.left;
                x.left = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }

            public static void Rotation(ref Node t)
            {
                t.NewHeight();
                if (t.BalanceFactor == 2)
                {
                    if (t.rigth.BalanceFactor < 0)
                    {
                        RotationRigth(ref t.rigth);
                    }
                    RotationLeft(ref t);
                }
                else if (t.BalanceFactor == -2)
                {
                    if (t.left.BalanceFactor > 0)
                    {
                        RotationLeft(ref t.left);
                    }
                    RotationRigth(ref t);
                }
            }

            public static void Add(ref Node r, int val)
            {
                if (r == null)
                {
                    r = new Node(val);
                    return;
                }
                if (val < r.inf)
                    Add(ref r.left, val);
                else
                    Add(ref r.rigth, val);

                Rotation(ref r);
            }
        }

        Node root;

        public void Add(int val)
        {
            Node.Add(ref root, val);
        }

        public int Height => root?.Height ?? 0;

        private int CountNodes(Node node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.left) + CountNodes(node.rigth);
        }

        private int GetHeight(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.left), GetHeight(node.rigth));
        }

        private bool IsPerfectlyBalanced(Node node)
        {
            if (node == null)
                return true;

            int lh = GetHeight(node.left);
            int rh = GetHeight(node.rigth);
            if (lh != rh)
                return false;

            return IsPerfectlyBalanced(node.left) && IsPerfectlyBalanced(node.rigth);
        }

        public bool IsPerfectlyBalanced()
        {
            int count = CountNodes(root);
            int h = GetHeight(root);
            return count == (1 << h) - 1 && IsPerfectlyBalanced(root);
        }

        public bool CanInsertToBalance(int val)
        {
            AVLTree copy = Clone();
            copy.Add(val);
            return copy.IsPerfectlyBalanced();
        }

        private Node CloneNode(Node node)
        {
            if (node == null) return null;
            Node newNode = new Node(node.inf)
            {
                left = CloneNode(node.left),
                rigth = CloneNode(node.rigth)
            };
            newNode.NewHeight();
            return newNode;
        }

        public AVLTree Clone()
        {
            AVLTree newTree = new AVLTree();
            newTree.root = CloneNode(root);
            return newTree;
        }

        public List<int> FindPossibleInsertValues()
        {
            List<int> result = new List<int>();
            List<int> inorderList = new List<int>();
            InOrder(root, inorderList);

            int total = inorderList.Count;
            int targetSize = NextFullTreeSize(total + 1);
            if (targetSize != total + 1)
                return result;

            for (int i = 0; i <= inorderList.Count; i++)
            {
                int minVal = (i == 0) ? inorderList[0] - 1 : inorderList[i - 1] + 1;
                int maxVal = (i == inorderList.Count) ? inorderList[^1] + 1 : inorderList[i] - 1;

                for (int candidate = minVal; candidate <= maxVal; candidate++)
                {
                    if (CanInsertToBalance(candidate))
                    {
                        result.Add(candidate);
                        break;
                    }
                }
            }
            return result;
        }

        private int NextFullTreeSize(int n)
        {
            int h = 0;
            while ((1 << h) - 1 < n) h++;
            return (1 << h) - 1;
        }

        private void InOrder(Node node, List<int> list)
        {
            if (node == null) return;
            InOrder(node.left, list);
            list.Add(node.inf);
            InOrder(node.rigth, list);
        }
    }
}
