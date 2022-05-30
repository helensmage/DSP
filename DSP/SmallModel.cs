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
    public partial class SmallModel : Form
    {
        Form1 Parent;
        //глобальные textbox
        TextBox nbox;
        TextBox fdbox;
        TextBox n0box;
        TextBox abox;
        TextBox wbox;
        TextBox fibox;
        TextBox lbox;
        TextBox tbox;
        TextBox fbox;
        TextBox fobox;
        TextBox fnbox;
        TextBox mbox;
        TextBox fkbox;
        TextBox a1box;
        TextBox b1box;
        TextBox averagebox;
        TextBox dispersionbox;
        TextBox pbox;
        TextBox qbox;
        public SmallModel(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
            Holder.flagSamples = false;
            Holder.flagRate = false;
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
            foreach (Form frm in collection)
            {
                if (frm.GetType() == typeof(Navigation2))
                {
                    frm.Close();
                    break;
                }
            }
            /*Holder.flagSamples = true;
            Holder.flagRate = true;*/
        }
        private void shablon(int h, int w, string s, int okx, int oky)
        {
            this.Height = h;
            this.Width = w;
            Label labelname = new Label();
            labelname.Location = new Point(12, 10);
            labelname.Text = s;
            labelname.Size = new Size(this.Width - 13, 30);
            labelname.Font = new Font(labelname.Font, labelname.Font.Style | FontStyle.Bold);
            this.Controls.Add(labelname);
            Label n = new Label();
            n.Location = new Point(12, 40);
            n.Text = "Количество отсчётов n:";
            n.Size = new Size(this.Width - 13, 20);
            this.Controls.Add(n);
            nbox = new TextBox();
            nbox.Text = Holder.SamplesNumber.ToString();
            nbox.Location = new Point(13, 60);
            nbox.Size = new Size(this.Width - 39, 20);
            nbox.TextChanged += textBoxN_TextChanged;
            this.Controls.Add(nbox);
            Label fd = new Label();
            fd.Location = new Point(12, 85);
            fd.Text = "Частота дискретизации fd:";
            fd.Size = new Size(this.Width - 13, 20);
            this.Controls.Add(fd);
            fdbox = new TextBox();
            fdbox.Text = Holder.SamplingRate.ToString();
            fdbox.Location = new Point(13, 105);
            fdbox.Size = new Size(this.Width - 39, 20);
            fdbox.TextChanged += textBoxFd_TextChanged;
            this.Controls.Add(fdbox);
            Button okay = new Button();
            okay.Size = new Size(80, 30);
            okay.Text = "ОК";
            okay.Location = new Point(okx, oky);
            this.Controls.Add(okay);
            okay.Click += Ok_Click;
        }
        private void fillwindow12(string s, string s1)
        {
            this.shablon(270, 250, s, 13, 190);
            Label n0 = new Label();
            n0.Location = new Point(13, 130);
            n0.Text = s1;
            n0.Size = new Size(this.Width - 13, 20);
            this.Controls.Add(n0);
            n0box = new TextBox();
            n0box.Text = Holder.n0.ToString();
            n0box.Location = new Point(13, 150);
            n0box.Size = new Size(this.Width - 39, 20);
            this.Controls.Add(n0box);
        }
        private void textBoxN_TextChanged(object sender, EventArgs e)
        {
            //как-нибудь пометить это флагом
            Holder.flagSamples = true;
        }
        private void textBoxFd_TextChanged(object sender, EventArgs e)
        {
            //как-нибудь пометить это флагом
            Holder.flagRate = true;
        }
        private void fillwindow56(string s)
        {
            this.shablon(270, 200, s, 13, 190);
            Label l = new Label();
            l.Location = new Point(13, 130);
            l.Text = "Период L:";
            l.Size = new Size(this.Width - 13, 20);
            this.Controls.Add(l);
            lbox = new TextBox();
            lbox.Text = Holder.l.ToString();
            lbox.Location = new Point(13, 150);
            lbox.Size = new Size(this.Width - 39, 20);
            this.Controls.Add(lbox);
        }
        private void SmallModel_Load(object sender, EventArgs e)
        {
            if (Holder.check == 1)
            {
                this.fillwindow12("Задержанный единичный импульс", "Задержка импульса n0:");
            }
            else if (Holder.check == 2)
            {
                this.fillwindow12("Задержанный единичный скачок", "Задержка скачка n0:");
            }
            else if (Holder.check == 3)
            {
                this.shablon(270, 320, "Дискретизированная убывающая экспонента", 13, 190);
                Label a = new Label();
                a.Location = new Point(13, 130);
                a.Text = "Амплитуда 0 < a < 1:";
                a.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(a);
                abox = new TextBox();
                abox.Text = Holder.a3.ToString().Replace(",", ".");
                abox.Location = new Point(13, 150);
                abox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(abox);
            }
            else if (Holder.check == 4)
            {
                this.shablon(360, 240, "Дискретизированная синусоида", 13, 280);
                Label a = new Label();
                a.Location = new Point(13, 130);
                a.Text = "Амплитуда 0 < a < 1:";
                a.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(a);
                abox = new TextBox();
                abox.Text = Holder.a.ToString();
                abox.Location = new Point(13, 150);
                abox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(abox);

                Label w = new Label();
                w.Location = new Point(13, 175);
                w.Text = "Круговая частота 0 <= w <= pi:";
                w.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(w);
                wbox = new TextBox();
                wbox.Text = Holder.w.ToString().Replace(",", ".");
                wbox.Location = new Point(13, 195);
                wbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(wbox);

                Label fi = new Label();
                fi.Location = new Point(13, 220);
                fi.Text = "Начальная фаза 0 <= fi <= 2pi:";
                fi.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fi);
                fibox = new TextBox();
                fibox.Text = Holder.fi.ToString();
                fibox.Location = new Point(13, 240);
                fibox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fibox);
            }
            else if (Holder.check == 5)
            {
                this.fillwindow56("Меандр");
            }
            else if (Holder.check == 6)
            {
                this.fillwindow56("Пила");
            }
            else if (Holder.check == 7)
            {
                this.shablon(405, 283, "Сигнал с экспоненциальной огибающей", 13, 325);
                Label a = new Label();
                a.Location = new Point(13, 130);
                a.Text = "Амплитуда 0 < a < 1:";
                a.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(a);
                abox = new TextBox();
                abox.Text = Holder.a.ToString();
                abox.Location = new Point(13, 150);
                abox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(abox);

                Label t = new Label();
                t.Location = new Point(13, 175);
                t.Text = "Параметр ширины огибающей t:";
                t.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(t);
                tbox = new TextBox();
                tbox.Text = Holder.t.ToString();
                tbox.Location = new Point(13, 195);
                tbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(tbox);

                Label f = new Label();
                f.Location = new Point(13, 220);
                f.Text = "Частота несущей 0 <= f <= 0.5fd:";
                f.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(f);
                fbox = new TextBox();
                fbox.Text = Holder.f.ToString();
                fbox.Location = new Point(13, 240);
                fbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fbox);

                Label fi = new Label();
                fi.Location = new Point(13, 265);
                fi.Text = "Начальная фаза 0 <= fi <= 2pi:";
                fi.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fi);
                fibox = new TextBox();
                fibox.Text = Holder.fi.ToString();
                fibox.Location = new Point(13, 285);
                fibox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fibox);
            }
            else if (Holder.check == 8)
            {
                this.shablon(405, 233, "Сигнал с балансной огибающей", 13, 325);
                Label a = new Label();
                a.Location = new Point(13, 130);
                a.Text = "Амплитуда 0 < a < 1:";
                a.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(a);
                abox = new TextBox();
                abox.Text = Holder.a.ToString();
                abox.Location = new Point(13, 150);
                abox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(abox);

                Label fo = new Label();
                fo.Location = new Point(13, 175);
                fo.Text = "Частота огибающей 0 <= fo <= 0.5fd:";
                fo.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fo);
                fobox = new TextBox();
                fobox.Text = Holder.fo.ToString().Replace(",", ".");
                fobox.Location = new Point(13, 195);
                fobox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fobox);

                Label fn = new Label();
                fn.Location = new Point(13, 220);
                fn.Text = "Частота несущей 0 <= fn <= 0.5fd:";
                fn.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fn);
                fnbox = new TextBox();
                fnbox.Text = Holder.fn.ToString();
                fnbox.Location = new Point(13, 240);
                fnbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fnbox);

                Label fi = new Label();
                fi.Location = new Point(13, 265);
                fi.Text = "Начальная фаза 0 <= fi <= 2pi:";
                fi.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fi);
                fibox = new TextBox();
                fibox.Text = Holder.fi.ToString();
                fibox.Location = new Point(13, 285);
                fibox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fibox);
            }
            else if (Holder.check == 9)
            {
                this.shablon(450, 243, "Сигнал с тональной огибающей", 13, 370);
                Label a = new Label();
                a.Location = new Point(13, 130);
                a.Text = "Амплитуда 0 < a < 1:";
                a.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(a);
                abox = new TextBox();
                abox.Text = Holder.a.ToString();
                abox.Location = new Point(13, 150);
                abox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(abox);

                Label fo = new Label();
                fo.Location = new Point(13, 175);
                fo.Text = "Частота огибающей 0 <= fo <= 0.5fd:";
                fo.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fo);
                fobox = new TextBox();
                fobox.Text = Holder.fo.ToString().Replace(",", ".");
                fobox.Location = new Point(13, 195);
                fobox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fobox);

                Label fn = new Label();
                fn.Location = new Point(13, 220);
                fn.Text = "Частота несущей 0 <= fn <= 0.5fd:";
                fn.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fn);
                fnbox = new TextBox();
                fnbox.Text = Holder.fn.ToString();
                fnbox.Location = new Point(13, 240);
                fnbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fnbox);

                Label fi = new Label();
                fi.Location = new Point(13, 265);
                fi.Text = "Начальная фаза 0 <= fi <= 2pi:";
                fi.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fi);
                fibox = new TextBox();
                fibox.Text = Holder.fi.ToString();
                fibox.Location = new Point(13, 285);
                fibox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fibox);

                Label m = new Label();
                m.Location = new Point(13, 310);
                m.Text = "Индекс глубины модуляции 0 <= m <= 1:";
                m.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(m);
                mbox = new TextBox();
                mbox.Text = Holder.m.ToString().Replace(",", ".");
                mbox.Location = new Point(13, 330);
                mbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(mbox);
            }
            else if (Holder.check == 10)
            {
                this.shablon(410, 296, "Сигнал с линейной частотной модуляцией", 13, 330);
                Label a = new Label();
                a.Location = new Point(13, 130);
                a.Text = "Амплитуда 0 < a < 1:";
                a.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(a);
                abox = new TextBox();
                abox.Text = Holder.a.ToString();
                abox.Location = new Point(13, 150);
                abox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(abox);

                Label fo = new Label();
                fo.Location = new Point(13, 175);
                fo.Text = "Частота в начальный момент времени f0 (t = 0):";
                fo.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fo);
                fobox = new TextBox();
                fobox.Text = Holder.fo.ToString().Replace(",", ".");
                fobox.Location = new Point(13, 195);
                fobox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fobox);

                Label fk = new Label();
                fk.Location = new Point(13, 220);
                fk.Text = "Частота в конечный момент времени fk:";
                fk.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fk);
                fkbox = new TextBox();
                fkbox.Text = Holder.fk.ToString().Replace(",", ".");
                fkbox.Location = new Point(13, 240);
                fkbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fkbox);

                Label fi = new Label();
                fi.Location = new Point(13, 265);
                fi.Text = "Начальная фаза 0 <= fi <= 2pi:";
                fi.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(fi);
                fibox = new TextBox();
                fibox.Text = Holder.fi.ToString();
                fibox.Location = new Point(13, 285);
                fibox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(fibox);
            }
            else if (Holder.check == 11)
            {
                this.shablon(320, 244, "Сигнал белого шума в интервале", 13, 240);
                Label a1 = new Label();
                a1.Location = new Point(13, 130);
                a1.Text = "a:";
                a1.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(a1);
                a1box = new TextBox();
                a1box.Text = Holder.a1.ToString();
                a1box.Location = new Point(13, 150);
                a1box.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(a1box);

                Label b1 = new Label();
                b1.Location = new Point(13, 175);
                b1.Text = "b:";
                b1.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(b1);
                b1box = new TextBox();
                b1box.Text = Holder.b1.ToString();
                b1box.Location = new Point(13, 195);
                b1box.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(b1box);
            }
            else if (Holder.check == 12)
            {
                this.shablon(320, 244, "Сигнал белого шума \ncо средним и дисперсией", 13, 240);
                Label average = new Label();
                average.Location = new Point(13, 130);
                average.Text = "Среднее a:";
                average.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(average);
                averagebox = new TextBox();
                averagebox.Text = Holder.average.ToString();
                averagebox.Location = new Point(13, 150);
                averagebox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(averagebox);

                Label dispersion = new Label();
                dispersion.Location = new Point(13, 175);
                dispersion.Text = "Дисперсия sigma^2:";
                dispersion.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(dispersion);
                dispersionbox = new TextBox();
                dispersionbox.Text = Holder.dispersion.ToString();
                dispersionbox.Location = new Point(13, 195);
                dispersionbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(dispersionbox);
            }
            else if (Holder.check == 13)
            {
                this.shablon(320, 260, "Сигнал авторегрессии-скользящего \nсреднего порядка - APCC", 13, 240);
                Label p = new Label();
                p.Location = new Point(13, 130);
                p.Text = "p:";
                p.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(p);
                pbox = new TextBox();
                pbox.Text = Holder.p.ToString();
                pbox.Location = new Point(13, 150);
                pbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(pbox);

                Label q = new Label();
                q.Location = new Point(13, 175);
                q.Text = "q:";
                q.Size = new Size(this.Width - 13, 20);
                this.Controls.Add(q);
                qbox = new TextBox();
                qbox.Text = Holder.q.ToString();
                qbox.Location = new Point(13, 195);
                qbox.Size = new Size(this.Width - 39, 20);
                this.Controls.Add(qbox);
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            closeOtherForms();
            if (Holder.flagSamples) //100 = Holder.n из холдер
            {
                //количество изменилось
                Holder.SamplesNumber = int.Parse(nbox.Text);
                Holder.zoomY = Holder.SamplesNumber;
            }
            if (Holder.flagRate) //12 = Holder.fd из холдер
            {
                //частота изменилось
                Holder.SamplingRate = float.Parse(fdbox.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
            if (Holder.check == 1 || Holder.check == 2)
            {
                //записать глобальные в холдер
                Holder.n0 = int.Parse(n0box.Text);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 3)
            {
                //записать глобальные в холдер
                Holder.a3 = double.Parse(abox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 4)
            {
                //записать глобальные в холдер
                Holder.a = double.Parse(abox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.w = double.Parse(wbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fi = double.Parse(fibox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 5 || Holder.check == 6)
            {
                //записать глобальные в холдер
                Holder.l = double.Parse(lbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 7)
            {
                //записать глобальные в холдер
                Holder.a = double.Parse(abox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.t = double.Parse(tbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.f = double.Parse(fbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fi = double.Parse(fibox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 8)
            {
                //записать глобальные в холдер
                Holder.a = double.Parse(abox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fo = double.Parse(fobox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fn = double.Parse(fnbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fi = double.Parse(fibox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 9)
            {
                //записать глобальные в холдер
                Holder.a = double.Parse(abox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fo = double.Parse(fobox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fn = double.Parse(fnbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fi = double.Parse(fibox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.m = double.Parse(mbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 10)
            {
                //записать глобальные в холдер
                Holder.a = double.Parse(abox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fo = double.Parse(fobox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.fk = double.Parse(fkbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.T = Holder.SamplesNumber * (1 / Holder.SamplingRate);
                Holder.fi = double.Parse(fibox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 11)
            {
                //записать глобальные в холдер
                Holder.a1 = double.Parse(a1box.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.b1 = double.Parse(b1box.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 12)
            {
                //записать глобальные в холдер
                Holder.average = double.Parse(averagebox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Holder.dispersion = double.Parse(dispersionbox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Model model = new Model(Parent);
                model.MdiParent = Parent;
                model.Show();
            }
            else if (Holder.check == 13)
            {
                //записать глобальные в холдер
                Holder.p = int.Parse(pbox.Text);
                Holder.q = int.Parse(qbox.Text);
                //Holder.check = 14;
                Navigation2 modelling = new Navigation2(Parent);
                modelling.MdiParent = Parent;
                modelling.Show();
                /*SmallModel modelling = new SmallModel(Parent);
                modelling.MdiParent = Parent;
                modelling.Show();*/
            }
        }
    }
}
