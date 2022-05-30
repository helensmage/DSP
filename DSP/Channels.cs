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
    public partial class Channels : Form
    {
        Form1 Parent;
        public Channels(Form1 ParentForm)
        {
            InitializeComponent();
            Parent = ParentForm;
            foreach (string channel in Holder.ChannelsNames)
            {
                checkedListBox1.Items.Add(channel);
            }
            //checkedListBox1.Items.AddRange(Holder.ChannelsNames);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не было выбрано ни одного канала");
            }
            else
            {
                if (Holder.CheckBoxNames == null)
                {
                    Holder.CheckBoxNames = new List<string>();
                }
                for (int j = 0; j < Holder.ChannelsNumber; j++)
                {
                    if (checkedListBox1.GetItemChecked(j) == true)
                    {
                        //MessageBox.Show(Holder.ChannelsNames[j] + " ");
                        Holder.CheckBoxNames.Add(Holder.ChannelsNames[j]);
                    }
                }
                Navigation2 parametres = new Navigation2(Parent);
                parametres.MdiParent = Parent;
                parametres.Show();
            }
        }
    }
}
