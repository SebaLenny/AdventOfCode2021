using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5
{
    public class Line
    {
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }

        public Line(int x1, int y1, int x2, int y2)
        {
            var v1 = new Vector2 { X = x1, Y = y1 };
            var v2 = new Vector2 { X = x2, Y = y2 };
            if (v1 > v2)
            {
                End = v1;
                Start = v2;
            }
            else
            {
                Start = v1;
                End = v2;
            }
        }

        public bool IsHorizontalOrVertical()
        {
            return Vector2.IsHorizontalOrVertical(Start, End);
        }

        public List<Vector2> GetInLinePoints()
        {
            if (Start == End) { return new List<Vector2> { Start }; };
            if (Start.X == End.X) return GetVerticalLinePoints();
            if (Start.Y == End.Y) return GetHorizontalLinePoints();
            return GetDiagonalLinePoints();
        }

        private List<Vector2> GetVerticalLinePoints()
        {
            var ret = new List<Vector2>();
            for (int i = 0; i < 1 + End.Y - Start.Y; i++)
            {
                ret.Add(new Vector2 { X = Start.X, Y = Start.Y + i });
            }
            return ret;
        }

        private List<Vector2> GetHorizontalLinePoints()
        {
            var ret = new List<Vector2>();
            for (int i = 0; i < 1 + End.X - Start.X; i++)
            {
                ret.Add(new Vector2 { X = Start.X + i, Y = Start.Y });
            }
            return ret;
        }

        private List<Vector2> GetDiagonalLinePoints()
        {
            var ret = new List<Vector2>();
            for (int i = 0; i < 1 + End.X - Start.X; i++)
            {
                ret.Add(new Vector2 { X = Start.X + i, Y = Start.Y + i });
            }
            return ret;
        }
    }
}