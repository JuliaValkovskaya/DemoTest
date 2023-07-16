using System;
using System.Diagnostics;
using System.Threading;

namespace DemoTests.Utils
{
    public class Wait
    {
        public const int PageLoadTimeout = 80000;
        public const int DefaultTimeout = 40000;
        public const int DefaultInterval = 250;
        
        public static void For(Func<bool> condition, int timeoutMillis = DefaultTimeout, int intervalMillis = DefaultInterval, string timeoutMessage=null, bool breakOnException = true)
        {
            if (!Try(condition, timeoutMillis, intervalMillis))
            {
                Console.Write("condition --- ");
                Console.WriteLine(condition);
                string msg = $"Timeout {timeoutMillis}ms reached.\n";
                msg += timeoutMessage ?? $"Condition: {condition.Method.DeclaringType?.Name}.{condition.Method.Name}";
                if (breakOnException)
                {
                    throw new TimeoutException(msg);
                }
            }
        }

        public static bool Try(Func<bool> condition, int timeoutMillis = DefaultTimeout, int intervalMillis = DefaultInterval)
        {
            bool result = false;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (!result)
            {
                try
                {
                    result = condition();
                    if (result)
                    {
                        break;
                    }
                }
                catch (Exception) { }

                if (watch.ElapsedMilliseconds > timeoutMillis)
                {
                    break;
                }
                Thread.Sleep(intervalMillis);
            }
            watch.Stop();
            return result;
        }
    }
}