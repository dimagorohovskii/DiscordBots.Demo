using RolePlay.Common.Game.Contracts.System;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// Item possessed by the character
    /// </summary>
    public interface ICharItem : IChangeable
    {
        /// <summary>
        /// Item instance ID
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// Item ID. Link to <see cref="IItem.Id"/>
        /// </summary>
        public int ItemId { get; }
        /// <summary>
        /// User-friendly item name
        /// </summary>
        public string ItemName { get; }
        /// <summary>
        /// Item owner. Link to <see cref="ICharacter.CharacterId"/>
        /// </summary>
        public ulong OwnerId { get; set; }
        /// <summary>
        /// The ID of the vault where the item is currently located, or <see langword="null"/>, if it is currently in the character's inventory
        /// </summary>
        public long? StorageId { get; set; }
        /// <summary>
        /// Item weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Item Image
        /// </summary>
        public Image Image { get; }
        /// <summary>
        /// Item cost
        /// </summary>
        public double Cost { get; }
    }
}
