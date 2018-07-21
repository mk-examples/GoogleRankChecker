using System.Linq;
using GoogleRankChecker.Cli;
using Xunit;

namespace GoogleRankChecker.Test.Cli {
    public class PresenterTest {
        [Fact]
        public void should_present_NO_results_as_0 () {
            var result = Presenter.Present (new App.Result (Enumerable.Empty<int> ()));
            Assert.Equal ("0", result);
        }

        [Fact]
        public void should_present_results_comma_seperated () {
            var result = Presenter.Present (new App.Result (new int[] { 1, 5, 7, 9 }));
            Assert.Equal ("1, 5, 7, 9", result);
        }
    }
}