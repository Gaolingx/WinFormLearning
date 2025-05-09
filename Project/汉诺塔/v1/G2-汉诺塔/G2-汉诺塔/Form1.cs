using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G2_汉诺塔
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitGame(6);
        }
        bool isDown=false;
        Point old;
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb=sender as PictureBox;
            if (listA[listA.Count - 1].Equals(pb))
            {
                isDown = true;
                old = pb.Location;
            }
            
        }

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                PictureBox pb=sender as PictureBox;
                //MousePosition 屏幕的鼠标位置
                int x = MousePosition.X-this.Location.X-pb.Width/2;
                int y = MousePosition.Y - this.Location.Y -pb.Height/2;
                Point p=new Point(x, y);
                pb.Location = p;
            }
        }

        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            //2个矩形是否相交
            if (pictureBox2.Bounds.IntersectsWith(pb.Bounds))
            {
                SetPic(pb,pictureBox2);
            }
            isDown = false;
            
        }

        private void SetPic(PictureBox pb, PictureBox pictureBox2)
        {
            List<PictureBox> list =(List<PictureBox>) pictureBox2.Tag;
            int x = pictureBox2.Location.X + pictureBox2.Width / 2-pb.Width/2;
            int y = pictureBox2.Location.Y + pictureBox2.Height-pb.Height;
            if (list.Count == 0)
            {
                pb.Location=new Point(x, y);
                list.Add(pb);
                List<PictureBox> listTem = (List<PictureBox>)pb.Tag;
                listTem.Remove(pb);
                pb.Tag = list;
                return;
            }
            if (list[list.Count - 1].Width > pb.Width)
            {
                pb.Location = new Point(x, y-list.Count*60);
                list.Add(pb);
                List<PictureBox> listTem = (List<PictureBox>)pb.Tag;
                listTem.Remove(pb);
                pb.Tag = list;
            }
            else
            {
                pb.Location = old;
            }
        }

        List<PictureBox> listA= new List<PictureBox>();
        List<PictureBox> listB = new List<PictureBox>();
        List<PictureBox> listC = new List<PictureBox>();
        void InitGame(int n)
        {
            int x=pictureBox1.Location.X+pictureBox1.Width/2;
            int y=pictureBox1.Location.Y+pictureBox1.Height;
            for (int i = n; i>0; i--)
            {
                PictureBox pb = new System.Windows.Forms.PictureBox();

                pb.BackColor = System.Drawing.Color.Blue;
               
                pb.Name = "pb";
                pb.Size = new System.Drawing.Size(100+i*20, 50);
                pb.Location = new System.Drawing.Point(x-pb.Width/2, y -pb.Height- (n-i) * 60);
                pb.TabIndex = 6;
                pb.TabStop = false;
                pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
                pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
                pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_MouseUp);

                this.Controls.Add(pb);
                pb.BringToFront();
                listA.Add(pb);
                pb.Tag = listA;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Tag = listA;
            pictureBox2.Tag = listB;
            pictureBox3.Tag = listC;
        }
    }
}
