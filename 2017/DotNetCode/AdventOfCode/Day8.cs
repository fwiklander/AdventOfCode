using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public class Day8
    {
        public static void Run()
        {

            var instructions = GetInput("Day8.txt");
            var values = CalculateMaxValue(instructions);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Max value: {values.Item1}");
            
            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Balanced weight: {values.Item2}");
        }

        public static Tuple<int, int> CalculateMaxValue(List<string> instructions)
        {
            var registers = GetUniqueRegisters(instructions);
            var maxValueOfAnyInstruction = 0;
            foreach (var instruction in instructions)
            {
                if (ShouldMoveRegisterValue(registers, instruction))
                {
                    MoveRegisterValue(registers, instruction);
                    maxValueOfAnyInstruction = Math.Max(maxValueOfAnyInstruction, registers.Values.Max());
                }
            }

            var maxValue = registers.Values.Max();
            return Tuple.Create(maxValue, maxValueOfAnyInstruction);
        }

        private static void MoveRegisterValue(Dictionary<string, int> registers, string instruction)
        {
            var registerToMove = GetRegister(instruction);
            var direction = GetDirection(instruction);
            var moves = GetMoves(instruction);

            registers[registerToMove] += direction * moves;
        }

        private static int GetMoves(string instruction)
        {
            return int.Parse(instruction.Split(' ')[2]);
        }

        private static int GetDirection(string instruction)
        {
            return instruction.Split(' ')[1].Equals("inc") ? 1 : -1;
        }

        private static bool ShouldMoveRegisterValue(Dictionary<string, int> registers, string instruction)
        {
            if (!instruction.Contains("if"))
                return true;

            var instructionParts = instruction.Split(' ');
            var registerToCheck = registers[instructionParts[4]];
            var compareValue = int.Parse(instructionParts[6]);
            switch (instructionParts[5])
            {
                case "<":
                    return registerToCheck < compareValue;
                case ">":
                    return registerToCheck > compareValue;
                case ">=":
                    return registerToCheck >= compareValue;
                case "<=":
                    return registerToCheck <= compareValue;
                case "==":
                    return registerToCheck == compareValue;
                case "!=":
                    return registerToCheck != compareValue;
            }

            return false;
        }

        private static Dictionary<string, int> GetUniqueRegisters(IEnumerable<string> instructions)
        {
            var registers = new Dictionary<string, int>();
            foreach (var instruction in instructions)
            {
                var registerName = GetRegister(instruction);
                if (!registers.ContainsKey(registerName))
                {
                    registers.Add(registerName, 0);
                }
            }

            return registers;
        }

        private static string GetRegister(string instruction)
        {
            return instruction.Substring(0, instruction.IndexOf(" ", StringComparison.InvariantCulture));
        }

        public static List<string> GetInput(string filename)
        {
            var input = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"AdventOfCode.Inputs.Day8.{filename}";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    input.Add(reader.ReadLine());
                }
            }

            return input;
        }
    }
}