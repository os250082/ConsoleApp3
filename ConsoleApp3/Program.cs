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

            var calc = new Calc();
            var result = calc.Sum(1, 2);
            Console.WriteLine("The result: " + result);
        }
    }
}
