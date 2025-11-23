using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap
{
    internal class Heap
    {
        public Node root;
        private Queue<Node> queue;
        public Heap()
        {
            root = null;
            queue = new Queue<Node>();
        }
        public void Insert(int data)
        {
            Node newnode = new Node(data);
            if (root == null)
            {
                root = newnode;
                queue.Enqueue(newnode);
            }
            else
            {
                Node parent = queue.Peek();
                if (parent == null)
                {
                    parent.left = newnode;
                    newnode.parent = parent;
                }
                else if (parent.right == null)
                {
                    parent.right = newnode;
                    newnode.parent = parent;
                    queue.Dequeue();
                }
                queue.Enqueue(newnode);
                HeapifyUp(newnode);
            }
        }
        public void HeapifyUp(Node node)
        {
            while (node.parent != null && node.data > node.parent.data)
            {
                int temp = node.data;
                node.data = node.parent.data;
                node.parent.data = temp;
                node = node.parent;
            }
        }
        public void Display()
        {
            if (root == null)
            {
                Console.WriteLine("heap is empty!");
                return;
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                Node current = q.Dequeue();
                Console.WriteLine(current.data + " ");
                if (current.left != null)
                {
                    q.Enqueue(current.left);
                }
                    if(current.right != null)
                    {
                        q.Enqueue(current.right);
                    }
                }
            Console.WriteLine();
            }
        private bool Compare(int a, int b)
        {
            return isMinHeap ? a < b : a > b;
        }

        public void DeleteRoot()
        {
            if (root == null)
            {
                Console.WriteLine("Heap is empty!");
                return;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node lastNode = null;
            Node parentOfLast = null;
            while (q.Count > 0)
            {
                Node current = q.Dequeue();
                if (current.left != null)
                {
                    parentOfLast = current;
                    q.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    parentOfLast = current;
                    q.Enqueue(current.right);
                }
                lastNode = current;
            }

            if (lastNode == root)
            {
                root = null;
                return;
            }

            root.data = lastNode.data;

            if (parentOfLast.right == lastNode)
                parentOfLast.right = null;
            else
                parentOfLast.left = null;

            queue.Clear();
            BuildQueue();
            HeapifyDown(root);
        }

        private void BuildQueue()
        {
            if (root == null) return;
            Queue<Node> temp = new Queue<Node>();
            temp.Enqueue(root);
            while (temp.Count > 0)
            {
                Node current = temp.Dequeue();
                if (current.left == null || current.right == null)
                    queue.Enqueue(current);
                if (current.left != null)
                    temp.Enqueue(current.left);
                if (current.right != null)
                    temp.Enqueue(current.right);
            }
        }
        private void HeapifyDown(Node node)
        {
            while (node != null)
            {
                Node target = node;
                if (node.left != null && Compare(node.left.data, target.data))
                    target = node.left;
                if (node.right != null && Compare(node.right.data, target.data))
                    target = node.right;
                if (target == node)
                    break;
                int temp = node.data;
                node.data = target.data;
                target.data = temp;
                node = target;
            }
        }
    }
        }
    

