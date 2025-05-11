using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();
        }
        Point p1, p2;
        Graphics g;
        Pen pen;
        bool clicked;
        private void DrawForm_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
           clicked = true;
        }
        private void DrawForm_MouseUp(object sender, MouseEventArgs e)
        {
            p2 = e.Location;
            Drawline(p1, p2);
            clicked = false;
        }

        private void DrawForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                p2=e.Location;
                g.Clear(BackColor);
                Drawline(p1, p2);
            }
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
            pen = new Pen(Color.Yellow, 10);
            g = this.CreateGraphics();
        }

        private void DrawForm_Paint(object sender, PaintEventArgs e)
        {
            Drawline(p1, p2);
        }

        private void Drawline(Point p1, Point p2)
        {
          
            g.DrawLine(pen, p1, p2);
        }
    }
}
