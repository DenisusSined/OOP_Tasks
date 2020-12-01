using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Task7
{
    enum WeatherType { not_specified, rain, small_rain, thunderstorm, snow, fog, darkly, sunny }
    class Program
    {
        public static List<int> ReadFile(string fileName)  // Зчитування показників з файлу
        {
            string file_str = null;
            List<int> file_list = new List<int>();
            List<string> file_list_str = new List<string>();

            try 
            {
                StreamReader sr = new StreamReader(fileName);
                file_str = sr.ReadLine();
                sr.Close();
            }
            catch (IOException exc)
            {
                Console.WriteLine("Помилка доступу до файлу: " + exc.Message);
            }
            file_list = file_str.Split(' ').Select(file_str => Convert.ToInt32(file_str)).ToList();
            return file_list;
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            List<int> tPerDay_arr = ReadFile(@"D:\Унік\ООП\task7files\task7tPerDay.txt");
            List<int> tPerNight_arr = ReadFile(@"D:\Унік\ООП\task7files\task7tPerNight.txt");
            List<int> atmPress_arr = ReadFile(@"D:\Унік\ООП\task7files\task7atmPress.txt");
            List<int> watFall_arr = ReadFile(@"D:\Унік\ООП\task7files\task7watFall.txt");
            WeatherType[] wType_arr = (WeatherType[])Enum.GetValues(typeof(WeatherType));
            Random rnd = new Random();
            List<WeatherParametersDay> days = new List<WeatherParametersDay>();
            for (int i = 0; i < 30; i++)
            {
                days.Add(new WeatherParametersDay(tPerDay_arr[i], tPerNight_arr[i], atmPress_arr[i], 
                    watFall_arr[i], wType_arr[rnd.Next(0, 8)]));
            }
            WeatherDays weatherDays = new WeatherDays(days);
            Console.WriteLine($"Туманних днів - {weatherDays.FogDays}\nДнів без опадів - {weatherDays.DryDays}\n" +
                $"Максимальний тиск - {weatherDays.MaxPress}\nМінімальний тиск - {weatherDays.MinPress}");
        }
    }
    class WeatherDays
    {
        List<WeatherParametersDay> days = new List<WeatherParametersDay>();
        private int minPress = 0;
        public int MinPress
        {
            get { return minPress; }
            set { minPress = value; }
        }
        private int maxPress = 0;
        public int MaxPress
        {
            get { return maxPress; }
            set { maxPress = value; }
        }
        private int fogDays = 0;
        public int FogDays
        {
            get { return fogDays; }
            set { fogDays = value; }
        }
        private int dryDays = 0;
        public int DryDays
        {
            get { return dryDays; }
            set { dryDays = value; }
        }
        public WeatherDays(List<WeatherParametersDay> days)
        {
            this.days = days;
            Check();
        }
        public void CountFogDays()
        {
            foreach (WeatherParametersDay weatherPD in days)
            {
                if (weatherPD.WType == WeatherType.fog)
                {
                    FogDays++;
                }
            }
        }
        public void CountDryDays()
        {
            foreach (WeatherParametersDay weatherPD in days)
            {
                if (weatherPD.WType != WeatherType.rain && weatherPD.WType != WeatherType.thunderstorm && weatherPD.WType != WeatherType.small_rain)
                {
                    DryDays++;
                }
            }
        }
        public void MaxMinPress()
        {
            maxPress = days[0].AtmPress;
            minPress = days[0].AtmPress;
            foreach (WeatherParametersDay elem in days)
            {
                if (elem.AtmPress < minPress)
                {
                    minPress = elem.AtmPress;
                }
                else if (elem.AtmPress > maxPress)
                {
                    maxPress = elem.AtmPress;
                }
            }
        }
        public void Check()
        {
            MaxMinPress();
            CountFogDays();
            CountDryDays();
        }
    }
    class WeatherParametersDay
    {
        public WeatherParametersDay(int a, int b, int c, int d, WeatherType e)
        {
            tPerDay = a;
            tPerNight = b;
            atmPress = c;
            watFall = d;
            wType = e;
        }
        private int tPerDay;
        public int TPerDay
        {
            get { return tPerDay; }
            set { tPerDay = value; }
        }
        private int tPerNight;
        public int TPerNight
        {
            get { return tPerNight; }
            set { tPerNight = value; }
        }
        private int atmPress;
        public int AtmPress
        {
            get { return atmPress; }
            set { atmPress = value; }
        }
        private int watFall;
        public int WatFall
        {
            get { return watFall; }
            set { watFall = value; }
        }
        private WeatherType wType;
        public WeatherType WType
        {
            get { return wType; }
            set { wType = value; }
        }
    }
}
