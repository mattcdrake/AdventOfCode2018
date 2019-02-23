using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018CS
{
    class PuzzleManager
    {
        private Dictionary<int, string> solutions;

        public PuzzleManager()
        {
            solutions = new Dictionary<int, string>();

            Day day1 = new Day1();
            solutions.Add(0, day1.solution1);
            solutions.Add(1, day1.solution2);
        }

        // Iterates through the solution dictionary and prints day, puzzle, and solution to the console
        public void PrintSolutions()
        {
            Console.WriteLine("Solutions to Advent of Code 2018 Puzzles");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < solutions.Count; i++)
            {
                int day = (i / 2) + 1;
                int puzzle = i % 2 == 0 ? 1 : 2;
                Console.WriteLine("Day " + day + ", Puzzle #" + puzzle + ": " + solutions[i]);
            }
        }
    }
}
