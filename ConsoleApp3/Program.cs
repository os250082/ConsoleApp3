using System;
using System.Threading.Tasks;
using CommandLine;
using ConsoleApp3;
using static CommandLine.Parser;

var parser = Default.ParseArguments<ActionInputs>(() => new(), args);
await parser.WithParsedAsync(options => StartAnalysisAsync(options));

static async Task StartAnalysisAsync(ActionInputs inputs)
{
    Console.WriteLine("The owner is: " + inputs.Owner);

    bool updateddotnet = true;
    Console.WriteLine($"::set-output name=updated-dotnet::{updateddotnet}");
}
