using System;
using System.Linq;

namespace GoogleRankChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new App().Check(CliParsers.Parse(args));
            Console.WriteLine(ResultToString.Present(result));
        }
    }
}
