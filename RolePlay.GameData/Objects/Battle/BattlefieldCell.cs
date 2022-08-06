using RolePlay.Common.Game.Contracts.Battle;
using RolePlay.Common.Game.Enums;
using System.Drawing;

namespace RolePlay.GameData.Objects.Battle
{
    /// <summary>
    /// Battlefield cell
    /// </summary>
    public class BattlefieldCell : IBattleFieldCell
    {
        #region Fields
        private readonly long _battleFieldCellInfoId;
        #endregion

        #region Properties
        public int X { get; }

        public int Y { get; }

        public CoverType CoverType => BattlefieldCellInfo.Cells[_battleFieldCellInfoId].CoverType;

        public PassingType PassingType => BattlefieldCellInfo.Cells[_battleFieldCellInfoId].ObjectType;

        public Image Image => BattlefieldCellInfo.Cells[_battleFieldCellInfoId].Image;
        #endregion

        #region Constructors
        /// <summary>
        /// Form a new battlefield cell
        /// </summary>
        /// <param name="cellId">Cell ID</param>
        /// <param name="x">Cell X coordinate</param>
        /// <param name="y">Cell Y coordinate</param>
        public BattlefieldCell(long cellId, int x, int y)
        {
            _battleFieldCellInfoId = cellId;
            X = x;
            Y = y;
        }
        #endregion
    }
}
