using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    internal class MyTest<T, S, M> : Worker<T, S>, IStudy<M>
    {
        public MyTest(T username, S sex) : base(username, sex)
        {
        }

        public M Show()
        {
            throw new NotImplementedException();
        }
    }
}
