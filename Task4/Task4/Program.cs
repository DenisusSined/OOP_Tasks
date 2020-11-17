using System;
using System.IO;
namespace Task_4
{
    static class Line
    {
        private static int ax;
        public static int Ax
        {
            get
            {
                return ax;
            }
            set
            {
                ax = value;
            }
        }
        private static int ay;
        public static int Ay
        {
            get
            {
                return ay;
            }
            set
            {
                ay = value;
            }
        }
        private static int bx;
        public static int Bx
        {
            get
            {
                return bx;
            }
            set
            {
                bx = value;
            }
        }
        private static int by;
        public static int By
        {
            get
            {
                return by;
            }
            set
            {
                by = value;
            }
        }
        private static double s;
        public static double S
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }

        private static double llength;
        public static double Llength
        {
            get
            {
                return llength;
            }
            set
            {
                llength = value;
            }
        }
        public static string GetLength(int x1,int y1, int x2, int y2) // Довжина відрізка
        {
            llength = Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2));
            return String.Format("{0:f1}", llength);
        }
        public static void GetMid(int ax, int bx, int ay, int by, out double ma, out double mb) // Середина відрізка
        {
            ma = (ax + bx) / 2.0;
            mb = (ay + by) / 2.0;
        }
        public static void GetScope(int ax, int ay, int bx, int by, out int bxs, out int bys) // Масштабування відрізка
        {
            Console.WriteLine("У скільки разів потрібно масштабувати відрізок?");
            int k = Convert.ToInt32(Console.ReadLine());
            bxs = bx + (bx - ax) * (k - 1);
            bys = by + (by - ay) * (k - 1);
        }
        class Program
        {
            static void Main()
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.InputEncoding = System.Text.Encoding.Unicode;
                string xytxt;
                try
                {
                    StreamReader sr = new StreamReader(@"D:\Унік\ООП\task4sr.txt");
                    xytxt = sr.ReadLine();
                    sr.Close();
                    Console.WriteLine(xytxt);

                }
                catch (IOException exc)
                {
                    Console.WriteLine("Помилка доступу до файлу:" + exc.Message);
                    return;
                }
                for (int i = 0; i < xytxt.Length; i++)
                {
                    ax = int.Parse(xytxt[0].ToString());
                    ay = int.Parse(xytxt[1].ToString());
                    bx = int.Parse(xytxt[2].ToString());
                    by = int.Parse(xytxt[3].ToString());
                }
                Console.WriteLine($"A[{ax};{ay}],B[{bx};{by}]");
                Console.WriteLine($"Довжина AB - {GetLength(ax, ay, bx, by)}");
                GetMid(ax, bx, ay, by, out double ma, out double mb); // Оголошуємо вихідні змінні ma та mb
                Console.WriteLine($"Середина AB - [{ma};{mb}]");
                GetScope(ax, ay, bx, by, out int bxs, out int bys); // Оголошуємо вихідні змінні bxs та bys
                Console.WriteLine($"Масштабований відрізок = A[{ax};{ay}], B[{bxs};{bys}]");

                try
                {
                    using StreamWriter sw = new StreamWriter(@"D:\Унік\ООП\task4sw.txt", false, System.Text.Encoding.Default);
                    sw.WriteLine($"A[{ax};{ay}],B[{bx};{by}]");
                    sw.WriteLine($"Довжина AB - {GetLength(ax, ay, bx, by)}");
                    sw.WriteLine($"Середина AB - [{ma};{mb}]");
                    sw.WriteLine($"Масштабований відрізок = A[{ax};{ay}], B[{bxs};{bys}]");
                }
                catch (IOException exc)
                {
                    Console.WriteLine("Помилка доступу до файлу:" + exc.Message);
                    return;
                }
            }
        }       
    }
}