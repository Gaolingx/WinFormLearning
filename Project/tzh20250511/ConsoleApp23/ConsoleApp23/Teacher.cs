using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{   
    class Teacher : Employee,ITaecher
    {
        public string name = "aaa";
        public int age = 5;
        public override string Name { get => name  ; set => name=value; }
        public override int Age { get =>age ; set => age= value; }

        public Teacher print()
        {
            return null;
        }

        public override void Show()
        {
           Console.WriteLine(Name + " " + age); 
        }
    }
}
