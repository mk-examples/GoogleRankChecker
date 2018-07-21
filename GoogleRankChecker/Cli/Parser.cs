using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleRankChecker.Cli {
    /* Converts the cli commands into a request object 
        Normally I'd just use a cli parsing library, 
        However given the simple requirements I decided to do a simple one myself.
        If the program was to evolve with more requirements 
        a decided library for parsing should be used
    */
    internal static class Parser {
        const string usage = "Usage: dotnet run \"<search term>\" <domain>";
        static readonly Regex domainCheck = new Regex (@"^([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,}$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static Result Parse (string[] args) {
            if (args.Length == 0) {
                return new Result (new [] { usage });
            }

            if (args.Length == 1) {
                return new Result (new [] { "Error: 2 parameters are required", usage });
            }

            if (args.Length > 2) {
                return new Result (new [] { "Error: only 2 arguments allowed!", usage });
            }

            if (!domainCheck.IsMatch (args[1])) {
                return new Result (new [] { "Error: domain name doesn't look right", usage });
            }

            return new Result (null, args[0], args[1]);
        }

        public class Result {
            public Result (string[] messages, string searchTerm = null, string domain = null) {
                this.IsValid = messages == null || messages.Length == 0;
                this.Messages = messages ?? new string[0];
                this.SearchTerm = searchTerm;
                this.Domain = domain;
            }

            public bool IsValid { get; }
            public string[] Messages { get; }

            public string SearchTerm { get; }

            public string Domain { get; }

            public App.Request ToAppRequest () {
                if (!IsValid) throw new InvalidOperationException ("Only valid parameters can be converted to an App Request");
                return new App.Request (this.SearchTerm, this.Domain);
            }
        }
    }
}