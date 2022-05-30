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

namespace DSP
{
    public partial class Statistics : Form
    {
        Form1 Parent;
        int samplesNumber;
        float[] segment;
        float min;
        float max;
        public Statistics(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
        }
        private float[] getSegment(in float[] array)
        {
            float[] res = new float[samplesNumber];
            for (int i = (int)Holder.zoomX; i < (int)Holder.zoomY; i++)
            {
                res[i - (int)Holder.zoomX] = array[i];
            }
            return res;
        }
        private void Statistics_Load(object sender, EventArgs e)
        {
            samplesNumber = (int)Holder.zoomY - (int)Holder.zoomX;
            segment = getSegment(Holder.table[Holder.CurrentIndex]);
            //segment = new ArraySegment<float>(Holder.table[Holder.CurrentIndex], (int)Holder.zoomX, samplesNumber).Array;
            //MessageBox.Show(Holder.zoomX.ToString() + " " + Holder.zoomY.ToString());
            this.Text = Holder.ChannelsNames[Holder.CurrentIndex] + ": Статистика";

            double avg = segment.Sum() / samplesNumber;

            double disp = 0;
            for (int i = 0; i < samplesNumber; i++)
            {
                disp += Math.Pow(segment[i] - avg, 2);
            }
            disp /= samplesNumber;

            double divergence = Math.Pow(disp, 0.5);

            double variation = divergence / avg;

            double asymmetry = 0;
            for (int i = 0; i < samplesNumber; i++)
            {
                asymmetry += Math.Pow(segment[i] - avg, 3);
            }
            asymmetry /= samplesNumber * Math.Pow(divergence, 3);

            double excess = 0;
            for (int i = 0; i < samplesNumber; i++)
            {
                excess += Math.Pow(segment[i] - avg, 4);
            }
            excess /= samplesNumber * Math.Pow(divergence, 4);
            excess -= 3;

            min = segment.Min();
            max = segment.Max();

            float[] arr = new float[segment.Length];
            segment.CopyTo(arr, 0);
            quicksort(arr, 0, arr.Length - 1);

            int x005 = (int)(0.05 * samplesNumber);
            int x095 = (int)(0.95 * samplesNumber);
            int x05 = samplesNumber / 2;

            this.label12.Text = Math.Round(avg, 3).ToString();
            this.label13.Text = Math.Round(disp, 3).ToString();
            this.label14.Text = Math.Round(divergence, 3).ToString();
            this.label15.Text = Math.Round(variation, 3).ToString();
            this.label16.Text = Math.Round(asymmetry, 3).ToString();
            this.label17.Text = Math.Round(excess, 3).ToString();
            this.label18.Text = Math.Round(min, 3).ToString();
            this.label19.Text = Math.Round(max, 3).ToString();
            this.label20.Text = Math.Round(arr[x005], 3).ToString();
            this.label21.Text = Math.Round(arr[x095], 3).ToString();
            this.label22.Text = Math.Round(arr[x05], 3).ToString();

            Holder.h = (max - min) / Holder.K;
            drawHistogram();
        }

        int partition(float[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    float temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        void quicksort(float[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Gistoparam gistoparam = new Gistoparam(Parent, min, max);
            gistoparam.MdiParent = Parent;
            gistoparam.Show();
        }
        public void drawHistogram()
        {
            this.label24.Text = Holder.K.ToString();
            float[] g = new float[Holder.K];
            for (int i = 0; i < Holder.K; i++)
            {
                g[i] = 0;
            }
            for (int count = 0; count < samplesNumber; count++)
            {
                if (max == segment[count])
                {
                    g[Holder.K - 1]++;
                }
                else
                {
                    g[(int)((segment[count] - min) / Holder.h)]++;
                }
            }
            for (int i = 0; i < Holder.K; i++)
            {
                g[i] /= samplesNumber;
            }
            // Create the Bitmap.
            Bitmap bm = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);

            // Get a Graphics object associated with the Bitmap.
            Graphics gr = Graphics.FromImage(bm);

            gr.SmoothingMode = SmoothingMode.AntiAlias;
            float MIN_SAMPLE = 0;
            float MAX_SAMPLE = Holder.K;
            float MIN_LEVEL = g.Min();
            float MAX_LEVEL = g.Max();
            MapRectangles(gr,
                MIN_SAMPLE, MAX_SAMPLE, MIN_LEVEL, MAX_LEVEL,
                10, pictureBox1.Width - 10, pictureBox1.Height - 10, 10);

            using (Pen thin_pen = new Pen(Color.Green, 0))
            {
                for (int count = 0; count < Holder.K; count++)
                {
                    gr.FillRectangle(Brushes.PaleGreen, count, 0, 1, g[count]);
                    gr.DrawRectangle(thin_pen, count, 0, 1, g[count]);
                }
            }

            pictureBox1.Image = bm;
            gr.Dispose();
        }
    }
}
