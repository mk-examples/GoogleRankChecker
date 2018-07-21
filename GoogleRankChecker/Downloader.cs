using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleRankChecker {
    public class Downloader {
        private HttpClient httpClient;

        public Downloader (HttpClient httpClient) {
            if (httpClient == null) throw new ArgumentNullException (nameof (httpClient));
            this.httpClient = httpClient;
        }

        public async Task<string> Search (string searchTerm) {
            var url = $"https://www.google.com.au/search?num=100&q={System.Web.HttpUtility.UrlEncode(searchTerm)}";
            var request = new HttpRequestMessage () {
                RequestUri = new Uri (url),
                    Method = HttpMethod.Get,
                    Headers = { { "cache-control", "max-age=0" },
                        { "user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36" },
                        { "accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8" },
                        { "accept-language", "en-US,en;q=0.9,en-AU;q=0.8" },
                    },
            };
            var response = await httpClient.SendAsync (request);
            return await response.Content.ReadAsStringAsync ();
        }
    }

}