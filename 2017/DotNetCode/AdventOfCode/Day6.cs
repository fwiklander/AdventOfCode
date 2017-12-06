using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day6
    {
        private static readonly Dictionary<string, int> _usedSequences = new Dictionary<string, int>();

        public static void Run()
        {
            var input = new List<int> { 11, 11, 13, 7, 0, 15, 5, 5, 4, 4, 1, 1, 7, 1, 15, 11 };
            var iterations = CalculateInfiniteLoop(input);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Count: {iterations}");

            var loopLength = CalculateInfiniteLoopLength(input);
            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Count: {loopLength}");
        }

        public static int CalculateInfiniteLoopLength(List<int> input = null)
        {
            if (_usedSequences.Count == 0)
            {
                CalculateInfiniteLoop(input);
            }

            var checksum = CalculateCheckSum(input);
            var iterationsAtFirstOccurance = _usedSequences[checksum];

            return _usedSequences.Count - iterationsAtFirstOccurance;
        }

        public static int CalculateInfiniteLoop(List<int> input)
        {
            var iterations = 0;
            var checksum = CalculateCheckSum(input);

            do
            {
                _usedSequences.Add(checksum, iterations);
                var maxValue = input.Max();
                var maxIndex = input.IndexOf(maxValue);
                input[maxIndex] = 0;

                var toUpdateIndex = maxIndex + 1;
                while (maxValue > 0)
                {
                    if (toUpdateIndex >= input.Count)
                    {
                        toUpdateIndex = 0;
                    }

                    input[toUpdateIndex++]++;
                    maxValue--;
                }

                iterations++;
                checksum = CalculateCheckSum(input);
            } while (!_usedSequences.ContainsKey(checksum));

            return iterations;
        }

        private static string CalculateCheckSum(IEnumerable<int> input)
        {
            var checkSum = new StringBuilder();
            foreach (var val in input)
            {
                checkSum.Append(val);
                checkSum.Append("-");
            }

            return checkSum.Remove(checkSum.Length - 1, 1).ToString();
        }
    }
}