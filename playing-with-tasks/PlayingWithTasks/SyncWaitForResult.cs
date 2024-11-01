namespace PlayingWithTasks.AwaitForResult
{
    internal class SyncWaitForResult
    {
        static void Main(string[] args)
        {

            // Can cause deadlock
            var result = DoSomeStuffAsync().Result;
            Console.WriteLine(result);

            // Nothing is returned
            DoSomeStuffAsync().Wait();

            // Better option to get the result
            result = DoSomeStuffAsync().GetAwaiter().GetResult();
            Console.WriteLine(result);
        }

        static async Task<int> DoSomeStuffAsync()
        {
            await Task.Delay(2000);
            return 42;
        }
    }
}
