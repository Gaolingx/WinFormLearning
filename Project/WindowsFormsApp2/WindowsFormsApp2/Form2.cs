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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int size;
        Color c;
        Graphics g;
        Pen p;
        Point p1;
        Point p2;
        bool isDraw;
        MyTyepe currType=MyTyepe.Line;
        List<MyData> data=new List<MyData>();
        void DrawCircle(Pen p,Point p1,Point p2)
        {
            Rectangle rectangle = new Rectangle();
            int dis = (int)Math.Sqrt((p1.X - p2.X) *
                            (p1.X - p2.X) +
                            (p1.Y - p2.Y) *
                            (p1.Y - p2.Y));
            rectangle.X = p1.X - dis;
            rectangle.Y = p1.X - dis;
            rectangle.Width = 2 * dis;
            rectangle.Height = 2 * dis;
            g.DrawEllipse(p, rectangle);

        }
        void MyMoveAin()
        {
            switch (currType)
            {
                case MyTyepe.Line:
                    g.DrawLine(p,p1,p2);//2
                    break;
                case MyTyepe.Circle:
                    DrawCircle (p,p1,p2);
                    break;
                case MyTyepe.Rect:
                    break;
                default:
                    break;
            }
        }
        void MyDraw()
        {
            g.Clear(BackColor);
            foreach(var item in data)
            {
                switch (item.Type)
                {
                    case MyTyepe.Line:
                        g.DrawLine(item.P,item.P1,item.P2);//
                        break;
                    case MyTyepe.Circle:
                        Rectangle rectangle=new Rectangle();
                        int dis=(int)Math.Sqrt((item.P1.X-item.P2.X)*
                            (item.P1.X - item.P2.X) +
                            (item.P1.Y - item.P2.Y)*
                            (item.P1.Y - item.P2.Y));
                        rectangle.X = item.P1.X-dis;
                        rectangle.Y = item.P1.X - dis;
                        rectangle.Width = 2 * dis;
                        rectangle.Height = 2 * dis;
                        g.DrawEllipse(item.P,rectangle);
                        break;
                    case MyTyepe.Rect:
                        break;
                    default:
                        break;
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            p = new Pen(Color.Blue, 4);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size=(int)numericUpDown1.Value;
            p.Width = size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                c=colorDialog.Color;
                p.Color = colorDialog.Color;
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            p1=e.Location;
            isDraw=true;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                p2 = e.Location;
                MyDraw();
                MyMoveAin();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            p2 =e.Location;
            isDraw=false;
            MyData md=new MyData(p1,p2,p,currType);
            data.Add(md);
            MyDraw();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            MyDraw();
           
        }

        private void 画线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currType = MyTyepe.Line;
        }

        private void 画圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currType = MyTyepe.Circle;
        }

        private void 画矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currType = MyTyepe.Rect;
        }
    }
    public enum MyTyepe
    {
        Line,Circle,Rect
    }
    public  class MyData
    {
        Point p1;
        Point p2;
        Pen p;
        MyTyepe type;

        public MyData(Point p1, Point p2, Pen p, MyTyepe type)
        {
            this.P1 = p1;
            this.P2 = p2;
            this.P = p.Clone()as Pen;
            this.Type = type;
        }

        public Point P1 { get => p1; set => p1 = value; }
        public Point P2 { get => p2; set => p2 = value; }
        public Pen P { get => p; set => p = value; }
        public MyTyepe Type { get => type; set => type = value; }
    }
}
