using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018CS
{
    internal sealed class Day2 : Day
    {
        public Day2()
        {
            InputLines = Helpers.ParseInputLines("input_data\\day2.txt");
            Solution1 = Solve1();
            Solution2 = Solve2();
        }

        protected override string Solve1()
        {
            var twos = 0;
            var threes = 0;

            foreach (var id in InputLines)
            {
                if (Helpers.HasNDupes(id, 2))
                {
                    twos++;
                }

                if (Helpers.HasNDupes(id, 3))
                {
                    threes++;
                }
            }

            return (twos * threes).ToString();
        }

        protected override string Solve2()
        {
            foreach (var firstWord in InputLines)
            {
                foreach (var secondWord in InputLines)
                {
                    if (Helpers.StringDistance(firstWord, secondWord) == 1)
                    {
                        return Helpers.StripDifferent(firstWord, secondWord);
                    }
                }
            }

            return "Unable to find a solution.";
        }
    }
}
