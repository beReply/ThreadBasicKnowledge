using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadBasicKnowledgeConsole
{
    public class JoinAndSleep
    {
        private static Thread _threadOne, _threadTwo;
        private static TimeSpan _waitTime = new TimeSpan(0, 0, 1);

        /*
         * Thread.Sleep()方法会暂停当前的线程，并等一段时间
         *      注意:
         *          Thread.Sleep(0)这样调用会导致线程立即放弃本身当前的时间片，自动将CPU移交给其他线程
         *          Thread.Yield()做同样的事情，但是它只会把执行交给同一处理器上的其他线程
         *          当等待Sleep或Join的时候，线程处于阻塞的状态
         *
         * Sleep(0)或者Yield有时在高级性能调试的生产代码中很有用。
         * 如果在代码中的任何地方插入Thread.Yield()就破坏了程序，那么程序几乎肯定有bug
         */


        public void MainThread()
        {
            #region Join示例

            //var t = new Thread(Go);
            //t.Start();
            //t.Join();
            //Console.WriteLine("Thread t has ended!");

            #endregion

            #region Thread Join

            //_threadOne = new Thread(ThreadProc) {Name = "ThreadOne"};
            //_threadOne.Start();

            //_threadTwo = new Thread(ThreadProc) {Name = "ThreadTwo" };
            //_threadTwo.Start();

            #endregion

            #region Join with wait time

            var newThread = new Thread(Work);
            newThread.Start();

            Console.WriteLine(newThread.Join(_waitTime + _waitTime) ? "New thread terminated" : "Join timed out.");

            #endregion

        }

        #region Join示例

        private void Go()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }
        }

        #endregion


        #region Thread Join

        /// <summary>
        /// Join : 对线程进行等待
        ///     调用Join的时候，可以设置一个超时，用毫秒或者TimeSpan都可以。
        ///         设置TimeSpan后返回值为bool值。true:线程结束。 false:超时
        /// </summary>
        private void ThreadProc()
        {
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "ThreadOne" && _threadTwo.ThreadState != ThreadState.Unstarted)
            {
                Console.WriteLine(_threadTwo.Join(2000)
                    ? "ThreadTwo has termminated."
                    : "The timeout has elapsed and threadOne will resume");
            }

            Thread.Sleep(1000);
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("ThreadOne: {0}", _threadOne.ThreadState);
            Console.WriteLine("ThreadTwo: {0}\n", _threadTwo.ThreadState);
        }

        #endregion


        #region Join WaitTime

        private void Work()
        {
            Thread.Sleep(_waitTime);
        } 

        #endregion
    }
}
