using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Book
    {
        public Book() { }
        private string bookName;
        private int price;

        public string BookName { get => bookName; set => bookName = value; }
        public int Price { get => price; set => price = value; }

        public  Book (string BookName,int Price)
        {
            this.BookName = BookName;
            this.Price = Price;
        }
       
    }
}
