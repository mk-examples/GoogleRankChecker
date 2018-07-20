using System;
using Xunit;
using GoogleRankChecker;
using System.Net.Http;
using RichardSzalay.MockHttp;
using System.IO;
using System.Reflection;

namespace GoogleRankChecker.Test
{
    public class AppTest
    {
        HttpClient httpClient;

        public AppTest()
        {
            // We'll need to mock calls to google for all tests as they'll ban the ip address after 10 requests per hour.
            // Only returns one sample html document, would be nice to include a few more samples.
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("*").Respond("text/html", SampleHtml.Sample01);
            httpClient = mockHttp.ToHttpClient();
        }

        [Fact]
        public async void should_not_return_any_matches_for_unkown_domain()
        {
            var app = new App(httpClient);

            var result = await app.Check(new App.Request("fying fish", "www.xyz.com"));

            Assert.Empty(result.Organic);
        }
    }
}
