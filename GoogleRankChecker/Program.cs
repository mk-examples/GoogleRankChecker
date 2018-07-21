using System;
using System.Net.Http;

namespace GoogleRankChecker {
    class Program {

        static void Main (string[] args) {
            //ONLY create one httpClient and reuse (for performance)
            var httpClient = new HttpClient ();
            var parseResult = Cli.Parser.Parse (args);
            if (!parseResult.IsValid) {
                Console.WriteLine (String.Join ("\n", parseResult.Messages));
                return;
            }
            var result = new App (httpClient).Check (parseResult.ToAppRequest ()).Result;
            Console.WriteLine (Cli.Presenter.Present (result));
        }
    }
}