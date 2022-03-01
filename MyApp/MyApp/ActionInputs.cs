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
            Required = true,
            HelpText = "The owner, for example: \"dotnet\". Assign from `github.repository_owner`.")]
        public string Owner { get; set; } = null!;
    }
}
