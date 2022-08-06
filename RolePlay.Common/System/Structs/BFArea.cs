using System;

namespace RolePlay.Common.System.Structs
{
    /// <summary>
    /// Battlefield area
    /// </summary>
    public struct BFArea : IEquatable<BFArea>
    {
        /// <summary>
        /// Form a new area
        /// </summary>
        /// <param name="x">X coordinate of the region`s left top point</param>
        /// <param name="y">Y coordinate of the region`s left top point</param>
        /// <param name="width">Area width</param>
        /// <param name="height">Area height</param>
        public BFArea(int x, int y, int width, int height)
        {
            StartPoint = new BFPoint(x, y);
            Size = new BFSize(width, height);
        }

        /// <summary>
        /// Form a new area
        /// </summary>
        /// <param name="startPoint">Area start</param>
        /// <param name="size">Area size</param>
        public BFArea(BFPoint startPoint, BFSize size)
        {
            StartPoint = startPoint;
            Size = size;
        }

        /// <summary>
        /// Area start
        /// </summary>
        public BFPoint StartPoint { get; }
        /// <summary>
        /// Area size
        /// </summary>
        public BFSize Size { get; }

        public override bool Equals(object? obj)
        {
            return obj is BFArea area && Equals(area);
        }

        public bool Equals(BFArea other)
        {
            return StartPoint.Equals(other.StartPoint) &&
                   Size.Equals(other.Size);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartPoint, Size);
        }

        public static bool operator ==(BFArea left, BFArea right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BFArea left, BFArea right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"[{StartPoint} - {Size}]";
        }
    }
}
