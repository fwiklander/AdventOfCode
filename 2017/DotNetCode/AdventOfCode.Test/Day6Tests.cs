using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class Day6Tests
    {
        [Test]
        public void Task1_Test1()
        {
            var input = new List<int> { 0, 2, 7, 0 };
            var loopSteps = Day6.CalculateInfiniteLoop(input);
            Assert.That(loopSteps, Is.EqualTo(5));
        }

        [Test]
        public void Task2_Test1()
        {
            var input = new List<int> { 0, 2, 7, 0 };
            var loopSteps = Day6.CalculateInfiniteLoopLength(input);
            Assert.That(loopSteps, Is.EqualTo(4));
        }
    }
}