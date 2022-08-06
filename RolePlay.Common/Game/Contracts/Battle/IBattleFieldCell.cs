using RolePlay.Common.Game.Enums;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// Battlefield map slot view
    /// </summary>
    public interface IBattleFieldCell
    {
        /// <summary>
        /// Cell X coordinate
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Cell Y coordinate
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// Type of cover provided by the cell
        /// </summary>
        public CoverType CoverType { get; }
        /// <summary>
        /// Object passability type
        /// </summary>
        public PassingType PassingType { get; }
        /// <summary>
        /// Cell image
        /// </summary>
        public Image Image { get; }
    }
}
