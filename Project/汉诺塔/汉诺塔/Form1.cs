using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 汉诺塔
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitGame(2);
            
        }
        bool IsDown = false;
        string from;
        List<string> listString = new List<string>();
        Point old;
        private void label3_Click(object sender, EventArgs e)
        {
          
        }

        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            List<PictureBox> list = (List<PictureBox>)pb.Tag;
            if (list[list.Count - 1].Equals(pb))
            {
                IsDown = true;
                old = pb.Location;
             
   
                if (pictureBox2.Bounds.IntersectsWith(pb.Bounds))
                {
                    from = "B柱";
                }
                else if (pictureBox3.Bounds.IntersectsWith(pb.Bounds))
                {
                    from = "C柱";
                }
                else if (pictureBox1.Bounds.IntersectsWith(pb.Bounds))
                {
                    from = "A柱";
                }
            }
        }

        

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                PictureBox pb = sender as PictureBox;
                int x = MousePosition.X-this.Location.X-pb.Width/2;
                int y = MousePosition.Y-this.Location.Y-pb.Height/2;
                Point p = new Point(x, y);
                pb.Location = p;
            }
        }

        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDown == false) return;
            PictureBox pb = sender as PictureBox;
            if (pictureBox2.Bounds.IntersectsWith(pb.Bounds))
            {
                SetPic(pb,pictureBox2,"B柱");
            }
            else if (pictureBox3.Bounds.IntersectsWith(pb.Bounds))
            {
                SetPic(pb, pictureBox3, "C柱");
            }
            else if (pictureBox1.Bounds.IntersectsWith(pb.Bounds))
            {
                SetPic(pb, pictureBox1, "A柱");
            }
          
                IsDown = false;

        }

        private void SetPic(PictureBox pb, PictureBox pictureBox2, string v)
        {
            List<PictureBox> list =(List<PictureBox>) pictureBox2.Tag;
            int x = pictureBox2.Location.X + pictureBox2.Width / 2-pb.Width/2;
            int y = pictureBox2.Location.Y + pictureBox2.Height-pb.Height;
            if (list.Count == 0)
            {
                pb.Location = new Point(x, y);
                list.Add(pb);
                List<PictureBox> listTem = (List<PictureBox>)pb.Tag;
                listTem.Remove(pb);
                pb.Tag = list;
                listString.Add(pb.Name+":"+from+"->"+v);
                return;
            }
            if (list[list.Count - 1].Width > pb.Width)
            {
                pb.Location = new Point(x, y-list.Count*20);
                list.Add(pb);
                List<PictureBox> listTem = (List<PictureBox>)pb.Tag;
                listTem.Remove(pb);
                pb.Tag = list;
            }
            else
            {
                pb.Location = old;
            }
            if (listC.Count == n)
            {
                for(int i = 0; i < listString.Count; i++)
                {
                    richTextBox1.AppendText("第" + (i + 1) + "步"+listString[i]+"\n");
                }
                if (MessageBox.Show("你移动了" + listString.Count + "步", "汉诺塔游戏") == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        List<PictureBox> listA = new List<PictureBox>();
        List<PictureBox> listB = new List<PictureBox>();
        List<PictureBox> listC = new List<PictureBox>();
        int n;
        void InitGame(int n)
        {
            this.n = n;
            for (int i = n; i > 0; i--)
            {
                int x = pictureBox1.Location.X+pictureBox1.Width/2;
                int y = pictureBox1.Location.Y + pictureBox1.Height;
                PictureBox pb = new System.Windows.Forms.PictureBox(); 
                
                
                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                
              
                pb.Name = ""+i;
                pb.Size = new System.Drawing.Size(55+i*10, 19);

                Bitmap bit = new Bitmap(pb.Size.Width, pb.Size.Height);
                Graphics g = Graphics.FromImage(bit);
                g.Clear(Color.Crimson);
                Font f1 = new Font("宋体", 16);
             
                PointF pf = new PointF(pb.Width/2-8,0);
                Brush b = new SolidBrush(Color.Black);
                g.DrawString(i.ToString(), f1, b, pf);
                pb.Image = bit;
                pb.Location = new System.Drawing.Point(x - pb.Width / 2, y - pb.Height - (n - i) * 20);
                pb.TabIndex = 6;
                pb.TabStop = false;
                pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
               // pb.MouseHover += new System.EventHandler(this.pb_MouseHover);
                pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
                pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_MouseUp);

                this.Controls.Add(pb);
                pb.BringToFront();
                listA.Add(pb);
                pb.Tag = listA;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Tag = listA;
            pictureBox2.Tag = listB;
            pictureBox3.Tag = listC;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
