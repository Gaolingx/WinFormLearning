using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L5_Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存文件");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                contextMenuStrip1.Show(this,e.X, e.Y);
            }
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (richTextBox1.SelectedText==null||richTextBox1.SelectedText=="")
                {
                    this.复制ToolStripMenuItem.Enabled = false;
                    this.剪切ToolStripMenuItem.Enabled = false;
                }
                else
                {
                    this.复制ToolStripMenuItem.Enabled = true;
                    this.剪切ToolStripMenuItem.Enabled = true;
                }
                contextMenuStrip2.Show(richTextBox1, e.X, e.Y);
            }
        }
    }
}
