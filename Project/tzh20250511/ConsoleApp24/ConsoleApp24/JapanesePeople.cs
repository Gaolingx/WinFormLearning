using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class JapanesePeople : people, ISports1
    {
        public void PingPang()
        {
            Console.WriteLine("乒乓球");
        }
    }
}
