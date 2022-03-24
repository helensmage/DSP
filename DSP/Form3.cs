using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            TimeSpan time = TimeSpan.FromSeconds(SamplesNumber * (1 / SamplingRate));
            duration.Text = time.Days + " - суток, " + time.Hours + " - часов, " + time.Minutes + " - минут, "
               + time.Seconds + "." + time.Milliseconds + " - секунд";

            /*string dd, MM, yyyy, hh, mm, ss, mss;
            dd = Convert.ToString(StartDate[0]);
            dd += Convert.ToString(StartDate[1]);
            MM = Convert.ToString(StartDate[3]);
            MM += Convert.ToString(StartDate[4]);
            yyyy = Convert.ToString(StartDate[6]);
            yyyy += Convert.ToString(StartDate[7]);
            yyyy += Convert.ToString(StartDate[8]);
            yyyy += Convert.ToString(StartDate[9]);
            hh = Convert.ToString(StartTime[0]);
            hh += Convert.ToString(StartTime[1]);
            mm = Convert.ToString(StartTime[3]);
            mm += Convert.ToString(StartTime[4]);
            ss = Convert.ToString(StartTime[6]);
            ss += Convert.ToString(StartTime[7]);
            mss = Convert.ToString(StartTime[9]);
            mss += Convert.ToString(StartTime[10]);
            mss += Convert.ToString(StartTime[11]);
            end.Text = ((int.Parse(dd) + time.Days)%31).ToString() + "-" + MM + "-" + yyyy + " " + ((int.Parse(hh) + time.Hours)%60).ToString() +
                ":" + ((int.Parse(mm) + time.Minutes)%60).ToString() + ":" + ((int.Parse(ss) + time.Seconds)%60).ToString() + "." + ((int.Parse(mss) + time.Milliseconds)%1000).ToString();

            */filename = filename.Replace("C:\\Users\\User\\Desktop\\4 семестр\\Проект по Компьютерной Графике\\", "");
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
