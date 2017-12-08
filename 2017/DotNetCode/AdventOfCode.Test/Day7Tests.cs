using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class Day7Tests
    {
        [Test]
        public void Task1_Test1()
        {
            var input = Day7.GetInput("Day7_test1.txt");
            var allPrograms = Day7.CalculateRecursionTree(input);

            var bottomProgram = Day7.FindBottomProgram(allPrograms);
            Assert.That(bottomProgram, Is.Not.Null);
            Assert.That(bottomProgram.Name, Is.EqualTo("tknk"));
        }

        [Test]
        public void Task2_Test1()
        {
            var input = Day7.GetInput("Day7_test1.txt");
            var allPrograms = Day7.CalculateRecursionTree(input);
            var neededWeight = Day7.GetSortedRecursionTree(allPrograms);

            Assert.That(neededWeight, Is.EqualTo(60));

            /*var bottomProgram = Day7.FindBottomProgram(allPrograms);
            Assert.That(bottomProgram, Is.Not.Null);
            Assert.That(bottomProgram.Name, Is.EqualTo("tknk"));*/
        }

        [Test]
        public void Task2_test2()
        {
            var input = Day7.GetInput("Day7.txt");
            var allPrograms = Day7.CalculateRecursionTree(input);
            var unbalance = Day7.CalculateLevelUnbalance(allPrograms);
        }

        [Test]
        public void Dummytest()
        {
            var topShit = new List<string>();
            var lowershit = new List<string>();
            var rowHist = new List<int>();
            var input = Day7.GetInput("Day7.txt");
            foreach (var line in input)
            {
                rowHist.Add(line.Split(',').Length);
                if (line.Contains("->"))
                {
                    lowershit.Add(line);
                }
                else
                {
                    topShit.Add(line);
                }
            }
            var zero = rowHist.Count(x => x == 0);
            var topRow = rowHist.Count(x => x == 1);
            var two = rowHist.Count(x => x == 2);
            var three = rowHist.Count(x => x == 3);
            var four = rowHist.Count(x => x == 4);
            var five = rowHist.Count(x => x == 5);
            var six = rowHist.Count(x => x == 6);
            var seven = rowHist.Count(x => x == 7);
            var eight = rowHist.Count(x => x == 8);
            var nine = rowHist.Count(x => x == 9);
            var ten = rowHist.Count(x => x == 10);

            var tot = zero + topRow + two + three + four + five + six + seven + eight + nine + ten;
        }
    }
}