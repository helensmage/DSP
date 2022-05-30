using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;

namespace DSP
{
    public partial class Model : Form
    {
        Form1 Parent;
        Chart chart;
        int[] counts;
        float[] countsY;
        Random rand;
        public Model(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
        }
        double frand() {
            int RAND_MAX = 32676;
            return rand.Next(RAND_MAX) / (double)(RAND_MAX);
        }
        private void CreateChart()
        {
            chart = new Chart();
            chart.Parent = this;
            chart.SetBounds(0, 20, ClientSize.Width, ClientSize.Height - 20);
            ChartArea area = new ChartArea();
            area.Name = "myGraph";
            area.AxisY.Minimum = countsY.Min();
            area.AxisY.Maximum = countsY.Max();
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = Holder.SamplesNumber;
            area.AxisX.MajorGrid.LineColor = Color.Gray;
            area.AxisY.MajorGrid.LineColor = Color.Gray;
            area.AxisX.MajorGrid.Enabled = !Holder.grid;
            area.AxisY.MajorGrid.Enabled = !Holder.grid;
            area.AxisY.LabelStyle.Format = "N1";
            area.AxisX.LabelStyle.Format = "N0";
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
            series1.LegendText = "Model_" + Holder.check + "_1";
            chart.Legends.Add("Model_" + Holder.check + "_1");
            chart.Legends[0].Position.Auto = false;
            chart.Legends[0].Position = new ElementPosition(0, 0, 100, 20);
            chart.Series.Add(series1);
            //area.AxisX.ScaleView.Zoom(Holder.zoomX, Holder.zoomY);
        }
        private void Model_Load(object sender, EventArgs e)
        {
            counts = new int[Holder.SamplesNumber];
            for (int count = 0; count < Holder.SamplesNumber; count++)
            {
                counts[count] = count;
            }
            countsY = new float[Holder.SamplesNumber];
            if (Holder.check == 1)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = 0;
                }
                countsY[Holder.n0] = 1;
            }
            else if (Holder.check == 2)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    if (count >= Holder.n0)
                    {
                        countsY[count] = 1;
                    }
                    else
                    {
                        countsY[count] = 0;
                    }
                }
            }
            else if (Holder.check == 3)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)Math.Pow(Holder.a3, count);
                }
            }
            else if (Holder.check == 4)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)(Holder.a * Math.Sin(count * Holder.w + Holder.fi));
                }
            }
            else if (Holder.check == 5)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    if (count % Holder.l < (Holder.l / 2))
                    {
                        countsY[count] = 1;
                    }
                    else
                    {
                        countsY[count] = -1;
                    }
                }
            }
            else if (Holder.check == 6)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)((count % Holder.l) / Holder.l);
                }
            }
            else if (Holder.check == 7)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)(Holder.a * Math.Exp(-count * (1 / Holder.SamplingRate) / Holder.t) * Math.Cos(2 * Math.PI * Holder.f * count * (1 / Holder.SamplingRate) + Holder.fi));
                }
            }
            else if (Holder.check == 8)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)(Holder.a * Math.Cos(2 * Math.PI * Holder.fo * count * (1 / Holder.SamplingRate)) * Math.Cos(2 * Math.PI * Holder.fn * count * (1 / Holder.SamplingRate) + Holder.fi));
                }
            }
            else if (Holder.check == 9)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)(Holder.a * (1 + Holder.m * Math.Cos(2 * Math.PI * Holder.fo * count * (1 / Holder.SamplingRate))) * Math.Cos(2 * Math.PI * Holder.fn * count * (1 / Holder.SamplingRate) + Holder.fi));
                }
            }
            else if (Holder.check == 10)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    double tsmall = count * (1 / Holder.SamplingRate);
                    double f = Holder.fo + (Holder.fk - Holder.fo) * tsmall / Holder.T;
                    double inCos = 2 * Math.PI * f * tsmall + Holder.fi;
                    countsY[count] = (float)(Holder.a * Math.Cos(inCos));
                }
            }
            else if (Holder.check == 11)
            {
                rand = new Random();
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)(Holder.a1 + (Holder.b1 - Holder.a1) * frand());
                }
            }
            else if (Holder.check == 12)
            {
                rand = new Random();
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    double nu = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        nu += frand();
                    }
                    nu = nu - 6;
                    countsY[count] = (float)(Holder.average + Math.Pow(Holder.dispersion, 0.5) * nu);
                }
            }
            else if (Holder.check == 13)
            {
                List<double> xn = new List<double>();
                List<double> yn = new List<double>();
                rand = new Random();
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    double nu = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        nu += frand();
                    }
                    nu = nu - 6;
                    double bixn = 0;
                    if (Holder.q > 0)
                    {
                        if (xn.Count >= Holder.q)
                        {
                            for (int i = 1; i <= Holder.q; i++)
                            {
                                bixn += Holder.biList[i - 1] * xn[xn.Count - i];
                            }
                        }
                        else
                        {
                            for (int i = 1; i <= xn.Count; i++)
                            {
                                bixn += Holder.biList[i - 1] * xn[xn.Count - i];
                            }
                        }
                    }
                    double aiyn = 0;
                    if (Holder.p > 0)
                    {
                        if (yn.Count >= Holder.p)
                        {
                            for (int i = 1; i <= Holder.p; i++)
                            {
                                aiyn += Holder.aiList[i - 1] * yn[yn.Count - i];
                            }
                        }
                        else
                        {
                            for (int i = 1; i <= yn.Count; i++)
                            {
                                aiyn += Holder.aiList[i - 1] * yn[yn.Count - i];
                            }
                        }
                    }
                    countsY[count] = (float)(nu + bixn - aiyn);
                    xn.Add(nu);
                    yn.Add(countsY[count]);
                }
                Holder.aiList.Clear();
                Holder.biList.Clear();
            }
            else if (Holder.check == 14)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = (float)(Holder.aiList[0]);
                    for (int j = 0; j < Holder.CheckBoxNames.Count; j++)
                    {
                        countsY[count] += (float)(Holder.aiList[j + 1] * Holder.table[Holder.ChannelsNames.IndexOf(Holder.CheckBoxNames[j])][count]);
                    }
                }
                Holder.CheckBoxNames.Clear();
                Holder.aiList.Clear();
            }
            else if (Holder.check == 15)
            {
                for (int count = 0; count < Holder.SamplesNumber; count++)
                {
                    countsY[count] = Holder.a15;
                    for (int j = 0; j < Holder.CheckBoxNames.Count; j++)
                    {
                        countsY[count] *= Holder.table[Holder.ChannelsNames.IndexOf(Holder.CheckBoxNames[j])][count];
                    }
                }
                Holder.CheckBoxNames.Clear();
            }
            CreateChart();
            chart.Series[0].Points.DataBindXY(counts, countsY);
            chart.MouseDown += new MouseEventHandler(this.DeleteChart);
            this.ClientSizeChanged += Control1_ClientSizeChanged;
        }
        private void DeleteChart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                chart = sender as Chart;
            }
        }
        private void Control1_ClientSizeChanged(Object sender, EventArgs e)
        {
            chart.Width = this.ClientSize.Width;
            chart.Height = this.ClientSize.Height - 20;
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
        private void CreateBitmap()
        {
            Graphics graphicsObj;
            Holder.bbb.Add(new Bitmap(174,
                                102,
                               System.Drawing.Imaging.PixelFormat.Format24bppRgb));

            graphicsObj = Graphics.FromImage(Holder.bbb[Holder.bbb.Count - 1]);
            graphicsObj.Clear(Color.White);

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Blue);
            float x = 0;
            float y = 102 - 20;
            graphicsObj.DrawString(Holder.ChannelsNames[Holder.ChannelsNames.Count - 1], drawFont, drawBrush, x, y);

            graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
            float MIN_SAMPLE = 0;
            float MAX_SAMPLE = Holder.SamplesNumber;
            float MIN_LEVEL = (float)countsY.Min();
            float MAX_LEVEL = (float)countsY.Max();
            MapRectangles(graphicsObj,
                MIN_SAMPLE, MAX_SAMPLE, MIN_LEVEL, MAX_LEVEL,
                0, 174, 102 - 20, 0);

            using (Pen thin_pen = new Pen(Color.Black, 3))
            {
                for (int count = 0; count < Holder.SamplesNumber - 1; count++)
                {
                    graphicsObj.DrawLine(thin_pen, new PointF(count, (float)countsY[count]), new PointF(count + 1, (float)countsY[count + 1]));
                }
            }

            graphicsObj.Dispose();
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parent.f2 == null)
            {
                Parent.f2 = new Form2(Parent);
                Parent.f2.MdiParent = Parent;
                Parent.f2.Show();

                Holder.filename = "-";
                Holder.ChannelsNumber = 0;
                Holder.StartDate = "01-01-2000";
                Holder.StartTime = "00:00:00.000";
                Holder.ChannelsNames = new List<string>();
                Holder.table = new List<float[]>();
                Holder.bbb = new List<Bitmap>();
                Holder.SubOscillogram = new List<ToolStripMenuItem>();
            }
            if (!Holder.flagSamples && !Holder.flagRate && Holder.ChannelsNumber != 0)
            {
                DialogResult result = MessageBox.Show("Добавить к существующему навигационному окну?",
                                "Сообщение",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    Holder.ChannelsNumber++;
                    Holder.lastNumberModelName[Holder.check - 1]++;
                    Holder.ChannelsNames.Add("Model_" + Holder.check + "_" + Holder.lastNumberModelName[Holder.check - 1]);
                    Parent.addSubOscillogram(Holder.ChannelsNames.Last());
                    Holder.table.Add(countsY);
                    this.CreateBitmap();
                    if (Holder.bbb.Count > 6)
                    {
                        Holder.countScroll++;
                    }
                }
                else
                {
                    //Parent.f2.Close();
                    for (int i = 0; i < 13; i++)
                    {
                        Holder.lastNumberModelName[i] = 0;
                    }
                    Holder.filename = "-";
                    Holder.ChannelsNumber = 0;
                    Holder.StartDate = "01-01-2000";
                    Holder.StartTime = "00:00:00.000";
                    Holder.countScroll = 0;
                    if (Holder.ChannelsNames != null)
                    {
                        Holder.ChannelsNames.Clear();
                        //Holder.ChannelsNames = null;
                    }
                    if (Holder.bbb != null) {
                        Holder.bbb.Clear();
                        //Holder.bbb = null;
                    }
                    if (Holder.table != null)
                    {
                        Holder.table.Clear();
                        //Holder.bbb = null;
                    }
                    if (Holder.SubOscillogram != null)
                    {
                        Holder.SubOscillogram.Clear();
                        Parent.oscillogramToolStripMenuItemClear();
                        //Holder.SubOscillogram = null;
                    }
                    if (Holder.Ocsillograms != null)
                    {
                        Holder.Ocsillograms.Clear();
                        Holder.Ocsillograms = null;
                    }
                    if (Holder.CurIndArray != null)
                    {
                        Holder.CurIndArray.Clear();
                        Holder.CurIndArray = null;
                    }
                    Holder.ChannelsNumber++;
                    Holder.lastNumberModelName[Holder.check - 1]++;
                    Holder.ChannelsNames.Add("Model_" + Holder.check + "_" + Holder.lastNumberModelName[Holder.check - 1]);
                    Parent.addSubOscillogram(Holder.ChannelsNames.Last());
                    Holder.table.Add(countsY);
                    this.CreateBitmap();
                    if (Holder.bbb.Count > 6)
                    {
                        Holder.countScroll++;
                    }
                }
                Parent.f2.x(null, null);
                Parent.f2.Refresh();
            }
            else
            {
                Holder.filename = "-";
                Holder.ChannelsNumber = 0;
                Holder.StartDate = "01-01-2000";
                Holder.StartTime = "00:00:00.000";
                Holder.ChannelsNames = new List<string>();
                Holder.bbb = new List<Bitmap>();

                for (int i = 0; i < 13; i++)
                {
                    Holder.lastNumberModelName[i] = 0;
                }
                Holder.ChannelsNumber = 0;
                Holder.countScroll = 0;
                if (Holder.ChannelsNames != null)
                {
                    Holder.ChannelsNames.Clear();
                    //Holder.ChannelsNames = null;
                }
                if (Holder.bbb != null)
                {
                    Holder.bbb.Clear();
                    //Holder.bbb = null;
                }
                if (Holder.table != null)
                {
                    Holder.table.Clear();
                    //Holder.bbb = null;
                }
                if (Holder.SubOscillogram != null)
                {
                    Holder.SubOscillogram.Clear();
                    Parent.oscillogramToolStripMenuItemClear();
                    //Holder.SubOscillogram = null;
                }
                if (Holder.Ocsillograms != null)
                {
                    Holder.Ocsillograms.Clear();
                    Holder.Ocsillograms = null;
                }
                if (Holder.CurIndArray != null)
                {
                    Holder.CurIndArray.Clear();
                    Holder.CurIndArray = null;
                }
                //Holder.bbb = new List<Bitmap>();
                Holder.ChannelsNumber++;
                Holder.lastNumberModelName[Holder.check - 1]++;
                Holder.ChannelsNames.Add("Model_" + Holder.check + "_" + Holder.lastNumberModelName[Holder.check - 1]);
                Parent.addSubOscillogram(Holder.ChannelsNames.Last());
                Holder.table.Add(countsY);
                this.CreateBitmap();
                //Holder.ChannelsNumber = 1;
                if (Holder.bbb.Count > 6)
                {
                    Holder.countScroll++;
                }
                Parent.f2.x(null, null);
                Parent.f2.Refresh();
            }
            Holder.flagSamples = false;
            Holder.flagRate = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Holder.grid = !Holder.grid;
            this.toolStripButton1.Checked = Holder.grid; // кнопка нажата или нет
            chart.ChartAreas["myGraph"].AxisX.MajorGrid.Enabled = !Holder.grid;
            chart.ChartAreas["myGraph"].AxisY.MajorGrid.Enabled = !Holder.grid;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Holder.dots = !Holder.dots;
            this.toolStripButton2.Checked = Holder.dots;
            if (!Holder.dots)
                chart.Series[0].MarkerStyle = MarkerStyle.None;
            else
                chart.Series[0].MarkerStyle = MarkerStyle.Circle;
        }
    }
}
