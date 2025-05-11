using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
 class Student<T>:IComparable<T>
    {
        public string Name { set; get; }
        public Student(string name) { this.Name = name; }

        public int CompareTo(T obj)
        {
            //Student stu = obj;
            Student<T> stu = obj as Student<T>;
           return this.Name.CompareTo(stu.Name);
        }
    }
}
