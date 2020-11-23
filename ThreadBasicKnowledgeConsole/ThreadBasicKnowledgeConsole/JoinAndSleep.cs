using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadBasicKnowledgeConsole
{
    public class JoinAndSleep
    {
        public void MainThread()
        {
            var t = new Thread(Go);
            t.Start();
            t.Join();

            Console.WriteLine("Thread t has ended!");
        }

        public void Go()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }
        }
    }
}
