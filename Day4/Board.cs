using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day4
{
    public class Board
    {
        public List<List<Field>> Grid { get; set; }

        public void ParseString(string input)
        {
            Grid = input.Split("\n", options: StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Split(" ", options: StringSplitOptions.RemoveEmptyEntries)
                    .Select(
                        n => new Field { Number = int.Parse(n) }
                    ).ToList()
                ).ToList();
        }

        public void Mark(int number)
        {
            Grid.SelectMany(f => f)
                .ToList() // yeah, I know ...
                .ForEach(
                f =>
                {
                    if (f.Number == number)
                        f.IsMarked = f.Number == number;
                }
            );
            System.Console.WriteLine("");
        }

        public bool IsWinning()
        {
            var flippedGrid = new List<List<Field>>();
            for (int i = 0; i < Grid.Count; i++)
            {
                flippedGrid.Add(Grid.Select(l => l[i]).ToList());
            }
            var vertical = flippedGrid.Any(l => l.All(f => f.IsMarked));
            var horizontal = Grid.Any(l => l.All(f => f.IsMarked));
            return vertical || horizontal;
        }

        public int SumOfAllUnmarked()
        {
            return Grid
                .SelectMany(l => l)
                .Where(f => !f.IsMarked)
                .Sum(f => f.Number);
        }
    }
}