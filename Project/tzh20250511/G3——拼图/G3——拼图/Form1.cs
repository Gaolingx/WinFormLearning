using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace G3__拼图
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bit;
        int offX = 20;
        int offY = 20;
        int row = 3;
        int col = 3;
        int w = 0;
        int h = 0;
        Bitmap[][] clips;
        string[] fileNames;
        Random rnd = new Random();
        int curJ = -1;
        int curI = -1;
        bool isDrag=false;
        public Form1()
        {
            InitializeComponent();
        }

        private string RandomGetFile()
        {
            if(fileNames == null || fileNames.Length == 0)
            {
                return null;
            }
            return fileNames[rnd.Next(fileNames.Length)];
        }
        void InitGame(int r, int c)
        {
            row = r;
            col = c;
            bit = new Bitmap(RandomGetFile());
            w = bit.Width / c;
            h = bit.Height / r;
            clips = new Bitmap[r][];
            for (int i = 0; i < r; i++)
            {
                clips[i] = new Bitmap[c];
                for (int j = 0; j < c; j++)
                {
                    Rectangle rect = new Rectangle(j * w, i * h, w, h);
                    clips[i][j] = bit.Clone(rect, bit.PixelFormat);
                    clips[i][j].Tag = i * col + j;
                }

            }
          for (int i = 0;i < r*c; i++)
            {
                int i1 = rnd.Next(r);
                int i2 = rnd.Next(c);
                int j1 = rnd.Next(r);
                int j2 = rnd.Next(c);
                Bitmap temp = clips[i1][j1];
                clips[i1][j1] = clips[i2][j2];
                clips[i2][j2] = temp;   

            }
        }
        void DrawGame()
        {
            g.Clear(BackColor);
            for (int i = 0; i < row; i++)
            {
              
                for (int j = 0; j < col; j++)
                {
                    if (curI==i&&curJ==j)continue;
                    Rectangle rect = new Rectangle(offX + j * (w + 2), offY + i * (h + 2), w, h);

                    g.DrawImage(clips[i][j],rect);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fileNames = Directory.GetFiles("../../images");
            g = CreateGraphics();
            InitGame(3, 3);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            DrawGame();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > offX && e.X < offX + (w + 2) * col)
            {
                if(e.Y>offY&&e.Y < offY + (h + 2) * col)
                {
                    curI = (e.Y - offY) / h;
                    curJ= (e.X - offX) / w;
                    isDrag = true;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                if (curI < 0 || curJ < 0) return;
                Rectangle rect = new Rectangle(e.X-w/2,e.Y-h/2,w,h);
                DrawGame();
                g.DrawImage(clips[curI][curJ],rect);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X > offX && e.X < offX + (w + 2) * col)
            {
                if (e.Y > offY && e.Y < offY + (h + 2) * col)
                {
                   


                 int i1 = (e.Y - offY) / h;
                  int j1 = (e.X - offX) / w;
                
                    Bitmap temp = clips[i1][j1];

                    clips[i1][j1] = clips[curI][curJ];
                    clips[curI][curJ] = temp;
                }
            }
            isDrag = false;
            curI = -1;
             curI = -1;
            DrawGame();
            Gameover();
        }
        void Gameover()
        {
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < col; j++)
                {

                    if ((int)clips[i][j].Tag != i * col + j)

                        return;

                }
            }
                if (MessageBox.Show("fasdfghjk","拼图",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    row++;
                    col++;
                    InitGame(row, col);
                }
            
        }
    }
   
}
