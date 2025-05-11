using static ConsoleApp22.Person;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person pl = new Person();
            //pl.name = "Test";
            //pl.age = 1;
            //pl.idInfo = new IdInfo("111111");

            //  Person p2 = pl.shallowCopy();
            //  Person p3 = pl.DeepCopy();

            //  Console.WriteLine("p1");
            //  DisplayVaulers(pl);
            //  Console.WriteLine("p2");
            //  DisplayVaulers(p2);

            //  Console.WriteLine("p1");
            //  DisplayVaulers(pl);
            //  Console.WriteLine("p3");
            //  DisplayVaulers(p3);

            //  pl.name = "Name";
            //  pl.age = 2;
            //  p2.idInfo.idNumder =("44444");
            //  Console.WriteLine("p1");
            //  DisplayVaulers(pl);
            //  Console.WriteLine("p2");
            //  DisplayVaulers(p2);
            //  Console.WriteLine("p3");
            //  DisplayVaulers(p3);


            //  Console.WriteLine("p2");
            //  DisplayVaulers(p2);
            //  Console.WriteLine("p1");
            //  DisplayVaulers(pl);
            TestRef tr = new TestRef(1, 2);
            TestVal tv = new TestVal(1, 2);
            Console.WriteLine(tr.a);
            Console.WriteLine(tr.b);
            Console.WriteLine(tv.a);
            Console.WriteLine(tv.b);
            TestRef tr2 = tr;
            TestVal tv2 = tv;
            tr2.a = 3;
            Console.WriteLine(tr.a);
            tv2.a = 4;
            Console.WriteLine(tv.a);
        }
        static void DisplayVaulers(Person p)
        {
            Console.WriteLine("name：{0:s},age:{1:d}", p.name, p.age);
            Console.WriteLine("Value:{0:d}", p.idInfo.idNumder);
        }
    }
    struct TestVal /* (int x, int y)*/
    {
        public int a;
        public int b;
        public TestVal(int x, int y)
        {

            this.a = x;
            this.b = y;

        }

    }
}