using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace L2_IMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("新建", "星星");
        }

        private void 加入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("打开", "星星");
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存", "星星");
        }
        Form1 form;
        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (form==null)
            {
                form = new Form1();
                form.MdiParent = this;
                form.Show();
            }
            


            if(form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
        }
        int Count=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = DateTime.Now.ToString();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
