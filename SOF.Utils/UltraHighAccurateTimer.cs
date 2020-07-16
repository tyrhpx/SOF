using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    /// 
    /// ManualTimer
    /// A simulated timer by loop 
    /// It creates a new thread in Thread Pool using ThreadPool class
    /// Nocky Tian @ 2008-3-16
    /// 
    /// The timer starts a new thread using  object,
    /// and the value of the property Priority is set to 
    /// so that the accuray could be kept 1ms around.
    /// 
    /// 
    /// 
    /// 
    public class UltraHighAccurateTimer
    {
        private Action<object> Tick = null;
        private object tickArgs = null;
        private object threadLock = new object();       // for thread safe
        private long clockFrequency;            // result of QueryPerformanceFrequency() 
        bool running = true;
        Thread thread;

        private int intervalMs;                     // interval in mimliseccond;

        /// 
        /// Timer inteval in milisecond
        /// 
        public int Interval
        {
            get { return intervalMs; }
            set
            {
                intervalMs = value;
                intevalTicks = (long)((double)value * (double)clockFrequency / (double)1000);
            }
        }
        private long intevalTicks;
        private long nextTriggerTime;               // the time when next task will be executed

        /// 
        /// Pointer to a variable that receives the current performance-counter value, in counts. 
        /// 
        /// 
        /// If the function succeeds, the return value is nonzero.
        /// 
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        /// 
        /// Pointer to a variable that receives the current performance-counter frequency, 
        /// in counts per second. 
        /// If the installed hardware does not support a high-resolution performance counter, 
        /// this parameter can be zero. 
        /// 
        /// 
        /// If the installed hardware supports a high-resolution performance counter, 
        /// the return value is nonzero.
        /// 
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        public UltraHighAccurateTimer(Action<object> callback, int interval)
        {
            if (QueryPerformanceFrequency(out clockFrequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception("QueryPerformanceFrequency() function is not supported");
            }

            this.Tick = callback;
            this.Interval = interval;

            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Name = "HighAccuracyTimer";
            thread.Priority = ThreadPriority.Highest;
            thread.IsBackground = true;
        }

        /// 
        /// 进程主程序
        /// 
        /// 
        private void ThreadProc()
        {
            long currTime;
            GetTick(out currTime);
            nextTriggerTime = currTime + intevalTicks;
            while (running)
            {
                while (currTime < nextTriggerTime)
                {
                    Thread.Sleep(1);
                    GetTick(out currTime);
                }   // wait an interval
                nextTriggerTime = currTime + intevalTicks;

                //触发事件
                try
                {
                    if (running) // 定时器未关闭
                    {
                        Tick(tickArgs);
                    }
                }
                catch (Exception ex)
                {
                    // 吃掉所有异常
                    LogUtil.GetLogger("UltraHighAccurateTimer").Error(ex, "TickErr: {0}", ex.Message);
                }
            }
        }

        public bool GetTick(out long currentTickCount)
        {
            if (QueryPerformanceCounter(out currentTickCount) == false)
                throw new Win32Exception("QueryPerformanceCounter() failed!");
            else
                return true;
        }

        public void Start()
        {
            thread.Start();
        }
        public void Stop()
        {
            running = false;
        }

        ~UltraHighAccurateTimer()
        {
            running = false;
        }
    }
}
