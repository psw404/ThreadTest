using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadTest
{
    class TimerExample
    {
        private int invokeCount;
        private int maxCount;
        public TimerExample(int count)
        {
            invokeCount = 0;
            maxCount = count;
        }

        public void CheckStatus(object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0},Check Status {1,2}",DateTime.Now.ToString("h:mm:ss.fff"),(++invokeCount).ToString());

            if (invokeCount == maxCount)
            {
                invokeCount = 0;
                autoEvent.Set();
            }
        }
    }
}
