using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap
{
    internal class MinHeap
    {
        public Node root;
        private Queue<Node> queue;
        public MinHeap()
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
            while (node.parent != null && node.data < node.parent.data)
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
                if (current.right != null)
                {
                    q.Enqueue(current.right);
                }
            }
            Console.WriteLine();
        }
    }
}
