using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5
{
    public class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
        public override bool Equals(object obj) => this.Equals(obj as Vector2);

        public bool Equals(Vector2 p)
        {
            if (p is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }
            if (this.GetType() != p.GetType())
            {
                return false;
            }
            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);

        public static bool operator <(Vector2 lhs, Vector2 rhs)
        {
            return rhs.X >= lhs.X && rhs.Y >= lhs.Y && lhs != rhs;
        }

        public static bool operator >(Vector2 lhs, Vector2 rhs)
        {
            return rhs.X <= lhs.X && rhs.Y <= lhs.Y && lhs != rhs;
        }

        public static bool operator <=(Vector2 lhs, Vector2 rhs)
        {
            return rhs > lhs || lhs == rhs;
        }

        public static bool operator >=(Vector2 lhs, Vector2 rhs)
        {
            return rhs < lhs || lhs == rhs;
        }

        public static bool IsHorizontalOrVertical(Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X || v1.Y == v2.Y;
        }
    }
}