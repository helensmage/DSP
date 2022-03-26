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
using System.Windows;

namespace DSP
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            
            //panel1.Height *= Holder.Ocsillograms.Count + 1;
            //panel1.AutoScroll = true;
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
                wrectf = new RectangleF(wxmin, wymin * wymin * (-1000), wxmax - wxmin, wxmax - wxmin);
            }
            PointF[] dpts = {
                 new PointF(dxmin, dymin),
                 new PointF(dxmax, dymin),
                 new PointF(dxmin, dymax)
            };
            gr.Transform = new Matrix(wrectf, dpts);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //Holder.bbb = new Bitmap[Holder.ChannelsNumber];
            Graphics graphicsObj;
            /*if (Holder.ChannelsNumber < 3)
            {
                this.Height = this.ClientSize.Height / 3;
            }*/
            this.Height *= (Holder.Ocsillograms.Count + 1);
            Bitmap bmp = new Bitmap(/*this.ClientRectangle.Width*/ this.ClientSize.Width /*- 20*/,
                                /*this.ClientRectangle.Height*/ this.ClientSize.Height / (Holder.Ocsillograms.Count + 1),
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Holder.Ocsillograms.Add(bmp);
            

            graphicsObj = Graphics.FromImage(bmp);

            graphicsObj.Clear(Color.White);

            /*Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Blue);
            float x = 0;
            float y = this.ClientSize.Height / Holder.Ocsillograms.Count - 20;
            graphicsObj.DrawString(Holder.ChannelsNames[Holder.CurrentIndex], drawFont, drawBrush, x, y);*/

            graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
            float MIN_SAMPLE = 0;
            float MAX_SAMPLE = Holder.SamplesNumber;
            float MIN_LEVEL = Holder.table[Holder.CurrentIndex].Min();
            float MAX_LEVEL = Holder.table[Holder.CurrentIndex].Max();
            MapRectangles(graphicsObj,
                MIN_SAMPLE, MAX_SAMPLE, MIN_LEVEL, MAX_LEVEL,
                0, this.ClientSize.Width /*- 20*/, this.ClientSize.Height / Holder.Ocsillograms.Count/* - 20*/, 0);

            using (Pen thin_pen = new Pen(Color.Black, 3))
            {
                for (int count = 0; count < Holder.SamplesNumber - 1; count++)
                {
                    graphicsObj.DrawLine(thin_pen, new PointF(count, Holder.table[Holder.CurrentIndex][count]), new PointF(count + 1, Holder.table[Holder.CurrentIndex][count + 1]));
                }
            }

            graphicsObj.Dispose();
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
        {
            /*Panel Panel = new Panel();
            Panel.Width = this.ClientSize.Width;
            Panel.Height = this.ClientSize.Height;
            Panel.AutoScroll = true;
            this.Controls.Add(Panel);*/
            Graphics graphicsObj = /*Panel*/e.Graphics;

            int h = 0;
            foreach (Bitmap bmap in Holder.Ocsillograms)
            {
                graphicsObj.DrawImage(bmap, 0, bmap.Height * h, bmap.Width, bmap.Height);
                graphicsObj.DrawRectangle(Pens.Blue, 0, bmap.Height * h, bmap.Width, bmap.Height);
                h++;
            }

            graphicsObj.Dispose();
        }
    }
}
