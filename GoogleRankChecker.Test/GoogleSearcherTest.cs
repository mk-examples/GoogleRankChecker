using System;
using Xunit;
using GoogleRankChecker;
using System.Net.Http;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;

namespace GoogleRankChecker.Test
{
    public class GoogleSearcherTest
    {
        [Fact]
        public async void should_query_correct_google_url()
        {
            var mockHttp = new MockHttpMessageHandler();
            var expectedHtml = "Google says hello";
            mockHttp.Expect("https://www.google.com.au/search?num=100&q=conveyancing+software")
                .Respond("text/html", expectedHtml);
            var target = new GoogleSearcher(mockHttp.ToHttpClient());

            var result = await target.Search("conveyancing software");

            mockHttp.VerifyNoOutstandingExpectation();
            Assert.Equal(expectedHtml, result);
        }
    }

    public class MockHttpHandler : IHttpHandler
    {
        private readonly HttpResponseMessage result;

        public MockHttpHandler(HttpResponseMessage result)
        {
            this.result = result;
        }
        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return Task.FromResult(result);
        }
    }
}
