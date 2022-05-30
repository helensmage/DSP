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
        public Form2 f2;
        Form3 inf;
        Form6 f6;
        //Form5 oscillo;
        //private System.Windows.Forms.ToolStripMenuItem[] SubOscillogram;

        public Form1()
        {
            InitializeComponent();
            Holder.lastNumberModelName = new int[15];
            for (int i = 0; i < 15; i++)
            {
                Holder.lastNumberModelName[i] = 0;
            }
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
                for (int i = 0; i < Holder.ChannelsNames.Count; i++)
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
            Holder.zoomY = Holder.SamplesNumber;
            Holder.SamplingRate = float.Parse(array[5], CultureInfo.InvariantCulture.NumberFormat);
            Holder.StartDate = array[7];
            Holder.StartTime = array[9];
            Holder.ChannelsNames = new List<string>();
            string s = "";
            //int k = 0;
            for (int i = 0; i < array[11].Length; i++)
            {
                if (array[11][i] != ';')
                {
                    s += array[11][i];
                }
                if (array[11][i] == ';' || i == array[11].Length - 1)
                {
                    Holder.ChannelsNames.Add(s);
                    s = "";
                    //k++;
                }
            }

            float[][] arr = new float[Holder.ChannelsNumber][];
            for (int i = 0; i < Holder.ChannelsNumber; i++)
            {
                arr[i] = new float[Holder.SamplesNumber];
            }
            for (int i = 12; i < Holder.SamplesNumber + 12; i++)
            {
                int k = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != ' ')
                    {
                        s += array[i][j];
                    }
                    if (array[i][j] == ' ' || j == array[i].Length - 1)
                    {
                        arr[k][i - 12] = float.Parse(s, CultureInfo.InvariantCulture.NumberFormat);
                        s = "";
                        k++;
                    }
                }
            }
            Holder.table = arr.ToList();

            if (f2 != null) f2.Close();
            if (inf != null) inf.Close();
            if (Holder.oscillo != null)
            {
                if (Holder.Ocsillograms != null) { Holder.Ocsillograms.Clear(); Holder.Ocsillograms = null; }
                if (Holder.CurIndArray != null) { Holder.CurIndArray.Clear(); Holder.CurIndArray = null; }
                Holder.oscillo.Close();
            }
            if (f6 != null) f6.Close();
            closeOtherForms();
            Holder.closeOtherStatistics();
            //Holder.closeForms();
            f2 = new Form2(this);
            f2.MdiParent = this;
            f2.Show();

            Holder.SubOscillogram = new List<ToolStripMenuItem>(); // создаём подменю "осциллограммы"
            //for (int i = 0; i < Holder.ChannelsNames.Count; i++)
            foreach (string name in Holder.ChannelsNames)
            {
                Holder.SubOscillogram.Add(new ToolStripMenuItem(name) { Checked = false, CheckOnClick = true });
                Holder.SubOscillogram[Holder.SubOscillogram.Count - 1].Size = new Size(150, 26);
                this.oscillogramToolStripMenuItem.DropDownItems.Add(Holder.SubOscillogram[Holder.SubOscillogram.Count - 1]); // добавляем в меню "осциллограммы"
            }
            //Holder.CurIndArray = new List<int>();
            for (int i = 0; i < Holder.SubOscillogram.Count; i++)
            {
                Holder.SubOscillogram[i].Click += ShowOscillogram; // при клике на элемент подменю галка меняется
            }
        }
        public void oscillogramToolStripMenuItemClear()
        {
            this.oscillogramToolStripMenuItem.DropDownItems.Clear();
        }
        public void addSubOscillogram(string s)
        {
            Holder.SubOscillogram.Add(new ToolStripMenuItem(s) { Checked = false, CheckOnClick = true });
            Holder.SubOscillogram[Holder.SubOscillogram.Count - 1].Size = new Size(150, 26);
            this.oscillogramToolStripMenuItem.DropDownItems.Add(Holder.SubOscillogram[Holder.SubOscillogram.Count - 1]);
            Holder.SubOscillogram.Last().Click += ShowOscillogram;
        }
        private void ShowOscillogram(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem; // получили элемент подменю по клику
            Holder.CurrentIndex = Holder.ChannelsNames.IndexOf(menuItem.ToString()); // узнали этого элемента индекс

            if (menuItem.Checked) // проверяем, есть ли теперь галка на элементе подменю
            {
                //Holder.flagOscillo = true;
                if (Holder.Ocsillograms == null) // если в словаре нет пока осцилограмм
                {
                    Holder.Ocsillograms = new List<Chart>(); // создаём словарь осциллограмм
                    Holder.CurIndArray = new List<int>();
                    Holder.oscillo = new Form5(this); // создаём окно
                    Holder.oscillo.MdiParent = this;
                    Holder.oscillo.Show();
                }
                else // если уже есть осциллограммы, то надо добавить - вызвать функцию формы5 load
                {
                    Holder.oscillo.Form5_Load(null, null);
                }
            }
            else // проверяем, если теперь нет галки на элементе подменю
            {
                Holder.Ocsillograms[Holder.CurIndArray.IndexOf(Holder.CurrentIndex)].Dispose(); //
                Holder.Ocsillograms.Remove(Holder.Ocsillograms[Holder.CurIndArray.IndexOf(Holder.CurrentIndex)]); // удаляем из словаря осциллограмм по ключу-названию канала
                Holder.CurIndArray.Remove(Holder.CurrentIndex);
                if (Holder.Ocsillograms.Count == 0) // если после удаления в словаре не осталось осциллограмм
                {
                    if (Holder.Ocsillograms != null) { Holder.Ocsillograms.Clear(); Holder.Ocsillograms = null; }
                    Holder.oscillo.Close(); // то закрыть окно

                }
                else
                {
                    // иначе вызвать функцию перерисовки окна
                    Holder.oscillo.Height = 90 + 200 * (Holder.Ocsillograms.Count) + 40;
                    for (int i = 0; i < Holder.Ocsillograms.Count; i++)
                    {
                        Holder.Ocsillograms[i].SetBounds(0, 90 + 200 * i, Holder.oscillo.ClientSize.Width - 20, 200); // H = 200
                    }
                    //Holder.oscillo.panel1_Paint(null, null);
                }
            }
        }

        private void informationAboutSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Holder.ChannelsNames != null)
            {
                inf = new Form3(this);
                inf.MdiParent = this;
                inf.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, откройте файл!!!", "Предупреждение");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            HelpToolStripMenuItem.Click += HelpClick;

            OpenToolStripMenuItem.Click += OpenClick;

            сохранитьToolStripMenuItem.Click += SaveToolStripMenuItem_Click;

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";


        }

        private void fragmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Holder.Ocsillograms != null)
            {
                f6 = new Form6(this);
                f6.MdiParent = this;
                f6.Show();
            }
        }
        public void closeOtherForms()
        {
            FormCollection collection = Application.OpenForms;

            foreach (Form frm in collection)
            {
                if (frm.GetType() == typeof(Model))
                {
                    frm.Close();
                    break;
                }
            }
            foreach (Form frm in collection)
            {
                if (frm.GetType() == typeof(SmallModel))
                {
                    frm.Close();
                    break;
                }
            }
            foreach (Form frm in collection)
            {
                if (frm.GetType() == typeof(Navigation2))
                {
                    frm.Close();
                    break;
                }
            }
            foreach (Form frm in collection)
            {
                if (frm.GetType() == typeof(Channels))
                {
                    frm.Close();
                    break;
                }
            }
            /*Holder.flagSamples = true;
            Holder.flagRate = true;*/
        }
        private void signal11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 1;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 2;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 3;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signail14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 4;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 5;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 6;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal21ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 7;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal22ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 8;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal23ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 9;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void signal24ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 10;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Holder.ChannelsNumber != null)
            {
                SaveForm sv = new SaveForm();
                sv.Show();
            }
        }

        private void сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 11;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 12;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            Holder.check = 13;
            SmallModel modelling = new SmallModel(this);
            modelling.MdiParent = this;
            modelling.Show();
        }

        private void линейнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Holder.bbb != null && Holder.bbb.Count > 0)
            {
                closeOtherForms();
                Holder.check = 14;
                Channels channels = new Channels(this);
                channels.MdiParent = this;
                channels.Show();
            }
        }

        private void мультипликативнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Holder.bbb != null && Holder.bbb.Count > 0)
            {
                closeOtherForms();
                Holder.check = 15;
                Channels channels = new Channels(this);
                channels.MdiParent = this;
                channels.Show();
            }
        }
        private void ShowHistogram(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem; // получили элемент подменю по клику
            Holder.CurrentIndex = Holder.ChannelsNames.IndexOf(menuItem.ToString()); // узнали этого элемента индекс
            //Holder.closeOtherStatistics();
            Holder.statistics = new Statistics(this);
            Holder.statistics.MdiParent = this;
            Holder.statistics.Show();
        }

        private void статистикиToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            if (Holder.ChannelsNames != null)
            {
                this.статистикиToolStripMenuItem.DropDownItems.Clear();
                List<ToolStripMenuItem> SubHistogram = new List<ToolStripMenuItem>();
                foreach (string name in Holder.ChannelsNames)
                {
                    SubHistogram.Add(new ToolStripMenuItem(name));
                    SubHistogram[SubHistogram.Count - 1].Size = new Size(150, 26);
                    this.статистикиToolStripMenuItem.DropDownItems.Add(SubHistogram[SubHistogram.Count - 1]);
                }
                for (int i = 0; i < Holder.SubOscillogram.Count; i++)
                {
                    SubHistogram[i].Click += ShowHistogram;
                }
            }
        }
    }
}
