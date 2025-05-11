namespace ConsoleApp26
{
    delegate void MyDele(int num);
    internal class Program
    {
        static MyDele mydele1, mydele2, mydele3, mydeles;


        static void Main(string[] args)
        {
            // mydele = PrintNum;

            mydele1 = new MyDele(PrintNum);

            mydele2 = new MyDele(PrintDoubleNum);

            mydele3 = new MyDele(PrintTripleNum);
            mydeles = null;
            mydeles = (MyDele)Delegate.Combine(mydeles, mydele1);
            mydeles = (MyDele)Delegate.Combine(mydeles, mydele2);
            mydeles += mydeles;



            Print(10000, mydeles);
        }

        static void Print(int value, MyDele md)
        {
            if (null != md)
            {
                md(value);

            }
        }

        static void PrintNum(int num)
        {
            Console.WriteLine(num);
        }
        static void PrintDoubleNum(int num)
        {
            Console.WriteLine(num*2);
        }
        static void PrintTripleNum(int num)
        {
            Console.WriteLine(num*3);
        }
    }
}