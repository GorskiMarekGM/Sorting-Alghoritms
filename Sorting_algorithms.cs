using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorytmy3
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 1000;
            int[] array = ArrayGenerator.GenerateRandomArray(size);

            int[] ascendingArray = ArrayGenerator.GenerateSortedAscendingArray(size);
            int[] descendingArray = ArrayGenerator.GenerateSortedDescendingArray(size);
            int[] vShapedArray = ArrayGenerator.GenerateVShapeArray(size);
            int[] constantArray = ArrayGenerator.GenerateConstantArray(size);
            int[] aShapeArray = ArrayGenerator.GenerateAShapeArray(size);

      

            Stopwatch sw = Stopwatch.StartNew();
            int high = array.Length;
            AdvancedSortingAlgorithm.QuickSort(array, 0, high - 1);
            sw.Stop();
            Console.WriteLine("Time taken random: {0}ms", sw.Elapsed.TotalMilliseconds);
            
            Stopwatch sw1 = Stopwatch.StartNew();
            AdvancedSortingAlgorithm.QuickSort(descendingArray, 0, high - 1);
            sw1.Stop();
            Console.WriteLine("Time taken desc: {0}ms", sw1.Elapsed.TotalMilliseconds);
            
            Stopwatch sw2 = Stopwatch.StartNew();
            AdvancedSortingAlgorithm.QuickSort(vShapedArray, 0, high - 1);
            sw2.Stop();
            Console.WriteLine("Time taken V: {0}ms", sw2.Elapsed.TotalMilliseconds);
            
            Stopwatch sw3 = Stopwatch.StartNew();
            AdvancedSortingAlgorithm.QuickSort(aShapeArray, 0, high - 1);
            sw3.Stop();
            Console.WriteLine("Time taken A: {0}ms", sw3.Elapsed.TotalMilliseconds);

            Stopwatch sw4 = Stopwatch.StartNew();
            AdvancedSortingAlgorithm.QuickSort(constantArray, 0, high - 1);
            sw4.Stop();
            Console.WriteLine("Time taken Const: {0}ms", sw4.Elapsed.TotalMilliseconds);



        }

        public static int[] InsertionSort(int [] array)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int temp;
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while ((j>0) && (array[j-1]> array[j]))
                {
                    temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
            }
            sw.Stop();
            Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);

            return array;
        }

        class ArrayGenerator
        {
            public static int[] GenerateRandomArray(int size)
            {
                int[] tab = new int[size];

                Random randNum = new Random();
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = randNum.Next(0, size-1);
                }

                return tab;
            }


            public static int[] GenerateSortedAscendingArray(int size)
            {
                int[] tab = new int[size];

                tab = GenerateRandomArray(size);
                //sorting an array
                Array.Sort(tab);

                return tab;

            }

            public static int[] GenerateSortedDescendingArray(int size)
            {
                int[] tab = new int[size];

                tab = GenerateRandomArray(size);
                Array.Sort(tab);
                Array.Reverse(tab);

                return tab;

            }

            public static int[] GenerateVShapeArray(int size)
            {
                int[] tab = GenerateSortedDescendingArray(size);
                int secondHalfSize = size / 2;
                int firstHalfSize = size - secondHalfSize;
                int[] firstHalfArr = new int[firstHalfSize];
                int[] secondHalfArr = new int[secondHalfSize];
                int[] vShapeArr = new int[firstHalfSize + secondHalfSize];
                int j = 0;
                int k = 0;

                for (int i = 0; i < size; i++)
                {
                    if (i % 2 == 0)
                    {
                        firstHalfArr[j] = tab[i];
                        j += 1;
                    }
                    else
                    {
                        secondHalfArr[k] = tab[i];
                        k += 1;
                    }
                }

                Array.Reverse(secondHalfArr);
                firstHalfArr.CopyTo(vShapeArr, 0);
                secondHalfArr.CopyTo(vShapeArr, firstHalfArr.Length);
                return vShapeArr;
            }

            public static int[] GenerateAShapeArray(int size)
            {
                int[] tab = GenerateSortedAscendingArray(size);
                int secondHalfSize = size / 2;
                int firstHalfSize = size - secondHalfSize;
                int[] firstHalfArr = new int[firstHalfSize];
                int[] secondHalfArr = new int[secondHalfSize];
                int[] aShapeArr = new int[firstHalfSize + secondHalfSize];

                int j = 0;
                int k = 0;
                for (int i = 0; i < size; i++)
                {
                    if (i % 2 == 0)
                    {
                        firstHalfArr[j] = tab[i];
                        j += 1;
                    }
                    else
                    {
                        secondHalfArr[k] = tab[i];
                        k += 1;
                    }
                }
                Array.Reverse(secondHalfArr);
                firstHalfArr.CopyTo(aShapeArr, 0);
                secondHalfArr.CopyTo(aShapeArr, firstHalfArr.Length);
                return aShapeArr;


            }
            public static int[] GenerateConstantArray(int size)
            {

                Random randNum = new Random();

                int constant = randNum.Next(0, 100);
                int[] tab = new int[size];
                for (int i = 0; i < size; i++)
                {
                    tab[i] = constant;
                }
                return tab;
            }
        }
    }
}
static class AdvancedSortingAlgorithm
{
    public static int partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;
        return (i + 1);
    }
    public static void QuickSort(int[] arr, int low, int high)
    {
        
        if (low < high)
        {
            int pi = partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }

    }
}
