using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018
{
    internal sealed class Day5 : Day
    {
        public Day5()
        {
            InputLines = Helpers.ParseInputLines("input_data\\day5.txt");
            Solution1 = Solve1();
            Solution2 = Solve2();
        }

        protected override string Solve1()
        {

            return ReactPolymer(InputLines[0]).ToString();
        }

        protected override string Solve2()
        {
            List<int> lengths = new List<int>();
            for (var i = 65; i < 91; i++)
            {
                var lower = ((char) i).ToString();
                var upper = ((char) (i + 32)).ToString();

                // Strips lower & upper case character from input polymer
                var inString = InputLines[0].Replace(lower, "").Replace(upper, "");

                lengths.Add(ReactPolymer(inString));
            }

            return lengths.Min().ToString();
        }

        private static int ReactPolymer(string polymer)
        {
            var charStack = new Stack<char>();
            foreach (var c in polymer)
            {
                if (charStack.Count == 0)
                {
                    charStack.Push(c);
                    continue;
                }

                var top = charStack.Peek();

                if (((char.ToUpper(c) == top) || (char.ToLower(c) == top)) && (c != top))
                {
                    charStack.Pop();
                }
                else
                {
                    charStack.Push(c);
                }
            }

            return charStack.Count;
        }
    }
}
