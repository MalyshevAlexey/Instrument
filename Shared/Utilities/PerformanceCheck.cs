using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Instrument.Utilities
{
    public class PerformanceCheck
    {
        public static void Execute<T>(Func<T> Method, int count)
        {
            //Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            long[] res = new long[count];
            long min = long.MaxValue, max = long.MinValue, average = 0;
            GC.Collect();
            //Method.Invoke();
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < count; i++)
            {
                sw.Restart();
                Method.Invoke();
                sw.Stop();
                res[i] = sw.Elapsed.Ticks;
                if (res[i] > max) max = res[i];
                if (res[i] < min) min = res[i];
                average += res[i];
            }
            Console.WriteLine("Runned " + count);
            Console.WriteLine("Min {0:F3}", (double)min / 10);
            Console.WriteLine("Max {0:F3}", (double)max / 10);
            Console.WriteLine("Average {0:F3}", average / (double)count / 10);
            Console.WriteLine();
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
        }

        public static void Execute(Action Method, int count)
        {
            Execute(() => { Method(); return true; }, count);
        }
    }
}
