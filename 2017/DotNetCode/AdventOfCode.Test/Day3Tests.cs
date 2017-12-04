using System;
using NUnit.Framework;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class Day3Tests
    {
        [Test]
        public void Task1_CorrectSum()
        {
            var sum = Day3.CalculateManhattanDistance(8);

            Assert.That(sum, Is.EqualTo(1));
        }

        [Test]
        public void Task1_CorrectSum2()
        {
            var sum = Day3.CalculateManhattanDistance(21);

            Assert.That(sum, Is.EqualTo(4));
        }

        [Test]
        public void Task1_CorrectSum3()
        {
            var sum = Day3.CalculateManhattanDistance(17);

            Assert.That(sum, Is.EqualTo(4));
        }

        [Test]
        public void Task1_CorrectSum4()
        {
            var sum = Day3.CalculateManhattanDistance(12);

            Assert.That(sum, Is.EqualTo(3));
        }

        [Test]
        public void Task2_CorrectSum1()
        {
            var val = Day3.CalculateNPlus1(23);

            Assert.That(val, Is.EqualTo(25));
        }
    }
}
