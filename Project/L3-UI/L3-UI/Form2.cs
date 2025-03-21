using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3_UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uName=textBox1.Text.Trim();
            string yx=comboBox1.Text.Trim();
            string zy=listBox1.Text.Trim();
            string xb = radioButton1.Checked ? "男" : "女";
            string ah = "";
            string xq = "";
            string jj=richTextBox1.Text.Trim();
            if (checkBox1.Checked )
            {
                ah += checkBox1.Text + ",";
            }
            if (checkBox2.Checked)
            {
                ah += checkBox2.Text + ",";
            }
            if (checkBox3.Checked)
            {
                ah += checkBox3.Text + ",";
            }
            if (checkBox4.Checked)
            {
                ah += checkBox4.Text + ",";
            }
           if(ah!="")//如果选中了爱好，去掉最后的都好
            {
                ah = ah.Substring(0, ah.Length - 1);
            }
           foreach(var item in checkedListBox1.CheckedItems)
            {
                xq = item+",";

            }
            string msg = uName + "" + yx + "" + zy +
                "" + "xb" + "" + "" + ah + "" + xq + "" + jj;
            MessageBox.Show(msg);
        }
    }
}
