using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uName=textBox1.Text.Trim();
            string yx=comboBox1.Text.Trim();
            string zy=listBox1.Text.Trim();
            string xb = radioButton1.Checked ? "男" : "女";
            string sr = dateTimePicker1.Text;
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
            if(ah!=" ")
            {
                ah = ah.Substring(0,ah.Length-1);
            }
            foreach (var item in checkedListBox1.CheckedItems)
            {
                xq += item + ",";
            }
            string msg = uName + " " + yx + " " + zy + " " + xb + " " + ah + " " + xq + " " + jj;
            form1.St=new Student(uName,yx,zy,xb,sr,ah,xq,jj);
            //MessageBox.Show(msg);
        }
    }
}
