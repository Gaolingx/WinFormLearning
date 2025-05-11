using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Temp
    {

        public static void ShowType<T>(T iPara)
        {
            Console.WriteLine("这是{0}，参数={1}，类型={2}",
                typeof(Program).Name, iPara, iPara.GetType().Name);
        }
    }
}

