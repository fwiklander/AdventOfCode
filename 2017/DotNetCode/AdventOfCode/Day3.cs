using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode
{
    public class Day3
    {
        public static Dictionary<Point, int> ValueMap { get; set; }

        public static void Run()
        {
            var sum = CalculateManhattanDistance(265149);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Distance: {sum}");

            var nPlusOne = CalculateNPlus1(265149);
            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Number after N: {nPlusOne}");
        }

        public static int CalculateNPlus1(int theN)
        {
            var currentPos = new Point(0, 0);
            var valueMap = new Dictionary<Point, int> { { currentPos, 1 } };

            var offset = new Point(1, 0);
            int currentVal;
            do
            {
                currentPos.Offset(offset);
                var pointBehind = new Point(currentPos.X - offset.X, currentPos.Y - offset.Y);
                var pointInner = new Point(currentPos.X - offset.Y, currentPos.Y + offset.X);
                var pointInnerBehind = new Point(pointInner.X - offset.X, pointInner.Y - offset.Y);
                var pointInnerAhead = new Point(pointInner.X + offset.X, pointInner.Y + offset.Y);

                valueMap.TryGetValue(pointBehind, out int valueBehind);
                valueMap.TryGetValue(pointInner, out int valueInner);
                valueMap.TryGetValue(pointInnerBehind, out int valueInnerBehind);
                valueMap.TryGetValue(pointInnerAhead, out int valueInnerAhead);

                currentVal = valueBehind + valueInner + valueInnerBehind + valueInnerAhead;

                valueMap.Add(currentPos, currentVal);

                if (!valueMap.ContainsKey(new Point(currentPos.X - offset.Y, currentPos.Y + offset.X)))
                {
                    offset = new Point(-offset.Y, offset.X);
                }
            } while (currentVal <= theN);

            ValueMap = valueMap;
            return currentVal;
        }

        public static int CalculateManhattanDistance(int memoryValue)
        {
            var ring = (int)Math.Ceiling(Math.Sqrt(memoryValue));
            if (ring % 2 == 0)
            {
                ring++;
            }

            var upperBound = ring * ring;
            var ringSteps = (ring - 1) / 2;
            var lowerBound = upperBound - (ring - 1);
            for (var i = 0; i < 4; i++)
            {
                if (lowerBound <= memoryValue)
                {
                    var columnSteps = Math.Abs(upperBound - ringSteps - memoryValue);
                    return ringSteps + columnSteps;
                }

                upperBound = lowerBound;
                lowerBound = upperBound - (ring - 1);
            }

            return -100;
        }
    }
}
