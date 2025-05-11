using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L6_验证码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string yzmjh = "0123456789";
        string yzm = "";
        Color[] colors = {Color.Red,Color.Green,Color.Purple,Color.Black,Color.Blue,Color.Yellow,Color.Gold}; 
        void CreateYzm()
        {
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                yzm += yzmjh.Substring(rnd.Next() % yzmjh.Length, 1);
            }
            Bitmap bit = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            Graphics g = Graphics.FromImage(bit);
            Font f = new Font("宋体", pictureBox1.Size.Height - 50);
            Brush b = new SolidBrush(colors[rnd.Next(colors.Length)]);
            PointF pf = new PointF(0, 0);
            for (int i = 0; i < yzm.Length; i++)
            {
                int angle =rnd.Next()%18;
                g.RotateTransform(angle);
                pf.X = f.GetHeight() * i;
                b = new SolidBrush(colors[rnd.Next(colors.Length)]);
                g.DrawString(yzm[i].ToString(), f, b, pf);
                g.RotateTransform(-angle);
            }
            Pen p=new Pen(Color.Red);
            Point p1 =new Point(0, 0);
            Point p2 =new Point(0, 0);
            for (int i = 0; i < 20; i++)
            {
                p.Width = rnd.Next() % 2 + 1;
                p.Color = colors[rnd.Next(colors.Length)];
               p1.X = rnd.Next()%pictureBox1.Width;
                p1.Y = rnd.Next()%pictureBox1.Height;
                p2.X = rnd.Next() % pictureBox1.Width;
                p2.Y = rnd.Next() % pictureBox1.Height;
                g.DrawLine(p,p1, p2);
            }
            for (int i = 0; i <50 ; i++)
            {
                Rectangle rect = new Rectangle(0,0,3,2);

                rect.X = rnd.Next() % pictureBox1.Width;
                rect.Y = rnd.Next() % pictureBox1.Height;
                b=new SolidBrush(colors[rnd.Next(colors.Length)]);
                g.FillRectangle(b, rect);
            }

            pictureBox1.Image = bit;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals(yzm))
            {
                MessageBox.Show("正确");
            }
            else
            {
                MessageBox.Show("错误");
            }
        }

     

        private void Form1_Load_1(object sender, EventArgs e)
        {
            CreateYzm();
        }
    }

}

