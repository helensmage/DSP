using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DSP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            k.Text = Holder.ChannelsNumber.ToString();
            n.Text = Holder.SamplesNumber.ToString();
            rate.Text = Holder.SamplingRate.ToString() + " Гц (шаг между отсчетами " + (1/ Holder.SamplingRate).ToString().Replace(',', '.') + " сек)";
            start.Text = Holder.StartDate + " " + Holder.StartTime;

            DateTime timeParse0 = DateTime.ParseExact(
                Holder.StartDate + " " + Holder.StartTime,
                "dd-MM-yyyy HH:mm:ss.fff",
                CultureInfo.InvariantCulture
            );
            DateTime timeParse1 = timeParse0.AddSeconds(Holder.SamplesNumber * (1 / Holder.SamplingRate));
            end.Text = timeParse1.ToString("dd-MM-yyyy HH:mm:ss.fff");

            TimeSpan time = TimeSpan.FromSeconds(Holder.SamplesNumber * (1 / Holder.SamplingRate));
            duration.Text = time.Days + " - суток, " + time.Hours + " - часов, " + time.Minutes + " - минут, "
               + time.Seconds + "." + time.Milliseconds + " - секунд";

            Holder.filename = Holder.filename.Replace("C:\\Users\\User\\Desktop\\4 семестр\\Проект по Компьютерной Графике\\", ""); //
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 1;
            dataGridView1.Columns[0].MinimumWidth = 100;
            dataGridView1.Columns[1].MinimumWidth = 200;
            dataGridView1.Columns[2].MinimumWidth = 200;
            dataGridView1.Columns[0].HeaderText = "N";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Источник";
            for (int i = 0; i < Holder.ChannelsNumber; i++)
            {
                dataGridView1.Rows.Add((i + 1).ToString(), Holder.ChannelsNames[i], "Файл: " + Holder.filename);
            }
            
        }
    }
}
