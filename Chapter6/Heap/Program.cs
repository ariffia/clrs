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
            int[] array1 = new int[] { 1000, 9, 800, 7, 60, 5, 4, 4, 3, 2, 1 };
            Print(array1);
            Console.WriteLine();

            Console.WriteLine("After max heapify!");
            BuildMaxHeap(ref array1);
            Print(array1);
            Console.WriteLine();

            Console.WriteLine("After heapsort!");
            Heapsort(ref array1);
            Print(array1);
            Console.WriteLine();

            Console.ReadKey();
        }

        static void Heapsort(ref int[] A)
        {
            int heapSize = A.Length;
            BuildMaxHeap(ref A);
            for (int i = A.Length - 1; i >= 1; i--)  // Zero based i.
            {
                int temp = A[i];
                A[i] = A[0];
                A[0] = temp;
                heapSize -= 1;
                MaxHeapify(ref A, 0, heapSize);
            }
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

        static void MaxHeapify(ref int[] A, int index, int heapSize)  // Index is zero based.
        {
            int largest = index;  // If untouched will terminate the recursion.
            int l = Left(index);
            int r = Right(index);
            if (l < heapSize && A[l] > A[index])
            {
                largest = l;
            }
            if (r < heapSize && A[r] > A[largest])
            {
                largest = r;
            }
            if (largest != index)
            {
                int temp = A[index];
                A[index] = A[largest];
                A[largest] = temp;
                MaxHeapify(ref A, largest, heapSize);
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
