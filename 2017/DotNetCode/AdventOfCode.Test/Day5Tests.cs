using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode.Test
{
    public class Day5Tests
    {
        [Test]
        public void Task1_CountExitSteps()
        {
            var input = new List<int> { 0, 3, 0, 1, -3 };
            var stepsNeeded = Day5.LeaveInstructionList(input);
            Assert.That(stepsNeeded, Is.EqualTo(5));
        }

        [Test]
        public void Task1_CountExitSteps1()
        {
            var input = new List<int> { 1 };
            var stepsNeeded = Day5.LeaveInstructionList(input);
            Assert.That(stepsNeeded, Is.EqualTo(1));
        }

        [Test]
        public void Task1_CountExitSteps2()
        {
            var input = new List<int> { 0 };
            var stepsNeeded = Day5.LeaveInstructionList(input);
            Assert.That(stepsNeeded, Is.EqualTo(2));
        }

        [Test]
        public void Task2_CountExitSteps0()
        {
            var input = new List<int> { 0, 3, 0, 1, -3 };
            var stepsNeeded = Day5.LeaveInstructionList2(input);
            Assert.That(stepsNeeded, Is.EqualTo(10));
        }
    }
}