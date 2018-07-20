using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace GoogleRankChecker
{
    class Program
    {

        static void Main(string[] args)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy("http://localhost:8888", false),
                UseProxy = false
            };

            //ONLY create one httpClient and reuse (for performance)
            var httpClient = new HttpClient(httpClientHandler);

            var result = new App(httpClient).Check(CliParsers.Parse(args)).Result;
            Console.WriteLine(ResultToString.Present(result));
        }
    }
}
