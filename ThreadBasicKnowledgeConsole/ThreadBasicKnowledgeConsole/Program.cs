using System;

namespace ThreadBasicKnowledgeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var joinAndSleep = new JoinAndSleep();
            joinAndSleep.MainThread();

            Console.WriteLine("\n运行完成");
            Console.ReadLine();
        }
    }
}
