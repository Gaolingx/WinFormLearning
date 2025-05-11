using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    interface IList<T1>
    {
        T1[] GetElements();
    }
    interface IDictionary<K, V>
    {
        void Add(K key, V value);
    }
}
