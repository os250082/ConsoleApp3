using CommandLine;
using System;

namespace ConsoleApp3
{
    public class ActionInputs
    {
        public ActionInputs()
        {
            var greetings = Environment.GetEnvironmentVariable("GREETINGS");
            if (greetings is { Length: > 0 })
            {
                Console.WriteLine(greetings);
            }
        }

        [Option('o', "owner",
            Required = true,
            HelpText = "The owner, for example: \"dotnet\". Assign from `github.repository_owner`.")]
        public string Owner { get; set; } = null!;
    }
}
