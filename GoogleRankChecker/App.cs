using System;
using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace GoogleRankChecker
{
    /* Top level class for procesing the users request and return results */
    public class App
    {
        public Result Check(Request request)
        {
            return new Result(Enumerable.Empty<int>(), Enumerable.Empty<int>());
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