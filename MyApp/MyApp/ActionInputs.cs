using System;
using CommandLine;

namespace DotNet.GitHubAction
{
    public class ActionInputs
    {
        [Option('o', "owner", Required = true)]
        public string Owner { get; set; } = null!;

        public string Owner { get; set; } = null!;

        public string Owner2 { get; set; } = null!;
    }
}
