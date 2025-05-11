

namespace ConsoleApp25
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //   //TestChild<string, int> test = new TestChild<string, int>("aa", 111);
            //   //test.SetValue();
            //   //MyList<int> myList = new MyList<int>();
            //   //myList.Add(1, 4);
            //   //myList.GetElements();
            //   Worker<string, int> worker = new Worker<string, int>("QQQQa", 111);
            //   worker.SetValue();


            // ThreadStart childRef =new ThreadStart(CallChildThread);
            //Thread childthread = new Thread(childRef);
            //   childthread.Start();
            //   try
            //   {
            //       while (true)
            //       {
            //           Console.WriteLine("正在");
            //           Thread.Sleep(500);
            //       }
            //   }
            //   catch (Exception ex)
            //   {

            //   }
            TrainTicker.MainThead();


        }

    //    static void CallChildThread()
    //    {
    //        try
    //        {
    //            while (true)
    //            {
    //                Console.WriteLine("子线程启动！");
    //                Thread.Sleep(500);
    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //        finally
    //        {

    //        }
    //    }
        }

    //class MyList<T> : IList<T>, IDictionary<int, T>
    //{
    //    public void Add(int key, T value)
    //    {

    //    }

    //    public T[] GetElements()
    //    {
    //        return null;
    //    }
}
