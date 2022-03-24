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
        int ChannelsNumber;
        int SamplesNumber;
        float SamplingRate;
        string StartDate;
        string StartTime;
        string[] ChannelsNames;
        string filename;

        public Form3(int ChannelsNumber_, int SamplesNumber_, float SamplingRate_, string StartDate_,
            string StartTime_, string[] ChannelsNames_, string filename_)
        {
            InitializeComponent();
            ChannelsNumber = ChannelsNumber_;
            SamplesNumber = SamplesNumber_;
            SamplingRate = SamplingRate_;
            StartDate = StartDate_;
            StartTime = StartTime_;
            ChannelsNames = ChannelsNames_;
            filename = filename_;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            k.Text = ChannelsNumber.ToString();
            n.Text = SamplesNumber.ToString();
            rate.Text = SamplingRate.ToString() + " Гц (шаг между отсчетами " + (1/ SamplingRate).ToString().Replace(',', '.') + " сек)";
            start.Text = StartDate + " " + StartTime;

            DateTime timeParse0 = DateTime.ParseExact(
                StartDate + " " + StartTime,
                "dd-MM-yyyy HH:mm:ss.fff",
                CultureInfo.InvariantCulture
            );
            DateTime timeParse1 = timeParse0.AddSeconds(SamplesNumber * (1 / SamplingRate));
            end.Text = timeParse1.ToString("dd-MM-yyyy HH:mm:ss.fff");

            TimeSpan time = TimeSpan.FromSeconds(SamplesNumber * (1 / SamplingRate));
            duration.Text = time.Days + " - суток, " + time.Hours + " - часов, " + time.Minutes + " - минут, "
               + time.Seconds + "." + time.Milliseconds + " - секунд";

            filename = filename.Replace("C:\\Users\\User\\Desktop\\4 семестр\\Проект по Компьютерной Графике\\", ""); //
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 1;
            dataGridView1.Columns[0].MinimumWidth = 100;
            dataGridView1.Columns[1].MinimumWidth = 200;
            dataGridView1.Columns[2].MinimumWidth = 200;
            dataGridView1.Columns[0].HeaderText = "N";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Источник";
            for (int i = 0; i < ChannelsNumber; i++)
            {
                dataGridView1.Rows.Add((i + 1).ToString(), ChannelsNames[i], "Файл: " + filename);
            }
            
        }
    }
}
