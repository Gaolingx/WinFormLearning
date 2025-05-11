using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class OperData
    {

        public OperData() { }
        public void  ArrayListTest(ArrayList arrayList)
        {
            arrayList.RemoveAt(1);
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTest(List<Book> list) 
        {
        Book book1 = new Book("a",1);
        Book book2 = new Book("c", 2);
        Book book3 = new Book("d", 3);
        Book book4 = new Book("e", 4);
        Book book5 = new Book("f", 5);
            list.Add(book1);
            list.Add(book2);
            list.Add(book3);   
            list.Add(book4);
            list.Add(book5);
            list.Insert(4, book1);
            list.RemoveAt(0);
          
            foreach (var item in list)
            {
                Console.WriteLine(item.BookName+"\t"+item.Price);
            }


        }
        public void HashTabTest(Hashtable ht)
        {
            ht.Add("1","a");
            ht.Add("2","b");
            ht.Add("3","c");
            ht.Add("4","d");
            ht.Add("5","e");
            ht.Add("6","f");
            foreach (var key in ht.Keys)
            {
               Console.WriteLine(key);
                
            }
            foreach (var value in ht.Values)
            {
                Console.WriteLine(value);
            }
            foreach (var key in ht.Keys)
            {
                Console.WriteLine(ht[key]);
            }

        }

        public void DictionaryTest(Dictionary<int, string> dict)
        {
            dict.Add(1, "a");
            dict.Add(2, "b");
            dict.Add(3,"c");
            dict.Add(4,"d");
            dict.Add(5,"e");
            dict.Add(6,"f");
            dict.Add(7,"g");
            dict.Add(8,"h");
            dict.Add(9,"i");


            foreach (var key in dict.Keys)
            {
                if (key == 3)
                {
                    Console.WriteLine("包含3键  "  +key+"   "+ dict[key]);
                }
            }
            Console.WriteLine("包含"+dict.Count+"元素");
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(dict[key]);
            }


            foreach (var dicts in dict)
            {
                Console.WriteLine(dicts.Key +"  "+ dicts.Value);
            }
        }
    }
}
