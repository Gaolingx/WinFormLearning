using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int size;
        Color c;
        Graphics g;
        Pen p;
        Point p1;
        Point p2;
        bool isDeaw;

        MyType currTpe = MyType.Line;
        List<MyDate> date= new List<MyDate>();

        void DrawCircle(Pen p, Point p1,Point p2)
        {
            Rectangle rectangle = new Rectangle();
            int dis = (int)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

            rectangle.X = p1.X - dis;
            rectangle.Y = p1.Y - dis;
            rectangle.Width = 2 * dis;
            rectangle.Height = 2 * dis;
            g.DrawEllipse(p, rectangle);
        }
        void DrawRect(Pen p, Point p1, Point p2)
        {
            Point x1 = new Point(p1.X, p2.Y);
            Point y1 = new Point(p2.X, p1.Y);
            g.DrawLine(p, p1, x1);
            g.DrawLine(p, p2, y1);
            g.DrawLine(p, p1, y1);
            g.DrawLine(p, p2, x1);
        }

        void MyMoveAni()
        {
            switch (currTpe)
            {
                case MyType.Line:
                    g.DrawLine(p, p1, p2);
                    break;
                case MyType.Circle:
                    DrawCircle(p, p1, p2);
                    break;
                case MyType.Rect:
                    DrawRect(p, p1, p2);
                    break;
                default:
                    break;
            }
        }
        void MyDraw()
        {
            g.Clear(BackColor);
            foreach (var item in date)
            {
                switch (item.Type)
                {
               
                    case MyType.Line:

                        g.DrawLine(item.P,item.P1,item.P2);
                        break;
                    case MyType.Circle:


                        Rectangle rectangle = new Rectangle();
                        int dis = (int)Math.Sqrt((item.P1.X - item.P2.X) * (item.P1.X - item.P2.X) + (item.P1.Y - item.P2.Y) * (item.P1.Y - item.P2.Y));

                        rectangle.X = item.P1.X - dis;
                        rectangle.Y = item.P1.Y - dis;
                        rectangle.Width = 2 * dis;
                        rectangle.Height = 2 * dis;
                        g.DrawEllipse(item.P, rectangle);


                        break;
                    case MyType.Rect:
                        Point x1 = new Point(item.P1.X, item.P2.Y);
                        Point y1 = new Point(item.P2.X, item.P1.Y);
                        g.DrawLine(item.P, item.P1, x1);
                        g.DrawLine(item.P, item.P2, y1);
                        g.DrawLine(item.P, item.P1, y1);
                        g.DrawLine(item.P, item.P2, x1);

                        break;
                    default:
                        break;
                }
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
         size =(int)numericUpDown1.Value;
     p.Width = size;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                c=colorDialog.Color;
                p.Color = c;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g=CreateGraphics();
            p = new Pen(Color.Red );

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 =e.Location;
            isDeaw = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDeaw)
            {
                p2 =e.Location;
                MyDraw();
                MyMoveAni();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            p2 = e.Location;
            isDeaw = false;
            MyDate md =new MyDate(p1,p2,p,currTpe);
            date.Add(md);
            MyDraw();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MyDraw();
        }

        private void yxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currTpe = MyType.Circle;
         
        }

        private void 矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currTpe = MyType.Rect;
        }

        private void 线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currTpe = MyType.Line;
        }
    }
    public enum MyType
    {
        Line,
        Circle,
        Rect
    }

    public class MyDate
    {
        Point p1;
        Point p2;
        Pen p;
        MyType type;

        public MyDate(Point p1, Point p2, Pen p, MyType type)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p = p.Clone() as Pen;
            this.type = type;
        }

        public Point P1 { get => p1; set => p1 = value; }
        public Point P2 { get => p2; set => p2 = value; }
        public Pen P { get => p; set => p = value; }
        public MyType Type { get => type; set => type = value; }
    }
}
