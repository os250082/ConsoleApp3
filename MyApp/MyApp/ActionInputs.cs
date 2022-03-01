using System;
using CommandLine;

namespace DotNet.GitHubAction
{
    public class ActionInputs
    {
        public ActionInputs()
        {
            
        }

        [Option('o', "owner", Required = true)]
        public string Owner { get; set; } = null!;
    }
}
