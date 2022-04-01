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
            if (Holder.flagOscillo)
            {
                Graphics graphicsObj;
                this.Height = 120 + 200 * (Holder.Ocsillograms.Count + 1) + 40;
                Bitmap bmp = new Bitmap(this.ClientSize.Width /*- 20*/,
                                    /*this.ClientSize.Height / (Holder.Ocsillograms.Count + 1)*/ 200,
                                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Holder.Ocsillograms.Add(Holder.ChannelsNames[Holder.CurrentIndex], bmp);


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
                    0, this.ClientSize.Width /*- 20*/, /*this.ClientSize.Height / Holder.Ocsillograms.Count*//* - 20*/ 200, 0);

                using (Pen thin_pen = new Pen(Color.Black, 3))
                {
                    for (int count = 0; count < Holder.SamplesNumber - 1; count++)
                    {
                        graphicsObj.DrawLine(thin_pen, new PointF(count, Holder.table[Holder.CurrentIndex][count]), new PointF(count + 1, Holder.table[Holder.CurrentIndex][count + 1]));
                    }
                }

                graphicsObj.Dispose();
            }
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                Holder.point = this.PointToClient(Cursor.Position);
            }
        }

        // Закрыть
        private void осциллограммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Holder.flagOscillo = false;
            // Сделать каррент индекс по координатам
            Holder.CurrentIndex = (Holder.point.Y - 90) / (this.ClientSize.Height / Holder.Ocsillograms.Count);
            Holder.Ocsillograms.Remove(Holder.ChannelsNames[Holder.CurrentIndex]);
            Holder.SubOscillogram[Holder.CurrentIndex].CheckState = CheckState.Checked;
            // Вызвать функцию перерисовки окна
            Holder.oscillo.Close();
            if (Holder.Ocsillograms.Count != 0)
            {
                Holder.oscillo = new Form5();
                Holder.oscillo.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObj = e.Graphics;

            int h = 0;
            foreach (var bmap in Holder.Ocsillograms)
            {
                graphicsObj.DrawImage(bmap.Value, 0, bmap.Value.Height * h + 90, bmap.Value.Width, bmap.Value.Height);
                graphicsObj.DrawRectangle(Pens.Blue, 0, bmap.Value.Height * h + 90, bmap.Value.Width, bmap.Value.Height);
                h++;
            }

            graphicsObj.Dispose();
        }
    }
}
