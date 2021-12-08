using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    class Program
    {
        const string inputPath = "test_input.txt";

        static List<string> ReadInput(string path)
        {
            return System.IO.File.ReadAllLines(path).ToList();
        }

        static void Main(string[] args)
        {
            var map = new HydrothermalMap();
            map.AddParseList(ReadInput(inputPath));
            System.Console.WriteLine(map.OverlapCountNoDiagonal.Values.Where(v => v > 1).Count());
            System.Console.WriteLine(map.OverlapCount.Values.Where(v => v > 1).Count());
        }
    }
}
