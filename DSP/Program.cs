using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace DSP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class Holder
    {
        // это всё читается из файла
        public static string filename { get; set; } // имя файла
        public static int ChannelsNumber { get; set; } // количество каналов
        public static int SamplesNumber { get; set; } // количество записей
        public static float SamplingRate { get; set; } // частота
        public static string StartDate { get; set; } // начальная дата
        public static string StartTime { get; set; } // начальное время
        public static string[] ChannelsNames { get; set; } // массив названий каналов
        public static float[][] table { get; set; } // массив значений каналов

        // форма2 "каналы"
        public static Bitmap[] bbb { get; set; } // массив картинок графиков с их названиями

        // форма3 "осцилограммы"
        //public static Dictionary<string, Bitmap> Ocsillograms { get; set; } // словарь осциллограмм <название канала, картинка осциллограммы> 
        public static List<Chart> Ocsillograms { get; set; }
        public static ToolStripMenuItem[] SubOscillogram { get; set; } // подменю "Осциллограммы" на форме1 "главное окно"
        public static int CurrentIndex { get; set; } // текущий индекс-метка, с какой осциллограммой работаем
        public static List<int> CurIndArray { get; set; }
        public static Form5 oscillo { get; set; } // форма5 "осциллограммы"
        public static Point point { get; set; } // координаты точки для определения клика правой мышью по форме2 и форме5
        public static bool flagOscillo { get; set; } // флаг для создания битмап - убрать переменную
        public static bool grid { get; set; } // флаг для создания решётки
        public static bool dots { get; set; } // флаг для создания решётки
    }
}
