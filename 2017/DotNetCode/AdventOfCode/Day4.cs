﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public class Day4
    {
        public static void Run()
        {
            var passphrases = GetPassphrases("Day4.txt");
            var validCount = CalculateValidPhrases(passphrases, false);
            var validCountAdvanced = CalculateValidPhrases(passphrases, true);

            Console.WriteLine("----- Part 1 -----");
            Console.WriteLine($"Valid pass phrases: {validCount}");

            Console.WriteLine();
            Console.WriteLine("----- Part 2 -----");
            Console.WriteLine($"Valid pass phrases: {validCountAdvanced}");
        }

        public static string[] GetPassphrases(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"AdventOfCode.Inputs.Day4.{filename}";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static int CalculateValidPhrases(IEnumerable<string> passphrases, bool advancedSecurity)
        {
            var validPhrases = passphrases.Sum(passphrase => IsPhraseValid(passphrase, advancedSecurity));
            return validPhrases;
        }

        private static int IsPhraseValid(string passphrase, bool isAdvanced)
        {
            var words = passphrase.Split('\t', ' ').ToList();
            var startIndex = 1;
            foreach (var word in words)
            {
                var wordChars = word.ToCharArray();
                if (isAdvanced) Array.Sort(wordChars);
                var wordStringSorted = new string(wordChars);
                for (var i = startIndex; i < words.Count; i++)
                {
                    var toCheckChars = words[i].ToCharArray();
                    if (isAdvanced) Array.Sort(toCheckChars);
                    if (wordStringSorted.Equals(new string(toCheckChars)))
                    {
                        return 0;
                    }
                }

                startIndex++;
            }

            return 1;
        }
    }
}
