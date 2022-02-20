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
        { "-buildPath", "key1" }
        };

        var builder = new ConfigurationBuilder().AddCommandLine(args, switchMappings);
        var config = builder.Build();
        Console.WriteLine($"Key1: '{config["Key1"]}'");
    }
}
