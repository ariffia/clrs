using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before");
            int[] array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Print(array1);

            Console.WriteLine("After max heapify!");
            BuildMaxHeap(ref array1);
            Print(array1);

            Console.ReadKey();
        }

        #region Heap
        static void BuildMaxHeap(ref int[] A)
        {
            for (int i = (A.Length / 2) - 1; i >= 0; i--)  // Index i is zero based.
            {
                MaxHeapify(ref A, i);
            }
        }

        static void MaxHeapify(ref int[] A, int index)  // Index is zero based.
        {
            int largest = index;  // If untouched will terminate the recursion.
            int l = Left(index);
            int r = Right(index);
            if (l < A.Length && A[l] > A[index])
            {
                largest = l;
            }
            if (r < A.Length && A[r] > A[largest])
            {
                largest = r;
            }
            if (largest != index)
            {
                int temp = A[index];
                A[index] = A[largest];
                A[largest] = temp;
                MaxHeapify(ref A, largest);
            }
        }

        static int Parent(int index)  // Zero based input.
        {
            index++;
            return (index / 2) - 1;
        }

        static int Left(int index)  // Zero based input.
        {
            index++;
            return (2 * index) - 1;
        }

        static int Right(int index)  // Zero base input.
        {
            index++;
            return (2 * index + 1) - 1;
        }
        #endregion

        static void Print(int[] A)
        {
            Console.Write("Index\t");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
            Console.Write("Value\t");
            foreach(int i in A)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
        }
    }
}
