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
            { "-buildPath", "key1" },
            { "-folderName", "key2" },
            { "-filter", "key3" },
            { "-split", "key4" },
        };

        var builder = new ConfigurationBuilder().AddCommandLine(args, switchMappings);

        //var greetings = Environment.GetEnvironmentVariable("GREETINGS");
        //var split = greetings.Split(',');
        //Console.WriteLine(split[0]);

        var config = builder.Build();
        Console.WriteLine($"Key1: '{config["Key1"]}'");
        Console.WriteLine($"Key2: '{config["Key2"]}'");
        Console.WriteLine($"Key3: '{config["Key3"]}'");
        Console.WriteLine($"Key4: '{config["Key4"]}'");

        string str = "Master";
        Console.WriteLine($"::set-output name=demo::{str}");
        Console.ReadLine();
    }
}
