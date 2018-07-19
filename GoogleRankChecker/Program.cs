using System;
using System.Linq;
using System.Net.Http;

namespace GoogleRankChecker
{
    class Program
    {

        static void Main(string[] args)
        {
            //ONLY create one httpClient and reuse (for performance)
            var httpClient = new HttpClient();

            var result = new App(httpClient).Check(CliParsers.Parse(args)).Result;
            Console.WriteLine(ResultToString.Present(result));
        }
    }
}
