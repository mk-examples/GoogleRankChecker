using System;
using Xunit;
using GoogleRankChecker;

namespace GoogleRankChecker.Test
{
    public class AppTest
    {
        [Fact]
        public void should_not_return_any_matches_for_unkown_domain()
        {
            var app = new App();

            var result = app.Check(new App.Request("fying fish", "www.xyz.com"));

            Assert.Empty(result.Ad);
            Assert.Empty(result.Organic);
        }
    }
}
