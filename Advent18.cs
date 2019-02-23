using System;
using System.IO;

namespace Advent2018CS
{
    class Advent18
    {
        static void Main(string[] args)
        {
            PuzzleManager puzzleManager = new PuzzleManager();
            puzzleManager.PrintSolutions();

            /*
            FileStream fileStream = File.Open("input_data\\day1.txt", FileMode.Open);
            using (var streamReader = new StreamReader(fileStream))
            {
                while (!streamReader.EndOfStream)
                {
                    Console.WriteLine(streamReader.ReadLine());
                }
            }
            */
        }
    }
}
