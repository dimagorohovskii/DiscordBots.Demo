using System;

namespace RolePlay.Common.System.Structs
{
    /// <summary>
    /// Point on the battlefield
    /// </summary>
    public struct BFPoint : IEquatable<BFPoint>
    {
        /// <summary>
        /// Form a point on the battlefield
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public BFPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X coordinate on the battlefield
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Y coordinate on the battlefield
        /// </summary>
        public int Y { get; }

        public override bool Equals(object? obj)
        {
            return obj is BFPoint point && Equals(point);
        }

        public bool Equals(BFPoint other)
        {
            return X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(BFPoint left, BFPoint right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BFPoint left, BFPoint right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }
}
