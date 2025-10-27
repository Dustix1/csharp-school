using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv7
{
    internal class ArrayHelper<T>
    {
        public static void Swap(T[] array, int index1, int index2)
        {
            if (index1 > array.Length - 1 || index2 > array.Length - 1)
            {
                Console.WriteLine("index out of bounds");
                return;
            }
            T buff = array[index1];
            array[index1] = array[index2];
            array[index2] = buff;
        }

        public static T[] Concat(T[] firstArray, T[] secondArray)
        {
            T[] newArr = new T[firstArray.Length + secondArray.Length];

            int newArrIdx = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                newArr[newArrIdx] = firstArray[i];
                newArrIdx++;
            }

            for (int i = 0; i < secondArray.Length; i++)
            {
                newArr[newArrIdx] = secondArray[i];
                newArrIdx++;
            }

            return newArr;
        }
    }
}
