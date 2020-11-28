using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Task7
{
    enum WeatherType { not_specified, rain, small_rain, thunderstorm, snow, fog, darkly, sunny }

    class Functions
    {
        public int[] ConvertToArray(string txtline)
        {
            string[] string_arr = txtline.Split(' ');
            int[] arr = new int[31];
            Console.WriteLine();
            for (int i = 0; i < 31; i++)
            {
                arr[i] = int.Parse(string_arr[i]);
                Console.Write($"[{arr[i]}]");
            }
            return arr;
        }
        public string[] Convert_wType(string txtline)
        {
            string[] string_arr = txtline.Split(' ');
            Console.WriteLine();
            for (int i = 0; i < 31; i++)
            {
                Console.Write($"[{string_arr[i]}]");
            }
            return string_arr;
        }
        
        
        
        
    }

    class WeatherParametersDay
    {
        
        int tPerDay;
        int tPerNight;
        int atmPress;
        int watFall;
        WeatherType wType;
       

        public WeatherParametersDay(int p1, int p2, int p3, int p4, WeatherType wt)
        {
            tPerDay = p1;
            tPerNight = p2;
            atmPress = p3;
            watFall = p4;
            wType = wt;
        }
    }
    class WeatherDays
    {
        public void SetToFiles()
        {
            Random rand = new Random();
            try // Введення у файл
            {
                using StreamWriter w1 = new StreamWriter(@"D:\Унік\ООП\task7files\task7tPerDay.txt", false, System.Text.Encoding.Default);
                for(int i = 0; i < 31; i++)
                {
                    w1.Write($"{rand.Next(20,31)} ");
                }

                using StreamWriter w2 = new StreamWriter(@"D:\Унік\ООП\task7files\task7tPerNight.txt", false, System.Text.Encoding.Default);
                for (int i = 0; i < 31; i++)
                {
                    w2.Write($"{rand.Next(15, 26)} ");
                }

                using StreamWriter w3 = new StreamWriter(@"D:\Унік\ООП\task7files\task7atmPress.txt", false, System.Text.Encoding.Default);
                for (int i = 0; i < 31; i++)
                {
                    w3.Write($"{rand.Next(1000, 1100)} ");
                }

                using StreamWriter w4 = new StreamWriter(@"D:\Унік\ООП\task7files\task7watFall.txt", false, System.Text.Encoding.Default);
                for (int i = 0; i < 31; i++)
                {
                    w4.Write($"{rand.Next(5, 10)} ");
                }

                using StreamWriter w5 = new StreamWriter(@"D:\Унік\ООП\task7files\task7wType.txt", false, System.Text.Encoding.Default);
               
                Array values = Enum.GetValues(typeof(WeatherType));
                Random random = new Random();
                for (int i = 0; i < 31; i++)
                {
                    WeatherType weatherType = (WeatherType)values.GetValue(random.Next(values.Length));
                    w5.Write($"{weatherType} ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        int[] tPerDay_arr;
        public int[] TPerDay_arr
        {
            get { return tPerDay_arr; }
            set { tPerDay_arr = value; }
        }
        int[] tPerNight_arr;
        public int[] TPerNight_arr
        {
            get { return tPerNight_arr; }
            set { tPerNight_arr = value; }
        }
        int[] atmPress_arr;
        public int[] AtmPress_arr
        {
            get { return atmPress_arr; }
            set { atmPress_arr = value; }
        }
        int[] watFall_arr;
        public int[] WatFall_arr
        {
            get { return watFall_arr; }
            set { watFall_arr = value; }
        }
        WeatherType[] wType_arr;


        List<WeatherParametersDay> days = new List<WeatherParametersDay>();

        public void GetFromFiles()
        {
           
            string tPerDayTXT, tPerNightTXT, atmPressTXT, watFallTXT, wTypeTXT;
            try // Зчитування показників з файлу
            {
                StreamReader r1 = new StreamReader(@"D:\Унік\ООП\task7files\task7tPerDay.txt");
                tPerDayTXT = r1.ReadLine();
                r1.Close();
                Console.WriteLine(tPerDayTXT);

                StreamReader r2 = new StreamReader(@"D:\Унік\ООП\task7files\task7tPerNight.txt");
                tPerNightTXT = r2.ReadLine();
                r2.Close();
                Console.WriteLine(tPerNightTXT);

                StreamReader r3 = new StreamReader(@"D:\Унік\ООП\task7files\task7atmPress.txt");
                atmPressTXT = r3.ReadLine();
                r3.Close();
                Console.WriteLine(atmPressTXT);

                StreamReader r4 = new StreamReader(@"D:\Унік\ООП\task7files\task7watFall.txt");
                watFallTXT = r4.ReadLine();
                r4.Close();
                Console.WriteLine(watFallTXT);

                StreamReader r5 = new StreamReader(@"D:\Унік\ООП\task7files\task7wType.txt");
                wTypeTXT = r5.ReadLine();
                r5.Close();
                Console.WriteLine(wTypeTXT);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Помилка доступу до файлу:" + exc.Message);
                return;
            }
            Functions func = new Functions();
            
            tPerDay_arr = func.ConvertToArray(tPerDayTXT);
            tPerNight_arr = func.ConvertToArray(tPerNightTXT);
            atmPress_arr = func.ConvertToArray(atmPressTXT);
            watFall_arr = func.ConvertToArray(watFallTXT);
            wType_arr = (WeatherType[])Enum.GetValues(typeof(WeatherType));

            Random rand = new Random();
            for (int i = 0; i < 31; i++)
            {
                days.Add(new WeatherParametersDay(tPerDay_arr[i], tPerNight_arr[i], atmPress_arr[i], watFall_arr[i], wType_arr[rand.Next(0, 8)]));
            }
        }
        public void GetFogDays()
        {
            
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            WeatherDays weatherDays = new WeatherDays();
            Functions func = new Functions();
            weatherDays.SetToFiles();
            weatherDays.GetFromFiles();

        }
    }
}
