using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    class Ar
    {
        Random rand = new Random();

        int key;
        int n;
        int m;
        public int SetSizeN()
        {
            Console.WriteLine("Введіть кількість рядків масиву:");
            string l = Console.ReadLine();
            if (Int32.TryParse(l, out n))
            {
                return n;
            }
            else
            {
                Console.WriteLine($"Введіть символ типу int.");
                n = SetSizeN();
            }
            return n;
        }
        public int SetSizeM()
        {
            Console.WriteLine("Введіть кількість стовпців масиву:");
            string c = Console.ReadLine();
            if (Int32.TryParse(c, out m))
            {
                return m;
            }
            else
            {
                Console.WriteLine($"Введіть символ типу int.");
                m = SetSizeN();
            }
            return m;
        }

        private int[,] arr;
        Dictionary<int, int> elements;

        public int SetKey()
        {
            Console.WriteLine("Введіть ключ:");
            string x = Console.ReadLine();

            if (Int32.TryParse(x, out key))
            {
                if (key < 1 || key > n * m)
                {
                    Console.WriteLine($"Такого ключа як {key} не існує.");
                    key = SetKey();
                }
            }
            else
            {
                Console.WriteLine($"Такого ключа як {x} не існує.");
                key = SetKey();
            }
            return key;
        }
        public int[,] ArrRandInp()
        {
            arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rand.Next(1,40);
                    Console.Write("{0,3}", $"[{arr[i, j]}]");
                }
                Console.WriteLine();
            }
            return arr;
        }
        public Dictionary<int, int> ArrToDict()
        {
            elements = new Dictionary<int, int>(n * m);
            int z = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    elements.Add(z, arr[i, j]);
                    z++;
                }
            }
            Console.WriteLine($"ключ - елемент");
            foreach (KeyValuePair<int, int> keyValue in elements)
            {
                Console.WriteLine($"{keyValue.Key} - [{keyValue.Value}]");
            }
            return elements;
        }
        public void GetSum()
        {
            int max, min;
            int[] arrsum = new int[n];
            for (int i = 0; i < n; i++)
            {
                max = arr[i, 0];
                min = arr[i, 0];

                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
                }
                arrsum[i] = max + min;
                Console.WriteLine($"Сума мінімального та максимального елемента в {i + 1}му рядку - {arrsum[i]}");
            }

        }


        public void GetElement()
        {
            int el = SetKey();
            Console.WriteLine($"{el} - [{elements[el]}]");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Ar massive = new Ar();

            massive.SetSizeN();
            massive.SetSizeM();
            massive.ArrRandInp();
            massive.ArrToDict();
            massive.GetElement();
            massive.GetSum();
        }
    }
}
