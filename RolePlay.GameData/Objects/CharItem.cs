using RolePlay.Common.Game.Contracts;
using RolePlay.GameData.System;
using System;
using System.Drawing;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Non-Stackable Item
    /// </summary>
    public class CharItem : ChangeableObject, ICharItem
    {
        #region Fields
        private double _weight;
        #endregion

        #region Properties
        public ulong Id { get; set; }

        public int ItemId { get; }

        public string ItemName => Item.Items[ItemId].Name;

        public ulong OwnerId { get; set; }

        public long? StorageId { get; set; }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Weight));
                }

                _weight = value;
            }
        }

        public Image Image => Item.Items[ItemId].Image;

        public double Cost => GameRules.CostCounter.GetCostOf(this);
        #endregion

        #region Constructors
        /// <summary>
        /// Form a non-stackable item
        /// </summary>
        /// <param name="id">Player item ID</param>
        /// <param name="itemId">Item ID</param>
        /// <param name="ownerId">Owner ID</param>
        /// <param name="storageId">Storage ID</param>
        /// <param name="weight">Item weight</param>
        public CharItem(ulong id, int itemId, ulong ownerId, long? storageId, double weight)
        {
            Id = id;
            ItemId = itemId;
            OwnerId = ownerId;
            StorageId = storageId;
            Weight = weight;
        }
        #endregion
    }
}
