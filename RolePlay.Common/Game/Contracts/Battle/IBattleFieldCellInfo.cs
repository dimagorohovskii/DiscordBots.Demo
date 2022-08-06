using RolePlay.Common.Game.Enums;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// Battlefield map slot information
    /// </summary>
    public interface IBattleFieldCellInfo
    {
        /// <summary>
        /// Cell ID
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// Type of cover provided by the cell
        /// </summary>
        public CoverType CoverType { get; }
        /// <summary>
        /// Object passability type
        /// </summary>
        public PassingType ObjectType { get; }
        /// <summary>
        /// Cell image
        /// </summary>
        public Image Image { get; }
        /// <summary>
        /// Render priority
        /// </summary>
        public int Priority { get; }
    }
}
