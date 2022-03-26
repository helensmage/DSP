using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace DSP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
            StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(Location))
                {
                    Location = new Point(scrn.Bounds.Right - Width, scrn.Bounds.Top + 47);
                    return;
                }
            }
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

        private void Form2_Load(object sender, EventArgs e)
        {
            Holder.bbb = new Bitmap[Holder.ChannelsNumber];
            for (int i = 0; i < Holder.ChannelsNumber; i++)
            {
                Graphics graphicsObj;
                if (Holder.ChannelsNumber < 3)
                {
                    this.Height = this.ClientSize.Height / 3;
                }
                Holder.bbb[i] = new Bitmap(this.ClientRectangle.Width,
                                    this.ClientRectangle.Height / Holder.ChannelsNumber,
                                   System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                graphicsObj = Graphics.FromImage(Holder.bbb[i]);
                graphicsObj.Clear(Color.White);

                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Blue);
                float x = 0;
                float y = this.ClientSize.Height / Holder.ChannelsNumber - 20;
                graphicsObj.DrawString(Holder.ChannelsNames[i], drawFont, drawBrush, x, y);

                graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
                float MIN_SAMPLE = 0;
                float MAX_SAMPLE = Holder.SamplesNumber;
                float MIN_LEVEL = Holder.table[i].Min();
                float MAX_LEVEL = Holder.table[i].Max();
                MapRectangles(graphicsObj,
                    MIN_SAMPLE, MAX_SAMPLE, MIN_LEVEL, MAX_LEVEL,
                    0, this.ClientSize.Width, this.ClientSize.Height / Holder.ChannelsNumber - 20, 0);
                
                using (Pen thin_pen = new Pen(Color.Black, 3))
                {
                    for(int count = 0; count < Holder.SamplesNumber - 1; count++)
                    {
                        graphicsObj.DrawLine(thin_pen, new PointF(count, Holder.table[i][count]), new PointF(count + 1, Holder.table[i][count + 1]));
                    }
                }

                graphicsObj.Dispose();
            }
            
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObj = e.Graphics;

            int h = 0;
            foreach (Bitmap bmap in Holder.bbb)
            {
                graphicsObj.DrawImage(bmap, 0, bmap.Height * h, bmap.Width, bmap.Height);
                graphicsObj.DrawRectangle(Pens.Blue, 0, bmap.Height * h, bmap.Width, bmap.Height);
                h++;
            }

            graphicsObj.Dispose();
        }
    }
}
