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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Student st;

        public Student St { get => st; set => st = value; }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
            form2.MdiParent = this;
        }

        private void 查看用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(st);
            form3.Show();
            form3.MdiParent = this;
        }
    }
}
