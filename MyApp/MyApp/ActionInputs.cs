using System;
using CommandLine;

namespace DotNet.GitHubAction
{
    public class ActionInputs
    {
        string _repositoryName = null!;
        string _branchName = null!;

        public ActionInputs()
        {
            Console.WriteLine("Hello World");
        }

        [Option('o', "owner",
            Required = true]
        public string Owner { get; set; } = null!;
    }
}
