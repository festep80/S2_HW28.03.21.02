//2. Визначити методи для роботи з одновимірним масивом
//	- отримує 2 одновимірні масиви та повертає масив, що містить елементи обох масивів(для копіювання елементів можна скористатися методом CopyTo, arr.CopyTo(arr2, position))
//	- отримує 2 одновимірні масиви та повертає масив з спільними елементами(без повторів)
//	- отримує 2 одновимірні масиви та повертає масив, що містить елементи першого масиву, що НЕ зустрічаються у другому

//Для розв'язування задач можна скористатися методами класу Array: 
//      Array.IndexOf(arr, elem) - знаходження індекса шуканого елемента
//      Array.Resize(ref arr, newSize) - зміна розміру масиву

using System;
using System.Linq;

namespace S2_HW28._03._21._02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[5];
            int[] arr2 = new int[5];
            Fill(arr1, 1, 10);
            Fill(arr2, 1, 10);
            Print(arr1);
            Print(arr2);
            Print(CopyArrToArr(arr1, arr2));
            Print(ArrCommonElement(arr1, arr2));
            Print(ArrFirstCommonInSecond(arr1, arr2));

        }

        private static int[] ArrFirstCommonInSecond(int[] arr1, int[] arr2)
        {
            int[] arr3 = new int[1];
            foreach (var i in arr1)
            {
                int common = 0;
                foreach (var j in arr2)
                {
                    if(i==j)
                    {
                        common++;
                    }
                    
                }
                if(common==0)
                {
                    arr3[arr3.Length - 1] = i;
                    if (Array.IndexOf(arr1, i) != arr1.Length - 1)
                    {
                        Array.Resize(ref arr3, arr3.Length + 1);
                    }
                    
                }                
            }
            return arr3;
        }

        private static int[] ArrCommonElement(int[] arr1, int[] arr2)
        {
            int[] arr3 = new int[1];
            arr3[0] = arr1[0];
            foreach (var i in arr1)
            {
                int common = 0;
                foreach (var j in arr3)
                {                    
                    if(i==j)
                    {
                        common++;
                    }
                }
                if (common == 0)
                {
                    Array.Resize(ref arr3, arr3.Length + 1);
                    arr3[arr3.Length-1] = i;
                }
            }
            foreach (var i in arr2)
            {
                int common = 0;
                foreach (var j in arr3)
                {
                    if (i == j)
                    {
                        common++;
                    }
                }
                if (common == 0)
                {
                    Array.Resize(ref arr3, arr3.Length + 1);
                    arr3[arr3.Length - 1] = i;
                }
            }
            return arr3;
        }

        private static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n=============================\n");
        }

        private static int[] CopyArrToArr(int[] arr1, int[] arr2)
        {
            int[] arr3 = new int[arr1.Length + arr2.Length];
            arr1.CopyTo(arr3, 0);
            arr2.CopyTo(arr3, arr1.Length);
            return arr3;
        }

        private static void Fill(int[] arr, int start, int end)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(start, end);
            }
        }
    }
}
