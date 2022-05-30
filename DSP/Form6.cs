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
    public partial class Form6 : Form
    {
        Form1 Parent;
        public Form6(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = Holder.SamplesNumber.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Holder.zoomX = double.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
            Holder.zoomY = double.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
            Holder.oscillo.fragmentZoom(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
