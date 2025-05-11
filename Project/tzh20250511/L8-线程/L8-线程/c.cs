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
    public partial class 线程通信 : Form
    {
        public 线程通信()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        int no = 1;
        List<int> list = new List<int>();
        int max = 10;
        List<Thread> threads = new List<Thread>();
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++) 
            {
                Thread th = new Thread(Produce);
                th.Name=i.ToString();
                th.Start();
                threads.Add(th);
            }
        }
        void Produce()
        {
            while (true)
            {
                lock (this)
                {
                    if (list.Count >= max)
                    {
                       
                        richTextBox1.AppendText(Thread.CurrentThread.Name + "pool is foul wait for\n");
                        Monitor.Wait(this);
                    }
                    else
                    {
                        list.Add(no);
                        richTextBox1.AppendText(Thread.CurrentThread.Name + "Produce" + ":" + no + "\n");
                        no++;
                        Monitor.Pulse(this);
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread th = new Thread(ConSume);
                th.Name=i.ToString();
                th.Start();
                threads.Add(th);
            }
        }
        void ConSume()
        {
            while (true)
            {
                lock (this)
                {
                    if (list.Count == 0)
                    {

                        richTextBox1.AppendText(Thread.CurrentThread.Name + "pool is empty wait for\n");
                        Monitor.Wait(this);
                    }
                    else
                    {
                        int i = list[0];
                        richTextBox1.AppendText(Thread.CurrentThread.Name + "Consume" + ":" + i + "\n");
                        list.RemoveAt(0);
                        Monitor.Pulse(this);
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void 线程通信_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in threads)
            {
                item.Abort();
            }
        }
    }
    }

