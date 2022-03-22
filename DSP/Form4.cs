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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнили: студенты 2-го курса факультета математики и компьютерных наук Шестопалова А.В., Прохорова Д.Д., Смагина Е.Г.", "Информация об авторах");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1) технология ввода многоканальных сигналов из файлов формата TXT \n \n" +
                "2) средство навигации по каналам, позволяющее видеть полный список каналов и выбирать любой их них для отображения либо анализа \n \n" +
                "3) средство информирования пользователя о текущем состоянии многоканального сигнала",
                "Были реализованы:");
        }
    }
}
