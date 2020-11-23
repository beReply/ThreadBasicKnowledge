using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadBasicKnowledgeConsole
{
    public class Blocking
    {
        /*
         * 阻塞
         *      如果线程的执行由于某种原因导致暂停，那么就认为该线程被阻塞了
         *          例如在Sleep或者通过Join等待其他线程结束时
         *      被阻塞的线程会立即将其处理器的时间片生成给其他线程，从此就不再消耗处理器时间，直到满足其阻塞条件为止
         *      可以通过ThreadState这个属性来判断线程是否处于被阻塞的状态
         *          bool blocked = (thread.ThreadState & ThreadState.WaitSleepJoin) != 0; // 为true则线程处于被阻塞的状态
         *
         * ThreadState
         *      ThreadState是一个flags enum,通过按位的形式，可以合并数据的选项
         *      其中四个较为有用的状态Unstarted,Running,WaitSleepJoin和Stopped
         */

        public void MainThread()
        {
            var thread = new Thread(Work);

            bool blocked = (thread.ThreadState & ThreadState.WaitSleepJoin) != 0;
        }

        private void Work()
        {
            Console.WriteLine("work");
        }
    }
}
