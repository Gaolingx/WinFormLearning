using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2_IMS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            a();
        }
        Button[] bts =new Button[10];
         void a()
        {
            for (int i = 0; i < 10; i++)
            {
                bts[i] = new Button();
                bts[i].Enabled = false;
                bts[i].Location = new System.Drawing.Point(91+i*35, 235);
                bts[i].Name = "button"+1;
                bts[i].Size = new System.Drawing.Size(41, 24);
                bts[i].TabIndex = 0;
                bts[i].Text =""+i;
                bts[i].UseVisualStyleBackColor = true;
                bts[i].Click += new System.EventHandler(this.button1_Click);

            }
        }

    }
}
