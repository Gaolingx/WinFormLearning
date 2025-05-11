using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L8_拼图
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point oldP;
        private void pB_MouseDown(object sender, MouseEventArgs e)
        {
            curI=(MousePosition.Y-Location.Y-offY)/h;
            curJ=(MousePosition.X-Location.X-offX)/w;
            if (curI >= 0 && curI < row && curJ >= 0 && curJ < col)
            {
                isDrag = true;
                oldP = clips[curI][curJ].Location;
                clips[curI][curJ].BringToFront();
            }
        }

        private void pB_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                int x =(MousePosition.X - Location.X -w/2);
                int y = (MousePosition.Y - Location.Y -h/2);
                clips[curI][curJ].Location=new Point(x,y);
            }
        }

        private void pB_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrag)
                return;
            int curI1 = (MousePosition.Y - Location.Y - offY) / h;
            int curJ1 = (MousePosition.X - Location.X - offX) / w;
            if (curI1 >= 0 && curI1 < row && curJ1 >= 0 && curJ1 < col)
            {
                clips[curI][curJ].Location = clips[curI1][curJ1].Location;
                clips[curI1][curJ1].Location =oldP; 

                PictureBox temp = clips[curI][curJ];
                clips[curI][curJ]= clips[curI1][curJ1];
                clips[curI1][curJ1]=temp;
            }
            else
            {
                clips[curI][curJ].Location= oldP;
            }
            isDrag = false;

            GameOver();

        }
        Bitmap bit;
        int offX = 10;
        int offY = 10;
        int w;
        int h;
        int row = 3;
        int col = 3;
        PictureBox[][] clips;
        string[] fileNames;
        Random rnd=new Random();
        bool isDrag = false;
        int curI = -1;
        int curJ = -1;
        string GetFileRandom()
        {
            if (fileNames == null || fileNames.Length == 0)
            {
                return null;

            }
            return fileNames[rnd.Next(fileNames.Length)];
        }
        void ClearData()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    clips[i][j].MouseDown -= new System.Windows.Forms.MouseEventHandler(this.pB_MouseDown);
                    clips[i][j].MouseMove -= new System.Windows.Forms.MouseEventHandler(this.pB_MouseMove);
                    clips[i][j].MouseUp -= new System.Windows.Forms.MouseEventHandler(this.pB_MouseUp);
                    this.Controls.Add(clips[i][j]);
                    clips[i][j] .Dispose();
                }
            }
        }
        void GameOver()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((int)clips[i][j].Tag != ((i * col) + j))
                    {
                        return;
                    }
                 
                }
            }
            if (MessageBox.Show("1111", "aaa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearData();
                row++;
                col++;
               
                InitGame(row, col);
            }
                
            
        }
        void InitGame(int r, int c)
        {
            row = r; col = c;
            string fileName = GetFileRandom();
            if (fileName == null)
            {
                MessageBox.Show("空");
                return;
            }
            bit = new Bitmap(fileName);
            w = bit.Width / col;
            h = bit.Height / row;
            clips = new PictureBox[row][];
            for (int i = 0; i < row; i++)
            {
                clips[i] = new PictureBox[col];
                for (int j = 0; j < col; j++)
                {
                    Rectangle rect = new Rectangle(j * w, i * h, w, h);
                    clips[i][j] = new PictureBox();
                    clips[i][j].Size = new Size(w, h);
                    clips[i][j].Image = bit.Clone(rect, bit.PixelFormat);
                    clips[i][j].Tag = i * col + j;
                }
            }
            for (int i = 0; i < row * col; i++)
            {
                int i1 = rnd.Next(row);
                int j1 = rnd.Next(col);
                int i2 = rnd.Next(row);
                int j2 = rnd.Next(col);
                PictureBox temp = clips[i1][j1];
                clips[i1][j1] = clips[i2][j2];
                clips[i2][j2] = temp;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    clips[i][j].Location = new System.Drawing.Point(offX+ j * (w + 2),offY+ i * (h + 2));
                    clips[i][j].MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_MouseDown);
                    clips[i][j].MouseMove += new System.Windows.Forms.MouseEventHandler(this.pB_MouseMove);
                    clips[i][j].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_MouseUp);
                    this.Controls.Add(clips[i][j]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            fileNames = Directory.GetFiles("../../images");
            InitGame(3, 3);
        }
    }
}
