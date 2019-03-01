using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2018
{
    static class Helpers
    {
        // TODO Add comment
        public static List<string> ParseInputLines(string filePath)
        {
            var outputLines = new List<string>();

            // TODO add error handling for missing file

            // Open a file w/ the given filepath
            var fileStream = File.Open(filePath, FileMode.Open);

            using (var streamReader = new StreamReader(fileStream))
            {
                // Read each line and add it to outputLines
                while (!streamReader.EndOfStream)
                {
                    outputLines.Add(streamReader.ReadLine());
                }
            }
            return outputLines;
        }

        // TODO Add comment
        public static bool HasNDupes(string word, int number)
        {
            if (number < 0)
            {
                return false;
            }

            var foundChars = new Dictionary<char, int>();
            foreach (var c in word)
            {
                if (foundChars.ContainsKey(c))
                {
                    foundChars[c]++;
                }
                else
                {
                    foundChars.Add(c, 1);
                }
            }
            return foundChars.ContainsValue(number);
        }

        // TODO Add comment
        public static int StringDistance(string first, string second)
        {
            if (first.Length != second.Length)
            {
                return -1;
            }

            var distance = 0;

            for (var i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    distance++;
                }
            }
            return distance;
        }

        // TODO Add comment
        public static string StripDifferent(string first, string second)
        {
            var output = "";
            var minSize = Math.Min(first.Length, second.Length);

            for (var i = 0; i < minSize; i++)
            {
                if (first[i] == second[i])
                {
                    output += first[i];
                }
            }
            return output;
        }
    }
}
