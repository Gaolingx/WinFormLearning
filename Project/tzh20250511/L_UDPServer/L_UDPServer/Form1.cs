using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using L9_Game3231;

namespace L_UDPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram,
            ProtocolType.Udp);
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////IPEndPoint iPEnd = IPEndPoint.(IPAddress.Parse(textBoxIP.Text), int.Parse(textBox1.Text));
            server.Bind(iPEnd);
            new Thread(ReadMsg).Start();
            button1.Enabled = false;
        }
        void ReadMsg()
        {
            while (true) 
            {
            
            }
        }
    }
}
