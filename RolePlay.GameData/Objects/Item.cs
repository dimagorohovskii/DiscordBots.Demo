using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.Game.Enums;
using RolePlay.Common.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Game item
    /// </summary>
    public class Item : IItem
    {
        static Item()
        {
            Items = ServicesCollection.GetService<IExternalLoader>().GetGameItems();
        }

        /// <summary>
        /// All items in the game
        /// </summary>
        public static IReadOnlyDictionary<int, IItem> Items { get; }

        #region Class

        #region Properties
        public int Id { get; set; }

        public string Name { get; }

        public Image Image { get; }

        public string Description { get; }

        public int? MaxHealth { get; }

        public IReadOnlyCollection<ICharModifier> Modifiers { get; }

        public long Cost => GameRules.CostCounter.GetCostOf(this);

        public ImpactType? ImpactType { get; }

        public AttackType? AttackType { get; }

        public double Weight { get; }

        public ItemType ItemType { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Form a game item
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <param name="name">Item name</param>
        /// <param name="maxHealth">Item's maximum health, if any</param>
        /// <param name="image">Item image</param>
        /// <param name="description">Item description</param>
        /// <param name="impactType">Type of impact, if any</param>
        /// <param name="attackType">Type of attack, if any</param>
        /// <param name="weight">Single item weight</param>
        /// <param name="itemType">Item type</param>
        /// <param name="modifiers">Item modifiers</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Item(int id, string name, int? maxHealth, Image image, string description, ImpactType? impactType,
            AttackType? attackType, double weight, ItemType itemType, params ICharModifier[] modifiers)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Image = image ?? throw new ArgumentNullException(nameof(image));
            MaxHealth = maxHealth;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Modifiers = new ReadOnlyCollection<ICharModifier>(modifiers);
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight));
            }

            Weight = weight;
            ImpactType = impactType;
            AttackType = attackType;
            ItemType = itemType;
        }
        #endregion

        #endregion
    }
}
