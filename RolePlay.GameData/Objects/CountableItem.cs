using RolePlay.Common.Game.Contracts;
using RolePlay.GameData.System;
using System;
using System.Drawing;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Stackable item
    /// </summary>
    public class CountableItem : ChangeableObject, ICountableItem
    {
        #region Fields
        private int _count;
        private double _weight;
        #endregion

        #region Properties
        public int Count
        {
            get => _count;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(Count));
                }

                if (_count == value)
                {
                    return;
                }

                _count = value;
            }
        }

        public double SumWeight => Weight * Count;

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
        /// Сформировать стакающийся предмет
        /// </summary>
        /// <param name="id">Идентификатор предмета игрока</param>
        /// <param name="itemId">Идентификатор предмета</param>
        /// <param name="count">Количество предметов в стаке</param>
        /// <param name="ownerId">Владелец</param>
        /// <param name="storageId">Хранилище предмета</param>
        /// <param name="weight">Вес одного предмета</param>
        public CountableItem(ulong id, int itemId, int count, ulong ownerId, long? storageId, double weight)
        {
            Id = id;
            ItemId = itemId;
            Count = count;
            OwnerId = ownerId;
            StorageId = storageId;
            Weight = weight;
        }
        #endregion
    }
}
