using RolePlay.Common.Game.Contracts.System;

namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// Character skill
    /// </summary>
    public interface ICharacterSkill : IChangeable
    {
        /// <summary>
        /// Character skill ID
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// Skill ID Link to <see cref="ISkill.Id"/>
        /// </summary>
        public long SkillId { get; }
        /// <summary>
        /// Skill owner ID. Link to <see cref="ICharacter.CharacterId"/>
        /// </summary>
        public ulong CharacterId { get; }
        /// <summary>
        /// Skill experience value
        /// </summary>
        public long Exp { get; set; }
    }
}
