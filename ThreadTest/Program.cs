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

            Thread t = new Thread(new ThreadStart(ThreadPro));
            t.Start();

        }


        static void ThreadPro()
        {

        }
    }
}
