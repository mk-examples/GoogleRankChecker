using System.IO;
using System.Reflection;

namespace GoogleRankChecker.Test {
    public static class SampleHtml {
        private static readonly string thisAssemblyPath = Path.GetDirectoryName (
            Assembly.GetAssembly (typeof (AppTest)).Location
        );
        private static string GetSampleFile (string filename) => File.ReadAllText (
            Path.Join (thisAssemblyPath, "samples", filename)
        );

        public static readonly string Sample01 = GetSampleFile ("sample01.html");
        public static readonly string Sample02 = GetSampleFile ("sample02.html");
        //   public static readonly string Sample03 = GetSampleFile("sample03.html");
    }
}