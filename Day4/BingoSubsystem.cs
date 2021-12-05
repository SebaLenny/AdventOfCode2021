using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day4
{
    public class BingoSubsystem
    {
        private List<int> Numbers { get; set; }
        private List<Board> Boards { get; set; }
        private int CurrentIteration { get; set; }

        public void ParseInput(string input)
        {
            var split = input.Split("\n\n");
            Numbers = split[0].Split(",").Select(n => int.Parse(n)).ToList();
            Boards = split[1..].Select(b =>
            {
                var board = new Board();
                board.ParseString(b);
                return board;
            }).ToList();
        }

        private void Iterate()
        {
            var num = Numbers[CurrentIteration];
            foreach (var board in Boards)
            {
                board.Mark(num);
            }
            CurrentIteration += 1;
        }

        private List<Board> GetWinningBoards()
        {
            return Boards.Where(b => b.IsWinning()).ToList();
        }

        private int GetLastNumber()
        {
            return Numbers.ElementAtOrDefault(CurrentIteration - 1);
        }

        private int SolutionOrDefault()
        {
            var boards = GetWinningBoards();
            var ret = 0;
            if (boards.Count > 0)
            {
                ret = boards[0].SumOfAllUnmarked() * GetLastNumber();
            }
            return ret;
        }

        public int PartOneSolution()
        {
            var solution = 0;
            while (solution == 0)
            {
                Iterate();
                solution = SolutionOrDefault();
            }
            return solution;
        }
    }
}