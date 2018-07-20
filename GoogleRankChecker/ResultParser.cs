using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Diagnostics.Trace;
namespace GoogleRankChecker
{
    public class ResultParser
    {
        /* 
                Currently we are assuming that each result will have html like the sample below
                <cite class="iUh30">https://en.wikipedia.org/wiki/Brown_bear</cite>
                This can obviously this could break at any time google changes their html
            */
        private static Regex regex = new Regex(
            @"<cite[^>]*>(https?:\/\/)?([^\/\s]*)[^<]*<\/cite>",
            RegexOptions.Compiled |
            RegexOptions.IgnoreCase |
            RegexOptions.Multiline
            );
        public IEnumerable<Result> GetLinkedDomains(string html)
        {
            int position = 0;
            foreach (Match match in regex.Matches(html))
            {
                position++;
                var domain = match.Groups[2].Value;
                var result = new Result(position, domain);
                WriteLine($"{domain} found ({position})");
                yield return new Result(position, domain);
            }
        }


    }

    public class Result
    {
        public Result(int position, string domain)
        {
            Position = position;
            Domain = domain;
        }
        public int Position { get; }
        public string Domain { get; }
    }
}