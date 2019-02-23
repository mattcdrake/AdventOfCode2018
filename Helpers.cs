using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent2018CS
{
    static class Helpers
    {
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
    }
}
