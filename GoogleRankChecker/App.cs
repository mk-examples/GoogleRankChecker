using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static System.String;

namespace GoogleRankChecker
{
    /* Top level class for procesing the users request and return results */
    public class App
    {
        private ResultParser Parser { get; }
        private Downloader Downloader { get; }

        public App(HttpClient client)
        {
            //no DI for now.
            this.Parser = new ResultParser();
            this.Downloader = new Downloader(client);
        }

        public async Task<Result> Check(Request request)
        {
            var html = await this.Downloader.Search(request.SearchTerm);
            var domains = this.Parser.GetLinkedDomains(html);
            return new Result(new int[0]);
        }

        /*
            Represents the users request for checking the randing of the search terms (+ any other options)
         */
        public class Request
        {
            public Request(string searchTerm, string domain)
            {
                if (IsNullOrWhiteSpace(searchTerm)) throw new ArgumentOutOfRangeException(nameof(searchTerm));
                if (IsNullOrWhiteSpace(domain)) throw new ArgumentOutOfRangeException(nameof(domain));

                this.SearchTerm = searchTerm;
                this.Domain = domain;
            }
            public string SearchTerm { get; }
            public string Domain { get; }
        }

        /* Holds the result of the users request */
        public class Result
        {
            public Result(IEnumerable<int> organic)
            {
                if (organic == null) throw new ArgumentNullException(nameof(organic));

                this.Organic = organic.ToArray();
            }
            public int[] Organic { get; }
        }
    }
}