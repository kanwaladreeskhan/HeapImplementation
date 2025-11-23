using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap();
            MinHeap heapMin = new MinHeap();
            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(5);
            heap.Insert(50);
            heap.Insert(60);
            heap.Insert(2);
            heap.Insert(45);
            heap.Display();
            heapMin.Insert(10);
            heapMin.Insert(20);
            heapMin.Insert(5);
            heapMin.Insert(50);
            heap.Insert(60);
            heapMin.Insert(2);
            heapMin.Insert(45);
            heapMin.Display();
        }
    }
}
