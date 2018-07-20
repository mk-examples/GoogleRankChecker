using System;
using Xunit;
using GoogleRankChecker;
using System.Net.Http;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using System.Linq;
using System.Diagnostics;

namespace GoogleRankChecker.Test
{
    public class ResultParserTest
    {
        public ResultParserTest()
        {
            TraceOn.Ensure();
        }
        [Fact]
        public void should_parse_google_ad_results()
        {
            var parser = new ResultParser();
            var results = parser.GetLinkedDomains(SampleHtml.Sample01);

            Assert.Equal(100, results.Count());
            Assert.Equal("en.wikipedia.org", results.First().Domain);
        }
    }

}
