using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public class WebClients
    {
        public Task<byte[]> SendFormValues(string url, int intA, int intB)
        {
            var client = new WebClient();

            var nvc = new NameValueCollection() { { "a", intA.ToString() }, { "b", intB.ToString() } };

            return client.UploadValuesTaskAsync(new Uri(url), nvc);
        }

        public bool DownloadFile(string address, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(address, fileName);
            }

            return true;
        }

    }
}
