using System;

namespace GoogleRankChecker
{
    /* Converts the cli commands into a request object */
    internal static class CliParsers
    {
        public static App.Request Parse(string[] args)
        {
            return new App.Request("flying fish", Guid.NewGuid().ToString());
        }
    }
}