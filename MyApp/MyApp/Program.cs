// See https://aka.ms/new-console-template for more information
using CommandLine;
using DotNet.GitHubAction;
using static CommandLine.Parser;

Console.WriteLine("Hello, World!");

static async Task Start(ActionInputs inputs)
{
    Console.WriteLine(inputs.Owner);
}

var parser = Default.ParseArguments<ActionInputs>(() => new(), args);
await parser.WithParsedAsync(options => Start(options));
