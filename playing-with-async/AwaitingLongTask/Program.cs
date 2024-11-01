namespace AwaitingLongTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var utility = new MyUtility();

            await utility.GetUrlContentLengthAsync();
        }
    }

    public class MyUtility
    {

        public async Task<int> GetUrlContentLengthAsync()
        {
            var client = new HttpClient();

            Task<string> getStringTask = client.GetStringAsync("https://learn.microsoft.com/dotnet");

            DoIndependentWork();

            string contents = await getStringTask;

            return contents.Length;
        }

        void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
    }
}
