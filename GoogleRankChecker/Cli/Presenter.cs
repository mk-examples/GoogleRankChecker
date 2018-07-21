using System;

namespace GoogleRankChecker.Cli
{
    /* Converts the Result object into a string or display   */
    public static class Presenter
    {
        public static string Present(App.Result result)
        {
            if (result.Positions.Length == 0)
                return "0";

            return String.Join(", ", result.Positions);
        }

        internal static void Present(Parser.Result parseResult)
        {
            throw new NotImplementedException();
        }
    }
}