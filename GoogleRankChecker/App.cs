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

            /* 
                writes the html into a file for debugging.
                **
                    Could be done all all requests and used as a cache
                    And placed in a sensitble location 
                    e.g. System.IO.Path.GetTempPath()
                **
            */
            if (System.Diagnostics.Debugger.IsAttached)
                System.IO.File.WriteAllText("./html.html", html);

            var domainResults = this.Parser.GetLinkedDomains(html)
                //Filter only the domains we are interested it
                .Where(x => String.Compare(x.Domain, request.Domain, true) == 0)
                //return position only.
                .Select(x => x.Position);
            return new Result(domainResults);
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
            public Result(IEnumerable<int> positions)
            {
                if (positions == null) throw new ArgumentNullException(nameof(positions));

                this.Positions = positions.ToArray();
            }
            public int[] Positions { get; }
        }
    }
}