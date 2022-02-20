using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CommandLine;
using ConsoleApp3;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var switchMappings = new Dictionary<string, string>()
        {
            { "-buildPath", "buildPathKey" },
            { "-folderName", "folderNameKey" },
            { "-filter", "filterKey" },
            { "-split", "splitKey" },
        };

        var builder = new ConfigurationBuilder().AddCommandLine(args, switchMappings);

        var config = builder.Build();
        Console.WriteLine($"buildPathKey: '{config["buildPathKey"]}'");
        Console.WriteLine($"folderNameKey: '{config["folderNameKey"]}'");
        Console.WriteLine($"filterKey: '{config["filterKey"]}'");
        Console.WriteLine($"splitKey: '{config["splitKey"]}'");

        string str = "Master";
        Console.WriteLine($"::set-output name=demo::{str}");
        Console.ReadLine();
    }
}
