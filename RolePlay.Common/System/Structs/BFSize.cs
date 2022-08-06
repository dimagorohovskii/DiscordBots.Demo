using System;

namespace RolePlay.Common.System.Structs
{
    /// <summary>
    /// Battlefield size
    /// </summary>
    public struct BFSize : IEquatable<BFSize>
    {
        /// <summary>
        /// Generate a new size
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public BFSize(int width, int height)
        {
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            Width = width;
            Height = height;
        }

        /// <summary>
        /// Size width
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Size height
        /// </summary>
        public int Height { get; }

        public override bool Equals(object? obj)
        {
            return obj is BFSize size && Equals(size);
        }

        public bool Equals(BFSize other)
        {
            return Width == other.Width &&
                   Height == other.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height);
        }

        public static bool operator ==(BFSize left, BFSize right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BFSize left, BFSize right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"{Width} x {Height}";
        }
    }
}
