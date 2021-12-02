using System.Linq;
using System.Collections.Generic;
using System;

namespace Day2
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
            var instructions = inputLines.Select(l => new Instruction(l)).ToList();

            var boat = new Boat();
            boat.BoatStrategy = new PartOneBoatStrategy();
            boat.ApplyInstructions(instructions);
            var answ = boat.VerticalPosition * boat.HorizontalPosition;
            Console.WriteLine($"Answer to part 1 is: {answ}");

            boat.BoatStrategy = new PartTwoBoatStrategy();
            boat.ResetPosition();
            boat.ApplyInstructions(instructions);
            var answTwo = boat.VerticalPosition * boat.HorizontalPosition;
            Console.WriteLine($"Answer to part 1 is: {answTwo}");
        }
    }
}
