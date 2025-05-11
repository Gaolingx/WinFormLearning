namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
          
            Employ emp1 = new Employ("王小清", 22, "女");
            Employ emp2 = new Employ("王小清", 22, "女");
          
           

            
            //Console.WriteLine(emp1.GetHashCode);
            //Console.WriteLine(emp2.GetHashCode);

            if (emp1==emp2 ) 
            { Console.WriteLine("是"); }
            else 
            {Console.WriteLine("否"); }

            if (emp1.Equals(emp2))
            { Console.WriteLine("是"); }
            else
            { Console.WriteLine("否"); }

            if (emp1.Cname==emp2.Cname)
            { Console.WriteLine("是"); }
            else
            { Console.WriteLine("否"); }


            if (emp1.Cname.Equals(emp2.Cname))
            { Console.WriteLine("是"); }
            else
            { Console.WriteLine("否"); }

            emp1 = emp2;

            if (emp1.Equals(emp2))
            { Console.WriteLine("是"); }
            else
            { Console.WriteLine("否"); }

            if (emp1 == emp2)
            { Console.WriteLine("是"); }
            else
            { Console.WriteLine("否"); }


        }
    }
}