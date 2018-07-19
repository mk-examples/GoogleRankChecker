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
        private GoogleResultParser Parser { get; }
        private GoogleSearcher Searcher { get; }

        public App(HttpClient client)
        {
            //no DI for now.
            this.Parser = new GoogleResultParser();
            this.Searcher = new GoogleSearcher(client);
        }

        public async Task<Result> Check(Request request)
        {
            var html = await this.Searcher.Search(request.SearchTerm);
            return new Result(this.Parser.CountAdResults(html, request.Domain), this.Parser.CountOrganicResults(html, request.Domain));
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
            public Result(IEnumerable<int> ads, IEnumerable<int> organic)
            {
                if (ads == null) throw new ArgumentNullException(nameof(ads));
                if (organic == null) throw new ArgumentNullException(nameof(organic));

                this.Ad = ads.ToArray();
                this.Organic = organic.ToArray();
            }
            public int[] Ad { get; }
            public int[] Organic { get; }
        }
    }
}