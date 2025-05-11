using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    abstract class Employee
    {


        public Employee() { }
        
        public abstract string Name{get; set;}

        public abstract int Age { get; set; }

        public abstract void Show();
    }
}
