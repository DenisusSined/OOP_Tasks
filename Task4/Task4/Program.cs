using System;
using System.IO;
namespace Task_4
{
    class Line
    {
        private int ax;
        public int Ax
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
        private int ay;
        public int Ay
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
        private int bx;
        public int Bx
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
        private int by;
        public int By
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
        public Line(int xa, int ya, int xb, int yb) // Конструктор
        {
            Ax = xa;
            Ay = ya;
            Bx = xb;
            By = yb;
        }

        public string GetLength(int x1, int y1, int x2, int y2) // Довжина відрізка
        {
            double length = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return String.Format("{0:f1}", length);
        }
        public void GetMid(int ax, int bx, int ay, int by, out double ma, out double mb) // Середина відрізка
        {
            ma = (ax + bx) / 2.0;
            mb = (ay + by) / 2.0;
        }
        public void GetScope(int ax, int ay, int bx, int by, out int bxs, out int bys) // Масштабування відрізка
        {
            Console.WriteLine("У скільки разів потрібно масштабувати відрізок?");
            int k = Convert.ToInt32(Console.ReadLine());
            bxs = bx + (bx - ax) * (k - 1);
            bys = by + (by - ay) * (k - 1);
        }
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

            Line line = new Line(int.Parse(xytxt[0].ToString()), int.Parse(xytxt[1].ToString()), 
                                int.Parse(xytxt[2].ToString()), int.Parse(xytxt[3].ToString()));
            
            Console.WriteLine($"A[{line.Ax};{line.Ay}],B[{line.Bx};{line.By}]");
            Console.WriteLine($"Довжина AB - {line.GetLength(line.Ax, line.Ay, line.Bx, line.By)}");

            line.GetMid(line.Ax, line.Bx, line.Ay, line.By, out double ma, out double mb); // Оголошуємо вихідні змінні ma та mb
            Console.WriteLine($"Середина AB - [{ma};{mb}]");

            line.GetScope(line.Ax, line.Ay, line.Bx, line.By, out int bxs, out int bys); // Оголошуємо вихідні змінні bxs та bys
            Console.WriteLine($"Масштабований відрізок = A[{line.Ax};{line.Ay}], B[{bxs};{bys}]");

            try
            {
                using StreamWriter sw = new StreamWriter(@"D:\Унік\ООП\task4sw.txt", false, System.Text.Encoding.Default);
                sw.WriteLine($"A[{line.Ax};{line.Ay}],B[{line.Bx};{line.By}]");
                sw.WriteLine($"Довжина AB - {line.GetLength(line.Ax, line.Ay, line.Bx, line.By)}");
                sw.WriteLine($"Середина AB - [{ma};{mb}]");
                sw.WriteLine($"Масштабований відрізок = A[{line.Ax};{line.Ay}], B[{bxs};{bys}]");
            }
            catch (IOException exc)
            {
                Console.WriteLine("Помилка доступу до файлу:" + exc.Message);
                return;
            }
        }
    }
}