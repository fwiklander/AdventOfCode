using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode;

namespace ConsoleApp1
{
    public class Program
    {
        private static string QuestionSeparator = "-------------------- {0} --------------------";

        public static void Main(string[] args)
        {
            Console.WriteLine(QuestionSeparator, "Day 1");
            new Day1().Run();
            Console.WriteLine();

            Console.WriteLine(QuestionSeparator, "Day 2");
            new Day2().Run();
            Console.WriteLine();

            Console.WriteLine(QuestionSeparator, "Day 3");
            new Day3().Run();
            Console.WriteLine();

            Console.WriteLine(QuestionSeparator, "Day 4");
            new Day4().Run();
            Console.WriteLine();

            Console.WriteLine(QuestionSeparator, "DONE");
            Console.Read();
        }
    }
}
