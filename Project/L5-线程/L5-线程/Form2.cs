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

namespace L5_线程
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        int no = 1;//产品编号
        List<int> list = new List<int>();//生产地
        int max = 10;//生产池的最大容量
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread th = new Thread(Consume);
                th.Name = "Consumer" + i.ToString();
                th.Start();
            }
        }
        void Consume()
        {
            while (true)
            {
                lock (this)
                {
                    if (list.Count == 0)
                    {
                        richTextBox1.AppendText(Thread.CurrentThread.Name + "pool is empty Wait for \n");
                        Monitor.Wait(this);//等待

                    }
                    else
                    {
                        int i = list[0];
                        richTextBox1.AppendText(Thread.CurrentThread.Name + "consume" + ":" + i + "\n");
                        list.RemoveAt(0);
                        //通知等待的线程
                        Monitor.Pulse(this);
                    }
                }
                Thread.Sleep(100);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread th = new Thread(Produce);
                th.Name = i.ToString();
                th.Start();
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
                        richTextBox1.AppendText(Thread.CurrentThread.Name + "pool is foul Wait for \n");
                        Monitor.Wait(this);//等待

                    }
                    else
                    {
                        list.Add(no);
                        richTextBox1.AppendText(Thread.CurrentThread.Name + "produce" + ":" + no + "\n");
                        no++;
                        //通知等待的线程
                        Monitor.Pulse(this);
                    }
                }

            }
        }
    }
}
