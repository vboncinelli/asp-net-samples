namespace PlayingWithTasks.TaskBasedAsyncPattern
{
    internal class TaskBasedAsyncPattern
    {
        static void Main(string[] args)
        {
            var test = new Test();
            
            test.DoSomeWork();

            Console.WriteLine("this is the main thread...");
        }
    }
    
    public class Test
    {
        public void DoSomeWork()
        {
            Task<int> myTask = new Task<int>(() => LongOperation("test"));

            // Continuazione dopo il completamento del Task
            myTask.ContinueWith(task =>
            {
                int result = task.Result;

                Console.WriteLine($"Risultato: {result}");
            });

            myTask.Start();
            myTask.Wait();
        }

        public int LongOperation(string input)
        {
            // Simula un'operazione lunga
            Thread.Sleep(2000);
            return input.Length;
        }
    }
}
