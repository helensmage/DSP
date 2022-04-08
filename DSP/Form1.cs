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
            if (Holder.oscillo != null) Holder.oscillo.Close();
            f2 = new Form2(this);
            f2.MdiParent = this;
            f2.Show();
            
            Holder.SubOscillogram = new ToolStripMenuItem[Holder.ChannelsNumber]; // создаём подменю "осциллограммы"
            for (int i = 0; i < Holder.ChannelsNames.Length; i++)
            {
                Holder.SubOscillogram[i] = new ToolStripMenuItem(Holder.ChannelsNames[i]) { Checked = false, CheckOnClick = true };
                Holder.SubOscillogram[i].Size = new Size(150, 26);
                this.oscillogramToolStripMenuItem.DropDownItems.Add(Holder.SubOscillogram[i]); // добавляем в меню "осциллограммы"
            }
            //Holder.CurIndArray = new List<int>();
            for (int i = 0; i < Holder.ChannelsNames.Length; i++)
            {
                Holder.SubOscillogram[i].Click += ShowOscillogram; // при клике на элемент подменю галка меняется
            }
        }

        private void ShowOscillogram(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem; // получили элемент подменю по клику
            Holder.CurrentIndex = Array.IndexOf(Holder.ChannelsNames, menuItem.ToString()); // узнали этого элемента индекс
            
            if (menuItem.Checked) // проверяем, есть ли теперь галка на элементе подменю
            {
                //Holder.flagOscillo = true;
                if (Holder.oscillo == null && Holder.Ocsillograms == null) // если в словаре нет пока осцилограмм
                {
                    Holder.Ocsillograms = new List<Chart>(); // создаём словарь осциллограмм
                    Holder.CurIndArray = new List<int>();
                    Holder.oscillo = new Form5(this); // создаём окно
                    Holder.oscillo.MdiParent = this;
                    Holder.oscillo.Show();
                }
                else // если уже есть осциллограммы, то надо добавить - вызвать функцию формы5 load
                {
                    // ложня
                    Holder.oscillo.Form5_Load(null, null);
                    //Holder.oscillo.Refresh();
                }
            }
            else // проверяем, если теперь нет галки на элементе подменю
            {
                Holder.Ocsillograms[Holder.CurIndArray.IndexOf(Holder.CurrentIndex)].Dispose(); //
                Holder.Ocsillograms.Remove(Holder.Ocsillograms[Holder.CurIndArray.IndexOf(Holder.CurrentIndex)]); // удаляем из словаря осциллограмм по ключу-названию канала
                Holder.CurIndArray.Remove(Holder.CurrentIndex);
                if (Holder.Ocsillograms.Count == 0) // если после удаления в словаре не осталось осциллограмм
                {
                    Holder.oscillo.Close(); // то закрыть окно
                }
                else
                {
                    // иначе вызвать функцию перерисовки окна
                    Holder.oscillo.Height = 90 + 200 * (Holder.Ocsillograms.Count) + 40;
                    for (int i = 0; i < Holder.Ocsillograms.Count; i++)
                    {
                        Holder.Ocsillograms[i].SetBounds(0, 90 + 200 * i, Holder.oscillo.ClientSize.Width, 200); // H = 200
                    }
                    Holder.oscillo.panel1_Paint(null, null);
                }
            }
        }

        private void informationAboutSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                inf = new Form3(this);
                inf.MdiParent = this;
                inf.Show();
            }
            catch
            {
                MessageBox.Show("Пожалуйста, откройте файл!!!", "Предупреждение");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            HelpToolStripMenuItem.Click += HelpClick;

            OpenToolStripMenuItem.Click += OpenClick;

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
    }
}
