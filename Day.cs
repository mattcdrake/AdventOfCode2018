using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018CS
{
    abstract class Day
    {
        public string solution1 { get; private set; }
        public string solution2 { get; private set; }

        public Day()
        {
            solution1 = this.solve1();
            solution2 = this.solve2();
        }

        protected abstract string solve1();
        protected abstract string solve2();
    }
}
