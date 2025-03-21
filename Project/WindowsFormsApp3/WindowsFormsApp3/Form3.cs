using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        private Student st;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Student st)
        {
            this.st = st;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = st.UName;
            comboBox1.Text = st.Yx;
            listBox1.Text = st.Zy;
            if (st.Xb.Equals("男"))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            if (st.Ah.Contains(checkBox1.Text))
            {
                checkBox1.Checked = true;
            }
            if (st.Ah.Contains(checkBox2.Text))
            {
                checkBox2.Checked = true;
            }
            if (st.Ah.Contains(checkBox3.Text))
            {
                checkBox3.Checked = true;
            }
            dateTimePicker1.Text = st.Sr;
            richTextBox1.Text = st.Jj;
            for (int i =0;i<checkedListBox1.Items.Count;i++)
            {
                object oc = checkedListBox1.Items[i];
                if (st.Xq.Contains(oc.ToString()))
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }
    }
}
