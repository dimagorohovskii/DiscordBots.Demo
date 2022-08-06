using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.Game.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// Representation of the game item
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Item ID
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// User-friendly item name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Appearance of the item
        /// </summary>
        public Image Image { get; }
        /// <summary>
        /// User-friendly item description
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Item's maximum health, if any
        /// </summary>
        public int? MaxHealth { get; }
        /// <summary>
        /// Type of impact, if any
        /// </summary>
        public ImpactType? ImpactType { get; }
        /// <summary>
        /// Type of attack, if any
        /// </summary>
        public AttackType? AttackType { get; }
        /// <summary>
        /// Item cost
        /// </summary>
        public long Cost { get; }
        /// <summary>
        /// Item weight
        /// </summary>
        public double Weight { get; }
        /// <summary>
        /// Item type
        /// </summary>
        public ItemType ItemType { get; }
        /// <summary>
        /// Modifiers that an object has
        /// </summary>
        public IReadOnlyCollection<ICharModifier> Modifiers { get; }
    }
}
