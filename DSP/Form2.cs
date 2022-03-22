using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;

namespace DSP
{
    public partial class Form2 : Form
    {
        string[] array;
        System.Drawing.Bitmap[] bbb;
        public int ChannelsNumber;
        public int SamplesNumber;
        public float SamplingRate;
        public string StartDate;
        public string StartTime;
        public string[] ChannelsNames;

        public Form2(string[] arr)
        {
            InitializeComponent();
            array = arr;
        }

        private void MapRectangles(Graphics gr,
             float wxmin, float wxmax, float wymin, float wymax,
             float dxmin, float dxmax, float dymin, float dymax)
        {
            RectangleF wrectf;
            if (wymax - wymin != 0)
            {
                wrectf = new RectangleF(wxmin, wymin, wxmax - wxmin, wymax - wymin);
            }
            else
            {
                wrectf = new RectangleF(wxmin, wymin * 10000, wxmax - wxmin, wxmax - wxmin);
            }
            PointF[] dpts = {
                 new PointF(dxmin, dymin),
                 new PointF(dxmax, dymin),
                 new PointF(dxmin, dymax)
            };
            gr.Transform = new Matrix(wrectf, dpts);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ChannelsNumber = int.Parse(array[1]);
            SamplesNumber = int.Parse(array[3]);
            SamplingRate = float.Parse(array[5], CultureInfo.InvariantCulture.NumberFormat);
            StartDate = array[7];
            StartTime = array[9];
            ChannelsNames = new string[ChannelsNumber];
            string s = "";
            int k = 0;
            for (int i = 0; i < array[11].Length; i++)
            {
                if (array[11][i] != ';')
                {
                    s += array[11][i];
                }
                if (array[11][i] == ';' || i == array[11].Length - 1)
                {
                    ChannelsNames[k] = s;
                    s = "";
                    k++;
                }
            }

            float[][] table = new float[ChannelsNumber][];
            for (int i = 0; i < ChannelsNumber; i++)
            {
                table[i] = new float[SamplesNumber];
            }
            for (int i = 12; i < SamplesNumber + 12; i++)
            {
                k = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != ' ')
                    {
                        s += array[i][j];
                    }
                    if (array[i][j] == ' ' || j == array[i].Length - 1)
                    {
                        table[k][i - 12] = float.Parse(s, CultureInfo.InvariantCulture.NumberFormat);
                        s = "";
                        k++;
                    }
                }
            }

            Array.Clear(array, 0, array.Length);

            bbb = new System.Drawing.Bitmap[ChannelsNumber];
            for (int i = 0; i < ChannelsNumber; i++)
            {
                Graphics graphicsObj;
                if (ChannelsNumber < 3)
                {
                    this.Height = this.ClientSize.Height / 3;
                }
                bbb[i] = new Bitmap(this.ClientRectangle.Width,
                                    this.ClientRectangle.Height / ChannelsNumber,
                                   System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                graphicsObj = Graphics.FromImage(bbb[i]);
                graphicsObj.Clear(Color.White);

                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Blue);
                float x = this.ClientSize.Width / 2;
                float y = this.ClientSize.Height / ChannelsNumber - 20;
                graphicsObj.DrawString(ChannelsNames[i], drawFont, drawBrush, x, y);

                graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
                float MIN_SAMPLE = 0;
                float MAX_SAMPLE = SamplesNumber;
                float MIN_LEVEL = table[i].Min();
                float MAX_LEVEL = table[i].Max();
                MapRectangles(graphicsObj,
                    MIN_SAMPLE, MAX_SAMPLE, MIN_LEVEL, MAX_LEVEL,
                    0, this.ClientSize.Width, this.ClientSize.Height / ChannelsNumber, 0);
        
                PointF[] points = new PointF[SamplesNumber];
                for (int j = 0; j < points.Length; j++)
                {
                    points[j] = new PointF(j, table[i][j]);
                }
                using (Pen thin_pen = new Pen(Color.Black, 3))
                {
                    graphicsObj.DrawLines(thin_pen, points);
                }

                graphicsObj.Dispose();
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObj = e.Graphics;

            int h = 0;
            foreach (System.Drawing.Bitmap bmap in bbb)
            {
                graphicsObj.DrawImage(bmap, 0, bmap.Height * h, bmap.Width, bmap.Height);
                
                h++;
            }

            graphicsObj.Dispose();
        }
    }
}
