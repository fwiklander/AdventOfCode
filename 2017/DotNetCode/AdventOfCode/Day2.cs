using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public class Day2
    {
        public static void Run()
        {
            var sum = CalculateSum("Day2.txt", true);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Sum: {sum}");

            sum = CalculateSum("Day2.txt", false);
            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Sum: {sum}");
        }

        public static int CalculateSum(string filename, bool fromMaxAndMin)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"AdventOfCode.Inputs.Day2.{filename}";

            var sum = 0;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    if (fromMaxAndMin)
                    {
                        sum += GetAdditionFromMaxAndMin(reader.ReadLine());
                    }
                    else
                    {
                        sum += GetAdditionFromDivison(reader.ReadLine());
                    }
                }
            }

            return sum;
        }

        private static int GetAdditionFromDivison(string line)
        {
            var values = line.Split('\t', ' ').Select(int.Parse).ToList();
            foreach (var outerInt in values)
            {
                foreach (var innerInt in values)
                {
                    if (innerInt != outerInt && outerInt % innerInt == 0)
                    {
                        return outerInt / innerInt;
                    }
                }
            }

            return 0;
        }

        private static int GetAdditionFromMaxAndMin(string line)
        {
            var values = line.Split('\t', ' ').Select(int.Parse).ToList();
            return values.Max() - values.Min();
        }
    }
}