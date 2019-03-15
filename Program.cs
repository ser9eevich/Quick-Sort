using System;
using System.Linq;

namespace QuickSort
{
    public class Program
    {
        public static void Main()
        {
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
        }

        public static void Generate(int[] array)
        {
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 25);
            return;
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if ((end == start) | (array.Length == 0))
                return;
            var pivot = array[end];
            var i = start;
            for (int j = start; j <= end - 1; j++)
                if (array[j] <= pivot)
                {
                    var t1 = array[i];
                    array[i] = array[j];
                    array[j] = t1;
                    i++;
                }

            var t2 = array[i];
            array[i] = array[end];
            array[end] = t2;
            if (i > start) QuickSort(array, start, i - 1);
            if (i < end) QuickSort(array, i + 1, end);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void Test1()
        {
            int[] array = new int[3];
            Generate(array);
            QuickSort(array);
            var errorCount = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                    errorCount++;
            }
            Console.Write("Сортировка массива из 3 элементов: ");
            if (errorCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ТЕСТ НЕ ПРОЙДЕН!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ТЕСТ ПРОЙДЕН!");
            }
            Console.ResetColor();
        }

        public static void Test2()
        {
            int[] array1 = new int[100];
            int[] array2 = new int[100];
            for (int i = 0; i < array1.Length; i++)
                array1[i] = 13;
            array2 = array1;
            QuickSort(array2);
            Console.Write("Сортировка массива из 100 одинаковых чисел: ");
            if (!array2.SequenceEqual(array1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ТЕСТ НЕ ПРОЙДЕН!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ТЕСТ ПРОЙДЕН!");
            }
            Console.ResetColor();
        }

        /*
         * Сортировка массива из 1000 случайных элементов.
         *  Проверить что 10 случайных пар элементов массива после сортировки упорядочены
        */
        public static void Test3()
        {
            int[] array = new int[1000];
            Generate(array);
            QuickSort(array);
            var rnd = new Random();
            int errorCount = 0;
            for (int i = 0; i < 10; i++)
            {
                int j = rnd.Next(array.Length);
                int k = rnd.Next(array.Length);
                int a = array[j];
                int b = array[k];
                if (j == k)
                    i--;
                else if (j > k)
                {
                    if (a < b)
                        errorCount++;
                }
                else if (j < k)
                {
                    if (a > b)
                        errorCount++;
                }
            }
            Console.Write("Сортировка массива из 1000 случайных элементов: ");
            if (errorCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ТЕСТ НЕ ПРОЙДЕН!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ТЕСТ ПРОЙДЕН!");
            }
            Console.ResetColor();
        }

        public static void Test4() //Сортировка пустого массива работает корректно
        {
            int[] array = new int[0];
            Generate(array);
            QuickSort(array);
            Console.Write("Сортировка пустого массива: ");
            if (!(array.Length == 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ТЕСТ НЕ ПРОЙДЕН!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ТЕСТ ПРОЙДЕН!");
            }
            Console.ResetColor();
        }

        public static void Test5()
        {
            Console.WriteLine("В Вашем компьютере больше 8ГБ оперативной памяти?");
            Console.Write("1 - Да, 2 - Нет: ");
            int choose = Console.Read();

            if (choose == '1')
            {
                int[] array = new int[1500000000];
                Generate(array);
                QuickSort(array);

                int errorCount = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                        errorCount++;
                }

                Console.Write("Сортировка массива из 1 500 000 000 элементов: ");
                if (errorCount == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ТЕСТ НЕ ПРОЙДЕН!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ТЕСТ ПРОЙДЕН!");
                }
                Console.ResetColor();
            }
            else
                return;
        }
    }
}
