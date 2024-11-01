using System.Net;

namespace PlayingWithTasks.Deadlocks
{
    internal class DeadLockExample
    {
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Lock1ThenLock2);
            Thread thread2 = new Thread(Lock2ThenLock1);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        static void Lock1ThenLock2()
        {
            lock (lock1)
            {
                Console.WriteLine("Thread 1 ha acquisito il lock1.");
                Thread.Sleep(500); // Simula il lavoro
                lock (lock2)
                {
                    Console.WriteLine("Thread 1 ha acquisito il lock2.");
                }
            }
        }

        static void Lock2ThenLock1()
        {
            lock (lock2)
            {
                Console.WriteLine("Thread 2 ha acquisito il lock2.");
                Thread.Sleep(500); // Simula il lavoro
                lock (lock1)
                {
                    Console.WriteLine("Thread 2 ha acquisito il lock1.");
                }
            }
        }
    }
}
