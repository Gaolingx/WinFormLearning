using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L5_线程
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
       
        }

        private void label1_Click(object sender, EventArgs e)
        {
            th = new Thread(ThreadDeal);
            th.Start();
            button1.Enabled = true;
            label1.Enabled = false;
            button2.Enabled = true;
        }
        int counter = 0;
        Thread th;
        void ThreadDeal()
        {
            while (true)
            {
                label2.Text = counter.ToString();
                counter++;
                Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (th.ThreadState != ThreadState.Suspended)
            {
                th.Suspend();
                button1.Text = "继续";
            }
            else
            {
                th.Resume();
                button1.Text = "挂起";
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th.Abort();
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                Thread th = new Thread(SaleTicket);
                th.Name = "Window" + i;
                th.Start();
            }
        }
        int max = 100;
        int no = 1;
        void SaleTicket()
        {
            while (true)
            {
                lock (this)
                {
                    if (no > max) break;
                    string str = Thread.CurrentThread.Name + ":Sale" + no + "\n";
                    richTextBox1.AppendText(str);
                    no++;
                }
                
                Thread.Sleep(100);
            }
        }
    }
}
