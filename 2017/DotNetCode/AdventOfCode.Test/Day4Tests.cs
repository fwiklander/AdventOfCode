using NUnit.Framework;

namespace AdventOfCode.Test
{
    [TestFixture]
    public class Day4Tests
    {
        [Test]
        public void Task1_CorrectCount()
        {
            var passphrases = Day4.GetPassphrases("Day4_test1.txt");
            var sum = Day4.CalculateValidPhrases(passphrases, false);

            Assert.That(sum, Is.EqualTo(2));
        }

        [Test]
        public void Task2_CorrectCount()
        {
            var passphrases = Day4.GetPassphrases("Day4_test1.txt");
            var sum = Day4.CalculateValidPhrases(passphrases, true);

            Assert.That(sum, Is.EqualTo(3));
        }
    }
}
