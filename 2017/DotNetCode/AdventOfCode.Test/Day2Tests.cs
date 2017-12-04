using NUnit.Framework;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void Task1_CorrectSum()
        {
            var sum = Day2.CalculateSum("Day2_1_test1.txt", true);

            Assert.That(sum, Is.EqualTo(18));
        }

        [Test]
        public void Task2_CorrectSum()
        {
            var sum = Day2.CalculateSum("Day2_2_test1.txt", false);

            Assert.That(sum, Is.EqualTo(9));
        }
    }
}
