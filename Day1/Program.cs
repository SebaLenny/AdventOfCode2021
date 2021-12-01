using System.Linq;
using System.Collections.Generic;
using System;

namespace Day1
{
    class Program
    {
        static List<int> PrepareInputNumbers(string path)
        {
            return System.IO.File.ReadAllLines("input.txt")
                .Select(line => int.Parse(line))
                .ToList();
        }

        static int CountIncreases(List<int> numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] < numbers[i + 1]) count += 1;
            }
            return count;
        }

        static List<int> PrepareSlidingSums(List<int> numbers, int windowSize)
        {
            var sums = new List<int>();
            for (int i = 0; i < numbers.Count - windowSize + 1; i++)
            {
                sums.Add(numbers.Skip(i).Take(windowSize).Sum());
            }
            return sums;
        }

        const string inputPath = "input.txt";
        const int windowSize = 3;

        static void Main(string[] args)
        {
            var inputLines = PrepareInputNumbers(inputPath);
            var partOne = CountIncreases(inputLines);
            System.Console.WriteLine($"Part One answer is: {partOne} increases");
            var partTwo = CountIncreases(PrepareSlidingSums(inputLines, windowSize));
            System.Console.WriteLine($"Part Two answer is: {partTwo} increases");
        }
    }
}
