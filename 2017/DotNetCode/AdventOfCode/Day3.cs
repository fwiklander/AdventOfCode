using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode
{
    public class Day3 : IDay
    {
        public void Run()
        {
            var sum = CalculateManhattanDistance(265149);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Sum part 1: {sum}");

            var nPlusOne = CalculateNPlus1(265149);
            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Sum part 2: {nPlusOne}");
        }

        public static int CalculateNPlus1(int theN)
        {
            var currentPos = new Point(0, 0);
            var nextPos = new Point(1, 0);
            var valueMap = new Dictionary<Point, int> { { currentPos, 1 } };

            var offset = new Point(1, 0);
            int stepCount = 1, currentStepLength = 1;

            int currentVal = 1;
            do
            {
                currentPos.Offset(offset);
                stepCount--;
                Point pointBehind, pointInner, pointInnerBehind, pointInnerAhead;
                if (offset.X > 0)
                {
                    pointBehind = new Point(currentPos.X - 1, currentPos.Y);
                    pointInner = new Point(currentPos.X, currentPos.Y + 1);
                    pointInnerBehind = new Point(pointInner.X - 1, pointInner.Y);
                    pointInnerAhead = new Point(pointInner.X + 1, pointInner.Y);

                    if (stepCount == 0)
                    {
                        offset = new Point(0, 1);
                    }
                }
                else if (offset.Y > 0)
                {
                    pointBehind = new Point(currentPos.X, currentPos.Y - 1);
                    pointInner = new Point(currentPos.X - 1, currentPos.Y);
                    pointInnerBehind = new Point(pointInner.X, pointInner.Y - 1);
                    pointInnerAhead = new Point(pointInner.X, pointInner.Y + 1);

                    if (stepCount == 0)
                    {
                        currentStepLength++;
                        offset = new Point(-1, 0);
                    }
                }
                else if (offset.X < 0)
                {
                    pointBehind = new Point(currentPos.X + 1, currentPos.Y);
                    pointInner = new Point(currentPos.X, currentPos.Y - 1);
                    pointInnerBehind = new Point(pointInner.X + 1, pointInner.Y);
                    pointInnerAhead = new Point(pointInner.X - 1, pointInner.Y);

                    if (stepCount == 0)
                    {
                        offset = new Point(0, -1);
                    }
                }
                else // if (offset.Y < 0)
                {
                    pointBehind = new Point(currentPos.X, currentPos.Y + 1);
                    pointInner = new Point(currentPos.X + 1, currentPos.Y);
                    pointInnerBehind = new Point(pointInner.X, pointInner.Y + 1);
                    pointInnerAhead = new Point(pointInner.X, pointInner.Y - 1);

                    if (stepCount == 0)
                    {
                        currentStepLength++;
                        offset = new Point(1, 0);
                    }
                }

                valueMap.TryGetValue(pointBehind, out int valueBehind);
                valueMap.TryGetValue(pointInner, out int valueInner);
                valueMap.TryGetValue(pointInnerBehind, out int valueInnerBehind);
                valueMap.TryGetValue(pointInnerAhead, out int valueInnerAhead);

                var pointSum = valueBehind + valueInner + valueInnerBehind + valueInnerAhead;

                valueMap.Add(currentPos, pointSum);

                if (stepCount == 0)
                    stepCount = currentStepLength;

                currentVal = pointSum;
                //currentVal++;
            } while (currentVal <= theN);

            return currentVal;
        }

        public static int CalculateManhattanDistance(int memoryValue)
        {
            var ring = 1;
            var upperBound = 1;
            while (upperBound < memoryValue)
            {
                ring += 2;
                upperBound = ring * ring;
            }

            var ringSteps = (ring - 1) / 2;

            var lowerBound = upperBound - (ring - 1);
            for (int i = 0; i < 4; i++)
            {
                if (lowerBound <= memoryValue)
                {
                    var columnSteps = Math.Abs(upperBound - (ring - 1) / 2 - memoryValue);
                    return ringSteps + columnSteps;
                }

                upperBound = lowerBound;
                lowerBound = upperBound - (ring - 1);
            }

            return -100;
        }
    }
}
