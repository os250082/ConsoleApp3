using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestsSplitter
{
    class Program
    {
        static private Dictionary<string, string> testClassesSplitter;
        static private string _buildPath;
        static private string _folderName;
        static private string _filter;

        static void Main(string[] args)
        {
            ParseArgs(new List<string>(args));

            var splitter = new TestsSplitter(_buildPath, _folderName, _filter, testClassesSplitter);
            splitter.SplitTests();

            var builder = new SplitTestsJsonBuilder(splitter.Models);

            File.WriteAllText("c:\\temp\\a" + ".json", builder.BuildJson());
        }

        private static void ParseArgs(List<string> args)
        {
            _buildPath = args[0];
            _folderName = args[1];
            _filter = args[2];

            args.RemoveRange(0, 3);
            if (args.Count > 0)
            {
                testClassesSplitter = args.Select((v, i) => new
                { Key = args[i].Split(':')[0], Value = args[i].Split(':')[1] })
                    .ToDictionary(o => o.Key, o => o.Value);
            }
        }
    }
}
