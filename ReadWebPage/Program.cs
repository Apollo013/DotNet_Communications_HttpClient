using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReadWebPage
{
    /// <summary>
    /// This example simply reads a page from the bcc home website
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://bbc.co.uk");
            Task.Factory.StartNew(() => GetPage(uri));
            Console.ReadKey();
        }

        private static async Task GetPage(Uri uri)
        {
            HttpClient client = new HttpClient();
            string page = await client.GetStringAsync(uri);
            Console.WriteLine(page);
        }
    }
}
