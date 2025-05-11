using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Employ
    {
        public Employ() { }
        private string cname;
        private int age;
        private string sex;

        public string Cname { get => cname; set => cname = value; }
        public int Age { get => age; set => age = value; }
        public string Sex { get => sex; set => sex = value; }

        public Employ(string cname, int age, string sex)
        {
            this.Cname = cname;
            this.Age = age;
            this.Sex = sex;
        }
    }
}
