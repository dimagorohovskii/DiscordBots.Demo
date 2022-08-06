using RolePlay.Common.Game.Contracts;
using RolePlay.GameData.System;
using System;
using System.Drawing;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Equipment item
    /// </summary>
    public class Equipment : ChangeableObject, IEquipment
    {
        #region Fields
        private int _health;
        private double _weight;
        #endregion

        #region Properties
        public int Health
        {
            get => _health;
            set
            {
                if (_health == value)
                {
                    return;
                }

                _health = Math.Max(0, Math.Min(MaxHealth, value));
            }
        }

        public int MaxHealth
        {
            get
            {
                int? value = Item.Items[ItemId].MaxHealth;
                if (value.HasValue)
                {
                    return value.Value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(MaxHealth));
                }
            }
        }

        public string HealthName => GameRules.ItemsConverter.GetLevelStringView((int)Math.Round((Health * 100f) / MaxHealth), nameof(Health));

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
        /// Form equipment
        /// </summary>
        /// <param name="id">Equipment identifier</param>
        /// <param name="itemId">Item ID</param>
        /// <param name="ownerId">Owner ID</param>
        /// <param name="health">Item health</param>
        /// <param name="storageId">Item storage</param>
        /// <param name="weight">Item weight</param>
        public Equipment(ulong id, int itemId, ulong ownerId, int health, long? storageId, double weight)
        {
            Id = id;
            ItemId = itemId;
            Health = health;
            OwnerId = ownerId;
            StorageId = storageId;
            Weight = weight;
        }
        #endregion
    }
}
