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
        static Holder()
        {
            Initialize();
        }
        public static void Initialize()
        {
            SamplesNumber = 2000;
            SamplingRate = 100;
            zoomX = 0;
            zoomY = SamplesNumber;
            n0 = 1200;
            a3 = 0.997;
            a = 1;
            w = 0.03;
            l = 200;
            t = 5;
            f = 1;
            fi = 0;
            fo = 0.1;
            fn = 2;
            m = 0.5;
            fk = 0.5;
            a1 = 0;
            b1 = 1;
            average = 3;
            dispersion = 1;
            p = 2;
            q = 0;
            K = 10;
        }
        // это всё читается из файла
        public static string filename { get; set; } // имя файла
        public static int ChannelsNumber { get; set; } // количество каналов
        public static int SamplesNumber { get; set; } // количество записей
        public static float SamplingRate { get; set; } // частота
        public static string StartDate { get; set; } // начальная дата
        public static string StartTime { get; set; } // начальное время
        public static List<string> ChannelsNames { get; set; } // массив названий каналов
        public static List<float[]> table { get; set; } // массив значений каналов

        // форма2 "каналы"
        public static List<Bitmap> bbb { get; set; } // массив картинок графиков с их названиями

        // форма3 "осцилограммы"
        //public static Dictionary<string, Bitmap> Ocsillograms { get; set; } // словарь осциллограмм <название канала, картинка осциллограммы> 
        public static List<Chart> Ocsillograms { get; set; }
        public static List<ToolStripMenuItem> SubOscillogram { get; set; } // подменю "Осциллограммы" на форме1 "главное окно"
        public static int CurrentIndex { get; set; } // текущий индекс-метка, с какой осциллограммой работаем
        public static List<int> CurIndArray { get; set; }
        public static Form5 oscillo { get; set; } // форма5 "осциллограммы"
        public static Point point { get; set; } // координаты точки для определения клика правой мышью по форме2 и форме5
        public static bool flagOscillo { get; set; } // флаг для создания битмап - убрать переменную
        public static bool grid { get; set; } // флаг для создания решётки
        public static bool dots { get; set; } // флаг для создания решётки
        public static double zoomX { get; set; }
        public static double zoomY { get; set; }
        public static int check { get; set; }
        public static int n0 { get; set; }
        public static double a3 { get; set; }
        public static double a { get; set; }
        public static double w { get; set; }
        public static double fi { get; set; }
        public static double l { get; set; }
        public static double t { get; set; }
        public static double f { get; set; }
        public static double fo { get; set; }
        public static double fn { get; set; }
        public static double m { get; set; }
        public static double fk { get; set; }
        public static double T { get; set; }
        public static bool flagSamples { get; set; }
        public static bool flagRate { get; set; }
        public static int countScroll { get; set; }
        public static bool firstLoad { get; set; }
        public static int[] lastNumberModelName { get; set; }
        public static bool flagTimeXForm5 { get; set; }
        public static double a1 { get; set; }
        public static double b1 { get; set; }
        public static double average { get; set; }
        public static double dispersion { get; set; }
        public static int p { get; set; }
        public static int q { get; set; }
        public static List<double> aiList { get; set; }
        public static List<double> biList { get; set; }
        public static List<string> CheckBoxNames { get; set; }
        public static float a15 { get; set; }
        public static Statistics statistics { get; set; }
        public static int K { get; set; }
        public static double h { get; set; }
        /*public static void closeForms()
        {
            FormCollection collection = Application.OpenForms;

            foreach (Form frm in collection)
            {
                if (frm.GetType() != typeof(Form1))
                {
                    frm.Close();
                    break;
                }
            }
        }*/
        public static void closeOtherStatistics()
        {
            FormCollection collection = Application.OpenForms;

            foreach (Form frm in collection)
            {
                if (frm.GetType() == typeof(Statistics))
                {
                    frm.Close();
                    break;
                }
            }
        }
    }
}
