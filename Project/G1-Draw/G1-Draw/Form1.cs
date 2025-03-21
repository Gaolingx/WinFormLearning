using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G1_Draw
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
        bool isDraw;
        MyType currType = MyType.Line;
        List<MyData> data = new List<MyData>();
        void DrawCircle(Pen p,Point p1,Point p2)
        {
            Rectangle rectangle = new Rectangle();
            int dis = (int)Math.Sqrt((p2.X - p2.X) *
                (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

            rectangle.X =p1.X - dis;
            rectangle.Y =p1.Y - dis;
            rectangle.Width = 2 * dis;
            rectangle.Height = 2 * dis;
            g.DrawEllipse(p, rectangle);
            
        }
        void DrawRectangle(Pen p, Point p1, Point p2)
        {
            Rectangle rrectangle = new Rectangle();
            int Dis = (int)Math.Sqrt((p1.X - p2.X) *
               (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

            rrectangle.X = p1.X - Dis;
            rrectangle.Y = p1.Y - Dis;
            rrectangle.Width = 2 * Dis;
            rrectangle.Height = 2 * Dis;
            g.DrawRectangle(p, rrectangle);
        }
        void MyMoveAni()
        {
            switch (currType) {
                case MyType.Line:
                    g.DrawLine(p, p1, p2);
                    break;
                case MyType.Circle:
                    DrawCircle(p, p1, p2);
                    break;
                case MyType.Rect:
                    DrawRectangle(p, p1, p2);
                    break;
                default:
                    break;
            }

        }

        void MyDraw()
        {
            g.Clear(BackColor);
            foreach (var item in data)
            {
              
                switch(item.Type){
                    case MyType.Line:
                        g.DrawLine(item.P, item.P1, item.P2);
                        break;
                    case MyType.Circle:
                        Rectangle rectangle = new Rectangle();
                        int dis = (int)Math.Sqrt((item.P1.X-item.P2.X)* 
                            (item.P1.X - item.P2.X) + (item.P1.Y - item.P2.Y) * (item.P1.Y - item.P2.Y));
                    
                        rectangle.X = item.P1.X - dis;
                        rectangle.Y = item.P1.Y - dis;
                        rectangle.Width = 2* dis;
                        rectangle.Height = 2*dis;
                        g.DrawEllipse(item.P, rectangle);
                        break;
                    case MyType.Rect:
                        Rectangle rrectangle = new Rectangle();
                        int Dis = (int)Math.Sqrt((item.P1.X - item.P2.X) *
                           (item.P1.X - item.P2.X) + (item.P1.Y - item.P2.Y) * (item.P1.Y - item.P2.Y));

                        rrectangle.X = item.P1.X - Dis;
                        rrectangle.Y = item.P1.Y - Dis;
                        rrectangle.Width = 2 * Dis;
                        rrectangle.Height = 2 * Dis;
                        g.DrawRectangle(item.P,rrectangle);
                        break;
                    default:
                        break;
                }
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size = (int)numericUpDown1.Value;
            p.Width = size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog.Color;
                p.Color = c;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            p = new Pen(Color.Blue,4);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            isDraw = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            p2 = e.Location;
            isDraw = false;
            MyData md = new MyData(p1, p2, p, currType);
            data.Add(md);
            MyDraw();
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                p2 = e.Location;
                MyDraw();
                MyMoveAni();
            }
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            MyDraw();
        }

        private void 画线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currType = MyType.Line;
        }

        private void 画圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currType = MyType.Circle;
        }

        private void 画矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currType = MyType.Rect;
        }
    }
    public enum MyType
    {
        Line,
        Circle,
        Rect
    }
    public class MyData 
    {
        Point p1;
        Point p2;
        Pen p;
        MyType type;

        public MyData(Point p1, Point p2, Pen p, MyType type)
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
