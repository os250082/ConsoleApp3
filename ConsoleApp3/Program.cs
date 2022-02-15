using System;

namespace ConsoleApp3
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var greetings = Environment.GetEnvironmentVariable("GREETINGS");
            Console.WriteLine(greetings);

        }
    }
}
