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
            var greetings = Environment.GetEnvironmentVariable("GREETINGS");
            if (greetings is { Length: > 0 })
            {
                Console.WriteLine(greetings);
                Console.WriteLine(" aaa");
            }
        }

        [Option('o', "owner",
            Required = true,
            HelpText = "The owner, for example: \"dotnet\". Assign from `github.repository_owner`.")]
        public string Owner { get; set; } = null!;
    }
}
