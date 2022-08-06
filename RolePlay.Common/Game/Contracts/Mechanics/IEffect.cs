using System.Collections.Generic;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts.Mechanics
{
    /// <summary>
    /// An effect that changes a character
    /// </summary>
    public interface IEffect
    {
        /// <summary>
        /// Effect ID
        /// </summary>
        public int EffectId { get; }
        /// <summary>
        /// User-friendly effect name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// User-friendly effect description
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Effect icon
        /// </summary>
        public Bitmap Icon { get; }
        /// <summary>
        /// Can the effect be applied to a character multiple times?
        /// </summary>
        public bool CanBeMultyplied { get; }
        /// <summary>
        /// Effect modifiers
        /// </summary>
        public IReadOnlyCollection<ICharModifier> Modifiers { get; }
    }
}
