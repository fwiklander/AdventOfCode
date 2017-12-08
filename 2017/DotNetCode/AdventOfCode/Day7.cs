using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public class Day7
    {
        public static void Run()
        {
            var input = GetInput("Day7.txt").ToList();
            var allPrograms = CalculateRecursionTree(input);
            var bottomProgram = FindBottomProgram(allPrograms);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Bottom program: {bottomProgram.Name}");

            ////allPrograms = CalculateRecursionTree(input);
            ////var balancedWeight = GetSortedRecursionTree(allPrograms);

            ////SortTheTree(allPrograms);

            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            //Console.WriteLine($"Balanced weight: {balancedWeight}");
        }

        public static Dictionary<string, RecursionProgram> CalculateRecursionTree(IEnumerable<string> input)
        {
            var allPrograms = new Dictionary<string, RecursionProgram>();
            foreach (var serializedInput in input)
            {
                var strippedInput = serializedInput.Replace(" ", string.Empty).Replace(">", string.Empty);
                var thisAndAbove = strippedInput.Split('-');
                GetNameAndWeight(thisAndAbove[0], out var name, out var weight);

                var program = new RecursionProgram
                {
                    Name = name,
                    Weight = weight,
                    CombinedWeight = weight,
                    ProgramsAbove = thisAndAbove.Length == 1 ? null : thisAndAbove[1]?.Split(',').Select(x => x)
                };

                allPrograms.Add(program.Name, program);
            }

            foreach (var recursionProgram in allPrograms.Values)
            {
                var programBelow = allPrograms.Values.SingleOrDefault(x => x.ProgramsAbove?.SingleOrDefault(y => y.Equals(recursionProgram.Name)) != null);
                if (programBelow != null)
                {
                    recursionProgram.ProgramBelow = programBelow;
                }
            }

            return allPrograms;
        }

        public static int GetSortedRecursionTree(Dictionary<string, RecursionProgram> unsortedTree)
        {
            var sortedTree = new Dictionary<int, List<RecursionProgram>>();
            GetTopLevel(unsortedTree, sortedTree);
            SortTheTree(unsortedTree, sortedTree);

            return GetUnbalancedProgramWeight(sortedTree);
        }

        private static int CalculateCombinedWeights(IDictionary<string, RecursionProgram> allPrograms, RecursionProgram program, int treeLevel = 0)
        {
            foreach (var programAboveName in program.ProgramsAbove ?? new List<string>())
            {
                var programAbove = allPrograms[programAboveName];
                program.CombinedWeight += CalculateCombinedWeights(allPrograms, programAbove, treeLevel + 1);
            }

            return program.CombinedWeight;
        }

        public static int CalculateLevelUnbalance(Dictionary<string, RecursionProgram> allPrograms)
        {
            var unbalance = 0;
            var nextIteration = allPrograms.Values.Where(x => x.ProgramsAbove == null).ToList();
            while (unbalance == 0)
            {
                var programs = new List<RecursionProgram>();
                foreach (var program in nextIteration)
                {
                    program.ProgramBelow.CombinedWeight += program.CombinedWeight;
                    if (!programs.Contains(program.ProgramBelow))
                    {
                        programs.Add(program.ProgramBelow);
                    }
                }

                var min = programs.Min(x => x.CombinedWeight);
                var max = programs.Max(x => x.CombinedWeight);
                unbalance = max - min;

                nextIteration = programs;
            }

            ////unbalance = bottomProgram.ProgramsAbove.Max(x => x.)
            /*while (unbalance == 0)
            {
                // Recurse the shit out of it

            }*/

            return unbalance;
        }

        private static int GetUnbalancedProgramWeight(Dictionary<int, List<RecursionProgram>> sortedTree)
        {
            for (var i = 1; i <= sortedTree.Keys.Max(); i++)
            {
                var treeLine = sortedTree[i];
                var max = treeLine.Max(x => x.CombinedWeight);
                var min = treeLine.Min(x => x.CombinedWeight);
                var unbalance = max - min;
                if (unbalance != 0)
                {
                    if (treeLine.Count(x => x.CombinedWeight == max) == 1)
                    {
                        var unbalancedProgram = treeLine.Single(x => x.CombinedWeight == max);
                        return unbalancedProgram.Weight - unbalance;
                    }
                    else
                    {
                        var unbalancedProgram = treeLine.Single(x => x.CombinedWeight == min);
                        return unbalancedProgram.Weight + unbalance;
                    }
                }
            }

            return 0;
        }

        public static void SortTheTreeUpwards(Dictionary<string, RecursionProgram> allPrograms)
        {
            var treeLevel = 0;
            var sortedTree = new Dictionary<int, List<RecursionProgram>>();
            var bottomProgram = FindBottomProgram(allPrograms);
            sortedTree.Add(treeLevel, new List<RecursionProgram> { bottomProgram });

            CalculateCombinedWeight(bottomProgram);
        }

        private static int CalculateCombinedWeight(RecursionProgram program)
        {
            foreach (var programName in program.ProgramsAbove)
            {
                
            }

            return 0;
        }

        private static void SortTheTree(IDictionary<string, RecursionProgram> unsortedTree, IDictionary<int, List<RecursionProgram>> sortedTree)
        {
            var treeLevel = 1;
            RecursionProgram lastProgramOnLevel = null;
            do
            {
                var previousLevel = sortedTree[treeLevel - 1];
                var thisLevel = new List<RecursionProgram>();
                sortedTree.Add(treeLevel, thisLevel);
                foreach (var recursionProgram in previousLevel)
                {
                    lastProgramOnLevel = recursionProgram.ProgramBelow;
                    if (!sortedTree[treeLevel].Contains(lastProgramOnLevel))
                    {
                        thisLevel.Add(recursionProgram.ProgramBelow);
                    }

                    lastProgramOnLevel.CombinedWeight += recursionProgram.CombinedWeight;
                }

                treeLevel++;
            } while (lastProgramOnLevel?.ProgramBelow != null);
        }

        private static void GetTopLevel(IDictionary<string, RecursionProgram> unsortedTree, IDictionary<int, List<RecursionProgram>> sortedTree)
        {
            var sortedList = unsortedTree.Values.Where(unsortedProgram => unsortedProgram.ProgramsAbove == null).ToList();
            sortedTree.Add(0, sortedList);
        }

        private static void GetNameAndWeight(string nameAndWeight, out string name, out int weight)
        {
            name = nameAndWeight.Substring(0, nameAndWeight.IndexOf('(')).Trim();
            var weightString = nameAndWeight.Substring(nameAndWeight.IndexOf('(') + 1, nameAndWeight.IndexOf(')') - nameAndWeight.IndexOf('(') - 1);
            weight = int.Parse(weightString);
        }

        public static IEnumerable<string> GetInput(string filename)
        {
            var input = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"AdventOfCode.Inputs.Day7.{filename}";
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

        public static RecursionProgram FindBottomProgram(Dictionary<string, RecursionProgram> allPrograms)
        {
            return allPrograms.Values.SingleOrDefault(program => program.ProgramBelow == null);
        }
    }

    public class RecursionProgram
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int CombinedWeight { get; set; }

        public IEnumerable<string> ProgramsAbove { get; set; }

        public RecursionProgram ProgramBelow { get; set; }
    }
}