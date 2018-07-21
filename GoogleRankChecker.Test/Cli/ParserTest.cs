using System;
using Xunit;
using GoogleRankChecker.Cli;

namespace GoogleRankChecker.Test.Cli
{
    public class ParserTest
    {
        [Fact]
        public void should_show_usage_when_no_parameters_supplied()
        {
            var result = Parser.Parse(new string[0]);
            Assert.False(result.IsValid);
            Assert.Single(result.Messages);
            Assert.Equal("Usage: dotnet run \"<search term>\" <domain>", result.Messages[0]);
        }

        [Fact]
        public void should_show_error_and_usage_when_only_parameters_supplied()
        {
            var result = Parser.Parse(new[] { "hello" });
            Assert.False(result.IsValid);
            Assert.Equal(2, result.Messages.Length);
            Assert.Equal("Error: 2 parameters are required", result.Messages[0]);
            Assert.Equal("Usage: dotnet run \"<search term>\" <domain>", result.Messages[1]);
        }

        [Fact]
        public void should_show_error_if_domain_name_looks_funky()
        {
            var result = Parser.Parse(new[] { "hello", "https://" });
            Assert.False(result.IsValid);
            Assert.Equal(2, result.Messages.Length);
            Assert.Equal("Error: domain name doesn't look right", result.Messages[0]);
            Assert.Equal("Usage: dotnet run \"<search term>\" <domain>", result.Messages[1]);
        }

        [Fact]
        public void should_show_error_more_than_2_arguments()
        {
            var result = Parser.Parse(new[] { "hello", "world", "additional" });
            Assert.False(result.IsValid);
            Assert.Equal(2, result.Messages.Length);
            Assert.Equal("Error: only 2 arguments allowed!", result.Messages[0]);
            Assert.Equal("Usage: dotnet run \"<search term>\" <domain>", result.Messages[1]);
        }

        [Fact]
        public void should_passback_search_term_and_domain_when_valid()
        {
            var result = Parser.Parse(new[] { "flying fish", "flyingfish.com" });
            Assert.True(result.IsValid);
            Assert.Equal("flying fish", result.SearchTerm);
            Assert.Equal("flyingfish.com", result.Domain);
        }

    }
}
