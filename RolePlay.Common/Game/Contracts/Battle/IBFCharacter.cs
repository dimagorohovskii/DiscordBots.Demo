using RolePlay.Common.Game.Enums;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// Character representation on the battlefield
    /// </summary>
    public interface IBFCharacter : IDynamicBFObject
    {
        /// <summary>
        /// Link to character instance
        /// </summary>
        public ICharacter Character { get; }
        /// <summary>
        /// Draw a character with all the information about him on the canvas
        /// </summary>
        /// <param name="g">Graphic tool</param>
        /// <param name="x">X coordinate of drawing</param>
        /// <param name="y">Y coordinate of drawing</param>
        public void DrawOn(Graphics g, int x, int y);
        /// <summary>
        /// Is the character in cover?
        /// </summary>
        /// <returns>The type of cover the character is in</returns>
        public CoverType IsInCover();
        /// <summary>
        /// Whether the character is in cover relative to the observer
        /// </summary>
        /// <param name="x">X coordinate of the observer</param>
        /// <param name="y">Y coordinate of the observer</param>
        /// <returns>The type of cover the character is in relative to the observer</returns>
        public CoverType IsInCover(int x, int y);
    }
}
