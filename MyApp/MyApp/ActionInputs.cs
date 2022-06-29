using System;
using CommandLine;

namespace DotNet.GitHubAction
{
    public class ActionInputs
    {
        [Option('aaa', "owner", Required = true)]
        public string Ownerbbb { get; set; } = null!;

        public string Ownert { get; set; } = null!;

        public string Owner2 { get; set; } = null!;

        public string Owner3 { get; set; } = null!;

        public string Owner4 { get; set; } = null!;

        public string OwNer5 { get; set; } = null!;
    }
}
