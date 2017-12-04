using System;
using NUnit.Framework;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class Day4Tests
    {
        [Test]
        public void Task1_CorrectCount()
        {
            var sum = Day4.CalculateValidPhrases("Day4_test1.txt", false);

            Assert.That(sum, Is.EqualTo(2));
        }

        [Test]
        public void Task2_CorrectCount()
        {
            var sum = Day4.CalculateValidPhrases("Day4_test2.txt", true);

            Assert.That(sum, Is.EqualTo(3));
        }
    }
}
