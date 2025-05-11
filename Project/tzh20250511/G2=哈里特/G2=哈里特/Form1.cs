using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G2_哈里特
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initGame(10);
         
        }
        bool isDown=false;
        Point old;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Tag = listA;
            pictureBox2.Tag = listB;
            pictureBox3.Tag = listC;
        }

        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDown == false) return;
            PictureBox pb = sender as PictureBox;
            if (pictureBox2.Bounds.IntersectsWith(pb.Bounds))
            {
                SetPic(pb, pictureBox2,"B柱");
            }
            else if (pictureBox3.Bounds.IntersectsWith(pb.Bounds))
            {
                SetPic(pb, pictureBox3, "C柱");
            }
            else if (pictureBox1.Bounds.IntersectsWith(pb.Bounds))
            {
                SetPic(pb, pictureBox1, "A柱");
            }
            isDown = false;
        }

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                PictureBox pb = sender as PictureBox;
                int x = MousePosition.X - this.Location.X - pb.Width / 2;
                int y = MousePosition.Y - this.Location.Y - pb.Height/2- pb.Height;
                Point p = new Point(x, y);
                pb.Location = p;


            }
        }

        private void pb_MouseDown(object sender, MouseEventArgs e)
        {

            PictureBox pb = sender as PictureBox;
            List<PictureBox> list = (List<PictureBox>)pb.Tag;
            if (list[list.Count - 1].Equals(pb))
            {
                isDown = true;
                old = pb.Location;
                if (pictureBox2.Bounds.IntersectsWith(pb.Bounds))
                {
                   from="B柱";
                }
                else if (pictureBox3.Bounds.IntersectsWith(pb.Bounds))
                {
                    from = "C柱";
                }
                else if (pictureBox1.Bounds.IntersectsWith(pb.Bounds))
                {
                    from = "A柱";
                }
                else pb.Location = old;
            }
        }

        private void SetPic(PictureBox pb, PictureBox pictureBox2, string v)
        {
            List<PictureBox> list = (List<PictureBox>)pictureBox2.Tag;
            int x = pictureBox2.Location.X + pictureBox2.Width / 2-pb.Width/2;
            int y = pictureBox2.Location.Y + pictureBox2.Height-pb.Height;
            if (list.Count==0)
            {
                pb.Location = new Point(x, y);
                list.Add(pb);
                List<PictureBox> listTem = (List<PictureBox>)pb.Tag;
                listTem.Remove(pb);
                pb.Tag = list;
                listString.Add(pb.Name + ":" + "->" + v);
                return;
            }
           

            if (list[list.Count - 1].Width > pb.Width) 
            {
                pb.Location=new Point(x, y-list.Count*40);
                list.Add(pb);
                List<PictureBox> listTem=(List<PictureBox>)pb.Tag;

                listTem.Remove(pb);
                pb.Tag = list;
                listString.Add(pb.Name + ":" + "->" + v);
            }
            else
            {
                pb.Location = old;
            }
            if (listC.Count == n)
            {
                for (int i = 0; i <listString.Count; i++)
                {
                    richTextBox1.AppendText("第" + (i + 1) + "步::" + listString[i] + "\n");

                }
                if (MessageBox.Show("你" + listString.Count + "步", "哈里特") == DialogResult.OK)
                {
                    Application.Exit();
                }
            }


        }

        List<PictureBox> listA = new List<PictureBox>();
        List<PictureBox> listB = new List<PictureBox>();
        List<PictureBox> listC = new List<PictureBox>();
        string from;
        List<string> listString=new List<string>();
        int n;
        void initGame(int n)
            {
            this.n = n;
            int x=pictureBox1.Location.X+pictureBox1.Width/2;
            int y=pictureBox1.Location.Y+pictureBox1.Height;
                for (int i = n; i > 0; i--)
                {
                PictureBox pb = new System.Windows.Forms.PictureBox();

              
                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                pb.Size = new System.Drawing.Size(30 + i * 30, 30);
                pb.Location = new System.Drawing.Point(x-pb.Width/2,y-pb.Height-(n-i)*40);
                pb.Name = ""+i;
                Bitmap bit = new Bitmap(pb.Size.Width, pb.Size.Height);
                Graphics g = Graphics.FromImage(bit);
                g.Clear(Color.Blue);
                Brush b=new SolidBrush(Color.Black);
                Font f = new Font("宋体",20);
                PointF pf = new PointF(pb.Width/2-10,0);
                g.DrawString(i.ToString(),f,b,pf);
                pb.Image = bit;
                //pb.Size = new System.Drawing.Point(x - pb.Width / 2, y - pb.Height - (n - i) * 60)
                    
               
                pb.TabIndex = 2;
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
        
    }
}
