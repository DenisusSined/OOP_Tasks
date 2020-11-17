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
            string result = String.Format("{0:f1}", llength);
            return result;
        }
        public static double GetMid(int x, int y) // Середина відрізка
        {
            s = (x + y) / 2.0;
            return s;
        }
        public static int[] GetScope(int ax, int ay, int bx, int by) // Масштабування відрізка
        {
            Console.WriteLine("У скільки разів потрібно масштабувати відрізок?");
            int k = Convert.ToInt32(Console.ReadLine());
            int bxs = bx + (bx - ax) * (k - 1);
            int bys = by + (by - ay) * (k - 1);
            int[] scopedb = {bxs, bys};
            return scopedb;
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
                Console.WriteLine($"Середина AB - [{GetMid(ax, bx)};{GetMid(ay, by)}]");
                int[] scopedb = GetScope(ax, ay, bx, by);
                Console.WriteLine($"Масштабований відрізок = A[{ax};{ay}], B[{scopedb[0]};{scopedb[1]}]");

                try
                {
                    using StreamWriter sw = new StreamWriter(@"D:\Унік\ООП\task4sw.txt", false, System.Text.Encoding.Default);
                    sw.WriteLine($"A[{ax};{ay}],B[{bx};{by}]");
                    sw.WriteLine($"Довжина AB - {GetLength(ax, ay, bx, by)}");
                    sw.WriteLine($"Середина AB - [{GetMid(ax, bx)};{GetMid(ay, by)}]");
                    sw.WriteLine($"Масштабований відрізок = A[{ax};{ay}], B[{scopedb[0]};{scopedb[1]}]");
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