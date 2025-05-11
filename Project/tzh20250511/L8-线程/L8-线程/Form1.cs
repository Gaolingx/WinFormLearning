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

namespace L8_线程
{
    public partial class Form1 : Form
    {
        int counter;
        Thread th;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(ThreadDeal);
            th.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }
        void ThreadDeal()
        {
            while (true)
            {
                label1.Text = counter.ToString();
                counter++;
                Thread.Sleep(1000);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (th.ThreadState != ThreadState.Running)
            {
                th.Suspend();
                button2.Text = " 继续";
            }
            else
            {
                th.Resume();
                button2.Text = " 挂起";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            th.Abort();
            button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread th = new Thread(SelaTicket);
                th.Name = "Window" + i;
                th.Start();
            }
        }
        int max = 100;
        int no = 1;
        void SelaTicket()
        {
            while (no <= max)
            {
                lock (this)
                {
                    string str = Thread.CurrentThread.Name + ":Sale" + no + "\n";
                    richTextBox1.AppendText(str);
                    no++;
                }
                    Thread.Sleep(1000);

                
            }
        }
    }
}
