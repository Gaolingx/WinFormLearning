using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class chinesePeople : people, Iwork1, ISports1
    {
        public void PingPang()
        {
            Console.WriteLine("乒乓球");
        }

        public void work()
        {
            Console.WriteLine("工作");

        }
        public void tttt()
        {
            Console.WriteLine("aaaaaaaaa");
        }
    }
}
