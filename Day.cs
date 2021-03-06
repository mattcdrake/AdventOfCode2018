﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    abstract class Day
    {
        public List<string> InputLines { get; protected set; }
        public string Solution1 { get; protected set; }
        public string Solution2 { get; protected set; }

        protected abstract string Solve1();
        protected abstract string Solve2();
    }
}
