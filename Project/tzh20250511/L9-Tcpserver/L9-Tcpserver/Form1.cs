using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L9_Tcpserver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        Socket server;
        private void button1_Click(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), int.Parse(textBoxPort.Text));
            try
            {
                server.Bind(ip);
            }
            catch (Exception)
            {

                MessageBox.Show("错误");
                return;
            }
            server.Listen(100);
            new Thread(Accept).Start();
            button1.Enabled = false;
            richTextBox1.AppendText("已启动.....\n");
        }
        List<Socket> list = new List<Socket>();
        void Accept()
        {
            string msg = "欢迎";
            byte[] buff = new byte[1024];
            while (true)
            {
                Socket s = server.Accept();
                richTextBox1.AppendText(s.RemoteEndPoint.ToString() + "  上线了!\n");
                listBox1.Items.Add(s.RemoteEndPoint.ToString());
                buff = Encoding.UTF8.GetBytes(msg + "xxx" + s.LocalEndPoint.ToString() + "aa");
                s.Send(buff);
                list.Add(s);
                new ReadThread(s, list, richTextBox1, listBox1);
            }
        }
    }
    class ReadThread
    {
        Socket s;
        List<Socket> list;
        RichTextBox rich;
        ListBox listBox;

        public ReadThread(Socket s, List<Socket> list, RichTextBox rich, ListBox Box)
        {
            this.s = s;
            this.list = list;
            this.rich = rich;
            listBox = Box;
            new Thread(ReadMsg).Start();
            this.listBox = listBox;
        }
        void ReadMsg()
        {
            byte[] buff = new byte[1024];
            while (true)
            {
                int n;
                try
                {
                    n = s.Receive(buff);
                }
                catch (Exception)
                {
                    list.Remove(s);
                    listBox.Items.Remove(s.RemoteEndPoint.ToString());
                    break;
                }
                string msg = Encoding.UTF8.GetString(buff, 0, n);
                if (msg.Equals("offline\n"))
                {
                    rich.AppendText(s.RemoteEndPoint.ToString() + "下了\n");
                    listBox.Items.Remove(s.RemoteEndPoint.ToString());
                    list.Remove(s);
                }
                rich.AppendText(msg + "\n");
                foreach (var item in list)
                {
                    try
                    {
                        item.Send(Encoding.UTF8.GetBytes(s.RemoteEndPoint.ToString()+ "下了\n"));
                    }
                    catch (Exception)
                    {
                        list.Remove(item);
                        listBox.Items.Remove(item.RemoteEndPoint.ToString());
                    }
                }
            }
        }
    }
}

