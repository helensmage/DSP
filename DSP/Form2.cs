using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace DSP
{
    public partial class Form2 : Form
    {
        const int channelHeight = 102;
        Form1 Parent;
        VScrollBar vScroller;
        public Form2(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
            Holder.countScroll = 0;
            Holder.firstLoad = true;
            for (int i = 0; i < 10; i++)
            {
                Holder.lastNumberModelName[i] = 0;
            }

            StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(Location))
                {
                    Location = new Point(scrn.Bounds.Right - Width - 25, scrn.Bounds.Top);
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
        
        public void Form2_Load(object sender, EventArgs e)
        {
            if (Holder.firstLoad)
            {
                Holder.bbb = new List<Bitmap>();
                for (int i = 0; i < Holder.ChannelsNumber; i++)
                {
                    Graphics graphicsObj;
                    Holder.bbb.Add(new Bitmap(174, channelHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb));

                    graphicsObj = Graphics.FromImage(Holder.bbb[Holder.bbb.Count - 1]);
                    graphicsObj.Clear(Color.White);

                    Font drawFont = new Font("Arial", 16);
                    SolidBrush drawBrush = new SolidBrush(Color.Blue);
                    float x = 0;
                    float y = channelHeight - 20;
                    graphicsObj.DrawString(Holder.ChannelsNames[i], drawFont, drawBrush, x, y);

                    graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
                    float MIN_SAMPLE = 0;
                    float MAX_SAMPLE = Holder.SamplesNumber;
                    float MIN_LEVEL = Holder.table[i].Min();
                    float MAX_LEVEL = Holder.table[i].Max();
                    MapRectangles(graphicsObj,
                        MIN_SAMPLE, MAX_SAMPLE, MIN_LEVEL, MAX_LEVEL,
                        0, 174, channelHeight - 20, 0);

                    using (Pen thin_pen = new Pen(Color.Black, 3))
                    {
                        for (int count = 0; count < Holder.SamplesNumber - 1; count++)
                        {
                            graphicsObj.DrawLine(thin_pen, new PointF(count, Holder.table[i][count]), new PointF(count + 1, Holder.table[i][count + 1]));
                        }
                    }

                    graphicsObj.Dispose();
                }
                
            }
            Holder.firstLoad = false;
            

            if (Holder.bbb.Count > 6)
            {
                this.Width += 21;
                Holder.countScroll += Holder.bbb.Count - 6;
                vScroller = new VScrollBar();
                vScroller.Height = 200;
                vScroller.Width = 20;
                vScroller.Dock = DockStyle.Right;
                vScroller.Minimum = this.panel1.VerticalScroll.Minimum;
                vScroller.Maximum = this.panel1.VerticalScroll.Maximum + 11;
                vScroller.Value = this.panel1.VerticalScroll.Value;
                this.Controls.Add(vScroller);
                vScroller.Scroll += new ScrollEventHandler(vScroller_Scroll);
            }
            else
            {
                this.Height = Holder.bbb.Count * channelHeight + SystemInformation.CaptionHeight + 17;
            }
        }

        public void x(object sender, EventArgs e)
        {
            if (Holder.bbb.Count == 7)
            {
                this.Width += 21;
                vScroller = new VScrollBar();
                vScroller.Height = 200;
                vScroller.Width = 20;
                vScroller.Dock = DockStyle.Right;
                vScroller.Minimum = this.panel1.VerticalScroll.Minimum;
                vScroller.Maximum = this.panel1.VerticalScroll.Maximum + 11;
                vScroller.Value = this.panel1.VerticalScroll.Value;
                this.Controls.Add(vScroller);
                vScroller.Scroll += new ScrollEventHandler(vScroller_Scroll);
            }
            else if (Holder.bbb.Count < 7)
            {
                if (vScroller != null)
                {
                    vScroller.Dispose();
                    vScroller = null;
                    this.Width -= 21;
                }
                this.Height = Holder.bbb.Count * channelHeight + SystemInformation.CaptionHeight + 17;
            }
        }

        void vScroller_Scroll(object sender, ScrollEventArgs e)
        {
            Graphics graphicsObj = panel1.CreateGraphics();
            int h = 0;
            foreach (Bitmap bmap in Holder.bbb)
            {
                graphicsObj.DrawImage(bmap, 0, bmap.Height * h - (vScroller.Value) * Holder.countScroll, bmap.Width, bmap.Height);
                graphicsObj.DrawRectangle(Pens.Blue, 0, bmap.Height * h - (vScroller.Value) * Holder.countScroll, bmap.Width, bmap.Height);
                float x1 = bmap.Width * ((float)(Holder.zoomX / Holder.SamplesNumber));
                float x2 = bmap.Width * ((float)(Holder.zoomY / Holder.SamplesNumber));
                graphicsObj.DrawLine(Pens.Red, x1, bmap.Height * h - (vScroller.Value) * Holder.countScroll, x1, bmap.Height * h + bmap.Height - 20);
                graphicsObj.DrawLine(Pens.Red, x2, bmap.Height * h - (vScroller.Value) * Holder.countScroll, x2, bmap.Height * h + bmap.Height - 20);
                h++;
            }
            graphicsObj.Dispose();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                Holder.point = this.PointToClient(System.Windows.Forms.Cursor.Position);
            }
        }
        private void setCurrentIndex()
        {
            if (vScroller == null)
            {
                Holder.CurrentIndex = Holder.point.Y / channelHeight;
            }
            else
            {
                Holder.CurrentIndex = (Holder.point.Y + vScroller.Value * Holder.countScroll) / channelHeight;
            }
        }
        private void осциллограммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentIndex();
            if (Holder.Ocsillograms == null)
            {
                Holder.SubOscillogram[Holder.CurrentIndex].CheckState = CheckState.Checked;
                Holder.Ocsillograms = new List<Chart>();
                Holder.CurIndArray = new List<int>();
                Holder.oscillo = new Form5(Parent); // создаём окно
                Holder.oscillo.MdiParent = Parent;
                Holder.oscillo.Show();
            }
            else
            {
                if (!Holder.CurIndArray.Contains(Holder.CurrentIndex))
                {
                    Holder.SubOscillogram[Holder.CurrentIndex].CheckState = CheckState.Checked;
                    Holder.oscillo.Form5_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Осциллограмма канала " + Holder.ChannelsNames[Holder.CurrentIndex] + " уже существует!", "Предупреждение");
                }
            }
        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObj = e.Graphics;
            int h = 0;
            foreach (Bitmap bmap in Holder.bbb)
            {
                graphicsObj.DrawImage(bmap, 0, bmap.Height * h, bmap.Width, bmap.Height);
                graphicsObj.DrawRectangle(Pens.Blue, 0, bmap.Height * h, bmap.Width, bmap.Height);
                float x1 = bmap.Width * ((float)(Holder.zoomX / Holder.SamplesNumber));
                float x2 = bmap.Width * ((float)(Holder.zoomY / Holder.SamplesNumber));
                graphicsObj.DrawLine(Pens.Red, x1, bmap.Height * h, x1, bmap.Height * h + bmap.Height - 20);
                graphicsObj.DrawLine(Pens.Red, x2, bmap.Height * h, x2, bmap.Height * h + bmap.Height - 20);
                h++;
            }
            graphicsObj.Dispose();
        }

        private void статистикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentIndex();
            Holder.statistics = new Statistics(Parent);
            Holder.statistics.MdiParent = Parent;
            Holder.statistics.Show();
        }

        private void спектральныйАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentIndex();
            Spectra spectra = new Spectra(Parent);
            spectra.MdiParent = Parent;
            spectra.Show();
        }
    }
}
