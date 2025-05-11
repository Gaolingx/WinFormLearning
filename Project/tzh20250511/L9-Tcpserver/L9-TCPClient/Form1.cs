using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L9_TCPClient
{
    public partial class TCP客户端 : Form
    {
        public TCP客户端()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        Socket client;
        Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), int.Parse(textBoxPort.Text));
            try
            {
                client.Connect(iP);
            }
            catch (Exception) { MessageBox.Show("错了"); return; }

            th = new Thread(ReadMsg);
            th.Start();
            button1.Enabled = false;
            new Thread(ReadMsg).Start();
            richTextBox1.AppendText("成功");
        }
        void ReadMsg()
        {
          
            byte[] buff = new byte[1024];
            while (true)
            {
                int n = client.Receive(buff);
                string msg=Encoding.UTF8.GetString(buff, 0, n);
                richTextBox1.AppendText(msg + "\n");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg=client.LocalEndPoint.ToString()+":"+textBox1.Text;
            client.Send(Encoding.UTF8.GetBytes(msg));
        }

        private void TCP客户端_Load(object sender, EventArgs e)
        {
            
        }

        private void TCP客户端_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th!=null) {

                string msg = "offline\n" + client.LocalEndPoint.ToString();
                client.Send(Encoding.UTF8.GetBytes(msg));
                
                th.Abort();
            
            
            
            }
        }
    }
    class ReadThread
    {
        Socket s;
        List<Socket> list;
        RichTextBox rich;
    }
    
}
