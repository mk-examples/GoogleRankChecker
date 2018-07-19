using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleRankChecker
{
    public class GoogleSearcher
    {
        private HttpClient httpClient;

        public GoogleSearcher(HttpClient httpClient)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));
            this.httpClient = httpClient;
        }

        public async Task<string> Search(string searchTerm)
        {
            var url = $"https://www.google.com.au/search?num=100&q={System.Web.HttpUtility.UrlEncode(searchTerm)}";
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }

    public class HttpClientHandler : IHttpHandler
    {
        private static HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> GetAsync(Uri url)
        {

            return null;
        }
    }

    public interface IHttpHandler
    {
        Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}