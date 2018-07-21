using RichardSzalay.MockHttp;
using Xunit;

namespace GoogleRankChecker.Test {
    public class DownloaderTest {
        [Fact]
        public async void should_query_correct_google_url () {
            var mockHttp = new MockHttpMessageHandler ();
            var expectedHtml = "Google says hello";
            mockHttp.Expect ("https://www.google.com.au/search?num=100&q=ginger+cats")
                .Respond ("text/html", expectedHtml);
            var target = new Downloader (mockHttp.ToHttpClient ());

            var result = await target.Search ("ginger cats");

            mockHttp.VerifyNoOutstandingExpectation ();
            Assert.Equal (expectedHtml, result);
        }
    }
}