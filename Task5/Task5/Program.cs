using System;
using System.IO;
namespace task5
{
    static class Arrays
    {
        private static int[] arrx;
        public static int[] Arrx
        {
            get
            {
                return arrx;
            }
            set
            {
                arrx = value;
            }
        }

        private static int[] arry;
        public static int[] Arry
        {
            get
            {
                return arry;
            }
            set
            {
                arry = value;
            }
        }

        private static int[] arrz;
        public static int[] Arrz
        {
            get
            {
                return arrz;
            }
            set
            {
                arrz = value;
            }
        }

        public static int[] Check_x(int[] arrx)
        {
            for (int i = 0; i < arrx.Length; i++)
            {
                if (arrx[i] % 2 == 0)
                {
                    arrx[i] -= 8;
                }
            }
            return arrx;
        }
        public static int[] Check_z(int[] arrx, int[] arry)
        {

            for (int i = 0; i < arrx.Length; i++)
            {
                arrz[i] = Convert.ToInt32(Math.Pow(Convert.ToDouble(arry[i]), 2) - Math.Pow(Convert.ToDouble(arrx[i]), 2));
            }
            return arrz;
        }
        public static void Getarrays(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"[{arr[i]}]");
            }
            Console.WriteLine();
        }

        class Program
        {
            static void Main()
            {
                string xt, yt;
                try // Зчитування з файлу
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
                arrx = new int[xt.Length];
                arry = new int[xt.Length];
                arrz = new int[xt.Length];

                for (int i = 0; i < xt.Length; i++)
                {
                    arrx[i] = int.Parse(xt[i].ToString());
                }

                for (int i = 0; i < yt.Length; i++)
                {
                    arry[i] = int.Parse(yt[i].ToString());
                }
                Check_x(arrx);
                Check_z(arrx, arry);

                Console.WriteLine("Масив Х:");
                Getarrays(arrx);
                Console.WriteLine("Масив Y:");
                Getarrays(arry);
                Console.WriteLine("Масив Z:");
                Getarrays(arrz);

                try // Запис у файл
                {
                    using StreamWriter sw = new StreamWriter(@"D:\Унік\ООП\task5.txt", false, System.Text.Encoding.Default);
                    sw.WriteLine("Масив Х:");
                    foreach (int i in arrx)
                    {
                        sw.Write($"[{i}];");
                    }
                    sw.WriteLine();
                    sw.WriteLine("Масив Y:");
                    foreach (int i in arry)
                    {
                        sw.Write($"[{i}];");
                    }
                    sw.WriteLine();
                    sw.WriteLine("Масив Z:");
                    foreach (int i in arrz)
                    {
                        sw.Write($"[{i}];");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
