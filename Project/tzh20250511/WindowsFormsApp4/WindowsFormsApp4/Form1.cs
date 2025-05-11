using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.Text = "点击即玩";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("正在进入", "xxx系统", MessageBoxButtons.OKCancel);
            //if (dr == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
