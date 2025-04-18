using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace G3_拼图
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] fileNames;
        Random rnd = new Random();
        Graphics g;
        Bitmap bit;
        int offX = 10;
        int offY = 10;
        int row = 3;
        int col = 3;
        int w = 100;
        int h = 100;
        Bitmap[][] clips;
        void InitGame(int r,int c)
        {
            row = r;
            col = c;
            bit = new Bitmap(GetRandomFileName());
            w = bit.Width / col;
            h = bit.Height / row;
            clips = new Bitmap[row][];
            for (int i = 0; i < clips.Length; i++)
            {
                clips[i] = new Bitmap[col];
                for (int j = 0; j < col; j++)
                {
                    Rectangle rect = new Rectangle(j * w, i * h, w, h);
                    clips[i][j] = bit.Clone(rect, bit.PixelFormat);
                    clips[i][j].Tag = i * col + j;
                }
            }
            for (int i = 0; i < row*col; i++)
            {
                int i1 = rnd.Next() % row;
                int j1 = rnd.Next() % col;
                int i2 = rnd.Next() % row;
                int j2 = rnd.Next() % col;
                Bitmap temp = clips[i1][j1];
                clips[i1][j1] = clips[i2][j2];
                clips[i2][j2] = temp;
            }
            DrawGame();
        }
        private void DrawGame()
        {
            g.Clear(BackColor);
            for (int i = 0; i < clips.Length; i++)
            {
                
                for (int j = 0; j < col; j++)
                {
                    if (curI == i && curJ == j) continue;
                    Rectangle rect = new Rectangle(offX + j * (w + 2), offY + i * (h + 2), w, h);
                    g.DrawImage(clips[i][j], rect);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fileNames = Directory.GetFiles("../../images");
            g = CreateGraphics();
            InitGame(3, 3);
            //DrawGame();
        }
        private string GetRandomFileName()
        {
            if (fileNames == null || fileNames.Length == 0)
            {
                return null;
            }
            return fileNames[rnd.Next(fileNames.Length)];
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGame();
        }
        bool isDrag = false;
        int curI=-1;
        int curJ=-1;
        Bitmap curBit;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > offX && e.X < offX + col * (w + 2))
            {
                if (e.Y > offX && e.Y < offY + row * (h + 2))
                {
                    curI = (e.Y - offY) / h;
                    curJ = (e.X - offX) / w;
                    isDrag = true;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                Point p = new Point(e.X - w / 2, e.Y - h / 2);
                DrawGame();
                g.DrawImage(clips[curI][curJ], p);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrag == false) return;
            isDrag = false;
            if (e.X > offX && e.X < offX + col * (w + 2))
            {
                if (e.Y > offX && e.Y < offY + row * (h + 2))
                {
                    int curI1 = (e.Y - offY) / h;
                    int curJ1 = (e.X - offX) / w;
                    Bitmap temp = clips[curI1][curJ1];
                    clips[curI1][curJ1] = clips[curI][curJ];
                    clips[curI][curJ] = temp;
                    //DrawGame();
                    //return;
                }
            }
            curI = -1;
            curJ = -1;
            DrawGame();
            GameOver();
        }

        private void GameOver()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((int)clips[i][j].Tag!= i * col + j)
                    {
                        return;
                    }
                }
            }
            if (DialogResult.Yes == MessageBox.Show("游戏胜利", "拼图游戏", MessageBoxButtons.YesNoCancel))
            {
                row++;
                col++;
                InitGame(row, col);
            }
            //MessageBox.Show("胜利");
        }
    }
}
