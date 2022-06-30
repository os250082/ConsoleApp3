// See https://aka.ms/new-console-template for more information
using CommandLine;
using DotNet.GitHubAction;
using static CommandLine.Parser;

Console.WriteLine("567Hello, Worldd!dddeee");

static async Task Start(ActionInputs inputs)
{
    Console.WriteLine(inputs.Owner);

    string testDll = @"C:\GitHub\r10-server\Servers\Store\App\LibsLocal\Retalix.StoreServer.Model.Test.dll";
    var assenmblyLoader = new TestAssemblyLoader(testDll);
    var testsClasses = assenmblyLoader
    .GetTestsClasses()
    .OrderBy(x => x.Name)
    .ToList();

    Console.WriteLine(testsClasses);
}

var parser = Default.ParseArguments<ActionInputs>(() => new(), args);
await parser.WithParsedAsync(options => Start(options));
