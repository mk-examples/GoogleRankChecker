using System.Diagnostics;

namespace GoogleRankChecker.Test {
    public static class TraceOn {
        static TraceOn () {
            Trace.Listeners.Add (new TextWriterTraceListener (System.Console.Out));
        }

        internal static void Ensure () {
            //Ensure the static constructor has been called.
        }
    }
}