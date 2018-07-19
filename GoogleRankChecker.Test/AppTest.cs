using System;
using Xunit;
using GoogleRankChecker;
using System.Net.Http;

namespace GoogleRankChecker.Test
{
    public class AppTest
    {
        static HttpClient httpClient = new HttpClient();

        [Fact]
        public async void should_not_return_any_matches_for_unkown_domain()
        {
            var app = new App(httpClient);

            var result = await app.Check(new App.Request("fying fish", "www.xyz.com"));

            Assert.Empty(result.Ad);
            Assert.Empty(result.Organic);
        }
    }
}
