using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public class Day4 : IDay
    {
        public void Run()
        {
            var validCount = CalculateValidPhrases("Day4.txt", false);
            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Valid pass phrases part 1: {validCount}");

            validCount = CalculateValidPhrases("Day4.txt", true);
            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Sum part 2: {validCount}");
        }

        public static int CalculateValidPhrases(string filename, bool advancedSecurity)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"AdventOfCode.Inputs.Day4.{filename}";

            var validPhrases = 0;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    validPhrases += IsPhraseValid(reader.ReadLine(), advancedSecurity);
                }
            }

            return validPhrases;
        }

        private static int IsPhraseValid(string passphrase, bool isAdvanced)
        {
            try
            {
                var keyValue = passphrase.Split('\t', ' ').ToDictionary(x => x);
                if (isAdvanced)
                {
                    var words = keyValue.Keys.ToList();
                    foreach (var word in words)
                    {
                        var wordChars = word.ToCharArray();
                        Array.Sort(wordChars);
                        var wordStringSorted = new string(wordChars);
                        foreach (var toCheck in words)
                        {
                            if (word.Equals(toCheck))
                                continue;

                            var toCheckChars = toCheck.ToCharArray();

                            Array.Sort(toCheckChars);

                            if (wordStringSorted.Equals(new string(toCheckChars)))
                            {
                                return 0;
                            }
                        }
                    }
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
