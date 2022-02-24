using System;
using CommandLine;

namespace TestsSplitter
{
    public class ActionInputs
    {
        string _repositoryName;
        string _branchName;

        public ActionInputs()
        {
            var greetings = Environment.GetEnvironmentVariable("GREETINGS");

        }

        [Option('d', "dir",
            Required = true,
            HelpText = "The root directory to start recursive searching from.")]
        public string Directory { get; set; } = null;

    }
}
