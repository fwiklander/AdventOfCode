using NUnit.Framework;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class Day8Tests
    {
        [Test]
        public void Task1And2_Test1()
        {
            var input = Day8.GetInput("Day8_test1.txt");
            var maxValues = Day8.CalculateMaxValue(input);
            
            Assert.That(maxValues.Item1, Is.EqualTo(1));
            Assert.That(maxValues.Item2, Is.EqualTo(10));
        }
    }
}