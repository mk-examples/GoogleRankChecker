using System.Linq;
using Xunit;

namespace GoogleRankChecker.Test {
    public class ResultParserTest {
        public ResultParserTest () {
            TraceOn.Ensure ();
        }

        [Fact]
        public void should_parse_google_results () {
            var parser = new ResultParser ();
            var results = parser.GetLinkedDomains (SampleHtml.Sample01);

            Assert.Equal (100, results.Count ());
            Assert.Equal ("en.wikipedia.org", results.First ().Domain);
        }
    }

}