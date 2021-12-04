using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    class Program
    {
        const string inputPath = "input.txt";

        static List<string> ReadInput(string path)
        {
            return System.IO.File.ReadAllLines(path)
                .ToList();
        }

        static void Main(string[] args)
        {
            var inputLines = ReadInput(inputPath);

            var report = ReportAnalyzer.Analyze(inputLines);

            System.Console.WriteLine($"Part 1 answer is: {report.PowerConsumption}");

            System.Console.WriteLine($"Part 2 answer is: {report.LifeSupportRating}");
        }
    }
}

