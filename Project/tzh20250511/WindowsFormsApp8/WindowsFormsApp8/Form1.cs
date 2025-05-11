using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 读写对象ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRWO f=new FormRWO();
            f.Show();
        }

        private void 读写jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJson f = new FormJson();
            f.Show();
        }

        private void 数据联动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();

        }
    }
}
