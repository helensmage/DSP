using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace DSP
{
    public partial class Form1 : Form
    {
        Form2 f2;
        Form3 inf;
        //Form5 oscillo;
        //private System.Windows.Forms.ToolStripMenuItem[] SubOscillogram;

        public Form1()
        {
            InitializeComponent();
        }

        private void HelpClick(object sender, EventArgs e)
        {
            Form4 help = new Form4();
            help.Show();
        }
        
        private void OpenClick(object sender, EventArgs e)
        {
            if (Holder.SubOscillogram != null)
            {
                for (int i = 0; i < Holder.ChannelsNames.Length; i++)
                {
                    Holder.SubOscillogram[i].Dispose();
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            Holder.filename = openFileDialog1.FileName;

            string[] array = File.ReadAllLines(Holder.filename, Encoding.Default);
            // Распарсить
            Holder.ChannelsNumber = int.Parse(array[1]);
            Holder.SamplesNumber = int.Parse(array[3]);
            Holder.SamplingRate = float.Parse(array[5], CultureInfo.InvariantCulture.NumberFormat);
            Holder.StartDate = array[7];
            Holder.StartTime = array[9];
            Holder.ChannelsNames = new string[Holder.ChannelsNumber];
            string s = "";
            int k = 0;
            for (int i = 0; i < array[11].Length; i++)
            {
                if (array[11][i] != ';')
                {
                    s += array[11][i];
                }
                if (array[11][i] == ';' || i == array[11].Length - 1)
                {
                    Holder.ChannelsNames[k] = s;
                    s = "";
                    k++;
                }
            }

            Holder.table = new float[Holder.ChannelsNumber][];
            for (int i = 0; i < Holder.ChannelsNumber; i++)
            {
                Holder.table[i] = new float[Holder.SamplesNumber];
            }
            for (int i = 12; i < Holder.SamplesNumber + 12; i++)
            {
                k = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != ' ')
                    {
                        s += array[i][j];
                    }
                    if (array[i][j] == ' ' || j == array[i].Length - 1)
                    {
                        Holder.table[k][i - 12] = float.Parse(s, CultureInfo.InvariantCulture.NumberFormat);
                        s = "";
                        k++;
                    }
                }
            }

            if (f2 != null) f2.Close();
            if (inf != null) inf.Close();
            f2 = new Form2();
            f2.Show();
            
            Holder.SubOscillogram = new ToolStripMenuItem[Holder.ChannelsNumber];
            for (int i = 0; i < Holder.ChannelsNames.Length; i++)
            {
                Holder.SubOscillogram[i] = new ToolStripMenuItem(Holder.ChannelsNames[i]) { Checked = false, CheckOnClick = true }; ;
                Holder.SubOscillogram[i].Size = new Size(150, 26);
                //Holder.SubOscillogram[i].Text = Holder.ChannelsNames[i];
                this.oscillogramToolStripMenuItem.DropDownItems.Add(Holder.SubOscillogram[i]);
            }
            for (int i = 0; i < Holder.ChannelsNames.Length; i++)
            {
                Holder.SubOscillogram[i].Click += ShowOscillogram;
            }
        }

        private void ShowOscillogram(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            Holder.CurrentIndex = Array.IndexOf(Holder.ChannelsNames, menuItem.ToString());
            if (menuItem.Checked)
            {
                Holder.flagOscillo = true;
                if (Holder.Ocsillograms == null)
                {
                    Holder.Ocsillograms = new Dictionary<string, Bitmap>();
                }
                else
                {
                    Holder.oscillo.Close();
                }
                /*if (!Holder.Ocsillograms.ContainsKey(Holder.ChannelsNames[Holder.CurrentIndex]))
                {

                }*/
                Holder.oscillo = new Form5();
                Holder.oscillo.Show();
            }
            else
            {
                Holder.flagOscillo = false;
                Holder.Ocsillograms.Remove(Holder.ChannelsNames[Holder.CurrentIndex]);
                // Вызвать функцию перерисовки окна
                Holder.oscillo.Close();
                if (Holder.Ocsillograms.Count != 0)
                {
                    Holder.oscillo = new Form5();
                    Holder.oscillo.Show();
                }
            }
        }

        private void informationAboutSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                inf = new Form3();
                inf.Show();
            }
            catch
            {
                MessageBox.Show("Пожалуйста, откройте файл!!!", "Предупреждение");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HelpToolStripMenuItem.Click += HelpClick;

            OpenToolStripMenuItem.Click += OpenClick;

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
    }
}
