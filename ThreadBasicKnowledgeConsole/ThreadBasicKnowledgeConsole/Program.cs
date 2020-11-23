using System;

namespace ThreadBasicKnowledgeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var threadSync = new ThreadSync();
            threadSync.MainThread();

            Console.ReadLine();
        }
    }
}
