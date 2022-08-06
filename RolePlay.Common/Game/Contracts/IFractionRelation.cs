using RolePlay.Common.Game.Contracts.System;

namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// Relationship with a faction
    /// </summary>
    public interface IFractionRelation : IChangeable
    {
        /// <summary>
        /// Relationship ID
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// The character whose relationship is displayed. Link to <see cref="ICharacter.CharacterId"/>
        /// </summary>
        public ulong CharacterId { get; }
        /// <summary>
        /// The fraction whose relationship is displayed. Link to <see cref="IFraction.Id"/>
        /// </summary>
        public long FractionId { get; }
        /// <summary>
        /// Relationship value
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Reputation value
        /// </summary>
        public int Reputation { get; set; }
    }
}
