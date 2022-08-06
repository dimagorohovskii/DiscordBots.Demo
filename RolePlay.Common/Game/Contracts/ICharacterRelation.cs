using RolePlay.Common.Game.Contracts.System;

namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// Relationship level with NPC
    /// </summary>
    public interface ICharacterRelation : IChangeable
    {
        /// <summary>
        /// Relationship ID
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// Character ID. Link to <see cref="ICharacter.CharacterId"/>
        /// </summary>
        public ulong CharacterId { get; }
        /// <summary>
        /// NPC ID Link to <see cref="ICharacter.CharacterId"/>
        /// </summary>
        public ulong NPCUid { get; }
        /// <summary>
        /// Relationship level
        /// </summary>
        public int Value { get; set; }
    }
}
