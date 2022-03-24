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

namespace DSP
{
    public partial class Form1 : Form
    {
        Form2 f2;
        Form3 inf;
        Form4 help;
        public string filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void HelpClick(object sender, EventArgs e)
        {
            help = new Form4();
            help.Show();
        }
        
        private void OpenClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            filename = openFileDialog1.FileName;

            string[] array = File.ReadAllLines(filename, Encoding.Default);
            if (f2 != null) f2.Close();
            f2 = new Form2(array);
            f2.Show();

        }

        private void informationAboutSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                inf = new Form3(f2.ChannelsNumber, f2.SamplesNumber, f2.SamplingRate, f2.StartDate, f2.StartTime, f2.ChannelsNames, filename);
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
