using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
        public static string filename { get; set; }
        public static int ChannelsNumber { get; set; }
        public static int SamplesNumber { get; set; }
        public static float SamplingRate { get; set; }
        public static string StartDate { get; set; }
        public static string StartTime { get; set; }
        public static string[] ChannelsNames { get; set; }
        public static float[][] table { get; set; }
        public static Bitmap[] bbb { get; set; }
        public static List<Bitmap> Ocsillograms { get; set; }
        public static System.Windows.Forms.ToolStripMenuItem[] SubOscillogram { get; set; }
        public static int CurrentIndex { get; set; }
    }
}
