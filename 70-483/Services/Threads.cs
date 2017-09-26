using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        async void Start() {
            string res = await GetData();
        }

        private Task<string> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
