using RolePlay.Common.Game.Contracts.Battle;
using RolePlay.Common.Game.Enums;
using RolePlay.GameData.Objects.Battle.Tools;
using System;
using System.Drawing;

namespace RolePlay.GameData.Objects.Battle
{
    /// <summary>
    /// Dynamic cell of the battlefield
    /// </summary>
    internal class DynamicBFObject : IMovableObject, IDynamicBFObject
    {
        #region Fields
        private readonly long? _cellInfoId;
        private readonly Image? _image;
        private readonly CoverType _coverType;
        private readonly PassingType _objectType;
        private readonly BattleField _battlefield;
        private readonly int _priority;
        #endregion

        #region Properties
        public int X { get; set; }

        public int Y { get; set; }

        public int Priority => _cellInfoId.HasValue ? BattlefieldCellInfo.Cells[_cellInfoId.Value].Priority : _priority;

        public CoverType CoverType => _cellInfoId.HasValue ? BattlefieldCellInfo.Cells[_cellInfoId.Value].CoverType : _coverType;

        public PassingType PassingType => _cellInfoId.HasValue ? BattlefieldCellInfo.Cells[_cellInfoId.Value].ObjectType : _objectType;

        public Image Image => _cellInfoId.HasValue ? BattlefieldCellInfo.Cells[_cellInfoId.Value].Image : _image ?? throw new ArgumentNullException(nameof(Image));
        #endregion

        #region Constructors
        /// <summary>
        /// Generate a dynamic object for the battlefield
        /// </summary>
        /// <param name="battlefield">Battlefield-owner</param>
        /// <param name="cellId">Cell type identifier</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DynamicBFObject(BattleField battlefield, long cellId, int x, int y)
        {
            _battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            if (!BattlefieldCellInfo.Cells.ContainsKey(cellId))
            {
                throw new ArgumentOutOfRangeException(nameof(cellId));
            }

            _cellInfoId = cellId;
            X = x;
            Y = y;
        }
        /// <summary>
        /// Generate a dynamic object for the battlefield
        /// </summary>
        /// <param name="battlefield">Battlefield-owner</param>
        /// <param name="image">Object image</param>
        /// <param name="coverType">Object cover type</param>
        /// <param name="objectType">Object passability type</param>
        /// <param name="priority">Render priority</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DynamicBFObject(BattleField battlefield, Image image, CoverType coverType, PassingType objectType, int priority, int x, int y)
        {
            _battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            _image = image ?? throw new ArgumentNullException(nameof(image));
            _coverType = coverType;
            _objectType = objectType;
            _priority = priority;
            X = x;
            Y = y;
        }
        #endregion

        #region Public/Internal methods
        public void Delete()
        {
            _battlefield.DynamicObjectsContainer.Delete(this);
        }

        public void Move(int x, int y)
        {
            _battlefield.DynamicObjectsContainer.Move(this, x, y);
        }
        #endregion
    }
}
