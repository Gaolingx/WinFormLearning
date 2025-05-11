using System.IO;
namespace ConsoleApp27
{
    delegate void NumberChange(int n);
    internal class Program
    {
        static int num = 10;
        static void MyShow(int i,int j) 
        {
            Console.WriteLine(i*j);
        }
        static string HerShow(string s)
        {
         return s.Count().ToString();

        }

        static void Say(string s)
        {
            Console.WriteLine("我想说"+s);
        }
        static void Eat(string s)
        {
            Console.WriteLine("我想吃"+s);
        }
        public static void dosth(Action<string> act,string s)
        {
           
                act(s);

        }

        //static void Say(string s)
        //{
        //    Console.WriteLine(s);
        //}
        static string Add (int a, int b)
        {
            int c = a + b;
            return c.ToString();
        }
        static void dosch(Func<int,int,string> func ,int a,int b)
        {
            func(a,b);
        }
        static void addNum(int p)
        {
            num += p;
            Console.WriteLine("方法1:"+num);
        }
        static void MulNum(int p)
        {
            num *= p;
            Console.WriteLine("方法2:" + num);
        }
        static void Main(string[] args)
        {
            { 
            //  NumberChange nc1 = new NumberChange(addNum);
            //  nc1(10);
            //  NumberChange nc2 = addNum;
            //  nc2(10);

            //  NumberChange nc3 = delegate (int x)
            //  {
            //      Console.WriteLine("匿名函数:" + x);
            //  };

            //  nc3 += MulNum;
            //  nc3(10);
            //  Action<string> say1 = Say;
            //  say1("123");
            //  Func<int, int, string> add1 = Add;
            //Console.WriteLine( add1(3, 4));
            }
            //dosth(Say, "nh");
            //dosth(Eat, "苹果");
            //Action<int,int> myshow= MyShow;
            //myshow(1, 2);
            //Func<string,string> hershow= HerShow;
            //////Console.WriteLine(dosch(delegate (int a, int b) { return (a + b).ToString(); }, 1, 3)) ;
            //dosch(delegate (int a, int b) { return (a + b).ToString(); }, 1, 3);
            FileStream f1 = null;
            FileStream f2 = null;
            try
            {
                f1 = new FileStream("args[0]", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                f2 = new FileStream("args[1]", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                for (int i = 0; i < 10; i++)
                {
                    f1.WriteByte((byte)i);
                }
                f1.Position = 0;
                int t = 0;
                while ((t=f1.ReadByte())!=-1) { f2.WriteByte((byte)t); }
            }
            catch 
            {
            
            }
            f1.Close();
            f2.Close();
        }
    }
}