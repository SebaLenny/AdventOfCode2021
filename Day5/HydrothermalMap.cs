using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5
{
    public class HydrothermalMap
    {
        private List<Line> Lines { get; set; } = new List<Line>();
        public Dictionary<Vector2, int> OverlapCount { get; private set; } = new Dictionary<Vector2, int>();
        public Dictionary<Vector2, int> OverlapCountNoDiagonal { get; private set; } = new Dictionary<Vector2, int>();

        public void AddParseList(List<string> lines)
        {
            foreach (var line in lines)
            {
                var split = line.Replace(" -> ", ",")
                    .Split(",")
                    .Select(n => int.Parse(n))
                    .ToList();
                Lines.Add(new Line(split[0], split[1], split[2], split[3]));
            }
            foreach (var line in Lines)
            {
                var points = line.GetInLinePoints();
                foreach (var point in points)
                {
                    AddPointToDict(point, OverlapCount);
                    if (line.IsHorizontalOrVertical())
                    {
                        AddPointToDict(point, OverlapCountNoDiagonal);
                    }
                }
            }
        }

        private static void AddPointToDict(Vector2 point, Dictionary<Vector2, int> dict)
        {
            if (dict.ContainsKey(point)) dict[point] += 1;
            else dict.Add(point, 1);
        }
    }
}