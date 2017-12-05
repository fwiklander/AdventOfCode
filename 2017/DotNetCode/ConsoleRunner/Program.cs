using System;
using System.Diagnostics;
using AdventOfCode;

namespace ConsoleApp1
{
    public class Program
    {
        private const string QuestionSeparator = "-------------------- {0} --------------------";

        public static void Main(string[] args)
        {
            Console.WriteLine(QuestionSeparator, "Day 1");
            var watch = Stopwatch.StartNew();
            Day1.Run();
            watch.Stop();
            PrintRequiredTime(watch);

            Console.WriteLine(QuestionSeparator, "Day 2");
            watch = Stopwatch.StartNew();
            Day2.Run();
            watch.Stop();
            PrintRequiredTime(watch);

            Console.WriteLine(QuestionSeparator, "Day 3");
            watch = Stopwatch.StartNew();
            Day3.Run();
            watch.Stop();
            PrintRequiredTime(watch);

            Console.WriteLine(QuestionSeparator, "Day 4");
            watch = Stopwatch.StartNew();
            Day4.Run();
            watch.Stop();
            PrintRequiredTime(watch);

            Console.WriteLine(QuestionSeparator, "Day 5");
            watch = Stopwatch.StartNew();
            Day5.Run();
            watch.Stop();
            PrintRequiredTime(watch);

            Console.WriteLine(QuestionSeparator, "DONE");
            Console.Read();
        }

        private static void PrintRequiredTime(Stopwatch watch)
        {
            Console.WriteLine();
            Console.WriteLine($"Required time: {watch.ElapsedMilliseconds}ms");
            Console.WriteLine();
        }
    }
}
