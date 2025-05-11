using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    class Worker<T,S>
    {
        private T username;
        private S sex;

        public Worker(T username, S sex)
        {
            this.username = username;
            this.sex = sex;
        }
        public void SetValue()
        {
            Console.WriteLine(username.ToString() + "\t" + sex.ToString());
        }

        internal class Woker<T, S> : Worker<T, S>
        {
            public Woker(T username, S sex) : base(username, sex)
            {


            }
        }
    }
}
