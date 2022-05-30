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
using System.Windows.Forms.DataVisualization.Charting;

namespace DSP
{
    public partial class Form5 : Form
    {
        Chart chart;
        int H = 200; // стандартная высота графика
        int[] counts;
        //флаги для масштабирования
        bool loc = false;
        bool glob = false;
        bool oneloc = false;
        bool oneglob = false;

        Form1 Parent;
        public Form5(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
            Holder.grid = false;
            Holder.flagTimeXForm5 = false;
            Holder.zoomX = 0;
            Holder.zoomY = Holder.SamplesNumber;
            this.label1.Text = Holder.SamplesNumber.ToString();
            this.label2.Text = "#0";
            this.label3.Text = "#" + (Holder.SamplesNumber-1).ToString();
            counts = new int[Holder.SamplesNumber];
            for (int count = 0; count < Holder.SamplesNumber; count++)
            {
                counts[count] = count;
            }
        }
        private void CreateChart()
        {
            chart = new Chart();
            chart.Parent = this.panel1;
            chart.SetBounds(0, 90 + H * Holder.Ocsillograms.Count, ClientSize.Width - 20, H);
            ChartArea area = new ChartArea();
            area.Name = "myGraph";
            if (Holder.table[Holder.CurrentIndex].Min() == Holder.table[Holder.CurrentIndex].Max())
            {
                area.AxisY.Minimum = Holder.table[Holder.CurrentIndex].Min() - 1;
                area.AxisY.Maximum = Holder.table[Holder.CurrentIndex].Max() + 1;
            }
            else
            {
                area.AxisY.Minimum = Holder.table[Holder.CurrentIndex].Min();
                area.AxisY.Maximum = Holder.table[Holder.CurrentIndex].Max();
                if (loc && !glob && !oneloc && !oneglob)
                {
                    area.AxisY.Minimum = mini(Holder.table[Holder.CurrentIndex], (int)Holder.zoomX, (int)Holder.zoomY);
                    area.AxisY.Maximum = maxi(Holder.table[Holder.CurrentIndex], (int)Holder.zoomX, (int)Holder.zoomY);
                }
                else if (!loc && glob && !oneloc && !oneglob)
                {
                    area.AxisY.Minimum = Holder.table[Holder.CurrentIndex].Min();
                    area.AxisY.Maximum = Holder.table[Holder.CurrentIndex].Max();
                }
                else if (!loc && !glob && oneloc && !oneglob)
                {
                    area.AxisY.Minimum = onelocmin((int)Holder.zoomX, (int)Holder.zoomY);
                    area.AxisY.Maximum = onelocmax((int)Holder.zoomX, (int)Holder.zoomY);
                }
                else if (!loc && !glob && !oneloc && oneglob)
                {
                    area.AxisY.Minimum = onelocmin(0, Holder.SamplesNumber);
                    area.AxisY.Maximum = onelocmax(0, Holder.SamplesNumber);
                }
            }
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
            series1.LegendText = Holder.ChannelsNames[Holder.CurrentIndex];
            chart.Legends.Add(Holder.ChannelsNames[Holder.CurrentIndex]);
            chart.Legends[0].Position.Auto = false;
            chart.Legends[0].Position = new ElementPosition(0, 0, 100, 20);
            chart.Series.Add(series1);
            area.AxisX.ScaleView.Zoom(Holder.zoomX, Holder.zoomY);
        }

        public void Form5_Load(object sender, EventArgs e)
        {
            this.Height = 90 + 200 * (Holder.Ocsillograms.Count + 1) + 40;
            CreateChart();
            Holder.Ocsillograms.Add(chart);
            Holder.CurIndArray.Add(Holder.CurrentIndex);
            chart.Series[0].Points.DataBindXY(counts, Holder.table[Holder.CurIndArray[Holder.CurIndArray.Count - 1]]);
            chart.MouseDown += new MouseEventHandler(this.DeleteChart);
            chart.AxisViewChanged += chart1_AxisViewChanged;
            this.ClientSizeChanged += Control1_ClientSizeChanged;
            this.FormClosed += Form5_FormClosed;
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Holder.Ocsillograms != null) { Holder.Ocsillograms.Clear(); Holder.Ocsillograms = null; }
            foreach(var v in Holder.SubOscillogram)
            {
                if (v.Checked)
                {
                    v.Checked = false;
                }
            }
        }

        private void Control1_ClientSizeChanged(Object sender, EventArgs e)
        {
            for (int i = 0; i < Holder.Ocsillograms.Count; i++) // перебираем все осцилограммы
            {
                Holder.Ocsillograms[i].Width = this.ClientSize.Width - 20;
                this.groupBox1.Width = this.ClientSize.Width;
            }
        }

        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            Holder.zoomX = e.ChartArea.AxisX.ScaleView.Position;
            Holder.zoomY = e.ChartArea.AxisX.ScaleView.Position + e.ChartArea.AxisX.ScaleView.Size;
            for (int i = 0; i < Holder.Ocsillograms.Count; i++) // перебираем все осцилограммы
            {
                Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisX.ScaleView.Zoom(Holder.zoomX, Holder.zoomY);
            }
            if (double.IsNaN(Holder.zoomX))
            {
                Holder.zoomX = 0;
                Holder.zoomY = Holder.SamplesNumber;
            }
            this.label1.Text = ((int)(Holder.zoomY - Holder.zoomX)).ToString();
            this.label2.Text = "#" + ((int)(Holder.zoomX)).ToString();
            this.label3.Text = "#" + ((int)(Holder.zoomY - 1)).ToString();
            ourscale();
            Parent.f2.Refresh();
            //
            Holder.closeOtherStatistics();
            Holder.statistics = new Statistics(Parent);
            Holder.statistics.MdiParent = Parent;
            Holder.statistics.Show();
        }

        public void fragmentZoom(object sender, ViewEventArgs e)
        {
            for (int i = 0; i < Holder.Ocsillograms.Count; i++) // перебираем все осцилограммы
            {
                Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisX.ScaleView.Zoom(Holder.zoomX, Holder.zoomY);
            }
            this.label1.Text = ((int)(Holder.zoomY - Holder.zoomX)).ToString();
            this.label2.Text = "#" + ((int)(Holder.zoomX)).ToString();
            this.label3.Text = "#" + ((int)(Holder.zoomY - 1)).ToString();
            ourscale();
            Parent.f2.Refresh();
        }

        // Закрыть
        private void осциллограммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Holder.SubOscillogram[Holder.CurIndArray[Holder.Ocsillograms.IndexOf(chart)]].CheckState = CheckState.Unchecked;
            Holder.CurIndArray.RemoveAt(Holder.Ocsillograms.IndexOf(chart)); // ?
            Holder.Ocsillograms[Holder.Ocsillograms.IndexOf(chart)].Dispose(); //
            Holder.Ocsillograms.RemoveAt(Holder.Ocsillograms.IndexOf(chart)); // удаляем из осциллограмм по индексу
            if (Holder.Ocsillograms.Count == 0) // если после удаления не осталось осциллограмм
            {
                if (Holder.Ocsillograms != null) { Holder.Ocsillograms.Clear(); Holder.Ocsillograms = null; }
                this.Close(); // то закрыть окно
            }
            else
            {
                // иначе вызвать функцию перерисовки окна
                this.Height = 90 + 200 * (Holder.Ocsillograms.Count) + 40;
                for (int j = 0; j < Holder.Ocsillograms.Count; j++)
                {
                    Holder.Ocsillograms[j].SetBounds(0, 90 + 200 * j, this.ClientSize.Width - 20, 200); // H = 200
                }
                //this.Refresh();
            }
        }
        private void DeleteChart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                chart = sender as Chart;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Holder.grid = !Holder.grid;
            this.toolStripButton1.Checked = Holder.grid; // кнопка нажата или нет
            for (int i = 0; i < Holder.Ocsillograms.Count; i++) // перебираем все осцилограммы
            {
                Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisX.MajorGrid.Enabled = !Holder.grid;
                Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.MajorGrid.Enabled = !Holder.grid;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Holder.dots = !Holder.dots;
            this.toolStripButton2.Checked = Holder.dots;
            for (int i = 0; i < Holder.Ocsillograms.Count; i++)
            {
                if (!Holder.dots)
                    Holder.Ocsillograms[i].Series[0].MarkerStyle = MarkerStyle.None;
                else
                    Holder.Ocsillograms[i].Series[0].MarkerStyle = MarkerStyle.Circle;
            }
        }

        public float mini(float[] data, int s, int f)
        {
            if (f > Holder.SamplesNumber) f = Holder.SamplesNumber;
            float mini = Math.Min(data[s], data[s + 1]);
            for (int k = s + 2; k < f; k++)
            {
                mini = Math.Min(mini, data[k]);
            }
            return mini;
        }
        public float maxi(float[] data, int s, int f)
        {
            if (f > Holder.SamplesNumber) f = Holder.SamplesNumber;
            float maxi = Math.Max(data[s], data[s + 1]);
            for (int k = s + 2; k < f; k++)
            {
                maxi = Math.Max(maxi, data[k]);
            }
            return maxi;
        }
        private float onelocmin(int start, int finish)
        {
            float onelocmin = mini(Holder.table[Holder.CurIndArray[0]], start, finish);
            if (Holder.Ocsillograms.Count > 1)
            {
                for (int i = 1; i < Holder.Ocsillograms.Count; i++)
                {
                    onelocmin = Math.Min(onelocmin, mini(Holder.table[Holder.CurIndArray[i]], start, finish));
                }
            }  
            return onelocmin;
        }
        private float onelocmax(int start, int finish)
        {
            float onelocmax = maxi(Holder.table[Holder.CurIndArray[0]], start, finish);
            if (Holder.Ocsillograms.Count > 1)
            {
                for (int i = 1; i < Holder.Ocsillograms.Count; i++)
                {
                    onelocmax = Math.Max(onelocmax, maxi(Holder.table[Holder.CurIndArray[i]], start, finish));
                }
            }
            return onelocmax;
        }
        private void ourscale()
        {
            for (int i = 0; i < Holder.Ocsillograms.Count; i++)
            {
                if (Holder.table[Holder.CurIndArray[i]].Min() != Holder.table[Holder.CurIndArray[i]].Max())
                {
                    if (loc && !glob && !oneloc && !oneglob)
                    {
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Minimum = mini(Holder.table[Holder.CurIndArray[i]], (int)Holder.zoomX, (int)Holder.zoomY);
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Maximum = maxi(Holder.table[Holder.CurIndArray[i]], (int)Holder.zoomX, (int)Holder.zoomY);
                    }
                    else if (!loc && glob && !oneloc && !oneglob)
                    {
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Minimum = mini(Holder.table[Holder.CurIndArray[i]], 0, Holder.SamplesNumber);
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Maximum = maxi(Holder.table[Holder.CurIndArray[i]], 0, Holder.SamplesNumber);
                    }
                    else if (!loc && !glob && oneloc && !oneglob)
                    {
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Minimum = onelocmin((int)Holder.zoomX, (int)Holder.zoomY);
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Maximum = onelocmax((int)Holder.zoomX, (int)Holder.zoomY);
                    }
                    else if (!loc && !glob && !oneloc && oneglob)
                    {
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Minimum = onelocmin(0, Holder.SamplesNumber);
                        Holder.Ocsillograms[i].ChartAreas["myGraph"].AxisY.Maximum = onelocmax(0, Holder.SamplesNumber);
                    }
                }
            }
        }
        private void checkstate()
        {
            this.locscaleToolStripMenuItem.Checked = loc;
            this.globalescaleToolStripMenuItem.Checked = glob;
            this.onelocscaleToolStripMenuItem.Checked = oneloc;
            this.oneglobalscaleToolStripMenuItem.Checked = oneglob;
        }
        private void locscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loc = true;
            glob = false;
            oneloc = false;
            oneglob = false;
            checkstate();
            ourscale();
        }

        private void globalescaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loc = false;
            glob = true;
            oneloc = false;
            oneglob = false;
            checkstate();
            ourscale();
        }

        private void fixscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loc = false;
            glob = false;
            oneloc = false;
            oneglob = false;
            checkstate();
            ourscale();
        }

        private void onelocscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loc = false;
            glob = false;
            oneloc = true;
            oneglob = false;
            checkstate();
            ourscale();
        }

        private void oneglobalscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loc = false;
            glob = false;
            oneloc = false;
            oneglob = true;
            checkstate();
            ourscale();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Holder.flagTimeXForm5 = !Holder.flagTimeXForm5;
            if (Holder.flagTimeXForm5) //true
            {
                for (int i = 0; i < Holder.Ocsillograms.Count; i++)
                {
                    List<string> arrLabel = new List<string>();
                    for (int k = 0; k < Holder.SamplesNumber; k++)
                    {
                        TimeSpan time = TimeSpan.FromSeconds(k * (1 / Holder.SamplingRate));
                        arrLabel.Add(time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString());
                    }
                    Holder.Ocsillograms[i].Series[0].Points.DataBindXY(arrLabel, Holder.table[Holder.CurIndArray[i]]);
                }
            }
            else
            {
                for (int i = 0; i < Holder.Ocsillograms.Count; i++)
                {
                    Holder.Ocsillograms[i].Series[0].Points.DataBindXY(counts, Holder.table[Holder.CurIndArray[i]]);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.locscaleToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.globalescaleToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(Parent);
            f6.MdiParent = Parent;
            f6.Show();
        }
    }
}
