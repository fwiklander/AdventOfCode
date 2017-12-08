using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
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
        public void Task1_CorrectSum5()
        {
            var sum = Day3.CalculateManhattanDistance(7);

            Assert.That(sum, Is.EqualTo(2));
        }

        [Test]
        public void Task1_CorrectSum6()
        {
            var sum = Day3.CalculateManhattanDistance(25);

            Assert.That(sum, Is.EqualTo(4));
        }

        [Test]
        public void Task1_CorrectSum7()
        {
            var sum = Day3.CalculateManhattanDistance(24);

            Assert.That(sum, Is.EqualTo(3));
        }

        [Test, Explicit]
        public void Task1_Pontus()
        {
            ////var sum = Day3.CalculateManhattanDistance(361527);
            var sum = Day3.CalculateManhattanDistance(204);
            Console.Write($"Antal steg för Pontus: {sum}");
        }

        [Test]
        public void Task2_CorrectSum1()
        {
            var val = Day3.CalculateNPlus1(23);

            Assert.That(val, Is.EqualTo(25));
        }

        [Test, Explicit]
        public void Task1_PrintMatrix()
        {
            //int.MaxValue   =   2147483647
            Day3.CalculateNPlus1(265149);
            //Day3.CalculateNPlus1(806);
            GetOuterCorners(out var lowerLeft, out var upperRight);

            var stringWriter = new StringWriter();
            using (var writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag("html");
                writer.RenderBeginTag("head");
                writer.RenderBeginTag(HtmlTextWriterTag.Style);
                writer.Write(".value { display: inline-block; width: 65px; height: 65px; background: blue; color: white; font-size: 14pt; }");
                writer.RenderEndTag();
                writer.RenderEndTag();

                writer.RenderBeginTag("body");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                int x = lowerLeft.X, y = upperRight.Y;
                while (y >= lowerLeft.Y)
                {
                    while (x <= upperRight.X)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "value");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        if (Day3.ValueMap.ContainsKey(new Point(x, y)))
                        {
                            writer.Write(Day3.ValueMap[new Point(x, y)]);
                        }
                        else
                        {
                            writer.Write("&nbsp;");
                        }
                        writer.RenderEndTag();
                        x++;
                    }

                    writer.Write("<br/>");
                    x = lowerLeft.X;
                    y--;
                }

                writer.RenderEndTag();
                writer.RenderEndTag();
                writer.RenderEndTag();
            }

            // Return the result.
            var temp = stringWriter.ToString();
            File.WriteAllText("C:\\Users\\frwi20\\Desktop\\valueMatrix.htm", temp);
        }

        private static void GetOuterCorners(out Point lowerLeft, out Point upperRight)
        {
            lowerLeft = new Point(int.MaxValue, int.MaxValue);
            upperRight = new Point(int.MinValue, int.MinValue);
            foreach (var valueMapKey in Day3.ValueMap.Keys)
            {
                upperRight.X = Math.Max(upperRight.X, valueMapKey.X);
                upperRight.Y = Math.Max(upperRight.Y, valueMapKey.Y);
                lowerLeft.X = Math.Min(lowerLeft.X, valueMapKey.X);
                lowerLeft.Y = Math.Min(lowerLeft.Y, valueMapKey.Y);
            }
        }
    }
}
