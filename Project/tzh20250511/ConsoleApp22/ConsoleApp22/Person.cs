using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Person
    {
        public string name;
        public IdInfo idInfo;
        public int age;
        //public IdInfo idInfo;
        public Person shallowCopy()
        {
          return (Person)this.MemberwiseClone();
        }
        public Person DeepCopy()
        {
            Person other=(Person)MemberwiseClone();
            other.name = string.Copy(name);
            other.idInfo = new IdInfo(idInfo.idNumder);
            return other;
        }

        internal class IdInfo
        {
            public string idNumder;
            public IdInfo(string idNumder) 
            {
            this.idNumder = idNumder;
            }
        }
    }
}
