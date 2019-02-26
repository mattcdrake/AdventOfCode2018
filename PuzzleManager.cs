using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018
{
    class PuzzleManager
    {
        private readonly Dictionary<int, string> _solutions;

        public PuzzleManager()
        {
            _solutions = new Dictionary<int, string>();

            Day day1 = new Day1();
            _solutions.Add(0, day1.Solution1);
            _solutions.Add(1, day1.Solution2);

            Day day2 = new Day2();
            _solutions.Add(2, day2.Solution1);
            _solutions.Add(3, day2.Solution2);

            Day day3 = new Day3();
            _solutions.Add(4, day3.Solution1);
            _solutions.Add(5, day3.Solution2);
        }

        // Iterates through the solution dictionary and prints day, puzzle, and solution to the console
        public void PrintSolutions()
        {
            Console.WriteLine("Solutions to Advent of Code 2018 Puzzles");
            Console.WriteLine("----------------------------------------");

            for (var i = 0; i < _solutions.Count; i++)
            {
                var day = (i / 2) + 1;
                var puzzle = i % 2 == 0 ? 1 : 2;
                Console.WriteLine("Day " + day + ", Puzzle #" + puzzle + ": " + _solutions[i]);
            }
        }
    }
}
