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
        private HttpClient StubHttpRequest(string resultingHtml = null)
        {
            // Make sure we mock calls to google for all tests as they'll ban the ip address after 10 requests per hour.
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("*").Respond("text/html", resultingHtml ?? SampleHtml.Sample01);
            return mockHttp.ToHttpClient();
        }

        [Fact]
        public async void should_not_return_any_matches_for_unknown_domain()
        {
            var app = new App(StubHttpRequest());

            var result = await app.Check(new App.Request("brown bear", "www.xyz.com"));

            Assert.Empty(result.Positions);
        }

        [Fact]
        public async void should_count_domains_in_known_sample()
        {
            var app = new App(StubHttpRequest(SampleHtml.Sample02));

            var result = await app.Check(new App.Request("flying fish", "flyingfish.com.au"));

            Assert.Equal(new[] { 1, 2, 3 }, result.Positions);
        }
    }
}
