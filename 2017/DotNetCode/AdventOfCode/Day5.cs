using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
    public static class Day5
    {
        public static void Run()
        {
            var instructions = GetInput("Day5.txt");
            var validCount = LeaveInstructionList(instructions);

            instructions = GetInput("Day5.txt");
            var validCountTask2 = LeaveInstructionList2(instructions);

            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Count part 1: {validCount}");

            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Count part 2: {validCountTask2}");
        }

        public static int LeaveInstructionList(List<int> instructions, int index = 0)
        {
            var totalCount = 0;
            while (instructions.Count > index)
            {
                totalCount++;
                var instruction = instructions[index];
                instructions[index]++;
                index += instruction;
            }

            return totalCount;
        }

        public static int LeaveInstructionList2(List<int> instructions, int index = 0)
        {
            var totalCount = 0;
            while (instructions.Count > index)
            {
                totalCount++;
                var instruction = instructions[index];
                instructions[index] += instruction >= 3 ? -1 : 1;
                index += instruction;
            }

            return totalCount;
        }

        public static List<int> GetInput(string fileName)
        {
            var input = new List<int>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"AdventOfCode.Inputs.Day5.{fileName}";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    input.Add(int.Parse(reader.ReadLine()));
                }
            }

            return input;
        }
    }
}