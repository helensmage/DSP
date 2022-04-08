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
        Chart chart1;
        int H = 200; // стандартная высота графика + отступ с названием канала

        Form1 Parent;
        public Form5(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
            Holder.grid = false;
        }
        private void CreateChart()
        {
            chart = new Chart();
            chart.Parent = this.panel1;
            chart.SetBounds(0, 90 + H * Holder.Ocsillograms.Count, ClientSize.Width, H);
            ChartArea area = new ChartArea();
            area.Name = "myGraph";
            area.AxisY.Minimum = Holder.table[Holder.CurrentIndex].Min();
            area.AxisY.Maximum = Holder.table[Holder.CurrentIndex].Max();
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = Holder.SamplesNumber;
            area.AxisY.LabelStyle.Format = "N0";
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
            chart.ChartAreas.Add(area);
            Series series1 = new Series();
            series1.ChartArea = "myGraph";
            series1.ChartType = SeriesChartType.Line;
            series1.LegendText = Holder.ChannelsNames[Holder.CurrentIndex];
            chart.Legends.Add(Holder.ChannelsNames[Holder.CurrentIndex]);
            chart.Series.Add(series1);
        }

        public void Form5_Load(object sender, EventArgs e)
        {
            this.Height = 90 + 200 * (Holder.Ocsillograms.Count + 1) + 40;
            CreateChart();
            Holder.Ocsillograms.Add(chart);
            Holder.CurIndArray.Add(Holder.CurrentIndex);
            this.panel1.Refresh();
            chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeleteChart);
        }

        // Закрыть
        private void осциллограммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Holder.SubOscillogram[Holder.CurIndArray[Holder.Ocsillograms.IndexOf(chart1)]].CheckState = CheckState.Unchecked;
            Holder.CurIndArray.RemoveAt(Holder.Ocsillograms.IndexOf(chart1)); // ?
            Holder.Ocsillograms[Holder.Ocsillograms.IndexOf(chart1)].Dispose(); //
            Holder.Ocsillograms.RemoveAt(Holder.Ocsillograms.IndexOf(chart1)); // удаляем из осциллограмм по индексу
            if (Holder.Ocsillograms.Count == 0) // если после удаления не осталось осциллограмм
            {
                this.Close(); // то закрыть окно
            }
            else
            {
                // иначе вызвать функцию перерисовки окна
                this.Height = 90 + 200 * (Holder.Ocsillograms.Count) + 40;
                for (int j = 0; j < Holder.Ocsillograms.Count; j++)
                {
                    Holder.Ocsillograms[j].SetBounds(0, 90 + 200 * j, this.ClientSize.Width, 200); // H = 200
                }
                this.Refresh();
            }
        }
        private void DeleteChart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                chart1 = sender as Chart;
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

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            int[] counts = new int[Holder.SamplesNumber];
            for (int count = 0; count < Holder.SamplesNumber; count++)
            {
                counts[count] = count;
            }
            for (int i = 0; i < Holder.Ocsillograms.Count; i++)
            {
                Holder.Ocsillograms[i].Series[0].Points.DataBindXY(counts, Holder.table[Holder.CurIndArray[i]]);
            }
        }
    }
}
