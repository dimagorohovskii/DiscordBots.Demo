using RolePlay.Common.Game.Contracts.System;
using System;

namespace RolePlay.Common.Game.Contracts.Mechanics
{
    /// <summary>
    /// Character modifier that changes his characteristics
    /// </summary>
    public interface ICharEffect : IChangeable
    {
        /// <summary>
        /// Character Effect ID
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// Prototype effect ID
        /// </summary>
        public int EffectId { get; }
        /// <summary>
        /// The character affected by this effect
        /// </summary>
        public ulong CharacterId { get; }
        /// <summary>
        /// The end date of the effect
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Effect value
        /// </summary>
        public double? Value { get; set; }
    }
}
