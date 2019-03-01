using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    public class PuzzleManager
    {
        public readonly Dictionary<int, string> Solutions;

        public PuzzleManager()
        {
            Solutions = new Dictionary<int, string>();

            Day day1 = new Day1();
            Solutions.Add(0, day1.Solution1);
            Solutions.Add(1, day1.Solution2);

            Day day2 = new Day2();
            Solutions.Add(2, day2.Solution1);
            Solutions.Add(3, day2.Solution2);

            Day day3 = new Day3();
            Solutions.Add(4, day3.Solution1);
            Solutions.Add(5, day3.Solution2);

            Day day4 = new Day4();
            Solutions.Add(6, day4.Solution1);
            Solutions.Add(7, day4.Solution2);
        }

        // Iterates through the solution dictionary and prints day, puzzle, and solution to the console
        public void PrintSolutions()
        {
            Console.WriteLine("Solutions to Advent of Code 2018 Puzzles");
            Console.WriteLine("----------------------------------------");

            for (var i = 0; i < Solutions.Count; i++)
            {
                var day = (i / 2) + 1;
                var puzzle = i % 2 == 0 ? 1 : 2;
                Console.WriteLine("Day " + day + ", Puzzle #" + puzzle + ": " + Solutions[i]);
            }
        }
    }
}
