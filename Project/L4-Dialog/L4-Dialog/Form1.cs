using System;
using System.Drawing;
using System.Windows.Forms;

namespace L4_Dialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 新建ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
            }
        }

        private void 文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(folderBrowserDialog.SelectedPath);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog.FileName);
                string fs = string.Empty;
                foreach (string file in openFileDialog.FileNames)
                {
                    fs += $"{file},";
                }
            }
        }

        private Color textCol;
        private Font textFont;
        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textCol = fd.Color;
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (textFont != null)
            {
                richTextBox1.SelectionColor = textCol;
                richTextBox1.SelectionFont = textFont;
            }
        }
    }
}
