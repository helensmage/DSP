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
    public partial class Gistoparam : Form
    {
        Form1 Parent;
        float min;
        float max;
        public Gistoparam(Form1 ParentForm, float _min, float _max)
        {
            InitializeComponent();
            Parent = ParentForm;
            max = _max;
            min = _min;
        }

        private void Gistoparam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Holder.K = int.Parse(textBox1.Text);
                Holder.h = (max - min) / Holder.K;
            }
            else
            {
                Holder.h = float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.K = (int)Math.Ceiling((max - min) / Holder.h);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            Holder.statistics.drawHistogram();
            this.Close();
        }
    }
}
