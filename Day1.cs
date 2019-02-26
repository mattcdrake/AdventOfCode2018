using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Advent2018
{
    internal sealed class Day1 : Day
    {
        public Day1()
        {
            InputLines = Helpers.ParseInputLines("input_data\\day1.txt");
            Solution1 = Solve1();
            Solution2 = Solve2();
        }

        protected override string Solve1()
        {
            var runningTotal = 0;

            foreach (var line in InputLines)
            {
                if (int.TryParse(line, out var number))
                {
                    runningTotal += number;
                }
            }
            return runningTotal.ToString();
        }

        protected override string Solve2()
        {
            var seenValues = new HashSet<int>();
            var runningTotal = 0;
            var i = 0;

            while (true)
            {
                if (int.TryParse(InputLines[i], out var number))
                {
                    runningTotal += number;
                    if (seenValues.Contains(runningTotal))
                    {
                        return runningTotal.ToString();
                    }
                    seenValues.Add(runningTotal);
                }

                // Reset counter to 0 if it's larger than the input array
                if (i >= InputLines.Count - 1)
                {
                    i = 0;
                }
                else
                {
                    ++i;
                }
            }
        }
    }
}
