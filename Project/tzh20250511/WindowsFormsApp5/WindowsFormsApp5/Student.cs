using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public class Student
    {

        string uName;
        string yx;
        string zy;
        string xb;
        string sr;
        string ah;
        string xq;
        string jj;

        public Student(string uName, string yx, string zy, string xb, string sr, string ah, string xq, string jj)
        {
            this.uName = uName;
            this.yx = yx;
            this.zy = zy;
            this.xb = xb;
            this.sr = sr;
            this.ah = ah;
            this.xq = xq;
            this.jj = jj;
        }

        public string UName { get => uName; set => uName = value; }
        public string Yx { get => yx; set => yx = value; }
        public string Zy { get => zy; set => zy = value; }
        public string Xb { get => xb; set => xb = value; }
        public string Sr { get => sr; set => sr = value; }
        public string Ah { get => ah; set => ah = value; }
        public string Xq { get => xq; set => xq = value; }
        public string Jj { get => jj; set => jj = value; }
    }
}
