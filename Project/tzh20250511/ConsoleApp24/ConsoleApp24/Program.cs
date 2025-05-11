namespace ConsoleApp24
{
    delegate string GenericDelete<in T>(T value);
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student<object>[] stu = new Student<object>[]
            //{
            //    new Student<object>("1"),
            //   new Student < object >("1")
            //};
            //int result = stu[0].CompareTo(stu[1]);
            //Console.WriteLine(result==0?"1":"2");
            //Console.ReadLine();
            // GenericDelete<int> gl = F;
            // GenericDelete<int> g2 = G;
            //Console.WriteLine(gl(3));
            // Console.WriteLine(g2(3));

            //Console.WriteLine(Demo.GetValue(3));
            //Console.WriteLine(Demo.GetValue("qqq"));
            //Console.WriteLine(Demo.GetValue(new Student<object>("1")).Name);
            //chinesePeople az=new chinesePeople();
            //ShowObject(az);
            C<A> a = new C<A>();
            GetA(a);
            GetB(3333330);
        }


        static void ShowObject<T>(T oPara) where T:people 
        {
            Console.WriteLine("aa      {0}  a     {1}  a    {2}",
            typeof(Program) , oPara.GetType().Name,oPara);
        }

        static T Get<T>(T t) where T : ISports1
        {
            t.PingPang();
            return t;
        }
        static T GetA<T>(T t) where T : class
        {
            return t;
        }
        static T GetB<T>(T t) where T : struct
        {
            return t;
        }
        static string F(int i)
        {
            return "f";
        }
        static string G(int i)
        {
            return "g";
        }
    
    }
    class A
    {

    }
    class B
    {
        public B(int i)
        {

        }
    }
    class C <T> where T : new()
    {

    }
    class D <T> where T:B ,new()
    {

    }
}