using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    static class ArrayExtensions
    {
        public static void BubbleSort(this int[] arr)
        {
            int length = arr.Length;

            for (int j = 0; j < length;)
            {
                for (int i = 0; i < length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                        Swap(arr, i, i + 1);
                
                }

                length--;
            }
        }

        public static void SelectionSort(this int[] arr)
        {
            int index = 0;
            int i = 0;

            for (int j = 0; j < arr.Length; j++)
            {
                i = j;
                int min = arr[j];

                for (; i < arr.Length - 1; i++)
                {
                    if (min > arr[i + 1])
                    {
                        min = arr[i + 1];
                        index = i + 1;
                    }
                }

                Swap(arr, index, j);
            }
        }

        public static void InsertionSort(this int[] arr) //arr[0] > arr[1],
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {

                for (int i = j + 1;i > 0; i--)
                {
                    if (arr[i] < arr[i - 1])
                        Swap(arr, i -1, i);
                }
            }
        }

        static void Swap(this int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
