using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
    public class Day2
    {
        public static void Run()
        {
            var sum = CalculateSum("Day2.txt", true);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Sum part 1: {sum}");

            sum = CalculateSum("Day2.txt", false);
            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Sum part 2: {sum}");
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
            var values = line.Split('\t', ' ');

            foreach (var outerValue in values)
            {
                var outerInt = int.Parse(outerValue);
                foreach (var innerValue in values)
                {
                    var innerInt = int.Parse(innerValue);
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
            var values = line.Split('\t', ' ');
            int min = int.MaxValue, max = int.MinValue;
            foreach (var value in values)
            {
                var intVal = int.Parse(value);
                min = Math.Min(min, intVal);
                max = Math.Max(max, intVal);
            }

            return max - min;
        }
    }
}