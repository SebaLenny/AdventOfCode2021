using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        const string inputPath = "input.txt";

        static string ReadInput(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        static void Main(string[] args)
        {
            var input = ReadInput(inputPath);

            var bingoSubsystem = new BingoSubsystem();
            bingoSubsystem.ParseInput(input);

            var partOneSolution = bingoSubsystem.PartOneSolution();
            System.Console.WriteLine($"Part one answer is: {partOneSolution}");
        }
    }
}
