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
            var response = await httpClient.GetAsync($"https://www.google.com.au/search?num=100&q=");
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