using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    class IndexNames
    {
        public static int size = 10;
        private string[] namelist =new string[size];
        public string this[int index]
        {
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }
            get
            {
                string temp;
                if (index >= 0 && index <= size - 1)
                {
                    temp = namelist[index];
                }
                else
                {
                    temp = "";
                }
              return temp;
            }

        }
        public int this[string name]
        {
            set { }
            get {
                int index=0;
                while (index < size)
                {
                    if (namelist[index]==name)
                    {
                        break;
                    }
                    index++;
                }
            return index;
            }
        }
        public Person this[string name, int age]
        {
            get
            {
                return new Person(name, age);
            }
        }

    }
}
