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
    public partial class Navigation2 : Form
    {
        Form1 Parent;
        List<TextBox> textAList;
        List<TextBox> textBList;
        TextBox a15;
        public Navigation2(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
        }
        private void closeOtherForms()
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
            /*Holder.flagSamples = true;
            Holder.flagRate = true;*/
        }
        private void Navigation2_Load(object sender, EventArgs e)
        {
            if (Holder.check == 13)
            {
                //лэйблы
                for (int k = 0; k < Holder.p; k++)
                {
                    Label Abox = new Label();
                    Abox.Location = new Point(13, 5 + k * 45);
                    Abox.Text = "a" + (k + 1);
                    Abox.Size = new Size((this.Width - 39) / 2 - 13, 20);
                    this.Controls.Add(Abox);
                }
                for (int k = 0; k < Holder.q; k++)
                {
                    Label Bbox = new Label();
                    Bbox.Location = new Point(26 + (this.Width - 39) / 2, 5 + k * 45);
                    Bbox.Text = "b" + (k + 1);
                    Bbox.Size = new Size((this.Width - 39) / 2 - 13, 20);
                    this.Controls.Add(Bbox);
                }
                //текстбоксы
                textAList = new List<TextBox>();
                textBList = new List<TextBox>();
                if (Holder.p > Holder.q)
                {
                    this.Height = 45 * (Holder.p) + 90;
                }
                else
                {
                    this.Height = 45 * (Holder.q) + 90;
                }
                this.Width = 250;
                if (Holder.p == 2)
                {
                    TextBox Abox = new TextBox();
                    Abox.Text = "0.68";
                    Abox.Location = new Point(13, 25);
                    Abox.Size = new Size((this.Width - 39) / 2 - 13, 20);
                    textAList.Add(Abox);
                    TextBox Abox1 = new TextBox();
                    Abox1.Text = "0.088";
                    Abox1.Location = new Point(13, 70);
                    Abox1.Size = new Size((this.Width - 39) / 2 - 13, 20);
                    textAList.Add(Abox1);
                }
                else
                {
                    for (int k = 0; k < Holder.p; k++)
                    {
                        TextBox Abox = new TextBox();
                        Abox.Location = new Point(13, 25 + k * 45);
                        Abox.Size = new Size((this.Width - 39) / 2 - 13, 20);
                        textAList.Add(Abox);
                    }
                }
                for (int k = 0; k < Holder.q; k++)
                {
                    TextBox Bbox = new TextBox();
                    Bbox.Location = new Point(26 + (this.Width - 39) / 2, 25 + k * 45);
                    Bbox.Size = new Size((this.Width - 39) / 2 - 13, 20);
                    textBList.Add(Bbox);
                }
                for (int k = 0; k < Holder.p; k++)
                {
                    this.Controls.Add(textAList[k]);
                }
                for (int k = 0; k < Holder.q; k++)
                {
                    this.Controls.Add(textBList[k]);
                }
            }
            else if (Holder.check == 14)
            {
                //лэйблы
                for (int k = 0; k < Holder.CheckBoxNames.Count + 1; k++)
                {
                    Label Abox = new Label();
                    Abox.Location = new Point(13, 5 + k * 45);
                    Abox.Text = "a" + k;
                    Abox.Size = new Size((this.Width - 39) / 2 - 13, 20);
                    this.Controls.Add(Abox);
                }
                //текстбоксы
                textAList = new List<TextBox>();
                this.Height = 45 * (Holder.CheckBoxNames.Count + 1) + 90;
                for (int k = 0; k < (Holder.CheckBoxNames.Count + 1); k++)
                {
                    TextBox Abox = new TextBox();
                    Abox.Location = new Point(13, 25 + k * 45);
                    Abox.Size = new Size((this.Width - 39) / 2 - 13, 20);
                    textAList.Add(Abox);
                }
                for (int k = 0; k < Holder.CheckBoxNames.Count + 1; k++)
                {
                    this.Controls.Add(textAList[k]);
                }
            }
            else if (Holder.check == 15)
            {
                //лэйблы
                Label Alabel = new Label();
                Alabel.Location = new Point(13, 5);
                Alabel.Text = "a";
                Alabel.Size = new Size((this.Width - 39) / 2 - 13, 20);
                this.Controls.Add(Alabel);
                //текстбоксы
                this.Height = 45 + 90;
                a15 = new TextBox();
                a15.Location = new Point(13, 25);
                a15.Size = new Size((this.Width - 39) / 2 - 13, 20);
                this.Controls.Add(a15);
            }
            Button okay = new Button();
            okay.Size = new Size(80, 30);
            okay.Text = "ОК";
            okay.Location = new Point(13, this.Height - 80);
            this.Controls.Add(okay);
            okay.Click += Ok_Click;
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            if (Holder.check == 13)
            {
                closeOtherForms();
                Holder.aiList = new List<double>();
                Holder.biList = new List<double>();
                foreach (TextBox elbox in textAList)
                {
                    Holder.aiList.Add(double.Parse(elbox.Text, CultureInfo.InvariantCulture.NumberFormat));
                }
                foreach (TextBox elbox in textBList)
                {
                    Holder.biList.Add(double.Parse(elbox.Text, CultureInfo.InvariantCulture.NumberFormat));
                }
            }
            else if (Holder.check == 14)
            {
                Holder.aiList = new List<double>();
                foreach (TextBox elbox in textAList)
                {
                    Holder.aiList.Add(double.Parse(elbox.Text, CultureInfo.InvariantCulture.NumberFormat));
                }
            }
            else if (Holder.check == 15)
            {
                Holder.a15 = float.Parse(a15.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
            Model model = new Model(Parent);
            model.MdiParent = Parent;
            model.Show();
        }
    }
}
