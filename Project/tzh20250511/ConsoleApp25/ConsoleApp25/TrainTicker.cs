internal class TrainTicker
{
    private static int Timer = 20;
    private static int ans = 20;
    public static Random rnd = new Random();
    public static void CallChildThread1()
    {
        try
        {
            if (ans <= 0)
            {
                Console.WriteLine("无");
            }
            else
            {
                Console.WriteLine("有");
            }
        }
        catch (Exception ex)
        {
        }
    }
    public static void CallChildThread2()
    {
        try
        {
            while (true)
            {
                Thread.Sleep(1000);
                Timer--;
            }
        }
        catch
        {
        }
    }
    public static void MainThead()
    {
        ThreadStart th1 = new ThreadStart(CallChildThread1);
        ThreadStart th2 = new ThreadStart(CallChildThread2);
        Thread thread1 = new Thread(th1);
        Thread thread2 = new Thread(th2);
        try
        {
            thread1.Start();
            thread2.Start();
            while (true)
            {
                Console.WriteLine("正在售票");
                if (Timer > 0)
                {
                    ans--;
                    if (ans <= 0)
                    {
                        Console.WriteLine("已售空");
                        thread1.Abort();
                        thread2.Abort();
                     
                        break;
                    }
                    Console.WriteLine("售票成功");
                }
                else
                {
                    Console.WriteLine("火车离开");
                    thread1.Abort();
                    thread2.Abort();
                
                    break;
                }
                Thread.Sleep(rnd.Next(500, 1000));
            }

        }
        catch (Exception ex) { }
    }
}

