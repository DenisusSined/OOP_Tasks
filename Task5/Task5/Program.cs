using System;
using System.IO;
namespace task5
{
    class Arrays
    {
        public int[] Check_x(int[] arrx) // Метод для зміни масиву Х
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
        public int[] Check_z(int[] arrx, int[] arry,int[] arrz) // Метод для створення масиву Z
        {

            for (int i = 0; i < arrx.Length; i++)
            {
                arrz[i] = Convert.ToInt32(Math.Pow(Convert.ToDouble(arry[i]), 2) - Math.Pow(Convert.ToDouble(arrx[i]), 2));
            }
            return arrz;
        }
        public void Getarrays(int[] arr) // Метод для виведення масивів в консоль
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"[{arr[i]}]");
            }
            Console.WriteLine();
        }  
    }
    class Program
    {
        static void Main()
        {
            string xt, yt;
            try // Зчитування масивів з файлу
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

            Arrays arr = new Arrays(); // Cтворення об'єкта класу Arrays

            int[] x = new int[xt.Length]; // Створення масивів x, y, z
            int[] y = new int[yt.Length];
            int[] z = new int[xt.Length];

            for (int i = 0; i < xt.Length; i++) // З xt i yt передаємо значення елементам масивів x та y
            {
                x[i] = Convert.ToInt32(Convert.ToString(xt[i]));
            }
            for (int i = 0; i < yt.Length; i++)
            {
                y[i] = Convert.ToInt32(Convert.ToString(yt[i]));
            }

            arr.Check_x(x);
            arr.Check_z(x, y, z); // Використання методів

            Console.WriteLine("Масив Х:");
            arr.Getarrays(x);
            Console.WriteLine("Масив Y:");
            arr.Getarrays(y);
            Console.WriteLine("Масив Z:");
            arr.Getarrays(z);

            try // Виведення у файл
            {
                using StreamWriter sw = new StreamWriter(@"D:\Унік\ООП\task5.txt", false, System.Text.Encoding.Default);
                sw.WriteLine("Масив Х:");
                foreach (int i in x)
                {
                    sw.Write($"[{i}];");
                }
                sw.WriteLine();
                sw.WriteLine("Масив Y:");
                foreach (int i in y)
                {
                    sw.Write($"[{i}];");
                }
                sw.WriteLine();
                sw.WriteLine("Масив Z:");
                foreach (int i in z)
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
