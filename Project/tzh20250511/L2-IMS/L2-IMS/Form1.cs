using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace L2_IMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (textBoxNo.Text.Trim().Equals(""))
            {
                MessageBox.Show("空的！重来！");
                textBoxNo.Focus();
                return;
            }
            if (textBox2.Text.Trim().Equals(""))
            {
                MessageBox.Show("空的！重来！");
                return;
            }
            if (textBoxNo.Text.Trim().Equals("11") && textBox2.Text.Trim().Equals("11"))
            {
                MessageBox.Show("加载中");
                MainForm mf = new MainForm();
                mf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("错了");
            }
        }
    }
}
