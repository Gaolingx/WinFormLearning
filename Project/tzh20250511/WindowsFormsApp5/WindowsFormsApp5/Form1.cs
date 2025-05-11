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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
            f2.MdiParent = this;


        }
        Student st;

        public Student St { get => st; set => st = value; }

        private void 查看用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(st);
            f3.Show();
            f3.MdiParent = this;
        }
    }
}
