using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadBasicKnowledgeConsole
{
    public class ThreadSync
    {
        private static readonly Semaphore _semaphore = new Semaphore(0,1);

        public void MainThread()
        {
            _semaphore.Release(1);
            for (int i = 0; i < 10; i++)
            {
                _semaphore.WaitOne();
                var thread = new Thread(WriteMessage);
                thread.Start(i);
            }
        }


        public void WriteMessage(object i)
        {
            Console.WriteLine(i.ToString());
            _semaphore.Release(1);
        }
    }
}
