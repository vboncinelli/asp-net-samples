namespace PlayingWithTasks.SimpleTasks
{
    internal class SimpleTaskRun
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() =>
            {
                Console.WriteLine("Message from Task #1");
            }).ContinueWith((e) => Console.WriteLine("Task #1 has exited with status {0}", e.Status));

            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Message from Task #2");
            }).ContinueWith((e) => Console.WriteLine("Task #2 has exited with status {0}", e.Status));

            Console.WriteLine("I'm on the main thread...");

            //Attende l'esecuzione di entrambi i task prima di uscire dal programma
            Task.WaitAll(t1, t2);
        }
    }
}