using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static string QuestionSeparator = "-------------------- {0} --------------------";
        static void Main(string[] args)
        {
            Console.WriteLine(QuestionSeparator, "Question 1");
            new Day1().Run();
            Console.WriteLine();
            Console.WriteLine(QuestionSeparator, "Question 2");
            ////new Day2().Run();
            Console.Read();
        }
    }
}
