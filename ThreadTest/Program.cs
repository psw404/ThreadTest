using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Class System.Threading.Thread test
            Console.WriteLine("Main thread start ...");
            Thread t = new Thread(new ThreadStart(ThreadPro));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread " + i);
                Thread.Sleep(0);
            }
            Console.WriteLine("Main thread:Call join()");
            t.Join();
            Console.WriteLine("second thread has returned,");
            Console.WriteLine();
            #endregion

            #region Class System.Threading.Timer test

            TimerExample timerEx = new TimerExample(2);
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            TimerCallback timerCallBack = timerEx.CheckStatus;

            Console.WriteLine("{0} Creating timer.\n", DateTime.Now.ToString("h:mm:ss.fff"));

            Timer stateTimer = new Timer(timerCallBack, autoEvent, 1000, 250);
            autoEvent.WaitOne(5000, false);
            stateTimer.Change(0, 1000);
            Console.WriteLine("\nChanging period.\n");

            autoEvent.WaitOne(5000, false);
            stateTimer.Dispose();


            Console.WriteLine("\nDestroying timer.");

            #endregion

            #region Class ThreadPool test

            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolPro),null);

            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread exits.");

            #endregion



            Console.ReadKey();
        }

        private static void ThreadPoolPro(object state)
        {
            Console.WriteLine("Hello from the thread pool ");
            Thread.Sleep(100);
        }


        private static void ThreadPro()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("second thread " + i);
            }
        }
        private static void TimerMethod(object state)
        {
            Console.WriteLine("timer method test");
            Thread.Sleep(10);
        }
    }
}
