using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

namespace DSP
{
    public partial class Spectra : Form
    {
        Form1 Parent;
        int samplesNumber;
        double[] segment;
        Chart chart;
        int H = 200;
        double[] mag;
        public Spectra(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton2.Image = new Bitmap(@"C:\Users\User\Desktop\4 семестр\Проект по Компьютерной Графике\3.0\images\lin.png");
        }

        private void Spectra_Load(object sender, EventArgs e)
        {
            samplesNumber = (int)Holder.zoomY - (int)Holder.zoomX;
            segment = getSegment(Holder.table[Holder.CurrentIndex]);

            Complex[] samples = new Complex[samplesNumber];
            for (int i = 0; i < samplesNumber; i++)
            {
                samples[i] = new Complex(segment[i], 0);
            }

            Fourier.Forward(samples, FourierOptions.NoScaling);

            mag = new double[samplesNumber];

            for (int i = 0; i < samplesNumber; i++)
            {
                mag[i] = Math.Abs(Math.Sqrt(Math.Pow(samples[i].Real, 2) + Math.Pow(samples[i].Imaginary, 2)));
            }

            CreateChart();

            double[] hertz = new double[samplesNumber];
            for (int i = 0; i < samplesNumber; i++)
            {
                hertz[i] = i * (Holder.SamplingRate / samplesNumber);
            }

            chart.Series[0].Points.DataBindXY(hertz, mag);
        }
        private double[] getSegment(in float[] array)
        {
            double[] res = new double[samplesNumber];
            for (int i = (int)Holder.zoomX; i < (int)Holder.zoomY; i++)
            {
                res[i - (int)Holder.zoomX] = (double)array[i];
            }
            return res;
        }
        private void CreateChart()
        {
            chart = new Chart();
            chart.Parent = this;
            chart.SetBounds(0, 90 /*+ H * Holder.Ocsillograms.Count*/, ClientSize.Width - 20, H);
            ChartArea area = new ChartArea();
            area.Name = "myGraph";
            if (mag.Min() == mag.Max())
            {
                area.AxisY.Minimum = mag.Min() - 1;
                area.AxisY.Maximum = mag.Max() + 1;
            }
            else
            {
                area.AxisY.Minimum = mag.Min();
                area.AxisY.Maximum = mag.Max();
            }
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = samplesNumber * (Holder.SamplingRate / samplesNumber);
            area.AxisX.MajorGrid.LineColor = Color.Gray;
            area.AxisY.MajorGrid.LineColor = Color.Gray;
            area.AxisX.MajorGrid.Enabled = !Holder.grid;
            area.AxisY.MajorGrid.Enabled = !Holder.grid;
            area.AxisY.LabelStyle.Format = "N1";
            area.AxisX.LabelStyle.Format = "N1";
            area.AxisX.ScrollBar.Enabled = true;
            area.CursorX.IsUserEnabled = true;
            area.CursorX.IsUserSelectionEnabled = true;
            area.CursorX.Interval = 0;
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScrollBar.IsPositionedInside = true;
            area.BorderDashStyle = ChartDashStyle.Solid;
            area.BorderColor = Color.Black;
            area.BorderWidth = 1;
            area.Position.Y = 20;
            area.Position.Height = 80;
            area.Position.Width = 100;
            area.Position.X = 0;
            chart.ChartAreas.Add(area);
            Series series1 = new Series();
            if (Holder.dots) series1.MarkerStyle = MarkerStyle.Circle;
            series1.Color = Color.Black;
            series1.ChartArea = "myGraph";
            series1.ChartType = SeriesChartType.Line;
            series1.LegendText = Holder.ChannelsNames[Holder.CurrentIndex];
            chart.Legends.Add(Holder.ChannelsNames[Holder.CurrentIndex]);
            chart.Legends[0].Position.Auto = false;
            chart.Legends[0].Position = new ElementPosition(0, 0, 100, 20);
            chart.Series.Add(series1);
            area.AxisX.ScaleView.Zoom(Holder.zoomX, Holder.zoomY);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Holder.dots = !Holder.dots;
            this.toolStripButton4.Checked = Holder.dots;
            if (!Holder.dots)
                chart.Series[0].MarkerStyle = MarkerStyle.None;
            else
                chart.Series[0].MarkerStyle = MarkerStyle.Circle;
        }
    }
}
