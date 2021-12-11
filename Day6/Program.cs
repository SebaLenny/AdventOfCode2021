using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Program
    {
        const string inputPath = "input.txt";

        static List<byte> ReadInput(string path)
        {
            return System.IO.File.ReadAllText(path)
                .Split(",")
                .Select(n => byte.Parse(n))
                .ToList();
        }

        static void Main(string[] args)
        {
            var numbers = ReadInput(inputPath);

            var fishSimulator = new FishSimulator(numbers, 80);
            fishSimulator.IterateDays();
            Console.WriteLine($"Answer for Part 1 is: {fishSimulator.LastDayCount}");

            var fishSimulatorForever = new FishSimulator(numbers, 256);
            fishSimulatorForever.IterateDays();
            Console.WriteLine($"Answer for Part 2 is: {fishSimulatorForever.LastDayCount}");
        }
    }
}
