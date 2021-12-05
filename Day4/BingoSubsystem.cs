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
        private List<Board> WonBoards { get; set; } = new List<Board>();
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

        public int PartTwoSolution()
        {
            var lastWinNumber = -1;
            foreach (var number in Numbers)
            {
                Iterate();
                var winningBoards = GetWinningBoards();
                if (winningBoards.Count > 0)
                {
                    lastWinNumber = GetLastNumber();
                    winningBoards.ForEach(b => Boards.Remove(b));
                    winningBoards.ForEach(b => WonBoards.Add(b));
                }
            }
            return WonBoards.Last().SumOfAllUnmarked() * lastWinNumber;
        }
    }
}