using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public class Threads
    {
        public static void ConcurrentDict()
        {
            ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();

            dict.AddOrUpdate("asd", 1, (x, y) => y + 5); // 1
            dict.AddOrUpdate("asd", 1, (x, y) => y + 5); // 6

        }

        async void Start()
        {
            string res = await GetData();
        }

        private Task<string> GetData()
        {
            throw new NotImplementedException();

            CancellationToken token = new CancellationToken();
            token.ThrowIfCancellationRequested();
            CancellationTokenSource source = new CancellationTokenSource();
            source.Cancel();
        }


        public static void RunTimer()
        {
            var tokenSource = new CancellationTokenSource();
            Task<int> task = Task.Factory.StartNew<int>(() => RunTimer(tokenSource.Token));
            Console.WriteLine("Press [Enter] to stop the timer.");
            Console.ReadLine();

            tokenSource.Cancel();
            Console.WriteLine("Timer stopped at {0}", task.GetAwaiter().GetResult());
            Console.ReadLine();
        }

        private static int RunTimer(CancellationToken cancellationToken)
        {
            int time = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                time++;
            }
            return time;
        }
    }
}
