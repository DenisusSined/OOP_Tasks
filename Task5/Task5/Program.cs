using System;
using System.IO;
using System.Numerics;
using System.Reflection.PortableExecutable;

namespace task5
{
    class Arrays
    {
        public int[] arr;
        public Arrays(int[] a)  //конструктор
        {
            arr = a;
        }
        public int Check_xi(int xi)
        {
            if (xi % 2 == 0)
            {
                xi = xi - 8;
            }
            return xi;
        }
        public int Check_zi(int xi, int yi)
        {
            int zi = Convert.ToInt32(Math.Pow(Convert.ToDouble(yi), 2) - Math.Pow(Convert.ToDouble(xi), 2));
            return zi;

        }
        public void Getarrays(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"[{array[i]}]");
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string xt, yt;
            try
            {
                StreamReader xsr = new StreamReader(@"D:\Унік\ООП\task5x.txt");
                xt = xsr.ReadLine();
                xsr.Close();
                Console.WriteLine(xt);
                StreamReader ysr = new StreamReader(@"D:\Унік\ООП\task5y.txt");
                yt = ysr.ReadLine();
                ysr.Close();
                Console.WriteLine(yt);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Помилка доступу до файлу:" + exc.Message);
                return;
            }

            int[] array_x = new int[xt.Length];
            int[] array_y = new int[yt.Length];
            int[] array_z = new int[xt.Length];

            for (int i = 0; i < xt.Length; i++)
            {
                array_x[i] = int.Parse(xt[i].ToString());
            }

            for (int i = 0; i < yt.Length; i++)
            {
                array_y[i] = int.Parse(yt[i].ToString());
            }

            Arrays x = new Arrays(array_x);
            Arrays y = new Arrays(array_y);
            Arrays z = new Arrays(array_z);

            for (int i = 0; i < x.arr.Length; i++)
            {
                x.arr[i] = x.Check_xi(x.arr[i]);
            };

            for (int i = 0; i < z.arr.Length; i++)
            {
                z.arr[i] = z.Check_zi(x.arr[i], y.arr[i]);
            }

            Console.WriteLine("Масив Х:");
            x.Getarrays(x.arr);
            Console.WriteLine("Масив Y:");
            y.Getarrays(y.arr);
            Console.WriteLine("Масив Z:");
            z.Getarrays(z.arr);

            string path = @"D:\Унік\ООП\task5.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Масив Х:");
                    foreach (int i in x.arr)
                    {
                        sw.Write($"[{i}];");
                    }
                    sw.WriteLine();
                    sw.WriteLine("Масив Y:");
                    foreach (int i in y.arr)
                    {
                        sw.Write($"[{i}];");
                    }
                    sw.WriteLine();
                    sw.WriteLine("Масив Z:");
                    foreach (int i in z.arr)
                    {
                        sw.Write($"[{i}];");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
