using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Color c;
        Font f;

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
                //c=colorDialog1.Color;
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd= new FontDialog();
            if(fd.ShowDialog()== DialogResult.OK)
            {
                richTextBox1.Font= fd.Font;
            }
        }

        private void 文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog= new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(folderBrowserDialog.SelectedPath);

            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog=new OpenFileDialog();
            //openFileDialog.Filter = "文本文件|*.txt|所有文件*.*";
            openFileDialog.Multiselect = true;
            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog.FileName);
                string fs = "";
                foreach(var item in openFileDialog.FileNames)
                {
                    fs+= item+",";
                }
                MessageBox.Show(fs);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog=new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(saveFileDialog.FileName);
            }

        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if(f==null)return;
            richTextBox1.SelectionColor = c;
            richTextBox1.SelectionFont = f;
        }
    }
}
