using RolePlay.Common.Game.Contracts.Battle;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.Game.Enums;
using RolePlay.Common.System;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RolePlay.GameData.Objects.Battle
{
    /// <summary>
    /// Battlefield cell type
    /// </summary>
    public class BattlefieldCellInfo : IBattleFieldCellInfo
    {
        static BattlefieldCellInfo()
        {
            Cells = ServicesCollection.GetService<IExternalLoader>().GetBattleFieldCells();
        }

        /// <summary>
        /// All existing cells in the game
        /// </summary>
        public static IReadOnlyDictionary<long, IBattleFieldCellInfo> Cells { get; }

        #region Class

        #region Properties
        public long Id { get; }

        public CoverType CoverType { get; }

        public PassingType ObjectType { get; }

        public Image Image { get; }

        public int Priority { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Generate a new battlefield cell type
        /// </summary>
        /// <param name="id">Cell type identifier</param>
        /// <param name="priority">Render priority</param>
        /// <param name="coverType">Type of cover provided by the cell</param>
        /// <param name="objectType">Object passability type</param>
        /// <param name="image">Cell appearance</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BattlefieldCellInfo(long id, int priority, CoverType coverType, PassingType objectType, Image image)
        {
            Id = id;
            Priority = priority;
            CoverType = coverType;
            ObjectType = objectType;
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }
        #endregion

        #endregion
    }
}
