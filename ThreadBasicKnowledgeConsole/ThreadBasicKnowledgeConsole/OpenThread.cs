using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadBasicKnowledgeConsole
{
    public class OpenThread
    {
        /*
         * 术语:线程被抢占
         *      它的执行与另外一个线程上代码的执行交织的那一点。
         * 属性
         *      线程一旦开始运行，IsAlive就是true，线程结束就变成false。
         *      线程结束的条件:线程构造函数传入的委托结束了执行。
         *      线程一旦结束，就无法再重启。
         *      每个线程都有一个Name属性，通常用于调试。
         *          线程Name只能设置一次，以后更改会抛出异常。
         *      静态的Thread.CurrentThread属性会返回当前执行的线程。
         */


        /// <summary>
        /// 在单核计算机上，操作系统必须为每个线程分配"时间片"(在windows中通常为20毫秒)来模拟并发，从而导致重复的X和Y块。
        /// 在多核计算机或多处理器计算机上，这两个线程可以真正的并行执行，(可能受到计算机上其他活动进程的竞争)
        /// </summary>
        public void MainThread()
        {
            Thread.CurrentThread.Name = "Main Thread...";
            var thread = new Thread(WriteY) {Name = "Y Thread..."};
            thread.Start();

            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }
        }


        public void WriteY()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }
        }
    }
}
