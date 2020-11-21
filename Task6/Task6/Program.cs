using System;
using System.Collections.Generic;

namespace Task6
{
    class Arr
    {
        Random rand = new Random();

        private int key;
        public int Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }
        private int n;
        public int N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }
        private int m;
        public int M
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }
        public int SetSizeN()
        {
            Console.WriteLine("Введіть кількість рядків масиву:");
            string r = Console.ReadLine();
            if (Int32.TryParse(r, out n))
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
            Console.WriteLine("Введіть кількість рядків масиву:");
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
        public int SetKey()
        {
            Console.WriteLine("Введіть ключ:");
            string x = Console.ReadLine(); 
             
            if (Int32.TryParse(x, out key))
            {
                if (key < 1)
                {
                    Console.WriteLine($"Такого ключа як {key} не існує.");
                    key = SetKey();
                }
                else if (key > n * m)
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
        public int[,] ArrRandInp(int[,] arr)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rand.Next(40);
                    Console.Write("{0,3}", $"[{arr[i, j]}]");
                }
                Console.WriteLine();
            }
            return arr;
        }
        public Dictionary<int,int> ArrToDict(Dictionary<int,int> elements,int[,] arr)
        {
            int z = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    elements.Add(z,arr[i, j]);
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
        public void GetElement(Dictionary<int, int> elements)
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
            Arr massive = new Arr();

            massive.SetSizeN();

            massive.SetSizeM();
            int[,] arr = new int[massive.N, massive.M];

            Dictionary<int, int> elements = new Dictionary<int, int>(massive.N * massive.M);

            massive.ArrRandInp(arr);
            massive.ArrToDict(elements, arr);
            massive.GetElement(elements);
        }
    }
}
